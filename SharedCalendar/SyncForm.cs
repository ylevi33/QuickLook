using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Hpe.Nga.Api.UI.Core.Configuration;

namespace SharedCalendar
{
  public partial class SyncForm : Form
  {
    public SyncForm()
    {
      InitializeComponent();
    }

    public void Init(ICollection<String> calendars, LoginConfiguration config)
    {
      lbSyncRelease.Text = String.Format(lbSyncRelease.Text, config.ReleaseName);

      foreach(String calendar in calendars) {
        cbCalendars.Items.Add(calendar);
      }

      cbCalendars.SelectedItem = config.CalendarName;
    }
    
    private void cbCalendars_SelectedIndexChanged(object sender, EventArgs e)
    {
      btnSync.Enabled = true;
    }

    public String SelectedCalendar 
    {
      get { return (String)cbCalendars.SelectedItem; }
    }
  }
}
