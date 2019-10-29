using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BlazingProjects.Core.Entities
{
    public class Card
    {

        public int Id { get; set; }

        [Required, MaxLength(60)]
        public string Title { get; set; }

        [MaxLength(300)]
        public string Description { get; set; }

        [Required]
        public int Order { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }

        public DateTime? UpdatedOn { get; set; }

        public CardSection CardSection { get; set; }

    }
}
