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
    public class NotesController : ControllerBase
    {
        private readonly IActivityRepository activityRepository;
        private readonly INoteRepository noteRepository;

        public NotesController(IActivityRepository activityRepository ,INoteRepository noteRepository)
        {
            this.activityRepository = activityRepository;
            this.noteRepository = noteRepository;
        }


    }
}
