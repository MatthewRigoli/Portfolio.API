using Portfolio.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.API.Data
{
    public interface IRepository
    {
        IQueryable<Project> Projects { get; }
        IQueryable<Language> Languages { get; }
        IQueryable<Platform> Platforms { get; }
        IQueryable<Technology> Technologies { get; }

        IQueryable<ProjectTechnology> ProjectTechnologies { get; }
        IQueryable<ProjectLanguage> ProjectLanguages { get; }
        IQueryable<ProjectPlatform> ProjectPlatforms { get; }

        Task SaveProjectAsync(Project project);
        Task SaveLanguageAsync(Language language);
        Task SavePlatformAsync(Platform platform);
        Task SaveTechnologyAsync(Technology technology);
        Task EditProjectAsync(Project project);
        Task DeleteProjectAsync(Project project);
        Task AssignCategoryAsync(AssignRequest assignRequest);
    }
}
