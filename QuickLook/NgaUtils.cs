using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hpe.Nga.Api.Core.Entities;
using Hpe.Nga.Api.Core.Services;
using Hpe.Nga.Api.Core.Services.Query;
using Hpe.Nga.Api.Core.Services.RequestContext;

namespace QuickLook
{
  public static class NgaUtils
  {
    private static EntityService entityService = EntityService.GetInstance();
    private static WorkspaceContext workspaceContext;

    public static void init(long sharedSpaceId) 
    {
      workspaceContext = GetWorkspaceContext(sharedSpaceId);
    }

    private static WorkspaceContext GetWorkspaceContext(long sharedSpaceId)
    {
      SharedSpaceContext sharedSpaceContext = new SharedSpaceContext(sharedSpaceId);
      //EntityListResult<Workspace> workspaces = entityService.Get<Workspace>(sharedSpaceContext);
      //Workspace workspace = workspaces.data[0];
      long workspaceId = 2029;//workspaces.data[0].Id hardcoded workaround
      return new WorkspaceContext(sharedSpaceId, workspaceId);
    }

    public static Release GetReleaseById(long id)
    {
      List<String> fields = new List<string>();
      fields.Add(Release.NAME_FIELD);
      fields.Add(Release.START_DATE_FIELD);
      fields.Add(Release.END_DATE_FIELD);
      Release release = entityService.GetById<Release>(workspaceContext, id, fields);
      
      Debug.Assert(release.Id == id);
      return release;
    }

    public static EntityListResult<Sprint> GetSprintsByRelease(long releaseId)
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

      EntityListResult<Sprint> result = entityService.Get<Sprint>(workspaceContext, queryPhrases, fields);
      Release release = result.data[0].Release;
      Debug.Assert(release.Id == releaseId);
      return result;
    }

    public static EntityListResult<Milestone> GetMilestonesByRelease(long releaseId)
    {
        List<String> fields = new List<string>();
        fields.Add(Milestone.NAME_FIELD);
        fields.Add(Milestone.DATE_FIELD);
        fields.Add(Milestone.RELEASES_FIELD);
        fields.Add(Milestone.DESCRIPTION_FIELD);

        List<QueryPhrase> queryPhrases = new List<QueryPhrase>();
        QueryPhrase releaseIdPhrase = new LogicalQueryPhrase("id", releaseId);
        QueryPhrase byReleasePhrase = new CrossQueryPhrase(Milestone.RELEASES_FIELD, releaseIdPhrase);

        queryPhrases.Add(byReleasePhrase);

        EntityListResult<Milestone> result = entityService.Get<Milestone>(workspaceContext, queryPhrases, fields);
        return result;
    }

  }
}
