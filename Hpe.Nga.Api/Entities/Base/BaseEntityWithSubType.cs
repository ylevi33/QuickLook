using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hpe.Nga.Api.Core.Services;

namespace Hpe.Nga.Api.Core.Entities
{
    public class BaseEntityWithSubType : BaseEntity
    {
        public static string SUBTYPE_FIELD = "subtype";

        public string SubType
        {
            get
            {
                return GetStringValue(SUBTYPE_FIELD);
            }
            set
            {
                SetValue(SUBTYPE_FIELD, value);
            }

        }

    }
}
