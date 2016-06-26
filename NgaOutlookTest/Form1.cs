﻿using System;
using System.Windows.Forms;
using Hpe.Nga.Api.Core.Connector;
using Hpe.Nga.Api.Core.Services.RequestContext;
using Hpe.Nga.Api.UI.Core.Configuration;

namespace NgaOutlookTest
{
    public partial class Form1 : Form
    {


        ConfigurationPersistService persistService = new ConfigurationPersistService();
        LoginConfiguration loginConfig;


        public Form1()
        {
            InitializeComponent();

            //persistService.ConfigurationFileName = "TestApplication.loginLocalHost.json";
            persistService.ConfigurationFileName = "LoginConf.OnPrem.json";
        }

        private void btnRunReleaseTests_Click(object sender, EventArgs e)
        {

            WorkspaceContext workspaceContext = BasicCrudTests.GetWorkspaceContextTest(loginConfig.SharedSpaceId);
            BasicCrudTests.BasicReleaseCrudTest(workspaceContext);
            MessageBox.Show("Finished OK");
        }

        private void btnRunMilestonesTests_Click(object sender, EventArgs e)
        {
            WorkspaceContext workspaceContext = BasicCrudTests.GetWorkspaceContextTest(loginConfig.SharedSpaceId);
            BasicCrudTests.BasicMilestoneTest(workspaceContext);
            MessageBox.Show("Finished OK");
        }

        private void btnLoginDialog_Click(object sender, EventArgs e)
        {
            //Open login dialog
            LoginForm form = new LoginForm();
            form.Configuration = persistService.Load<LoginConfiguration>(); ;
            if (form.ShowDialog() == DialogResult.OK)
            {
                loginConfig = form.Configuration;
                PersistLoginConfiguration();
                UpdateLabelStatus();
            }
        }

        private void UpdateLabelStatus()
        {
            String format = String.Format("Connected as '{0}' to {1}, shared space ({2})", loginConfig.Name, loginConfig.ServerUrl, loginConfig.SharedSpaceId);
            lblStatus.Text = format;
        }

        private void PersistLoginConfiguration()
        {

            //save last successful configuration
            persistService.Save(loginConfig);
        }

        private void btnLoginConfiguration_Click(object sender, EventArgs e)
        {
            LoginConfiguration tempLoginConfig = persistService.Load<LoginConfiguration>();
            if (RestConnector.GetInstance().Connect(tempLoginConfig.ServerUrl, tempLoginConfig.Name, tempLoginConfig.Password))
            {
                loginConfig = tempLoginConfig;
                UpdateLabelStatus();
            }
        }

        private void btnRunSprintTests_Click(object sender, EventArgs e)
        {
            WorkspaceContext workspaceContext = BasicCrudTests.GetWorkspaceContextTest(loginConfig.SharedSpaceId);
            BasicCrudTests.BasicSprintTest(workspaceContext);
            MessageBox.Show("Finished OK");
        }

    }
}