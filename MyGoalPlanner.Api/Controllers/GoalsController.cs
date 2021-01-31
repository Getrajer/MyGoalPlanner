using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyGoalPlanner.Api.Models;
using MyGoalPlanner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyGoalPlanner.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GoalsController : ControllerBase
    {
        private readonly IGoalRepository goalRepository;

        public GoalsController(IGoalRepository goalRepository)
        {
            this.goalRepository = goalRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetGoals()
        {
            try
            {
                return Ok(await goalRepository.GetAllGoals());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error geting data from the database");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Goal>> CreateGoal(Goal goal)
        {
            try
            {
                if(goal == null)
                {
                    return BadRequest();
                }
                else
                {
                    var createdGoal = await goalRepository.AddGoal(goal);

                    return CreatedAtAction(nameof(GetGoal), new { id = createdGoal.GoalId }, createdGoal);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                    "Error with posting data to the database");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Goal>> GetGoal(int id)
        {
            try
            {
                var result = await goalRepository.GetGoal(id);

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

        [HttpPut]
        public async Task<ActionResult<Goal>> UpdateGoal(Goal updatedGoal)
        {
            try
            {
                
                var goalToUpdate = await goalRepository.GetGoal(updatedGoal.GoalId);

                if(goalToUpdate == null)
                {
                    return NotFound($"Goal with Id = {updatedGoal.GoalId} not found");
                }

                return await goalRepository.UpdateGoal(updatedGoal);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                  "Error updating data");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Goal>> DeleteGoal(int id)
        {
            try
            {
                var goalToDelete = await goalRepository.GetGoal(id);

                if(goalToDelete == null)
                {
                    return NotFound($"Goal with Id = {id} not found");
                }

                return await goalRepository.DeleteGoal(id);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                                 "Error deleting data");
            }
        }
        
    }
}
