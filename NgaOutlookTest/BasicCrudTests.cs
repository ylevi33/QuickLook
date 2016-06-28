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
        public static void BasicReleaseCrudTest(WorkspaceContext context)
        {
            //CREATE
            Release created = CreateRelease(context);
            Release created2 = CreateRelease(context);

            //Get by id
            Release receivedById = GetReleaseById(context, created.Id);
            Assert(receivedById.Name.Equals(created.Name));

            EntityListResult<Release> receivedByNameResult = GetReleaseWithQueryByName(context, created.Name);

            //update name
            Release updated = UpdateReleaseName(context, created.Id);

            //getAllReleases
            EntityListResult<Release> allReleases = GetAllReleases(context, 2/*expected count*/);

            //delete release
            DeleteRelease(context, created.Id);
            DeleteRelease(context, created2.Id);
        }

        public static void BasicMilestoneTest(WorkspaceContext context)
        {
            Release release = CreateRelease(context);
            Milestone created1 = CreateMilestone(context, release);
            Milestone created2 = CreateMilestone(context, release);
            Milestone created3 = CreateMilestone(context, release);
            Milestone milestone = GetMilestoneById(context, created1.Id);

            GetMilestonesByRelease(context, release.Id, 3/*expected count*/);
            GetMilestonesByName(context, created1.Name, created2.Name, 2/*expected count*/);

            DeleteRelease(context, release.Id);
            DeleteMilestone(context, created1.Id);
            DeleteMilestone(context, created2.Id);
            DeleteMilestone(context, created3.Id);
        }

        public static void BasicSprintTest(WorkspaceContext context)
        {
            Release release = CreateRelease(context);
            GetSprintsByRelease(context, release.Id, 2);

            DeleteRelease(context, release.Id);

        }

        public static void BasicWorkItemsTests(WorkspaceContext context)
        {
            GetAllDefectWithLimit1(context);
            GetAllDefectWithGroupBy(context);
        }


        #region Milestone CRUD

        private static Milestone CreateMilestone(WorkspaceContext context, Release release)
        {
            String name = "Milestone_" + Guid.NewGuid();
            Milestone milestone = new Milestone();
            milestone.Name = name;
            milestone.Date = DateTime.Now.AddDays(7);
            milestone.SetRelease(new EntityList<Release>(release));


            Milestone created = entityService.Create<Milestone>(context, milestone);
            Assert(created.Name.Equals(name));
            return created;
        }

        private static Milestone GetMilestoneById(WorkspaceContext context, long id)
        {
            List<String> fields = new List<string>();
            fields.Add(Milestone.NAME_FIELD);
            fields.Add(Milestone.RELEASES_FIELD);
            Milestone milestone = entityService.GetById<Milestone>(context, id, fields);
            Assert(milestone.Id == id);
            return milestone;
        }

        private static void GetMilestonesByName(WorkspaceContext context, string name1, string name2, int expectedResultCount)
        {
            List<String> fields = new List<string>();
            fields.Add(Milestone.NAME_FIELD);

            List<QueryPhrase> queryPhrases = new List<QueryPhrase>();
            LogicalQueryPhrase namePhrase = new LogicalQueryPhrase("name");
            namePhrase.AddExpression(name1, ComparisonOperator.Equal);
            namePhrase.AddExpression(name2, ComparisonOperator.Equal);


            queryPhrases.Add(namePhrase);

            EntityListResult<Milestone> result = entityService.Get<Milestone>(context, queryPhrases, fields);
            Assert(result.data.Count == expectedResultCount);
        }

        private static EntityListResult<Milestone> GetMilestonesByRelease(WorkspaceContext context, long releaseId, int expectedResultCount)
        {
            List<String> fields = new List<string>();
            fields.Add(Milestone.NAME_FIELD);
            fields.Add(Milestone.DATE_FIELD);

            List<QueryPhrase> queryPhrases = new List<QueryPhrase>();
            QueryPhrase releaseIdPhrase = new LogicalQueryPhrase("id", releaseId);
            QueryPhrase byReleasePhrase = new CrossQueryPhrase(Milestone.RELEASES_FIELD, releaseIdPhrase);

            queryPhrases.Add(byReleasePhrase);

            EntityListResult<Milestone> result = entityService.Get<Milestone>(context, queryPhrases, fields);
            Assert(result.data.Count == expectedResultCount);
            return result;
        }

        private static void DeleteMilestone(WorkspaceContext context, long id)
        {
            entityService.Delete<Milestone>(context, id);
            try
            {
                GetMilestoneById(context, id);
                Assert(false);
            }
            catch (Exception e)
            {
                Assert(e.Message.Contains("404"));
            }

        }

        #endregion

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


        private static EntityListResult<Sprint> GetSprintsByRelease(WorkspaceContext context, long releaseId, int expectedResultCount)
        {
            List<String> fields = new List<string>();
            fields.Add(Sprint.NAME_FIELD);
            fields.Add(Sprint.START_DATE_FIELD);
            fields.Add(Sprint.END_DATE_FIELD);
            fields.Add(Sprint.RELEASE_FIELD);

            List<QueryPhrase> queryPhrases = new List<QueryPhrase>();
            QueryPhrase releaseIdPhrase = new LogicalQueryPhrase("id", releaseId);
            QueryPhrase byReleasePhrase = new CrossQueryPhrase(Sprint.RELEASE_FIELD, releaseIdPhrase);

            queryPhrases.Add(byReleasePhrase);

            EntityListResult<Sprint> result = entityService.Get<Sprint>(context, queryPhrases, fields);
            Assert(result.data.Count >= expectedResultCount);
            Release release = result.data[0].Release;
            Assert(release.Id == releaseId);
            return result;
        }


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
