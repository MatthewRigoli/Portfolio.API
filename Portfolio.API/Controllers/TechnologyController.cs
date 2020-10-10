using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Portfolio.API.Data;
using Portfolio.Shared;
using Portfolio.Shared.ViewModels;

namespace Portfolio.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TechnologyController : ControllerBase
    {
        private readonly IRepository repository;

        public TechnologyController(IRepository repository)
        {
            this.repository = repository;
        }
        [HttpGet]
        public async Task<IList<Technology>> Get()
        {
            var technologies = await repository.Technologies.ToListAsync();
            return technologies;
        }

        [HttpGet("{slug}")]
        public async Task<TechnologyViewModel> GetTechnology(string slug)
        {
            try
            {
                var technology = await repository.Technologies
                   .Include(p => p.ProjectTechnologies)
                       .ThenInclude(pc => pc.Project)
                    .FirstOrDefaultAsync(p => p.Slug == slug);
                return new TechnologyViewModel(technology);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpGet("getprojects/{id}")]
        public async Task<IEnumerable<Project>> GetProjectsByTechnologyId(int id)
        {
            return await repository.ProjectTechnologies.Where(pl => pl.TechnologyId == id).Select(p => p.Project).ToListAsync();
        }
    }
}
