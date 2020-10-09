using Microsoft.EntityFrameworkCore;
using Portfolio.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.API.Data
{
    public class EfCoreRepository : IRepository
    {
        private readonly ApplicationDbContext context;

        public EfCoreRepository(ApplicationDbContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IQueryable<Project> Projects => context.Projects;

        public IQueryable<Language> Languages => context.Languages;

        public IQueryable<Platform> Platforms => context.Platforms;

        public IQueryable<Technology> Technologies => context.Technologies;

        public IQueryable<ProjectTechnology> ProjectTechnologies => context.ProjectTechnologies;

        public IQueryable<ProjectLanguage> ProjectLanguages => context.ProjectLanguages;

        public IQueryable<ProjectPlatform> ProjectPlatforms => context.ProjectPlatforms;

        public async Task AssignCategoryAsync(AssignRequest assignRequest)
        {
            switch (assignRequest.CategoryType)
            {
                case Project.LanguageCategory:
                    var language = await context.Languages.FirstOrDefaultAsync(l => l.Name == assignRequest.Name);
                    if (language == null)
                    {
                        language = new Language { Name = assignRequest.Name };
                        context.Languages.Add(language);
                        await context.SaveChangesAsync();
                    }
                    var lc = new ProjectLanguage
                    {
                        ProjectId = assignRequest.ProjectId,
                        LanguageId = language.Id
                    };
                    context.ProjectLanguages.Add(lc);
                    await context.SaveChangesAsync();
                    break;

                case Project.TechnologyCategory:
                    var technology = await context.Technologies.FirstOrDefaultAsync(l => l.Name == assignRequest.Name);
                    if (technology == null)
                    {
                        technology = new Technology { Name = assignRequest.Name };
                        context.Technologies.Add(technology);
                        await context.SaveChangesAsync();
                    }
                    var tc = new ProjectTechnology
                    {
                        ProjectId = assignRequest.ProjectId,
                        TechnologyId = technology.Id
                    };
                    context.ProjectTechnologies.Add(tc);
                    await context.SaveChangesAsync();
                    break;

                case Project.PlatformCategory:
                    var platform = await context.Platforms.FirstOrDefaultAsync(l => l.Name == assignRequest.Name);
                    if (platform == null)
                    {
                        platform = new Platform { Name = assignRequest.Name };
                        context.Platforms.Add(platform);
                        await context.SaveChangesAsync();
                    }
                    var pp = new ProjectPlatform
                    {
                        ProjectId = assignRequest.ProjectId,
                        PlatformId = platform.Id
                    };
                    context.ProjectPlatforms.Add(pp);
                    await context.SaveChangesAsync();
                    break;

                default:
                    break;
            }
        }
        public async Task DeleteProjectAsync(Project project)
        {
            context.Projects.Remove(project);
            await context.SaveChangesAsync();
        }

        public async Task EditProjectAsync(Project project)
        {
            context.Projects.Update(project);
            await context.SaveChangesAsync();
        }

        public async Task SaveProjectAsync(Project project)
        {
            if(project.Slug == null)
            {
                project.Slug = project.Title.ToSlug();
                context.Projects.Add(project);
            }
            else
            {
                project.Slug = project.Title.ToSlug();
                context.Projects.Add(project);
            }
            await context.SaveChangesAsync();
        }
    }
}
