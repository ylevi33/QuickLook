namespace NgaOutlookTest
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnRunReleaseTests = new System.Windows.Forms.Button();
            this.btnRunMilestonesTests = new System.Windows.Forms.Button();
            this.btnLoginDialog = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnRunSprintTests = new System.Windows.Forms.Button();
            this.btnLoginConfiguration = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnRunReleaseTests
            // 
            this.btnRunReleaseTests.Location = new System.Drawing.Point(18, 167);
            this.btnRunReleaseTests.Name = "btnRunReleaseTests";
            this.btnRunReleaseTests.Size = new System.Drawing.Size(131, 23);
            this.btnRunReleaseTests.TabIndex = 8;
            this.btnRunReleaseTests.Text = "Release tests";
            this.btnRunReleaseTests.UseVisualStyleBackColor = true;
            this.btnRunReleaseTests.Click += new System.EventHandler(this.btnRunReleaseTests_Click);
            // 
            // btnRunMilestonesTests
            // 
            this.btnRunMilestonesTests.Location = new System.Drawing.Point(171, 167);
            this.btnRunMilestonesTests.Name = "btnRunMilestonesTests";
            this.btnRunMilestonesTests.Size = new System.Drawing.Size(131, 23);
            this.btnRunMilestonesTests.TabIndex = 11;
            this.btnRunMilestonesTests.Text = "Milestones tests";
            this.btnRunMilestonesTests.UseVisualStyleBackColor = true;
            this.btnRunMilestonesTests.Click += new System.EventHandler(this.btnRunMilestonesTests_Click);
            // 
            // btnLoginDialog
            // 
            this.btnLoginDialog.Location = new System.Drawing.Point(25, 30);
            this.btnLoginDialog.Name = "btnLoginDialog";
            this.btnLoginDialog.Size = new System.Drawing.Size(124, 23);
            this.btnLoginDialog.TabIndex = 12;
            this.btnLoginDialog.Text = "Login with Dialog";
            this.btnLoginDialog.UseVisualStyleBackColor = true;
            this.btnLoginDialog.Click += new System.EventHandler(this.btnLoginDialog_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(25, 72);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(78, 13);
            this.lblStatus.TabIndex = 13;
            this.lblStatus.Text = "Not connected";
            // 
            // btnRunSprintTests
            // 
            this.btnRunSprintTests.Location = new System.Drawing.Point(332, 167);
            this.btnRunSprintTests.Name = "btnRunSprintTests";
            this.btnRunSprintTests.Size = new System.Drawing.Size(131, 23);
            this.btnRunSprintTests.TabIndex = 14;
            this.btnRunSprintTests.Text = "Sprint tests";
            this.btnRunSprintTests.UseVisualStyleBackColor = true;
            this.btnRunSprintTests.Click += new System.EventHandler(this.btnRunSprintTests_Click);
            // 
            // btnLoginConfiguration
            // 
            this.btnLoginConfiguration.Location = new System.Drawing.Point(155, 30);
            this.btnLoginConfiguration.Name = "btnLoginConfiguration";
            this.btnLoginConfiguration.Size = new System.Drawing.Size(124, 23);
            this.btnLoginConfiguration.TabIndex = 15;
            this.btnLoginConfiguration.Text = "Login with last saved configuration";
            this.btnLoginConfiguration.UseVisualStyleBackColor = true;
            this.btnLoginConfiguration.Click += new System.EventHandler(this.btnLoginConfiguration_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(557, 357);
            this.Controls.Add(this.btnLoginConfiguration);
            this.Controls.Add(this.btnRunSprintTests);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnLoginDialog);
            this.Controls.Add(this.btnRunMilestonesTests);
            this.Controls.Add(this.btnRunReleaseTests);
            this.Name = "Form1";
            this.Text = "Connect";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRunReleaseTests;
        private System.Windows.Forms.Button btnRunMilestonesTests;
        private System.Windows.Forms.Button btnLoginDialog;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnRunSprintTests;
        private System.Windows.Forms.Button btnLoginConfiguration;
    }
}

