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
    }
}
