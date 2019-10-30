using BlazingProjects.Core.Entities;
using BlazingProjects.Core.Models;
using BlazingProjects.DataAccess.Repositories;
using BlazingProjects.Website.Helpers;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazingProjects.Website.Shared
{
    public class NavMenuVM : ComponentBase
    {

        [Inject]
        public ScopeControl Control { get; set; }

        public IProjectRepository ProjectRepository => Control.GetService<IProjectRepository>();

        public ICollection<Project> Projects { get; set; }

        public bool IsAddShown { get; set; }

        public ProjectAdd ProjectAdd { get; set; }

        protected bool collapseNavMenu = true;

        protected string NavMenuCssClass => collapseNavMenu ? "collapse" : null;

        protected void ToggleNavMenu()
        {
            collapseNavMenu = !collapseNavMenu;
        }

        protected override async Task OnInitializedAsync()
        {
            ProjectAdd = new ProjectAdd();
            Projects = (await ProjectRepository.GetAllAsync()).ToList();
            await base.OnInitializedAsync();
            Control.ClearScope();
        }

        protected async Task AddAsync()
        {
            await ProjectRepository.AddAsync(ProjectAdd);
            Control.ClearScope();
        }

    }
}
