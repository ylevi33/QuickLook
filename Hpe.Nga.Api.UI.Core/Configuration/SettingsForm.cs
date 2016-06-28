using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Hpe.Nga.Api.Core.Connector;
using Hpe.Nga.Api.Core.Entities;
using Hpe.Nga.Api.Core.Services;
using Hpe.Nga.Api.Core.Services.Query;
using Hpe.Nga.Api.Core.Services.RequestContext;

namespace Hpe.Nga.Api.UI.Core.Configuration
{
    public partial class SettingsForm : Form
    {
        bool enableEvents = false;
        public SettingsForm()
        {
            InitializeComponent();
            OnLoginSettingsChanged(null, null);
        }

        public LoginConfiguration Configuration
        {
            get
            {
                enableEvents = false;
                SharedSpace selectedSS = (SharedSpace)cmbSharedSpace.SelectedItem;
                Workspace selectedWorkspace = (Workspace)cmbWorkspace.SelectedItem;
                Release selectedRelease = (Release)cmbRelease.SelectedItem;

                LoginConfiguration conf = new LoginConfiguration(txtServer.Text, txtName.Text, txtPassword.Text);
                if (selectedSS != null)
                {
                    conf.SharedSpaceId = selectedSS.Id;
                    conf.SharedSpaceName = selectedSS.Name;
                }
                if (selectedWorkspace != null)
                {
                    conf.WorkspaceId = selectedWorkspace.Id;
                    conf.WorkspaceName = selectedWorkspace.Name;
                }
                if (selectedRelease != null)
                {
                    conf.ReleaseId = selectedRelease.Id;
                    conf.ReleaseName = selectedRelease.Name;
                }

                enableEvents = true;
                return conf;
            }
            set
            {
                if (value != null)
                {
                    txtServer.Text = value.ServerUrl;
                    txtName.Text = value.Name;
                    txtPassword.Text = value.Password;

                    if (value.SharedSpaceName != null)
                    {
                        SharedSpace ss = new SharedSpace();
                        ss.Name = value.SharedSpaceName;
                        ss.Id = value.SharedSpaceId;
                        cmbSharedSpace.Items.Clear();
                        cmbSharedSpace.Items.Add(ss);
                        cmbSharedSpace.SelectedItem = ss;
                    }
                    if (value.WorkspaceName != null)
                    {
                        Workspace workspace = new Workspace();
                        workspace.Name = value.WorkspaceName;
                        workspace.Id = value.WorkspaceId;
                        cmbWorkspace.Items.Clear();
                        cmbWorkspace.Items.Add(workspace);
                        cmbWorkspace.SelectedItem = workspace;
                    }
                    if (value.ReleaseName != null)
                    {
                        Release release = new Release();
                        release.Name = value.ReleaseName;
                        release.Id = value.ReleaseId;
                        cmbRelease.Items.Clear();
                        cmbRelease.Items.Add(release);
                        cmbRelease.SelectedItem = release;
                    }
                }
            }


        }

        private void Save()
        {
            ConfigurationPersistService persistService = new ConfigurationPersistService();
            persistService.ConfigurationFileName = "LoginConf.OnPrem.json";
            LoginConfiguration conf = Configuration;
            persistService.Save(conf);
        }

        private void OnLoginSettingsChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtServer.Text) || String.IsNullOrEmpty(txtName.Text) || String.IsNullOrEmpty(txtPassword.Text))
            {
                btnLogin.Enabled = false;

            }
            else
            {
                btnLogin.Enabled = true;
            }

            ClearConnectSettings();

            lblStatus.Text = "";
        }

        private void OnConnectSettingsChanged()
        {
            btnConnect.Enabled = cmbSharedSpace.SelectedItem != null && cmbWorkspace.SelectedItem != null && cmbRelease.SelectedItem != null;
        }

        private void ClearConnectSettings()
        {
            cmbSharedSpace.Items.Clear();
            cmbSharedSpace.Enabled = false;

            cmbWorkspace.Items.Clear();
            cmbWorkspace.Enabled = false;

            cmbRelease.Items.Clear();
            cmbRelease.Enabled = false;

            btnConnect.Enabled = false;
        }

        private void OnLoginClick(object sender, EventArgs e)
        {
            try
            {
                lblStatus.Text = "Connecting ...";
                lblStatus.ForeColor = Color.White;
                bool connected = RestConnector.GetInstance().Connect(txtServer.Text, txtName.Text, txtPassword.Text);
                btnLogin.Enabled = true;
                lblStatus.Text = "Connected";
                lblStatus.ForeColor = Color.White;

                Save();
                Application.DoEvents();


            }
            catch (Exception ex)
            {
                lblStatus.Text = "Failed to connect";
                lblStatus.ForeColor = Color.Red;
            }

            LoadSharedSpaces();

        }

        private void LoadSharedSpaces()
        {
            EntityListResult<SharedSpace> sharedSpaces = null;
            try
            {
                sharedSpaces = EntityService.GetInstance().Get<SharedSpace>(new SiteContext());
            }
            catch (Exception e)
            {

            }

            if (sharedSpaces == null)
            {
                SharedSpace defaultSharedSpace = new SharedSpace();
                defaultSharedSpace.Id = 1001;
                defaultSharedSpace.Name = "Default shared space";

                sharedSpaces = new EntityListResult<SharedSpace>();
                sharedSpaces.data = new List<SharedSpace>();
                sharedSpaces.data.Add(defaultSharedSpace);
                sharedSpaces.total_count = 2;
            }
            FillCombo(cmbSharedSpace, sharedSpaces.data);
            //LoadWorkspaces(((SharedSpace)cmbSharedSpace.SelectedItem).Id);
        }

        private void FillCombo<T>(ComboBox combo, List<T> data) where T : BaseEntity
        {
            T selected = (T)combo.SelectedItem;
            T newSelected = null;
            combo.Items.Clear();

            List<T> ordered = data.OrderBy(en =>en.Name).ToList();
            foreach (T item in ordered)
            {
                //fill combo
                combo.Items.Add(item);

                //find previously selected item
                if (selected != null && item.Id == selected.Id)
                {
                    newSelected = item;
                }
            }


            if (newSelected != null)
            {
                combo.SelectedItem = newSelected;
            }
            else if (data.Count > 0)
            {
                combo.SelectedItem = data[0];
            }

            combo.Enabled = true;
        }

        private void LoadWorkspaces(long sharedSpaceId)
        {
            SharedSpaceContext context = new SharedSpaceContext(sharedSpaceId);
            EntityListResult<Workspace> workspaces = EntityService.GetInstance().Get<Workspace>(context);
            
            //User user = GetSharedSpaceUser(sharedSpaceId, txtName.Text);

            FillCombo<Workspace>(cmbWorkspace, workspaces.data);

        }

        private User GetSharedSpaceUser(long sharedSpaceId, string name)
        {
            SharedSpaceContext context = new SharedSpaceContext(sharedSpaceId);

            //s?query="name='hackathon@user'"

            QueryPhrase query = new LogicalQueryPhrase("name", name);
            List<QueryPhrase> queries = new List<QueryPhrase>();
            queries.Add(query);
            EntityListResult<User> users = EntityService.GetInstance().Get<User>(context, queries, null);
            return users.data[0];

        }

        private void LoadReleases(long sharedSpaceId, long workspaceId)
        {
            WorkspaceContext context = new WorkspaceContext(sharedSpaceId, workspaceId);
            EntityListResult<Release> result = EntityService.GetInstance().Get<Release>(context);

            if (result != null)
            {
                FillCombo<Release>(cmbRelease, result.data);

                btnConnect.Enabled = true;

                Save();
            }
            else
            {
                ClearCombo(cmbRelease);
            }
        }

        private void ClearCombo(ComboBox combo)
        {
            combo.Items.Clear();
            combo.Enabled = false;
        }

        private void cmbSharedSpace_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!enableEvents)
            {
                return;
            }
            LoadWorkspaces(((SharedSpace)cmbSharedSpace.SelectedItem).Id);
            OnConnectSettingsChanged();
        }

        private void cmbWorkspace_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!enableEvents)
            {
                return;
            }
            LoadReleases(((SharedSpace)cmbSharedSpace.SelectedItem).Id, ((Workspace)cmbWorkspace.SelectedItem).Id);
            OnConnectSettingsChanged();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            Save();
            this.DialogResult = DialogResult.OK;

        }

    }
}
