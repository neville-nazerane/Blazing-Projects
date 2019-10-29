using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BlazingProjects.Core.Models
{
    public class ProjectUpdate
    {

        public int Id { get; set; }

        [Required, MaxLength(60)]
        public string Title { get; set; }

    }
}
