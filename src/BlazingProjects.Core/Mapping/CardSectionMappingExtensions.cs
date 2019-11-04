using BlazingProjects.Core.Entities;
using BlazingProjects.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlazingProjects.Core.Mapping
{
    public static class CardSectionMappingExtensions
    {

        public static CardSection ToEntity(this CardSectionAdd add)
        {
            return new CardSection { 
                Title = add.Title,
                ProjectId = add.ProjectId
            };
        }

        public static void UpdateFrom(this CardSection cardSection, CardSectionUpdate update)
        {
            cardSection.Title = update.Title;
        }

    }
}
