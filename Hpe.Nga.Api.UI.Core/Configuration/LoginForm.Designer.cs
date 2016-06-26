namespace Hpe.Nga.Api.UI.Core.Configuration
{
    partial class LoginForm
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
      this.btnConnect = new System.Windows.Forms.Button();
      this.txtServer = new System.Windows.Forms.TextBox();
      this.label1 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.lblUserName = new System.Windows.Forms.Label();
      this.txtName = new System.Windows.Forms.TextBox();
      this.txtPassword = new System.Windows.Forms.TextBox();
      this.btnLogin = new System.Windows.Forms.Button();
      this.label2 = new System.Windows.Forms.Label();
      this.cmbSharedSpace = new System.Windows.Forms.ComboBox();
      this.label4 = new System.Windows.Forms.Label();
      this.lblStatus = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // btnConnect
      // 
      this.btnConnect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(169)))), ((int)(((byte)(130)))));
      this.btnConnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnConnect.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnConnect.ForeColor = System.Drawing.Color.White;
      this.btnConnect.Location = new System.Drawing.Point(430, 240);
      this.btnConnect.Name = "btnConnect";
      this.btnConnect.Size = new System.Drawing.Size(109, 32);
      this.btnConnect.TabIndex = 4;
      this.btnConnect.Text = "Connect";
      this.btnConnect.UseVisualStyleBackColor = false;
      this.btnConnect.Click += new System.EventHandler(this.OnConnectClick);
      // 
      // txtServer
      // 
      this.txtServer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
      this.txtServer.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.txtServer.Location = new System.Drawing.Point(205, 107);
      this.txtServer.Name = "txtServer";
      this.txtServer.Size = new System.Drawing.Size(334, 24);
      this.txtServer.TabIndex = 1;
      this.txtServer.TextChanged += new System.EventHandler(this.OnConfigurationChanged);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label1.ForeColor = System.Drawing.Color.White;
      this.label1.Location = new System.Drawing.Point(96, 106);
      this.label1.Name = "label1";
      this.label1.Padding = new System.Windows.Forms.Padding(0, 7, 0, 0);
      this.label1.Size = new System.Drawing.Size(55, 25);
      this.label1.TabIndex = 6;
      this.label1.Text = "Server:";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label3.ForeColor = System.Drawing.Color.White;
      this.label3.Location = new System.Drawing.Point(96, 146);
      this.label3.Name = "label3";
      this.label3.Padding = new System.Windows.Forms.Padding(0, 7, 0, 0);
      this.label3.Size = new System.Drawing.Size(52, 25);
      this.label3.TabIndex = 7;
      this.label3.Text = "Name:";
      // 
      // lblUserName
      // 
      this.lblUserName.AutoSize = true;
      this.lblUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblUserName.ForeColor = System.Drawing.Color.White;
      this.lblUserName.Location = new System.Drawing.Point(96, 186);
      this.lblUserName.Name = "lblUserName";
      this.lblUserName.Padding = new System.Windows.Forms.Padding(0, 7, 0, 0);
      this.lblUserName.Size = new System.Drawing.Size(79, 25);
      this.lblUserName.TabIndex = 8;
      this.lblUserName.Text = "Password:";
      // 
      // txtName
      // 
      this.txtName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
      this.txtName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.txtName.Location = new System.Drawing.Point(205, 147);
      this.txtName.Name = "txtName";
      this.txtName.Size = new System.Drawing.Size(334, 24);
      this.txtName.TabIndex = 2;
      this.txtName.TextChanged += new System.EventHandler(this.OnConfigurationChanged);
      // 
      // txtPassword
      // 
      this.txtPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
      this.txtPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.txtPassword.Location = new System.Drawing.Point(205, 187);
      this.txtPassword.Name = "txtPassword";
      this.txtPassword.PasswordChar = '*';
      this.txtPassword.Size = new System.Drawing.Size(334, 24);
      this.txtPassword.TabIndex = 3;
      this.txtPassword.TextChanged += new System.EventHandler(this.OnConfigurationChanged);
      // 
      // btnLogin
      // 
      this.btnLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(169)))), ((int)(((byte)(130)))));
      this.btnLogin.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnLogin.ForeColor = System.Drawing.Color.White;
      this.btnLogin.Location = new System.Drawing.Point(443, 337);
      this.btnLogin.Name = "btnLogin";
      this.btnLogin.Size = new System.Drawing.Size(96, 31);
      this.btnLogin.TabIndex = 6;
      this.btnLogin.Text = "Login";
      this.btnLogin.UseVisualStyleBackColor = false;
      this.btnLogin.Visible = false;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label2.ForeColor = System.Drawing.Color.White;
      this.label2.Location = new System.Drawing.Point(96, 298);
      this.label2.Name = "label2";
      this.label2.Padding = new System.Windows.Forms.Padding(0, 7, 0, 0);
      this.label2.Size = new System.Drawing.Size(105, 25);
      this.label2.TabIndex = 9;
      this.label2.Text = "Shared Space:";
      this.label2.Visible = false;
      // 
      // cmbSharedSpace
      // 
      this.cmbSharedSpace.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
      this.cmbSharedSpace.DisplayMember = "Name";
      this.cmbSharedSpace.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cmbSharedSpace.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.cmbSharedSpace.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.cmbSharedSpace.FormattingEnabled = true;
      this.cmbSharedSpace.Location = new System.Drawing.Point(205, 299);
      this.cmbSharedSpace.Name = "cmbSharedSpace";
      this.cmbSharedSpace.Size = new System.Drawing.Size(334, 26);
      this.cmbSharedSpace.TabIndex = 5;
      this.cmbSharedSpace.ValueMember = "Id";
      this.cmbSharedSpace.Visible = false;
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label4.ForeColor = System.Drawing.Color.White;
      this.label4.Location = new System.Drawing.Point(250, 9);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(224, 55);
      this.label4.TabIndex = 8;
      this.label4.Text = "Welcome";
      // 
      // lblStatus
      // 
      this.lblStatus.AutoSize = true;
      this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblStatus.ForeColor = System.Drawing.Color.White;
      this.lblStatus.Location = new System.Drawing.Point(202, 247);
      this.lblStatus.Name = "lblStatus";
      this.lblStatus.Size = new System.Drawing.Size(20, 18);
      this.lblStatus.TabIndex = 4;
      this.lblStatus.Text = "...";
      // 
      // LoginForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(68)))), ((int)(((byte)(79)))));
      this.BackgroundImage = global::Hpe.Nga.Api.UI.Core.Properties.Resources.background;
      this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
      this.ClientSize = new System.Drawing.Size(768, 380);
      this.Controls.Add(this.lblStatus);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.cmbSharedSpace);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.btnConnect);
      this.Controls.Add(this.txtPassword);
      this.Controls.Add(this.lblUserName);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.txtName);
      this.Controls.Add(this.txtServer);
      this.Controls.Add(this.btnLogin);
      this.Controls.Add(this.label1);
      this.DoubleBuffered = true;
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "LoginForm";
      this.ShowIcon = false;
      this.ShowInTaskbar = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Login";
      this.ResumeLayout(false);
      this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.TextBox txtServer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbSharedSpace;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblStatus;
    }
}