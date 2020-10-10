using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Portfolio.Shared.ViewModels
{
    public class LanguageViewModel
    {
        public LanguageViewModel() { }
        public LanguageViewModel(Language language)
        {
            Id = language.Id;
            Name = language.Name;
            Slug = language.Slug;
            Projects = new List<string>(language.ProjectLanguages.Select(projectlanguage => projectlanguage.Project.Title));
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public IList<string> Projects { get; set; }
    }
}
