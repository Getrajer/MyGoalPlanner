using Microsoft.AspNetCore.Components;
using MyGoalPlanner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MyGoalPlanner.Web.Services
{
    public class ServiceGoal : IGoalService
    {
        private readonly HttpClient httpClient;

        public ServiceGoal(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<Goal> CreateGoal(Goal newGoal)
        {
            return await httpClient.PostJsonAsync<Goal>("api/Goals", newGoal);
        }

        public async Task DeleteGoal(int goalId)
        {
            await httpClient.DeleteAsync($"api/Goals/{goalId}");
        }

        public async Task<Goal> GetGoal(int goalId)
        {
            return await httpClient.GetJsonAsync<Goal>($"api/Goals/{goalId}");
        }

        public async Task<IEnumerable<Goal>> GetGoals()
        {
            return await httpClient.GetJsonAsync<Goal[]>("api/Goals");
        }

        public async Task<Goal> UpdateGoal(Goal updatedGoal)
        {
            return await httpClient.PutJsonAsync<Goal>($"api/Goals", updatedGoal);
        }
    }
}
