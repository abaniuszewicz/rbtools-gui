using System;
using System.Linq;
using RBTools.Application.Communication.DTO;
using RBTools.Application.Communication.Mapping;

namespace RBTools.UI.Wpf.ViewModels.Mapping
{
    public class SendViewModelToDtoMapper : IMapper<SendViewModel, RbtPostDto>
    {
        public RbtPostDto Map(SendViewModel vm)
        {
            var dto = new RbtPostDto()
            {
                OpenBrowser = vm.Configuration.OpenInBrowser,
                Publish = vm.Configuration.Publish,
                SvnShowCopiesAsAdds = vm.Configuration.SvnShowCopiesAsAdds,
                Markdown = vm.Configuration.Markdown,
                TargetGroups = vm.Configuration.SelectableGroups.Where(g => g.IsSelected).Select(g => g.Value),
                TargetPeople = vm.Configuration.SelectablePeople.Where(p => p.IsSelected).Select(p => p.Value),
                IncludePaths = Environment.GetCommandLineArgs().Skip(1),
            };

            if (!string.IsNullOrWhiteSpace(vm.Description))
                dto.Description = vm.Description;
            if (!string.IsNullOrWhiteSpace(vm.Summary))
                dto.Summary = vm.Summary;
            if (!string.IsNullOrWhiteSpace(vm.TestingDone))
                dto.TestingDone = vm.TestingDone;
            if (!string.IsNullOrWhiteSpace(vm.Configuration.RepositoryName))
                dto.Repository = vm.Configuration.RepositoryName;
            if (!string.IsNullOrWhiteSpace(vm.Configuration.RepositoryUrl))
                dto.Server = vm.Configuration.RepositoryUrl;
            if (!string.IsNullOrWhiteSpace(vm.BugIds))
                dto.BugIds = vm.BugIds.Split(',', StringSplitOptions.RemoveEmptyEntries);

            if (vm.ReviewType.IsUpdate)
            {
                dto.Update = true;
                if (!string.IsNullOrWhiteSpace(vm.UpdateDescription))
                    dto.UpdateDescription = vm.UpdateDescription;
                if (!string.IsNullOrWhiteSpace(vm.ReviewId) && int.TryParse(vm.ReviewId, out var reviewId))
                    dto.ReviewRequestId = reviewId;
            }

            if (vm.ReviewType.IsPostCommit)
            {
                dto.IncludePaths = Enumerable.Empty<string>();
                dto.Revision = vm.Revision;
            }

            return dto;
        }
    }
}
