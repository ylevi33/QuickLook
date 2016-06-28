using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hpe.Nga.Api.Core.Services;

namespace Hpe.Nga.Api.Core.Entities
{
    public class WorkItem : BaseEntity
    {
        public static string SUBTYPE = "subtype";
        public static string RELEASE = "release";
        public static string PHASE = "phase";
        public static string SUBTYPE_DEFECT = "defect";
        public static string SUBTYPE_US = "story";
        
        public String Subtype
        {
            get
            {
                return GetStringValue(SUBTYPE);
            }
            set
            {
                SetValue(SUBTYPE, value);
            }

        }
    }
}
