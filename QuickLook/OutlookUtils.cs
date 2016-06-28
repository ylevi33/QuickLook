using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Outlook;

namespace QuickLook
{
  public static class OutlookUtils
  {
    public static string APPOINTMENT_RELEASE_ID_FIELD = "ReleaseId";
    public static string APPOINTMENT_SPRINT_ID_FIELD = "SprintId";
    public static string APPOINTMENT_MILESTONE_ID_FIELD = "MilestoneId";

    public static Application GetApplication()
    {
      Application outlookApp = new Microsoft.Office.Interop.Outlook.Application();
      return outlookApp;
    }

    public static Items GetAppointmentsInRange(DateTime startDate, DateTime endDate)
    {
      Folder calFolder = GetApplication().Session.GetDefaultFolder(OlDefaultFolders.olFolderCalendar) as Folder;
      string filter = "[Start] >= '" + startDate.ToString("g") + "' AND [End] <= '" + endDate.ToString("g") + "' AND [AllDayEvent] = True";
      Debug.WriteLine(filter);
      Items calItems = null;
      Items restrictItems = null;
      try
      {
        calItems = calFolder.Items;
        calItems.IncludeRecurrences = true;
        calItems.Sort("[Start]", Type.Missing);
        restrictItems = calItems.Restrict(filter);
        if (restrictItems.Count > 0)
        {
          return restrictItems;
        }
        return null;
      }
      catch
      {
        if (restrictItems != null)
        {
          Marshal.ReleaseComObject(restrictItems);
        }
        return null;
      }
      finally
      {
        if (calItems != null)
        {
          Marshal.ReleaseComObject(calItems);
        }
      }
    }

    public static AppointmentItem AddAppointment(String subject, DateTime startDate, DateTime endDate, String categories, int reminderMinutesBeforeStart, Dictionary<String, Object> customFields, bool save)
    {
      AppointmentItem newAppointment = (AppointmentItem)GetApplication().CreateItem(OlItemType.olAppointmentItem);
      newAppointment.AllDayEvent = true;
      newAppointment.Start = startDate;
      newAppointment.End = endDate;
      newAppointment.Subject = subject;
      newAppointment.ReminderSet = false;

      // Add categories
      newAppointment.Categories = categories;
        
      // Add reminder
      if (reminderMinutesBeforeStart >= 0)
      {
          newAppointment.ReminderSet = true;
          newAppointment.ReminderMinutesBeforeStart = reminderMinutesBeforeStart;
      }
        
      if (customFields != null)
      {
        foreach (KeyValuePair<String, object> keyValue in customFields)
        {
          newAppointment.UserProperties.Add(keyValue.Key, OlUserPropertyType.olText, true, Type.Missing);
          newAppointment.UserProperties[keyValue.Key].Value = keyValue.Value;
        }
      }

      if (save)
      {
        newAppointment.Save();
      }

      // todo set appointment category
      return newAppointment;
    }
  }
}
