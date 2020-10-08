using Portfolio.Blazor.Pages;
using Portfolio.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Portfolio.Blazor.DataProvider
{
    public class ApiService
    {
        private readonly HttpClient client;

        public ApiService(HttpClient client)
        {
            this.client = client;
        }

        public async Task<IEnumerable<Project>> GetProjectAsync()
        {
            var projects = await client.GetFromJsonAsync<IEnumerable<Project>>("api/project");
            return projects;
        }

        public async Task Post(Project project)
        {
            await client.PostAsJsonAsync("api/project", project);
        }

        public async Task Edit(Project project)
        {
            Console.WriteLine("Buy more Coke");
            await client.PostAsJsonAsync("api/project/edit", project);
        }

        public async Task Delete(int id)
        {

            await client.DeleteAsync($"api/project/{id}");
        }

        public async Task<Project> GetProjectById(int id)
        {
            var projects = await client.GetFromJsonAsync<IEnumerable<Project>>("api/project");
            var project = projects.Where(proj => proj.Id == id).First();
            return project;
        }

        public async Task AssignTag(string categoryType, int projectId, string newName)
        {
            var assignBody = new AssignRequest
            {
                CategoryType = categoryType,
                Name = newName,
                ProjectId = projectId
            };
            await client.PostAsJsonAsync("api/project/assign/", assignBody);
        }

        public async Task<IEnumerable<Language>> GetLanguagesAsync()
        {
            var languages = await client.GetFromJsonAsync<IEnumerable<Language>>("api/language");
            return languages;
        }
        public async Task<Language> GetLanguageById(int id)
        {
            var languages = await client.GetFromJsonAsync<IEnumerable<Language>>("api/language");
            var language = languages.Where(lang => lang.Id == id).First();
            return language;
        }
        public async Task<IEnumerable<Project>> GetProjectsByLanguageId(int id)
        {
            var projects = await client.GetFromJsonAsync<IEnumerable<Project>>("api/language/getprojects/"+id);
            return projects;
        }
        public async Task<IEnumerable<Technology>> GetTechnologiesAsync()
        {
            var technologies = await client.GetFromJsonAsync<IEnumerable<Technology>>("api/technology");
            return technologies;
        }


        public async Task<IEnumerable<Platform>> GetPlatformsAsync()
        {
            var platforms = await client.GetFromJsonAsync<IEnumerable<Platform>>("api/platform");
            return platforms;
        }
    }
}
