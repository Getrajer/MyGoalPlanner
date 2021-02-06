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
    public class MotivatorsController : ControllerBase
    {
        private readonly IMotivatorRepository motivatorRepository;

        public MotivatorsController(IMotivatorRepository motivatorRepository)
        {
            this.motivatorRepository = motivatorRepository;
        }


        [HttpPost]
        public async Task<ActionResult<Motivator>> CreateMotivator(Motivator motivator)
        {
            try
            {
                if(motivator == null)
                {
                    return BadRequest();
                }
                else
                {
                    var createdMotivator = await motivatorRepository.AddMotivator(motivator);

                    return createdMotivator;
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                    "Error with posting data to the database");
            }
        }

        [HttpGet]
        public async Task<ActionResult> GetMotivatorsOfGoal(int goalId)
        {
            try
            {
                return Ok(await motivatorRepository.GetAllMotivatorsOfGoal(goalId));
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPut]
        public async Task<ActionResult<Motivator>> UpdateMotivator(Motivator updateMotivator)
        {
            try
            {
                var motivatorToUpdate = await motivatorRepository.GetMotivator(updateMotivator.MotivatorId);

                if (motivatorToUpdate == null) 
                {
                    return NotFound($"Motivator with Id = {updateMotivator.GoalId} not found");
                }

                return await motivatorRepository.UpdateMotivator(updateMotivator);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                  "Error updating data");
            }
        }
    }
}
