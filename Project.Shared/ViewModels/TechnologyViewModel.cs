using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Portfolio.Shared.ViewModels
{
    public class TechnologyViewModel
    {
        public TechnologyViewModel() { }
        public TechnologyViewModel(Technology technology)
        {
            Id = technology.Id;
            Name = technology.Name;
            Slug = technology.Slug;
            Projects = new List<string>(technology.ProjectTechnologies.Select(projectlanguage => projectlanguage.Project.Title));
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public IList<string> Projects { get; set; }
    }
}
