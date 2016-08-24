using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hpe.Nga.Api.Core.Entities;
using Hpe.Nga.Api.Core.Services;
using Hpe.Nga.Api.Core.Services.GroupBy;
using Hpe.Nga.Api.Core.Services.Query;
using Hpe.Nga.Api.Core.Services.RequestContext;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Hpe.Nga.Api.Core.Tests
{
    [TestClass]
    public class DefectTests : BaseTest
    {
        private static Phase PHASE_NEW;
        private static ListNode SEVERITY_HIGH;
        private static WorkItemRoot WORK_ITEM_ROOT;

        [ClassInitialize()]
        public static void ClassInit(TestContext context)
        {
            PHASE_NEW = GetPhaseByName("defect", "New");
            SEVERITY_HIGH = getSeverityByName("High");
            WORK_ITEM_ROOT = getWorkItemRoot();
        }

        [TestMethod]
        public void GetDefectFieldMetadataTest()
        {
            List<QueryPhrase> queryPhrases = new List<QueryPhrase>();

            LogicalQueryPhrase byEntityNamePhrase = new LogicalQueryPhrase(FieldMetadata.ENTITY_NAME_FIELD, "defect");
            queryPhrases.Add(byEntityNamePhrase);

            EntityListResult<FieldMetadata> result = entityService.Get<FieldMetadata>(workspaceContext, queryPhrases, null);
            Assert.IsTrue(result.total_count >= 50);
        }

        [TestMethod]
        public void GetPhasesForDefectTest()
        {
            List<QueryPhrase> queryPhrases = new List<QueryPhrase>();
            LogicalQueryPhrase byEntityPhrase = new LogicalQueryPhrase(Phase.ENTITY_FIELD, "defect");
            queryPhrases.Add(byEntityPhrase);
            EntityListResult<Phase> result = entityService.Get<Phase>(workspaceContext, queryPhrases, null);
            Assert.IsTrue(result.total_count >= 8);
        }

        [TestMethod]
        public void GetSeverityListForDefectsTest()
        {
            List<QueryPhrase> queryPhrases = new List<QueryPhrase>();
            LogicalQueryPhrase byLogicalName = new LogicalQueryPhrase(ListNode.LOGICAL_NAME_FIELD, "list_node.severity.*");
            queryPhrases.Add(byLogicalName);

            EntityListResult<ListNode> result = entityService.Get<ListNode>(workspaceContext, queryPhrases, null);
            Assert.IsTrue(result.total_count >= 5);
        }

        [TestMethod]
        public void CreateDefectTest()
        {
            Defect defect = CreateDefect();
        }

        [TestMethod]
        public void CreateDefectAsWorkItemTest()
        {
            String name = "Defect" + Guid.NewGuid();
            WorkItem defect = new WorkItem();
            defect.Name = name;
            defect.Phase = PHASE_NEW;
            defect.Severity = SEVERITY_HIGH;
            defect.Parent = WORK_ITEM_ROOT;
            defect.SubType = WorkItem.SUBTYPE_DEFECT;

            WorkItem created = entityService.Create<WorkItem>(workspaceContext, defect);
            Assert.AreEqual<String>(name, created.Name);
        }

        [TestMethod]
        public void UpdateDefectNameTest()
        {
            Defect defect = CreateDefect();
            Defect defectForUpdate = new Defect(defect.Id);
            String newName = defect.Name + "_updated";
            defectForUpdate.Name = newName;
            entityService.Update<Defect>(workspaceContext, defectForUpdate);

            Defect defectAfterUpdate = entityService.GetById<Defect>(workspaceContext, defect.Id, null);
            Assert.AreEqual(newName, defectAfterUpdate.Name);
        }

        [TestMethod]
        public void GetAllNotCompletedDefectsAssinedToReleaseWithGroupByTest()
        {
            Defect defect = CreateDefect();
            Release release = CreateRelease();

            //set release to defect
            Defect defectForUpdate = new Defect(defect.Id);
            defectForUpdate.Release = release;
            entityService.Update<Defect>(workspaceContext, defectForUpdate);
            Defect defectAfterUpdate = entityService.GetById<Defect>(workspaceContext, defect.Id, null);
            Assert.AreEqual<long>(release.Id, defectAfterUpdate.Release.Id);

            //Fetch all defects that assigned to release and still not done
            List<QueryPhrase> queries = new List<QueryPhrase>();
            LogicalQueryPhrase subtypeQuery = new LogicalQueryPhrase(WorkItem.SUBTYPE_FIELD, WorkItem.SUBTYPE_DEFECT);
            queries.Add(subtypeQuery);

            QueryPhrase releaseIdPhrase = new LogicalQueryPhrase(WorkItem.ID_FIELD, release.Id);
            QueryPhrase byReleasePhrase = new CrossQueryPhrase(WorkItem.RELEASE_FIELD, releaseIdPhrase);
            queries.Add(byReleasePhrase);

            LogicalQueryPhrase phaseNamePhrase = new LogicalQueryPhrase(WorkItem.NAME_FIELD, "Done");
            phaseNamePhrase.NegativeCondition = true;
            CrossQueryPhrase phaseIdPhrase = new CrossQueryPhrase("metaphase", phaseNamePhrase);
            CrossQueryPhrase byPhasePhrase = new CrossQueryPhrase(WorkItem.PHASE_FIELD, phaseIdPhrase);
            queries.Add(byPhasePhrase);

            EntityListResult<WorkItem> entitiesResult = entityService.Get<WorkItem>(workspaceContext, queries, null);
            Assert.AreEqual<int>(1, entitiesResult.total_count.Value);
            Assert.AreEqual<long>(defect.Id, entitiesResult.data[0].Id);
            

            GroupResult groupedResult = entityService.GetWithGroupBy<WorkItem>(workspaceContext, queries, WorkItem.SEVERITY_FIELD);
            Assert.AreEqual<int>(1, groupedResult.groupsTotalCount);
        }


        private static Defect CreateDefect()
        {
            String name = "Defect" + Guid.NewGuid();
            Defect defect = PrepareDefectForCreate(name);
            Defect created = entityService.Create<Defect>(workspaceContext, defect);
            Assert.AreEqual<String>(name, created.Name);
            Assert.IsTrue(created.Id > 0);
            return created;
        }

        private static Defect PrepareDefectForCreate(String name)
        {
            Defect defect = new Defect();
            defect.Name = name;
            defect.Phase = PHASE_NEW;
            defect.Severity = SEVERITY_HIGH;
            defect.Parent = WORK_ITEM_ROOT;
            return defect;
        }

        private static Phase GetPhaseByName(String entityTypeName, String name)
        {
            List<QueryPhrase> queryPhrases = new List<QueryPhrase>();
            LogicalQueryPhrase byEntityPhrase = new LogicalQueryPhrase(Phase.ENTITY_FIELD, entityTypeName);
            LogicalQueryPhrase byNamePhrase = new LogicalQueryPhrase(Phase.NAME_FIELD, name);
            queryPhrases.Add(byEntityPhrase);
            queryPhrases.Add(byNamePhrase);

            List<String> fields = new List<String>() { Phase.NAME_FIELD, Phase.LOGICAL_NAME_FIELD };
            EntityListResult<Phase> result = entityService.Get<Phase>(workspaceContext, queryPhrases, fields);
            Assert.AreEqual(1, result.total_count);
            Phase phase = result.data[0];
            return phase;
        }

        private static ListNode getSeverityByName(String name)
        {
            List<QueryPhrase> queryPhrases = new List<QueryPhrase>();
            LogicalQueryPhrase byLogicalName = new LogicalQueryPhrase(ListNode.LOGICAL_NAME_FIELD, "list_node.severity.*");
            queryPhrases.Add(byLogicalName);

            LogicalQueryPhrase byName = new LogicalQueryPhrase(ListNode.NAME_FIELD, name);
            queryPhrases.Add(byName);

            List<String> fields = new List<String>() { Phase.NAME_FIELD, Phase.LOGICAL_NAME_FIELD };

            EntityListResult<ListNode> result = entityService.Get<ListNode>(workspaceContext, queryPhrases, fields);
            Assert.AreEqual(1, result.total_count);
            ListNode listNode = result.data[0];
            return listNode;
        }

        private static WorkItemRoot getWorkItemRoot()
        {
            List<String> fields = new List<String>() { Phase.NAME_FIELD };
            EntityListResult<WorkItemRoot> result = entityService.Get<WorkItemRoot>(workspaceContext, null, fields);
            Assert.AreEqual(1, result.total_count);
            WorkItemRoot root = result.data[0];
            return root;
        }

        private static Release CreateRelease()
        {
            String name = "Release_" + Guid.NewGuid();
            Release release = new Release();
            release.Name = name;
            release.StartDate = DateTime.Now;
            release.EndDate = DateTime.Now.AddDays(10);
            release.SprintDuration = 7;


            Release created = entityService.Create<Release>(workspaceContext, release);
            Assert.AreEqual<String>(name, created.Name);
            return created;
        }

    }

}
