using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Hpe.Nga.Api.Core.Entities;
using Hpe.Nga.Api.Core.Services;
using Hpe.Nga.Api.Core.Services.GroupBy;
using Hpe.Nga.Api.Core.Services.Query;
using Hpe.Nga.Api.Core.Services.RequestContext;

namespace NgaOutlookTest
{
    public static class BasicCrudTests
    {
        private static EntityService entityService = EntityService.GetInstance();

        public static WorkspaceContext GetWorkspaceContextTest(long sharedSpaceId, long workspaceId)
        {
            SharedSpaceContext sharedSpaceContext = new SharedSpaceContext(sharedSpaceId);
            //EntityListResult<Workspace> workspaces = entityService.Get<Workspace>(sharedSpaceContext);
            //Workspace workspace = workspaces.data[0];
            //long workspaceId = 2006;//workspaces.data[0].Id hardcoded workaround
            WorkspaceContext workspaceContext = new WorkspaceContext(sharedSpaceId, workspaceId);
            return workspaceContext;
        }
     


        public static void BasicWorkItemsTests(WorkspaceContext context)
        {
            GetAllDefectWithLimit1(context);
            GetAllDefectWithGroupBy(context);
        }



        #region WorkItems
        private static EntityListResult<WorkItem> GetAllDefectWithLimit1(WorkspaceContext context)
        {
            List<String> fields = new List<string>();
            fields.Add(WorkItem.NAME_FIELD);
            fields.Add(WorkItem.SUBTYPE_FIELD);

            List<QueryPhrase> queries = new List<QueryPhrase>();
            LogicalQueryPhrase subtypeQuery = new LogicalQueryPhrase(WorkItem.SUBTYPE_FIELD, WorkItem.SUBTYPE_DEFECT);
            queries.Add(subtypeQuery);


            //api/shared_spaces/1001/workspaces/2029/work_items/groups?group_by=severity&limit=20&query="(subtype='defect');(release={id=1055})"

            EntityListResult<WorkItem> result = entityService.Get<WorkItem>(context, queries, fields, 1);
            Assert(result.data.Count <= 1);
            return result;
        }

        private static Object GetAllDefectWithGroupBy(WorkspaceContext context)
        {
            List<String> fields = new List<string>();
            fields.Add(WorkItem.NAME_FIELD);
            fields.Add(WorkItem.SUBTYPE_FIELD);


            List<QueryPhrase> queries = new List<QueryPhrase>();
            LogicalQueryPhrase subtypeQuery = new LogicalQueryPhrase(WorkItem.SUBTYPE_FIELD, WorkItem.SUBTYPE_DEFECT);
            queries.Add(subtypeQuery);

            //api/shared_spaces/1001/workspaces/2029/work_items/groups?group_by=severity&limit=20&query="(subtype='defect');(release={id=1055})"

            GroupResult result = entityService.GetWithGroupBy<WorkItem>(context, queries, "severity");
            //Assert(result.data.Count <= 1);
            return result;
        }

        #endregion

        private static void Assert(bool condition)
        {
            if (!condition)
            {
                throw new Exception("Assertion is failed");
            }
        }


    }
}
