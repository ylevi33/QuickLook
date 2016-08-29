using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Outlook;

namespace SharedCalendar
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
      Folder calFolder = GetApplication().ActiveExplorer().CurrentFolder as Folder;
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
      catch(System.Exception ex)
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

    public static AppointmentItem AddAppointment(String subject, DateTime startDate, DateTime endDate, String categories, int reminderMinutesBeforeStart, Boolean reminderSet, Dictionary<String, Object> customFields, bool save)
    {
      AppointmentItem newAppointment = (AppointmentItem)GetApplication().ActiveExplorer().CurrentFolder.Items.Add(OlItemType.olAppointmentItem);
      newAppointment.AllDayEvent = true;
      newAppointment.Start = startDate;
      newAppointment.End = endDate;
      newAppointment.Subject = subject;
      newAppointment.ReminderSet = reminderSet;

      // Add categories
      newAppointment.Categories = categories;
        
      // Add reminder
      if (reminderMinutesBeforeStart >= 0)
      {
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
    public static MailItem AddMailItem()
    {
        MailItem mailItem = (MailItem)GetApplication().CreateItem(OlItemType.olMailItem);
        mailItem.Save();
        return mailItem;
    }

    public static bool IsCalendarActive()
    {
      var explorer = GetApplication().ActiveExplorer();
      if (explorer != null)
      {
        var folder = explorer.CurrentFolder;
        if (folder != null)
        {
          return folder.DefaultItemType == OlItemType.olAppointmentItem;
        }
      }

      return false;
    }
  }
}
