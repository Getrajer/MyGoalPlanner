using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyGoalPlanner.Api.Models;
using MyGoalPlanner.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyGoalPlanner.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivityController : ControllerBase
    {
        private IActivityRepository activityRepository;

        public ActivityController(IActivityRepository activityRepository)
        {
            this.activityRepository = activityRepository;
        }

        [HttpPost]
        public async Task<ActionResult<Activity>> CreateActivity(Activity newActivity)
        {
            try
            {
                if (newActivity == null)
                {
                    return BadRequest();
                }
                else
                {
                    var createdActivity = await activityRepository.AddActivity(newActivity);

                    return createdActivity;
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                                    "Error with posting data to the database");
            }
        }

        [HttpGet("{activityId}")]
        public async Task<ActionResult<Activity>> GetActivity(int activityId)
        {
            try
            {
                var result = await activityRepository.GetActivity(activityId);

                if(result == null)
                {
                    return NotFound();
                }

                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error geting data from the database");
            }
        }

        [HttpDelete("{activityId}")]
        public async Task<ActionResult<Activity>> DeleteActivity(int activityId)
        {
            try
            {
                var activityToDelete = await activityRepository.GetActivity(activityId);

                if(activityToDelete == null)
                {
                    return NotFound($"Activity with Id = {activityId} not found");
                }

                return await activityRepository.DeleteActivity(activityId);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                                 "Error deleting data");
            }
        }

        [HttpGet("GetOfGoalId/{goalId}")]
        public async Task<ActionResult<List<Activity>>> GetActivitiesOfGoalId(int goalId)
        {
            try
            {
                return Ok(await activityRepository.GetActivitiesByGoalId(goalId));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error geting data from the database");
            }
        }

    }
}
