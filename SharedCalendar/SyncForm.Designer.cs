namespace SharedCalendar
{
  partial class SyncForm
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
      this.lbSyncRelease = new System.Windows.Forms.Label();
      this.lbCalendar = new System.Windows.Forms.Label();
      this.btnSync = new System.Windows.Forms.Button();
      this.btnCancel = new System.Windows.Forms.Button();
      this.cbCalendars = new System.Windows.Forms.ComboBox();
      this.SuspendLayout();
      // 
      // lbSyncRelease
      // 
      this.lbSyncRelease.AutoSize = true;
      this.lbSyncRelease.Location = new System.Drawing.Point(28, 35);
      this.lbSyncRelease.Name = "lbSyncRelease";
      this.lbSyncRelease.Size = new System.Drawing.Size(168, 13);
      this.lbSyncRelease.TabIndex = 0;
      this.lbSyncRelease.Text = "You are about to sync release: {0}";
      // 
      // lbCalendar
      // 
      this.lbCalendar.AutoSize = true;
      this.lbCalendar.Location = new System.Drawing.Point(31, 66);
      this.lbCalendar.Name = "lbCalendar";
      this.lbCalendar.Size = new System.Drawing.Size(106, 13);
      this.lbCalendar.TabIndex = 1;
      this.lbCalendar.Text = "to Outllook Calendar:";
      // 
      // btnSync
      // 
      this.btnSync.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.btnSync.Enabled = false;
      this.btnSync.Location = new System.Drawing.Point(218, 104);
      this.btnSync.Name = "btnSync";
      this.btnSync.Size = new System.Drawing.Size(75, 23);
      this.btnSync.TabIndex = 2;
      this.btnSync.Text = "Sync";
      this.btnSync.UseVisualStyleBackColor = true;
      // 
      // btnCancel
      // 
      this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.btnCancel.Location = new System.Drawing.Point(123, 104);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new System.Drawing.Size(75, 23);
      this.btnCancel.TabIndex = 3;
      this.btnCancel.Text = "Cancel";
      this.btnCancel.UseVisualStyleBackColor = true;
      // 
      // cbCalendars
      // 
      this.cbCalendars.FormattingEnabled = true;
      this.cbCalendars.Location = new System.Drawing.Point(153, 62);
      this.cbCalendars.Name = "cbCalendars";
      this.cbCalendars.Size = new System.Drawing.Size(140, 21);
      this.cbCalendars.TabIndex = 4;
      this.cbCalendars.SelectedIndexChanged += new System.EventHandler(this.cbCalendars_SelectedIndexChanged);
      // 
      // SyncForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(325, 154);
      this.Controls.Add(this.cbCalendars);
      this.Controls.Add(this.btnCancel);
      this.Controls.Add(this.btnSync);
      this.Controls.Add(this.lbCalendar);
      this.Controls.Add(this.lbSyncRelease);
      this.Name = "SyncForm";
      this.Text = "Synchronize";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label lbSyncRelease;
    private System.Windows.Forms.Label lbCalendar;
    private System.Windows.Forms.Button btnSync;
    private System.Windows.Forms.Button btnCancel;
    private System.Windows.Forms.ComboBox cbCalendars;
  }
}