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
    }
}
