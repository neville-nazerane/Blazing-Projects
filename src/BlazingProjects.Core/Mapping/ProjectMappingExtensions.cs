using BlazingProjects.Core.Entities;
using BlazingProjects.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlazingProjects.Core.Mapping
{
    public static class ProjectMappingExtensions
    {

        public static Project ToEntity(this ProjectAdd add)
        {
            return new Project { 
                Title = add.Title
            };
        }

        public static void UpdateFrom(this Project project, ProjectUpdate update)
        {
            project.Title = update.Title;
        }

    }
}
