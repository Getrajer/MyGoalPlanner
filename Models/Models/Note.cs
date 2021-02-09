using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Web.Mvc;

namespace MyGoalPlanner.Models.Models
{
    public class Note
    {
        public int NoteId { get; set; }

        public int ActionId { get; set; }

        [AllowHtml]
        public string NoteText { get; set; }

    }
}
