using Microsoft.AspNetCore.Components;
using MyGoalPlanner.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MyGoalPlanner.Web.Services
{
    public class ServiceMotivator : IMotivatorService
    {
        private readonly HttpClient httpClient;

        public ServiceMotivator(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<Motivator> CreateMotivator(Motivator newMotivator)
        {
            return await httpClient.PostJsonAsync<Motivator>("api/Motivators", newMotivator);
        }

        public async Task DeleteMotivator(int motivatorId)
        {
            await httpClient.DeleteAsync($"api/Motivators/{motivatorId}");
        }

        public async Task<Motivator> EditMotivator(Motivator editedMotivator)
        {
            return await httpClient.PutJsonAsync<Motivator>($"api/Motivators", editedMotivator);
        }

        public async Task<IEnumerable<Motivator>> GetMotivatorsOfGoal(int goalId)
        {
            return await httpClient.GetJsonAsync<Motivator[]>($"api/Motivators/GetOfGoalId/{goalId}");
        }
    }
}
