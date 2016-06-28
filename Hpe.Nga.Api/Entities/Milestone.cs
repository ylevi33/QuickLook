using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hpe.Nga.Api.Core.Services;

namespace Hpe.Nga.Api.Core.Entities
{
    public class Milestone : BaseEntity
    {
        public static string DATE_FIELD = "date";
        public static string DESCRIPTION_FIELD = "description";
        public static string RELEASES_FIELD = "releases";
        public static string START_DATE_FIELD = "start_date";
        public static string END_DATE_FIELD = "end_date";

        public DateTime Date
        {
            get
            {
                return GetDateTimeValue(DATE_FIELD).Value;
            }
            set
            {
                SetDateTimeValue(DATE_FIELD, value);
            }

        }
        
        public DateTime StartDate
        {
            get
            {
                return GetDateTimeUTCValue(START_DATE_FIELD).Value;
            }
            set
            {
                SetDateTimeValue(START_DATE_FIELD, value);
            }

        }

        public DateTime EndDate
        {
            get
            {
                return GetDateTimeUTCValue(END_DATE_FIELD).Value;
            }
            set
            {
                SetDateTimeValue(END_DATE_FIELD, value);
            }

        }

        public void SetRelease(EntityList<Release> releases)
        {
            SetValue(RELEASES_FIELD, releases);

        }

        public EntityList<BaseEntity> Releases
        {
            get
            {
                return (EntityList<BaseEntity>)GetValue(RELEASES_FIELD);
            }
            set
            {
                SetValue(RELEASES_FIELD, value);
            }

        }

        public void setMilestoneStartDateEndDate()
        {
            DateTime date = GetDateTimeValue(DATE_FIELD).Value;
            StartDate = new DateTime(date.Year, date.Month, date.Day, 0, 0, 0, DateTimeKind.Utc);
            EndDate = new DateTime(date.Year, date.Month, date.Day, 0, 0, 0, DateTimeKind.Utc);
            EndDate = EndDate.AddDays(1);
        }
    }
}
