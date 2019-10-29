using BlazingProjects.Core.Entities;
using BlazingProjects.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlazingProjects.Core.Mapping
{
    public static class CardMappingExtensions
    {

        public static Card ToEntity(this CardAdd add)
        {
            return new Card { 
                Title = add.Title,
                Description = add.Description
            };
        }

        public static void UpdateFrom(this Card card, CardUpdate update)
        {
            card.Title = update.Title;
            card.Description = update.Description;
        }

    }
}
