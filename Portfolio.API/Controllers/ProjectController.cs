﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Portfolio.API.Data;
using Portfolio.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IRepository repository;

        public ProjectController(IRepository repository)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet()]
        public async Task<IEnumerable<Project>> Get() => await repository.Projects.ToListAsync();

        [HttpGet("[action]")]
        public async Task DefaultData()
        {
            await repository.SaveProjectAsync(new Project
            {
                Title = "Project 1",
                Requirements = "Demonstrate APIs with a database",
                Design = "Work with Blazor, C#, and Postgres to implement the requirements.",
                TimeStamp = "Completed 9/22/2020"
            });
        }

        [HttpPost]
        public async Task Post([FromBody] Project project)
        {
            await repository.SaveProjectAsync(project);
        }

        [HttpPost("[action]")]
        public async Task Edit(Project project)
        {
            await repository.EditProjectAsync(project);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            var projectToDelete = repository.Projects.Where(project => project.Id == id).FirstOrDefault();
            await repository.DeleteProjectAsync(projectToDelete);
        }
    }
}
