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
    public class StepsController : ControllerBase
    {
        private readonly IStepRepostitory stepRepostitory;

        public StepsController(IStepRepostitory stepRepostitory)
        {
            this.stepRepostitory = stepRepostitory;
        }

        [HttpGet]
        public async Task<ActionResult> GetSteps()
        {
            try
            {
                return Ok(await stepRepostitory.GetAllSteps());
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error geting data from the database");
            }
        } 

        [HttpPost]
        public async Task<ActionResult<Step>> CreateStep(Step step)
        {
            try
            {
                if (step == null)
                {
                    return BadRequest();
                }
                else
                {
                    var createdStep = await stepRepostitory.AddStep(step);
                    return CreatedAtAction(nameof(GetStep), new { id = createdStep.StepId }, createdStep);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                    "Error with posting data to the database");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Step>> GetStep(int id)
        {
            try
            {
                var result = await stepRepostitory.GetStep(id);

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

    }
}
