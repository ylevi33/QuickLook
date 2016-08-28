using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hpe.Nga.Api.Core.Connector
{
    public class MqmRestException : Exception
    {
        RestExceptionInfo exceptionInfo;
        public MqmRestException(RestExceptionInfo exceptionInfo)
        {
            this.exceptionInfo = exceptionInfo;
        }

        public String ErrorCode
        {
            get
            {
                return exceptionInfo.error_code;
            }
        }

        public String CorrelationInfo
        {
            get
            {
                return exceptionInfo.correlation_id;
            }
        }

        public String Description
        {
            get
            {
                return exceptionInfo.description;
            }
        }

        public String DescriptionTranslated
        {
            get
            {
                return exceptionInfo.description_translated;
            }
        }

        public Dictionary<String, String> Properties
        {
            get
            {
                return exceptionInfo.properties;
            }
        }
    }
}
