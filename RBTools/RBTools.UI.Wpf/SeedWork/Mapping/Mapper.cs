using System;
using System.Linq;
using RBTools.Application.Communication.DTO;
using RBTools.UI.Wpf.ViewModels;

namespace RBTools.UI.Wpf.SeedWork.Mapping
{
    public static class Mapper
    {
        public static RbtPostDto CreateDto(SendViewModel vm)
        {
            var dto = new RbtPostDto()
            {
                OpenBrowser = vm.Settings.OpenInBrowser,
                Publish = vm.Settings.Publish,
                SvnShowCopiesAsAdds = vm.Settings.SvnShowCopiesAsAdds,
                TargetGroups = vm.Settings.Groups.Where(g => g.IsSelected).Select(g => g.Value),
                TargetPeople = vm.Settings.People.Where(p => p.IsSelected).Select(p => p.Value),
                IncludePaths = Environment.GetCommandLineArgs().Skip(1),
            };

            if (!string.IsNullOrWhiteSpace(vm.Description))
                dto.Description = vm.Description;
            if (!string.IsNullOrWhiteSpace(vm.Summary))
                dto.Summary = vm.Summary;
            if (!string.IsNullOrWhiteSpace(vm.TestingDone))
                dto.TestingDone = vm.TestingDone;
            if (!string.IsNullOrWhiteSpace(vm.Settings.RepositoryName))
                dto.Repository = vm.Settings.RepositoryName;
            if (!string.IsNullOrWhiteSpace(vm.Settings.RepositoryUrl))
                dto.Server = vm.Settings.RepositoryUrl;
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
