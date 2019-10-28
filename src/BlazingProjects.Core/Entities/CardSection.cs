using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BlazingProjects.Core.Entities
{
    public class CardSection
    {

        public int Id { get; set; }

        [Required, MaxLength(60)]
        public string Title { get; set; }

        [Required]
        public int Order { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }

        public DateTime? UpdatedOn { get; set; }

        public IEnumerable<Card> Cards { get; set; }

        public Project Project { get; set; }

    }
}
