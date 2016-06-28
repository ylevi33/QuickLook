using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Hpe.Nga.Api.Core.Connector;
using Hpe.Nga.Api.Core.Entities;
using Hpe.Nga.Api.Core.Services;
using Hpe.Nga.Api.Core.Services.RequestContext;

namespace Hpe.Nga.Api.UI.Core.Configuration
{
    public partial class LoginForm : Form
    {

        public LoginForm()
        {
            InitializeComponent();
            OnConfigurationChanged(null, null);
        }

        public LoginConfiguration Configuration
        {
            get
            {
                SharedSpace selectedSS = (SharedSpace)cmbSharedSpace.SelectedItem;
                long ssIdForSave = 1001;
                String ssNameForSave = null;
                /*if (selectedSS != null)
                {
                    ssIdForSave = selectedSS.Id;
                    ssNameForSave = selectedSS.Name;
                }*/
                return new LoginConfiguration(txtServer.Text, txtName.Text, txtPassword.Text);
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
                        cmbSharedSpace.Items.Add(ss);
                        cmbSharedSpace.SelectedItem = ss;
                    }
                }
            }


        }

        private void OnConfigurationChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtServer.Text) || String.IsNullOrEmpty(txtName.Text) || String.IsNullOrEmpty(txtPassword.Text))
            {
                btnConnect.Enabled = false;

            }
            else
            {
                btnConnect.Enabled = true;
            }

            cmbSharedSpace.Items.Clear();
            cmbSharedSpace.Enabled = false;

            btnLogin.Enabled = false;
            lblStatus.Text = "";
        }

        private void OnConnectClick(object sender, EventArgs e)
        {
            try
            {
                lblStatus.Text = "Connecting ...";
                lblStatus.ForeColor = Color.White;
                bool connected = RestConnector.GetInstance().Connect(txtServer.Text, txtName.Text, txtPassword.Text);
                btnLogin.Enabled = true;
                lblStatus.Text = "Connected";
                lblStatus.ForeColor = Color.White;

                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                //LoadSharedSpaces();
            }
            catch (Exception)
            {
                lblStatus.Text = "Failed to connect";
                lblStatus.ForeColor = Color.Red;
            }
        }

        private void LoadSharedSpaces()
        {

            EntityListResult<SharedSpace> sharedSpaces = EntityService.GetInstance().Get<SharedSpace>(new SiteContext());

            SharedSpace selected = (SharedSpace)cmbSharedSpace.SelectedItem;
            SharedSpace newSelected = null;
            cmbSharedSpace.Items.Clear();
            foreach (SharedSpace ss in sharedSpaces.data)
            {
                cmbSharedSpace.Items.Add(ss);

                if (selected != null && ss.Name == selected.Name)
                {
                    newSelected = ss;
                }
            }


            if (newSelected != null)
            {
                cmbSharedSpace.SelectedItem = newSelected;
            }
            else if (sharedSpaces.data.Count > 0)
            {
                cmbSharedSpace.SelectedItem = sharedSpaces.data[0];
            }

            cmbSharedSpace.Enabled = true;

        }

        private void cmbSharedSpace_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void lblStatus_Click(object sender, EventArgs e)
        {

        }

        private void lblUserName_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

    }
}
