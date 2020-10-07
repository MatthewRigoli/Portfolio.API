using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Portfolio.API.Data;
using Portfolio.Shared;

namespace Portfolio.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguageController : ControllerBase
    {
        private readonly IRepository repository;

        public LanguageController(IRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public async Task<IList<Language>> Get()
        {
            var languages = await repository.Languages.ToListAsync();
            return languages;
        }

        [HttpGet("getprojects/{id}")]
        public async Task<IEnumerable<Project>> GetProjectsByLanguageId(int id)
        {
            return await repository.ProjectLanguages.Where(pl => pl.LanguageId == id).Select(p => p.Project).ToListAsync();
        }
    }
}
