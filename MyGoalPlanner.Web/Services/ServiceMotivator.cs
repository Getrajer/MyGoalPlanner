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
            return await httpClient.PostJsonAsync<Motivator>("api/Motivator", newMotivator);
        }

        public Task<Motivator> EditMotivator(Motivator editedMotivator)
        {
            throw new NotImplementedException();
        }

        public Task<Motivator> GetMotivatorsOfGoal(int goalId)
        {
            throw new NotImplementedException();
        }
    }
}
