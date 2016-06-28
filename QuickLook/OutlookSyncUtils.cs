using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Hpe.Nga.Api.Core.Entities;
using Hpe.Nga.Api.Core.Services;
using Microsoft.Office.Interop.Outlook;
using Hpe.Nga.Api.Core.Services.GroupBy;

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
            if (sprintMap.ContainsKey(appointmentSprintId))
            {
                Sprint tempSprint = sprintMap[appointmentSprintId];
                sprintMap.Remove(appointmentSprintId);


                if (tempSprint != null)
                {
                    SyncSprintToOutlook(tempSprint, appointment);
                }
            }
            else
            {
                //Delete Sprint no longer exist in NGA
                appointment.Delete();
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
        OutlookUtils.AddAppointment(sprintName, sprint.StartDate, sprint.EndDate, "", 0, false, customFields, true);
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

    public static void SyncMilestonesToOutlook(Release release, EntityListResult<Milestone> milestones)
    {
        //set sprint map
        Dictionary<long, Milestone> milestonesMap = new Dictionary<long, Milestone>();

        foreach (Milestone milestone in milestones.data)
        {
            milestone.setMilestoneStartDateEndDate();
            milestonesMap[milestone.Id] = milestone;
        }

        //iterate outlook appointments
        Items resultItems = OutlookUtils.GetAppointmentsInRange(new DateTime(2015, 1, 1), new DateTime(2030, 1, 1));
        foreach (AppointmentItem appointment in resultItems)
        {
            UserProperty releaseUP = appointment.UserProperties[OutlookUtils.APPOINTMENT_RELEASE_ID_FIELD];
            int appointmentReleaseId = (releaseUP == null ? NO_ID_VALUE : int.Parse(releaseUP.Value));

            UserProperty milestoneUP = appointment.UserProperties[OutlookUtils.APPOINTMENT_MILESTONE_ID_FIELD];
            int appointmentMilestoneId = (milestoneUP == null ? NO_ID_VALUE : int.Parse(milestoneUP.Value));

            if (appointmentReleaseId != NO_ID_VALUE && appointmentMilestoneId != NO_ID_VALUE) //milestone
            {
                if (milestonesMap.ContainsKey(appointmentMilestoneId))
                {
                Milestone tempMilestone = milestonesMap[appointmentMilestoneId];
                milestonesMap.Remove(appointmentMilestoneId);


                if (tempMilestone != null)
                {
                    SyncMilestoneToOutlook(tempMilestone, appointment);
                }
            }
                else
                {
                    //Delete Milestone no longer exist in NGA
                    appointment.Delete();
                }
            }

            Marshal.ReleaseComObject(appointment);
        }

        //create milestones that were not deleted from map
        foreach (Milestone milestone in milestonesMap.Values)
        {
            Dictionary<String, Object> customFields = new Dictionary<String, Object>();
            customFields.Add(OutlookUtils.APPOINTMENT_RELEASE_ID_FIELD, ((Release)(milestone.Releases.data.ElementAt<BaseEntity>(0))).Id);
            customFields[OutlookUtils.APPOINTMENT_MILESTONE_ID_FIELD] = milestone.Id;
            String milestoneName = getMilestoneAppointmentName(milestone);
            MilestoneDataContainer msExtraData = getMilestoneData(milestone);

            OutlookUtils.AddAppointment(milestoneName, milestone.StartDate, milestone.EndDate, msExtraData.Category, msExtraData.ReminderMinutesBeforeStart, msExtraData.ReminderSet, customFields, true);
        }
    }

    private static void SyncMilestoneToOutlook(Milestone milestone, AppointmentItem appointment)
    {
        bool modified = false;
        if ((appointment.Start.Date != milestone.StartDate.Date) || (appointment.End.Date != milestone.EndDate.Date))
        {
            appointment.Start = milestone.StartDate;
            appointment.End = milestone.EndDate;
            modified = true;
        }

        String milestoneName = getMilestoneAppointmentName(milestone);
        if (!milestoneName.Equals(appointment.Subject))
        {
            appointment.Subject = milestoneName;
            modified = true;
        }

        MilestoneDataContainer notificationData = getMilestoneData(milestone);

        if (notificationData.ReminderMinutesBeforeStart == 0 && appointment.ReminderSet) 
        {
          appointment.ReminderSet = false;
          modified = true;
        }
        if (notificationData.ReminderMinutesBeforeStart != appointment.ReminderMinutesBeforeStart) {
          appointment.ReminderSet = true;
          appointment.ReminderMinutesBeforeStart = notificationData.ReminderMinutesBeforeStart;
          modified = true;
        }

        if (!String.IsNullOrEmpty(notificationData.Category) && 
          (appointment.Categories == null || !appointment.Categories.Contains(notificationData.Category)))
        {
          appointment.Categories = appointment.Categories + notificationData.Category;
          modified = true;
        }

        if (modified)
        {
            appointment.Save();
        }
    }

    private static MilestoneDataContainer getMilestoneData(Milestone milestone)
    {
      MilestoneDataContainer dataContainer = new MilestoneDataContainer();
      String desc = milestone.Description;
      if (desc != null)
      {
        string[] lines = milestone.Description.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
        for (int i = 0; i < lines.Length; i++)
        {
          string[] phrases = lines[i].Split('@');
          if (phrases.Length > 1)
          {
            dataContainer.AddPhrase(phrases[1]);
          }
        }
      }

      return dataContainer;
    }

    private static String getMilestoneAppointmentName(Milestone milestone)
    {
        return ((Release)(milestone.Releases.data.ElementAt<BaseEntity>(0))).Name + " " + milestone.Name;
    }
    public static void getReleaseMailReport(Release release, GroupResult groupResult, EntityListResult<WorkItem> workItems)
    {
          MailItem mailItem = OutlookUtils.AddMaileItem();
          mailItem.Subject = "Release Status: #" + release.Id + " - " + release.Name + " (" + release.StartDate.ToShortDateString() + " - " + release.EndDate.ToShortDateString() + ")";
          
          //getting defect by severity
          StringBuilder defectsStrBuild = new StringBuilder();
        int totatDefects = 0;
          foreach (Group group in groupResult.groups)
          {
              defectsStrBuild.AppendLine("\t\t"+group.value.name+": "+group.count);
              totatDefects += group.count;
          }
          mailItem.Body = "Release:\n\t" + release.Name + " (" + release.StartDate.ToShortDateString() + " - " + release.EndDate.ToShortDateString() + ")\n"
              + "\tNumber Of Sprints: " + release.NumOfSprints
              + "\n\nOpen Defects:\n\tTotal: " + totatDefects + "\n" + defectsStrBuild.ToString() +
              "\nOpenUser Stories:\n\tTotal: " + workItems.total_count;
        mailItem.Display();
      }
  }

}
