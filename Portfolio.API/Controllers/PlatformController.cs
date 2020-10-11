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
    public class PlatformController : ControllerBase
    {
        private readonly IRepository repository;

        public PlatformController(IRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public async Task<IList<Platform>> Get()
        {
            var platforms = await repository.Platforms.ToListAsync();
            return platforms;
        }

        [HttpGet("{slug}")]
        public async Task<PlatformViewModel> GetPlatform(string slug)
        {
            try
            {
                var platform = await repository.Platforms
                   .Include(p => p.ProjectPlatforms)
                       .ThenInclude(pc => pc.Project)
                    .FirstOrDefaultAsync(p => p.Slug == slug);
                return new PlatformViewModel(platform);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("getprojects/{id}")]
        public async Task<IEnumerable<Project>> GetProjectsByPlatformId(int id)
        {
            return await repository.ProjectPlatforms.Where(pl => pl.PlatformId == id).Select(p => p.Project).ToListAsync();
        }
    }

}
