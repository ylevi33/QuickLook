using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hpe.Nga.Api.Core.Services.Query
    
{
    public class CrossQueryPhrase : QueryPhrase
    {
        public String FieldName { get; set; }

        public QueryPhrase QueryPhrase { get; set; }

        public CrossQueryPhrase(String fieldName, QueryPhrase queryPhrase)
           
        {
            this.FieldName = fieldName;
            this.QueryPhrase = queryPhrase;
        }
    }
}
