using BlazingProjects.Core.Entities;
using BlazingProjects.Core.Models;
using BlazingProjects.DataAccess.Repositories;
using BlazingProjects.Website.Helpers;
using BlazingProjects.Website.Models;
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

        [CascadingParameter]
        public NavigationContext NavigationContext { get; set; }

        public IProjectRepository ProjectRepository => Control.GetService<IProjectRepository>();

        public ICollection<Project> Projects { get; set; }

        public bool IsAddShown { get; set; }

        protected bool collapseNavMenu = true;

        protected string NavMenuCssClass => collapseNavMenu ? "collapse" : null;

        protected void ToggleNavMenu()
        {
            collapseNavMenu = !collapseNavMenu;
        }

        protected override async Task OnInitializedAsync()
        {
            await MenuUpdatedAsync();
            Control.ClearScope();
            await base.OnInitializedAsync();
        }

        protected override void OnParametersSet()
        {
            if (NavigationContext != null)
                NavigationContext.OnMenuUpdatedAsync = MenuUpdatedAsync;
            base.OnParametersSet();
        }

        private async Task MenuUpdatedAsync(ScopeControl control = null)
        {
            if (control is null) control = Control;
            Projects = (await control.GetService<IProjectRepository>().GetAllAsync()).ToList();
        }

    }
}
