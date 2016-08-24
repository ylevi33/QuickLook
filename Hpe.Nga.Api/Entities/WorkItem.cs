﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hpe.Nga.Api.Core.Services;

namespace Hpe.Nga.Api.Core.Entities
{
    /// <summary>
    /// Wrapper for WorkItem entity
    /// More fields might be supported by entity that still are not exposed in the class
    /// </summary>
    public class WorkItem : BaseEntity
    {        public static string RELEASE = "release";
        public static string PHASE = "phase";
        public static string SUBTYPE_DEFECT = "defect";
        public static string SUBTYPE_US = "story";
        
    }
}
