using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using Hpe.Nga.Api.Core.Connector;
using Hpe.Nga.Api.Core.Entities;
using Hpe.Nga.Api.Core.Services;
using Hpe.Nga.Api.Core.Services.RequestContext;
using Hpe.Nga.Api.UI.Core.Configuration;
using Microsoft.Office.Core;
using Microsoft.Office.Tools.Ribbon;
using QuickLook.Properties;
using Hpe.Nga.Api.Core.Services.GroupBy;
using Office = Microsoft.Office.Core;

// TODO:  Follow these steps to enable the Ribbon (XML) item:

// 1: Copy the following code block into the ThisAddin, ThisWorkbook, or ThisDocument class.

//  protected override Microsoft.Office.Core.IRibbonExtensibility CreateRibbonExtensibilityObject()
//  {
//      return new NgaRibbon();
//  }

// 2. Create callback methods in the "Ribbon Callbacks" region of this class to handle user
//    actions, such as clicking a button. Note: if you have exported this Ribbon from the Ribbon designer,
//    move your code from the event handlers to the callback methods and modify the code to work with the
//    Ribbon extensibility (RibbonX) programming model.

// 3. Assign attributes to the control tags in the Ribbon XML file to identify the appropriate callback methods in your code.  

// For more information, see the Ribbon XML documentation in the Visual Studio Tools for Office Help.


namespace QuickLook
{
    [ComVisible(true)]
    public class NgaRibbon : Office.IRibbonExtensibility
    {
        private Office.IRibbonUI ribbon;
        ConfigurationPersistService persistService = new ConfigurationPersistService();
        LoginConfiguration loginConfig;
        private Boolean isLoggedIn = false;

        public NgaRibbon()
        {
            persistService.ConfigurationFileName = "QuickLook.configuration";
            tryAutoLogin();
        }

        public String GetBtnConnectLable(IRibbonControl control)
        {
            if (isLoggedIn)
            {
                return "Connected";
            }
            else
            {
                return "Connect";
            }
        }

        private void tryAutoLogin()
        {
            try
            {
                LoginConfiguration tempLoginConfig = persistService.Load<LoginConfiguration>();
                if (RestConnector.GetInstance().Connect(tempLoginConfig.ServerUrl, tempLoginConfig.Name, tempLoginConfig.Password))
                {
                    loginConfig = tempLoginConfig;
                    NgaUtils.init(loginConfig.SharedSpaceId, loginConfig.WorkspaceId, loginConfig.ReleaseId);
                    isLoggedIn = true;
                    if (ribbon != null)
                    {
                        ribbon.InvalidateControl("btnConnect");
                    }
                }
            }
            catch (Exception)
            {
                //autologin fail
                if (ribbon != null)
                {
                    ribbon.InvalidateControl("btnConnect");
                }
            }

        }

        public void OnLogin(Office.IRibbonControl control)
        {
            SettingsForm form = new SettingsForm();
            form.Configuration = persistService.Load<LoginConfiguration>();
            if (form.ShowDialog() == DialogResult.OK)
            {
                loginConfig = form.Configuration;
                PersistLoginConfiguration();
                UpdateLabelStatus();
                NgaUtils.init(loginConfig.SharedSpaceId, loginConfig.WorkspaceId, loginConfig.ReleaseId);
                isLoggedIn = true;
            }
            if (ribbon != null)
            {
                ribbon.InvalidateControl("btnConnect");
            }
        }

        public void OnSync(Office.IRibbonControl control)
        {
            try
            {
                if (!OutlookUtils.IsCalendarActive())
                {
                    MessageBox.Show("Please select calendar to sync");
                }
                else
                {
                    //Get by id
                    Release release = NgaUtils.GetSelectedRelease(); //NgaUtils.GetReleaseById(releaseId);
                    EntityListResult<Sprint> sprints = NgaUtils.GetSprintsByRelease(release.Id);
                    OutlookSyncUtils.SyncSprintsToOutlook(release, sprints);
                    EntityListResult<Milestone> milestones = NgaUtils.GetMilestonesByRelease(release.Id);
                    OutlookSyncUtils.SyncMilestonesToOutlook(release, milestones);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Failed to sync : " + e.Message + e.StackTrace);
            }
        }

        public void OnMailReport(Office.IRibbonControl control)
        {
            try
            {
                //Get by id
                Release release = NgaUtils.GetSelectedRelease(); //NgaUtils.GetReleaseById(releaseId);
                GroupResult groupResult = NgaUtils.GetAllDefectWithGroupBy(release.Id);
                EntityListResult<WorkItem> workItems = NgaUtils.GetStoriesByRelease(release.Id);
                OutlookSyncUtils.getReleaseMailReport(release, groupResult, workItems);
            }
            catch (Exception e)
            {
                MessageBox.Show("Failed to generate Mail report : " + e.Message + e.StackTrace);
            }
        }

        public Bitmap imageConnect_GetImage(IRibbonControl control)
        {
            return Resources.OctaneConnect;
        }

        public Bitmap imageSync_GetImage(IRibbonControl control)
        {
            return Resources.OctaneSync;
        }

        public Bitmap imageReport_GetImage(IRibbonControl control)
        {
          return Resources.OctaneReport;
        }
        #region IRibbonExtensibility Members

        public string GetCustomUI(string ribbonID)
        {
            return GetResourceText("QuickLook.NgaRibbon.xml");
        }

        #endregion

        #region Ribbon Callbacks
        //Create callback methods here. For more information about adding callback methods, visit http://go.microsoft.com/fwlink/?LinkID=271226

        public void Ribbon_Load(Office.IRibbonUI ribbonUI)
        {
            this.ribbon = ribbonUI;
        }

        #endregion

        #region Helpers

        private static string GetResourceText(string resourceName)
        {
            Assembly asm = Assembly.GetExecutingAssembly();
            string[] resourceNames = asm.GetManifestResourceNames();
            for (int i = 0; i < resourceNames.Length; ++i)
            {
                if (string.Compare(resourceName, resourceNames[i], StringComparison.OrdinalIgnoreCase) == 0)
                {
                    using (StreamReader resourceReader = new StreamReader(asm.GetManifestResourceStream(resourceNames[i])))
                    {
                        if (resourceReader != null)
                        {
                            return resourceReader.ReadToEnd();
                        }
                    }
                }
            }
            return null;
        }

        #endregion

        private void UpdateLabelStatus()
        {
            Console.Write(String.Format("Connected as '{0}' to {1}, shared space ({2})", loginConfig.Name, loginConfig.ServerUrl, loginConfig.SharedSpaceId));
            //lblStatus.Text = format;
        }

        private void PersistLoginConfiguration()
        {

            //save last successful configuration
            persistService.Save(loginConfig);
        }



    }
}
