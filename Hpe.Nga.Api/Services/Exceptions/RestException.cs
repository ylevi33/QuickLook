using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hpe.Nga.Api.Core.Services.Exceptions
{
    public class RestException : Exception
    {
        public RestException(Exception exception)
            : base(exception.Message, exception)
        {

        }
    }
}
