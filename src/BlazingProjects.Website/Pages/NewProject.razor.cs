using BlazingProjects.Core.Models;
using BlazingProjects.DataAccess.Repositories;
using BlazingProjects.Website.Helpers;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazingProjects.Website.Pages
{
    public class NewProjectVM : ComponentBase
    {

        [Inject]
        public ScopeControl Control { get; set; }

        public IProjectRepository ProjectRepository => Control.GetService<IProjectRepository>();

        public ProjectAdd ProjectAdd { get; set; }

        protected override void OnInitialized()
        {
            ProjectAdd = new ProjectAdd();
            base.OnInitialized();
        }

        protected async Task AddAsync()
        {
            await ProjectRepository.AddAsync(ProjectAdd);
            ProjectAdd = new ProjectAdd();
            Control.ClearScope();
        }

    }
}
