using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BlazingProjects.Core.Models
{
    public class CardSectionAdd
    {

        [Required, MaxLength(60)]
        public string Title { get; set; }

        public int ProjectId { get; set; }

    }
}
