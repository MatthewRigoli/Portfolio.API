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
    }

}
