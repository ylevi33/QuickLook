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

      Dictionary<long, Release> releaseMap = new Dictionary<long, Release>();
      releaseMap[release.Id] = release;

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

        //if release
        if (appointmentReleaseId != NO_ID_VALUE && appointmentSprintId == NO_ID_VALUE)
        {
          Release tempRelease = releaseMap[appointmentReleaseId];
          releaseMap.Remove(appointmentReleaseId);

          // todo sync release
          if (tempRelease != null)
          {
            SyncReleaseToOutlook(release, appointment);
          }
        }
        else if (appointmentReleaseId != NO_ID_VALUE && appointmentSprintId != NO_ID_VALUE) //sprint
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

      //create releases that were not deleted from map
      foreach (Release tempRelease in releaseMap.Values)
      {
        Dictionary<String, Object> customFields = new Dictionary<String, Object>();
        customFields.Add(OutlookUtils.APPOINTMENT_RELEASE_ID_FIELD, tempRelease.Id);
        OutlookUtils.AddAppointment(tempRelease.Name, tempRelease.StartDate, tempRelease.EndDate, customFields, true);
      }

      //create sprints that were not deleted from map
      foreach (Sprint sprint in sprintMap.Values)
      {
        Dictionary<String, Object> customFields = new Dictionary<String, Object>();
        customFields.Add(OutlookUtils.APPOINTMENT_RELEASE_ID_FIELD, sprint.Release.Id);
        customFields[OutlookUtils.APPOINTMENT_SPRINT_ID_FIELD] = sprint.Id;
        OutlookUtils.AddAppointment(sprint.Name, sprint.StartDate, sprint.EndDate, customFields, true);
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
      if (!sprint.Name.Equals(appointment.Subject))
      {
        appointment.Subject = sprint.Name;
        modified = true;
      }
      if (modified)
      {
        appointment.Save();
      }
    }
  }
}
