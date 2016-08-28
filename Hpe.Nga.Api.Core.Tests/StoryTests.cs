using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hpe.Nga.Api.Core.Entities;
using Hpe.Nga.Api.Core.Services;
using Hpe.Nga.Api.Core.Services.Query;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Hpe.Nga.Api.Core.Tests
{
    [TestClass]
    public class StoryTests: BaseTest
    {
        private static Phase PHASE_NEW;
        private static WorkItemRoot WORK_ITEM_ROOT;

        [ClassInitialize()]
        public static void ClassInit(TestContext context)
        {
            PHASE_NEW = GetPhaseByName("story", "New");
            WORK_ITEM_ROOT = getWorkItemRoot();
        }

        [TestMethod]
        public void GetStoryFieldMetadataTest()
        {
            List<QueryPhrase> queryPhrases = new List<QueryPhrase>();

            LogicalQueryPhrase byEntityNamePhrase = new LogicalQueryPhrase(FieldMetadata.ENTITY_NAME_FIELD, "story");
            queryPhrases.Add(byEntityNamePhrase);

            EntityListResult<FieldMetadata> result = entityService.Get<FieldMetadata>(workspaceContext, queryPhrases, null);
            Assert.IsTrue(result.total_count >= 40);
        }

        [TestMethod]
        public void CreateStoryTest()
        {
            CreateStory();
        }



        [TestMethod]
        public void GetAllStories()
        {
            CreateStory();

            //get as stories
            EntityListResult<Story> stories = entityService.Get<Story>(workspaceContext, null, null);
            Assert.IsTrue(stories.total_count > 0);


            //get as work-items
            List<QueryPhrase> queries = new List<QueryPhrase>();
            LogicalQueryPhrase byStorySubType = new LogicalQueryPhrase(WorkItem.SUBTYPE_FIELD, WorkItem.SUBTYPE_US);
            queries.Add(byStorySubType);
  
            EntityListResult<WorkItem> storiesAsWorkItems = entityService.Get<WorkItem>(workspaceContext, queries, null);
            Assert.AreEqual<int?>(stories.total_count, storiesAsWorkItems.total_count);

        }

        private static Story CreateStory()
        {
            String name = "Story" + Guid.NewGuid();
            Story story = new Story();
            story.Name = name;
            story.Phase = PHASE_NEW;

            story.Parent = WORK_ITEM_ROOT;
            Story created = entityService.Create<Story>(workspaceContext, story);
            Assert.AreEqual<String>(name, created.Name);
            Assert.IsTrue(created.Id > 0);
            return created;
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

       
        private static WorkItemRoot getWorkItemRoot()
        {
            List<String> fields = new List<String>() { Phase.NAME_FIELD };
            EntityListResult<WorkItemRoot> result = entityService.Get<WorkItemRoot>(workspaceContext, null, fields);
            Assert.AreEqual(1, result.total_count);
            WorkItemRoot root = result.data[0];
            return root;
        }

    }
}
