using System.Collections.Generic;
using System.Linq;
using RBToolsContextMenu.Application.Communication.DTO;
using RBToolsContextMenu.Domain.Commands;
using RBToolsContextMenu.Domain.Options;
using RBToolsContextMenu.Domain.Options.Post;
using RBToolsContextMenu.Domain.Options.Post.DiffGeneration;
using RBToolsContextMenu.Domain.Options.Post.Fields;
using RBToolsContextMenu.Domain.Options.Post.Posting;
using RBToolsContextMenu.Domain.Options.Post.Server;
using RBToolsContextMenu.Domain.Options.Post.Subversion;

namespace RBToolsContextMenu.Application.Communication.Mapping
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
            if (dto.SvnShowCopiesAsAdds)
                options.Add(new SvnShowCopiesAsAdds(ShowCopiesAsAddsOption.Yes));
            if (dto.IncludePaths != null && dto.IncludePaths.Any())
                options.AddRange(dto.IncludePaths.Select(p => new Include(p)));
                
            return new PostCommand(options);
        }
    }
}