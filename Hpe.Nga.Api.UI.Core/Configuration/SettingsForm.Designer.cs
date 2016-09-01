namespace Hpe.Nga.Api.UI.Core.Configuration
{
    partial class SettingsForm
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
      System.Windows.Forms.Label label4;
      System.Windows.Forms.Label label7;
      System.Windows.Forms.Label label8;
      System.Windows.Forms.PictureBox separator1;
      System.Windows.Forms.PictureBox topBorder;
      System.Windows.Forms.PictureBox bottomBorder;
      System.Windows.Forms.PictureBox leftBorder;
      System.Windows.Forms.PictureBox rightBorder;
      this.cmbRelease = new System.Windows.Forms.ComboBox();
      this.cmbWorkspace = new System.Windows.Forms.ComboBox();
      this.cmbSharedSpace = new System.Windows.Forms.ComboBox();
      this.label6 = new System.Windows.Forms.Label();
      this.btnLogin = new System.Windows.Forms.Button();
      this.label5 = new System.Windows.Forms.Label();
      this.txtPassword = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.lblUserName = new System.Windows.Forms.Label();
      this.txtName = new System.Windows.Forms.TextBox();
      this.label3 = new System.Windows.Forms.Label();
      this.label1 = new System.Windows.Forms.Label();
      this.txtServer = new System.Windows.Forms.TextBox();
      this.btnConnect = new System.Windows.Forms.Button();
      this.lblStatus = new System.Windows.Forms.Label();
      label4 = new System.Windows.Forms.Label();
      label7 = new System.Windows.Forms.Label();
      label8 = new System.Windows.Forms.Label();
      separator1 = new System.Windows.Forms.PictureBox();
      topBorder = new System.Windows.Forms.PictureBox();
      bottomBorder = new System.Windows.Forms.PictureBox();
      leftBorder = new System.Windows.Forms.PictureBox();
      rightBorder = new System.Windows.Forms.PictureBox();
      ((System.ComponentModel.ISupportInitialize)(separator1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(topBorder)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(bottomBorder)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(leftBorder)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(rightBorder)).BeginInit();
      this.SuspendLayout();
      // 
      // label4
      // 
      label4.AutoSize = true;
      label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
      label4.Location = new System.Drawing.Point(11, 8);
      label4.Name = "label4";
      label4.Size = new System.Drawing.Size(68, 20);
      label4.TabIndex = 19;
      label4.Text = "Settings";
      // 
      // label7
      // 
      label7.AutoSize = true;
      label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
      label7.Location = new System.Drawing.Point(9, 53);
      label7.Name = "label7";
      label7.Size = new System.Drawing.Size(101, 18);
      label7.TabIndex = 24;
      label7.Text = "Login Settings";
      // 
      // label8
      // 
      label8.AutoSize = true;
      label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
      label8.Location = new System.Drawing.Point(16, 333);
      label8.Name = "label8";
      label8.Size = new System.Drawing.Size(101, 18);
      label8.TabIndex = 25;
      label8.Text = "Login Settings";
      // 
      // cmbRelease
      // 
      this.cmbRelease.BackColor = System.Drawing.Color.White;
      this.cmbRelease.DisplayMember = "Name";
      this.cmbRelease.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cmbRelease.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.cmbRelease.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.cmbRelease.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
      this.cmbRelease.FormattingEnabled = true;
      this.cmbRelease.Location = new System.Drawing.Point(136, 456);
      this.cmbRelease.Name = "cmbRelease";
      this.cmbRelease.Size = new System.Drawing.Size(335, 26);
      this.cmbRelease.TabIndex = 24;
      this.cmbRelease.ValueMember = "Id";
      // 
      // cmbWorkspace
      // 
      this.cmbWorkspace.BackColor = System.Drawing.Color.White;
      this.cmbWorkspace.DisplayMember = "Name";
      this.cmbWorkspace.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cmbWorkspace.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.cmbWorkspace.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.cmbWorkspace.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
      this.cmbWorkspace.FormattingEnabled = true;
      this.cmbWorkspace.Location = new System.Drawing.Point(136, 414);
      this.cmbWorkspace.Name = "cmbWorkspace";
      this.cmbWorkspace.Size = new System.Drawing.Size(335, 26);
      this.cmbWorkspace.TabIndex = 22;
      this.cmbWorkspace.ValueMember = "Id";
      this.cmbWorkspace.SelectedIndexChanged += new System.EventHandler(this.cmbWorkspace_SelectedIndexChanged);
      // 
      // cmbSharedSpace
      // 
      this.cmbSharedSpace.BackColor = System.Drawing.Color.White;
      this.cmbSharedSpace.DisplayMember = "Name";
      this.cmbSharedSpace.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cmbSharedSpace.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.cmbSharedSpace.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.cmbSharedSpace.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
      this.cmbSharedSpace.FormattingEnabled = true;
      this.cmbSharedSpace.Location = new System.Drawing.Point(136, 373);
      this.cmbSharedSpace.Name = "cmbSharedSpace";
      this.cmbSharedSpace.Size = new System.Drawing.Size(335, 26);
      this.cmbSharedSpace.TabIndex = 15;
      this.cmbSharedSpace.ValueMember = "Id";
      this.cmbSharedSpace.SelectedIndexChanged += new System.EventHandler(this.cmbSharedSpace_SelectedIndexChanged);
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(119)))), ((int)(((byte)(119)))));
      this.label6.Location = new System.Drawing.Point(18, 455);
      this.label6.Name = "label6";
      this.label6.Padding = new System.Windows.Forms.Padding(0, 7, 0, 0);
      this.label6.Size = new System.Drawing.Size(66, 25);
      this.label6.TabIndex = 25;
      this.label6.Text = "Release:";
      // 
      // btnLogin
      // 
      this.btnLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(169)))), ((int)(((byte)(130)))));
      this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnLogin.ForeColor = System.Drawing.Color.White;
      this.btnLogin.Location = new System.Drawing.Point(120, 250);
      this.btnLogin.Name = "btnLogin";
      this.btnLogin.Size = new System.Drawing.Size(259, 40);
      this.btnLogin.TabIndex = 14;
      this.btnLogin.Text = "Authenticate";
      this.btnLogin.UseVisualStyleBackColor = false;
      this.btnLogin.Click += new System.EventHandler(this.OnLoginClick);
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(119)))), ((int)(((byte)(119)))));
      this.label5.Location = new System.Drawing.Point(18, 413);
      this.label5.Name = "label5";
      this.label5.Padding = new System.Windows.Forms.Padding(0, 7, 0, 0);
      this.label5.Size = new System.Drawing.Size(89, 25);
      this.label5.TabIndex = 23;
      this.label5.Text = "Workspace:";
      // 
      // txtPassword
      // 
      this.txtPassword.BackColor = System.Drawing.Color.White;
      this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.txtPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.txtPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
      this.txtPassword.Location = new System.Drawing.Point(103, 196);
      this.txtPassword.MinimumSize = new System.Drawing.Size(2, 29);
      this.txtPassword.Name = "txtPassword";
      this.txtPassword.PasswordChar = '*';
      this.txtPassword.Size = new System.Drawing.Size(368, 24);
      this.txtPassword.TabIndex = 12;
      this.txtPassword.TextChanged += new System.EventHandler(this.OnLoginSettingsChanged);
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(119)))), ((int)(((byte)(119)))));
      this.label2.Location = new System.Drawing.Point(18, 372);
      this.label2.Name = "label2";
      this.label2.Padding = new System.Windows.Forms.Padding(0, 7, 0, 0);
      this.label2.Size = new System.Drawing.Size(105, 25);
      this.label2.TabIndex = 21;
      this.label2.Text = "Shared Space:";
      // 
      // lblUserName
      // 
      this.lblUserName.AutoSize = true;
      this.lblUserName.BackColor = System.Drawing.Color.Transparent;
      this.lblUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblUserName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(119)))), ((int)(((byte)(119)))));
      this.lblUserName.Location = new System.Drawing.Point(17, 189);
      this.lblUserName.Name = "lblUserName";
      this.lblUserName.Padding = new System.Windows.Forms.Padding(0, 7, 0, 0);
      this.lblUserName.Size = new System.Drawing.Size(79, 25);
      this.lblUserName.TabIndex = 20;
      this.lblUserName.Text = "Password:";
      // 
      // txtName
      // 
      this.txtName.BackColor = System.Drawing.Color.White;
      this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.txtName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.txtName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
      this.txtName.Location = new System.Drawing.Point(103, 142);
      this.txtName.Name = "txtName";
      this.txtName.Size = new System.Drawing.Size(368, 24);
      this.txtName.TabIndex = 11;
      this.txtName.TextChanged += new System.EventHandler(this.OnLoginSettingsChanged);
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(119)))), ((int)(((byte)(119)))));
      this.label3.Location = new System.Drawing.Point(16, 137);
      this.label3.Name = "label3";
      this.label3.Padding = new System.Windows.Forms.Padding(0, 7, 0, 0);
      this.label3.Size = new System.Drawing.Size(52, 25);
      this.label3.TabIndex = 18;
      this.label3.Text = "Name:";
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(119)))), ((int)(((byte)(119)))));
      this.label1.Location = new System.Drawing.Point(15, 89);
      this.label1.Name = "label1";
      this.label1.Padding = new System.Windows.Forms.Padding(0, 7, 0, 0);
      this.label1.Size = new System.Drawing.Size(55, 25);
      this.label1.TabIndex = 17;
      this.label1.Text = "Server:";
      // 
      // txtServer
      // 
      this.txtServer.BackColor = System.Drawing.Color.White;
      this.txtServer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.txtServer.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.txtServer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
      this.txtServer.Location = new System.Drawing.Point(103, 96);
      this.txtServer.Name = "txtServer";
      this.txtServer.Size = new System.Drawing.Size(368, 24);
      this.txtServer.TabIndex = 10;
      this.txtServer.TextChanged += new System.EventHandler(this.OnLoginSettingsChanged);
      // 
      // btnConnect
      // 
      this.btnConnect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(169)))), ((int)(((byte)(130)))));
      this.btnConnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnConnect.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnConnect.ForeColor = System.Drawing.Color.White;
      this.btnConnect.Location = new System.Drawing.Point(120, 526);
      this.btnConnect.Name = "btnConnect";
      this.btnConnect.Size = new System.Drawing.Size(259, 40);
      this.btnConnect.TabIndex = 21;
      this.btnConnect.Text = "Login";
      this.btnConnect.UseVisualStyleBackColor = false;
      this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
      // 
      // lblStatus
      // 
      this.lblStatus.AutoSize = true;
      this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(119)))), ((int)(((byte)(119)))));
      this.lblStatus.Location = new System.Drawing.Point(120, 296);
      this.lblStatus.Name = "lblStatus";
      this.lblStatus.Padding = new System.Windows.Forms.Padding(0, 7, 0, 0);
      this.lblStatus.Size = new System.Drawing.Size(0, 25);
      this.lblStatus.TabIndex = 26;
      // 
      // separator1
      // 
      separator1.Image = global::Hpe.Nga.Api.UI.Core.Properties.Resources.separator;
      separator1.Location = new System.Drawing.Point(15, 31);
      separator1.Name = "separator1";
      separator1.Size = new System.Drawing.Size(470, 1);
      separator1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
      separator1.TabIndex = 27;
      separator1.TabStop = false;
      // 
      // topBorder
      // 
      topBorder.BackColor = System.Drawing.SystemColors.ControlText;
      topBorder.Dock = System.Windows.Forms.DockStyle.Top;
      topBorder.Location = new System.Drawing.Point(1, 0);
      topBorder.Name = "topBorder";
      topBorder.Size = new System.Drawing.Size(498, 1);
      topBorder.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
      topBorder.TabIndex = 28;
      topBorder.TabStop = false;
      // 
      // bottomBorder
      // 
      bottomBorder.BackColor = System.Drawing.SystemColors.ControlText;
      bottomBorder.Dock = System.Windows.Forms.DockStyle.Bottom;
      bottomBorder.Location = new System.Drawing.Point(0, 599);
      bottomBorder.Name = "bottomBorder";
      bottomBorder.Size = new System.Drawing.Size(500, 1);
      bottomBorder.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
      bottomBorder.TabIndex = 29;
      bottomBorder.TabStop = false;
      // 
      // leftBorder
      // 
      leftBorder.BackColor = System.Drawing.SystemColors.ControlText;
      leftBorder.Dock = System.Windows.Forms.DockStyle.Left;
      leftBorder.Location = new System.Drawing.Point(0, 0);
      leftBorder.Margin = new System.Windows.Forms.Padding(0);
      leftBorder.MaximumSize = new System.Drawing.Size(1, 0);
      leftBorder.Name = "leftBorder";
      leftBorder.Size = new System.Drawing.Size(1, 599);
      leftBorder.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
      leftBorder.TabIndex = 30;
      leftBorder.TabStop = false;
      // 
      // rightBorder
      // 
      rightBorder.BackColor = System.Drawing.SystemColors.ControlText;
      rightBorder.Dock = System.Windows.Forms.DockStyle.Right;
      rightBorder.Location = new System.Drawing.Point(499, 0);
      rightBorder.Margin = new System.Windows.Forms.Padding(0);
      rightBorder.MaximumSize = new System.Drawing.Size(1, 0);
      rightBorder.Name = "rightBorder";
      rightBorder.Size = new System.Drawing.Size(1, 599);
      rightBorder.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
      rightBorder.TabIndex = 31;
      rightBorder.TabStop = false;
      // 
      // SettingsForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.White;
      this.ClientSize = new System.Drawing.Size(500, 600);
      this.Controls.Add(topBorder);
      this.Controls.Add(leftBorder);
      this.Controls.Add(rightBorder);
      this.Controls.Add(bottomBorder);
      this.Controls.Add(separator1);
      this.Controls.Add(this.txtServer);
      this.Controls.Add(label4);
      this.Controls.Add(label8);
      this.Controls.Add(this.cmbRelease);
      this.Controls.Add(label7);
      this.Controls.Add(this.cmbWorkspace);
      this.Controls.Add(this.cmbSharedSpace);
      this.Controls.Add(this.label6);
      this.Controls.Add(this.btnLogin);
      this.Controls.Add(this.label5);
      this.Controls.Add(this.txtPassword);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.lblUserName);
      this.Controls.Add(this.txtName);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.btnConnect);
      this.Controls.Add(this.lblStatus);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "SettingsForm";
      this.ShowIcon = false;
      this.ShowInTaskbar = false;
      this.Text = "Settings";
      ((System.ComponentModel.ISupportInitialize)(separator1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(topBorder)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(bottomBorder)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(leftBorder)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(rightBorder)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbSharedSpace;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.ComboBox cmbRelease;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbWorkspace;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtServer;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Label lblStatus;
    }
}