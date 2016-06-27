using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Hpe.Nga.Api.Core.Entities;
using Hpe.Nga.Api.Core.Services;
using Microsoft.Office.Interop.Outlook;

namespace QuickLook
{
  public class OutlookSyncUtils
  {
    public static int NO_ID_VALUE = -1;

    public static void SyncSprintsToOutlook(Release release, EntityListResult<Sprint> sprints) {

      //set sprint map
      Dictionary<long, Sprint> sprintMap = new Dictionary<long, Sprint>();
      foreach (Sprint sprint in sprints.data)
      {
        sprintMap[sprint.Id] = sprint;
      }

    //iterate outlook appointments
      Items resultItems = OutlookUtils.GetAppointmentsInRange(new DateTime(2015, 1, 1), new DateTime(2030, 1, 1));
      foreach (AppointmentItem appointment in resultItems)
      {
        UserProperty releaseUP = appointment.UserProperties[OutlookUtils.APPOINTMENT_RELEASE_ID_FIELD];
        int appointmentReleaseId = (releaseUP == null ? NO_ID_VALUE : int.Parse(releaseUP.Value));

        UserProperty sprintUP = appointment.UserProperties[OutlookUtils.APPOINTMENT_SPRINT_ID_FIELD];
        int appointmentSprintId = (sprintUP == null ? NO_ID_VALUE : int.Parse(sprintUP.Value));

        if (appointmentReleaseId != NO_ID_VALUE && appointmentSprintId != NO_ID_VALUE) //sprint
        {
          Sprint tempSprint = sprintMap[appointmentSprintId];
          sprintMap.Remove(appointmentSprintId);


          if (tempSprint != null)
          {
            SyncSprintToOutlook(tempSprint, appointment);
          }
        }

        Marshal.ReleaseComObject(appointment);
      }

      //create sprints that were not deleted from map
      foreach (Sprint sprint in sprintMap.Values)
      {
        Dictionary<String, Object> customFields = new Dictionary<String, Object>();
        customFields.Add(OutlookUtils.APPOINTMENT_RELEASE_ID_FIELD, sprint.Release.Id);
        customFields[OutlookUtils.APPOINTMENT_SPRINT_ID_FIELD] = sprint.Id;
        String sprintName = getSprintAppointmentName(sprint);
        OutlookUtils.AddAppointment(sprintName, sprint.StartDate, sprint.EndDate, customFields, true);
      }

    }

    private static void SyncReleaseToOutlook(Release release, AppointmentItem appointment)
    {
      bool modified = false;
      if (appointment.Start.Date != release.StartDate.Date)
      {
        appointment.Start = release.StartDate;
        modified = true;
      }
      if (appointment.End.Date != release.EndDate.Date)
      {
        appointment.End = release.EndDate;
        modified = true;
      }
      if (!release.Name.Equals(appointment.Subject))
      {
        appointment.Subject = release.Name;
        modified = true;
      }
      if (modified)
      {
        appointment.Save();
      }
    }

    private static void SyncSprintToOutlook(Sprint sprint, AppointmentItem appointment)
    {
      bool modified = false;
      if (appointment.Start.Date != sprint.StartDate.Date)
      {
        appointment.Start = sprint.StartDate;
        modified = true;
      }
      if (appointment.End.Date != sprint.EndDate.Date)
      {
        appointment.End = sprint.EndDate;
        modified = true;
      }

      String sprintName = getSprintAppointmentName(sprint);
      if (!sprintName.Equals(appointment.Subject))
      {
        appointment.Subject = sprintName;
        modified = true;
      }
      if (modified)
      {
        appointment.Save();
      }
    }

    private static String getSprintAppointmentName(Sprint sprint)
    {
      return sprint.Release.Name + " " + sprint.Name;
    }
  }

}
