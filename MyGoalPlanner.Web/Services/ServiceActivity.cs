using Microsoft.AspNetCore.Components;
using MyGoalPlanner.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MyGoalPlanner.Web.Services
{
    public class ServiceActivity : IActivityService
    {
        private readonly HttpClient httpClient;

        public ServiceActivity(HttpClient httpClient)
        {
            this.httpClient = httpClient;
    }

        public async Task<Activity> CreateActivity(Activity newActivity)
        {
            return await httpClient.PostJsonAsync<Activity>("api/Activity", newActivity);
        }

        public async Task DeleteActivity(int activityId)
        {
            await httpClient.DeleteAsync($"api/Activity/{activityId}");
        }

        public async Task<IEnumerable<Activity>> GetActivitiesOfGoalId(int goalId)
        {
            return await httpClient.GetJsonAsync<Activity[]>($"api/Activity/GetOfGoalId/{goalId}");
        }

        public async Task<Activity> GetActivity(int activityId)
        {
            return await httpClient.GetJsonAsync<Activity>($"api/Activity/{activityId}");
        }
    }
}
