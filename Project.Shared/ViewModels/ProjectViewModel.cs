using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Portfolio.Shared.ViewModels
{
    public class ProjectViewModel
    {
        public ProjectViewModel()
        {
            Languages = new List<LanguageViewModel>();
        }

        public ProjectViewModel(Project project)
        {
            Id = project.Id;
            Title = project.Title;
            Requirements = project.Requirements;
            Languages = new List<LanguageViewModel>(project.ProjectLanguages.Select(projectlanguage => new LanguageViewModel(projectlanguage.Language)));
            Slug = project.Slug;
            Design = project.Design;
            TimeStamp = project.TimeStamp;
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Requirements { get; set; }
        public string Design { get; set; }
        public string TimeStamp { get; set; }
        public IList<LanguageViewModel> Languages { get; set; }
        public string Slug { get; set; }
    }
}
