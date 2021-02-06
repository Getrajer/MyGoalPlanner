using Microsoft.AspNetCore.Components;
using MyGoalPlanner.Models;
using MyGoalPlanner.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MyGoalPlanner.Web.Services
{
    public class ServiceStep : IStepService
    {
        private readonly HttpClient httpClient;

        public ServiceStep(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<Step> CreateStep(Step newStep)
        {
            return await httpClient.PostJsonAsync<Step>("api/Steps", newStep);
        }

        public async Task<Step> UpdateStep(Step step)
        {
            return await httpClient.PutJsonAsync<Step>($"api/Steps", step);
        }

        public async Task<IEnumerable<Step>> GetStepsOfGoalId(int id)
        {
            return await httpClient.GetJsonAsync<Step[]>($"api/Steps/GetOfGoalId/{id}");
        }

        public async Task<Step> GetStep(int id)
        {
            return await httpClient.GetJsonAsync<Step>($"api/Steps/{id}");
        }

        public async Task DeleteStep(int stepId, int goalId)
        {
            await httpClient.DeleteAsync($"api/Steps/{goalId}/{stepId}");
        }
    }
}
