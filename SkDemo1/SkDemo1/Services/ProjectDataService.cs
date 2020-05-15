using Newtonsoft.Json;
using SkDemo.Models;
using SkDemo1.Helpers;
using SkDemo1.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SkDemo1.Services
{
    public class ProjectDataService : IProjectDataService
    {

        private HttpClient _httpClient;
        private string baseAddress = "https://ee982446.ngrok.io/api/project";

        public ProjectDataService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<List<Project>> GetAllProjects()
        {
            Logger.Log("GetAllProjects", "We're inside the method");

            try
            {
                var response = await _httpClient.GetAsync($"{baseAddress}/all");

                if (response.IsSuccessStatusCode)
                {
                    Logger.Log("GetAllProjects", "Data returned");

                    var json = await response.Content.ReadAsStringAsync();

                    var projectData = JsonConvert.DeserializeObject<List<Project>>(json);
                    return projectData;
                }
                else
                {
                    Logger.Log("error", response.ReasonPhrase);
                    throw new Exception(response.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.Message, ex);
                throw ex;
            }
        }

        public async Task<Project> Add(Project model)
        {
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Post, $"{baseAddress}/new")
                {
                    Content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json")
                };

                var response = await _httpClient.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var project = JsonConvert.DeserializeObject<Project>(json);
                    return project;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


    }
}
