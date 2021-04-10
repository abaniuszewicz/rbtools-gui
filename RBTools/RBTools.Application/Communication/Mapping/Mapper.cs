using System.Collections.Generic;
using System.Linq;
using RBTools.Application.Communication.DTO;
using RBTools.Domain.Commands;
using RBTools.Domain.Options;
using RBTools.Domain.Options.Post.DiffGeneration;
using RBTools.Domain.Options.Post.Fields;
using RBTools.Domain.Options.Post.Posting;
using RBTools.Domain.Options.Post.Repository;
using RBTools.Domain.Options.Post.Server;
using RBTools.Domain.Options.Post.Subversion;

namespace RBTools.Application.Communication.Mapping
{
    internal static class Mapper
    {
        public static IRbtCommand AsPostCommand(this RbtPostDto dto)
        {
            var options = new List<IRbtOption>();
            
            if (dto.Server != default)
                options.Add(new Server(dto.Server));
            if (dto.Repository != default)
                options.Add(new Repository(dto.Repository));
            if (dto.UpdateDescription != default)
                options.Add(new ChangeDescription(dto.UpdateDescription));
            if (dto.Description != default)
                options.Add(new Description(dto.Description));
            if (dto.Summary != default)
                options.Add(new Summary(dto.Summary));
            if (dto.BugIds != null && dto.BugIds.Any())
                options.Add(new BugsClosed(dto.BugIds));
            if (dto.TargetGroups != null && dto.TargetGroups.Any())
                options.Add(new TargetGroups(dto.TargetGroups));
            if (dto.TargetPeople != null && dto.TargetPeople.Any())
                options.Add(new TargetPeople(dto.TargetPeople));
            if (dto.TestingDone != default)
                options.Add(new TestingDone(dto.TestingDone));
            if (dto.OpenBrowser)
                options.Add(new Open());
            if (dto.Publish)
                options.Add(new Publish());
            if (dto.Update)
                options.Add(new Update());
            if (dto.Update && dto.ReviewRequestId.HasValue)
                options.Add(new ReviewRequestId(dto.ReviewRequestId.Value));
            if (dto.SvnShowCopiesAsAdds)
                options.Add(new SvnShowCopiesAsAdds(ShowCopiesAsAddsOption.Yes));
            if (dto.IncludePaths != null && dto.IncludePaths.Any())
                options.AddRange(dto.IncludePaths.Select(p => new Include(p)));
                
            return new PostCommand(options);
        }
    }
}