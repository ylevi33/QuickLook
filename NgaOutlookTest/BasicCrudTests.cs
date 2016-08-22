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


        #region Release CRUD

        private static EntityListResult<Release> GetAllReleases(WorkspaceContext context, int expectedCount)
        {
            List<String> fields = new List<string>();
            fields.Add(Release.NAME_FIELD);
            fields.Add(Release.START_DATE_FIELD);
            fields.Add(Release.END_DATE_FIELD);


            EntityListResult<Release> result = entityService.Get<Release>(context, null, fields);
            Assert(result.data.Count >= expectedCount);
            return result;
        }


        private static EntityListResult<Release> GetReleaseWithQueryByName(WorkspaceContext context, string name)
        {
            List<String> fields = new List<string>();
            fields.Add(Release.NAME_FIELD);

            List<QueryPhrase> queryPhrases = new List<QueryPhrase>();
            QueryPhrase phrase = new LogicalQueryPhrase("name", name);
            queryPhrases.Add(phrase);

            EntityListResult<Release> result = entityService.Get<Release>(context, queryPhrases, fields);
            Assert(result.data.Count == 1);
            Assert(result.data[0].Name.Equals(name));
            return result;
        }

        private static Release GetReleaseById(WorkspaceContext context, long id)
        {
            List<String> fields = new List<string>();
            fields.Add(Release.NAME_FIELD);
            Release release = entityService.GetById<Release>(context, id, fields);
            Assert(release.Id == id);
            return release;
        }

        private static Release CreateRelease(WorkspaceContext context)
        {
            String name = "Release_" + Guid.NewGuid();
            Release release = new Release();
            release.Name = name;
            release.StartDate = DateTime.Now;
            release.EndDate = DateTime.Now.AddDays(10);
            release.SprintDuration = 7;


            Release created = entityService.Create<Release>(context, release);
            Assert(created.Name.Equals(name));
            return created;
        }

        private static Release UpdateReleaseName(WorkspaceContext context, long id)
        {
            String name = "ReleaseUpdated_" + Guid.NewGuid();
            Release release = new Release(id);
            release.Name = name;

            Release updated = entityService.Update<Release>(context, release);
            Assert(updated.Name.Equals(name));
            return updated;
        }

        private static void DeleteRelease(WorkspaceContext context, long id)
        {
            entityService.Delete<Release>(context, id);
            try
            {
                Release r = GetReleaseById(context, id);
                Assert(false);
            }
            catch (Exception e)
            {
                Assert(e.Message.Contains("404"));
            }

        }

        #endregion

        #region Sprint Crud



        #endregion


        #region WorkItems
        private static EntityListResult<WorkItem> GetAllDefectWithLimit1(WorkspaceContext context)
        {
            List<String> fields = new List<string>();
            fields.Add(WorkItem.NAME_FIELD);
            fields.Add(WorkItem.SUBTYPE);

            List<QueryPhrase> queries = new List<QueryPhrase>();
            LogicalQueryPhrase subtypeQuery = new LogicalQueryPhrase(WorkItem.SUBTYPE, WorkItem.SUBTYPE_DEFECT);
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
            fields.Add(WorkItem.SUBTYPE);


            List<QueryPhrase> queries = new List<QueryPhrase>();
            LogicalQueryPhrase subtypeQuery = new LogicalQueryPhrase(WorkItem.SUBTYPE, WorkItem.SUBTYPE_DEFECT);
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
