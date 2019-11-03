using BlazingProjects.Core.Entities;
using BlazingProjects.DataAccess.Repositories;
using BlazingProjects.Website.Helpers;
using BlazingProjects.Website.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazingProjects.Website.Pages
{
    public class ProjectPageVM : ComponentBase
    {

        [Parameter]
        public int ProjectId { get; set; }

        [Inject]
        public ScopeControl Control { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public NavigationContext NavigationContext { get; set; }

        protected Project Project { get; set; }

        private IProjectRepository ProjectRepository => Control.GetService<IProjectRepository>();

        protected override async Task OnParametersSetAsync()
        {
            Project = await ProjectRepository.GetAsync(ProjectId);
            Control.ClearScope();
            await base.OnParametersSetAsync();
        }

        protected async Task DeleteAsync()
        {
            await ProjectRepository.DeleteAsync(ProjectId);
            await NavigationContext.OnMenuUpdatedAsync(Control);
            Control.ClearScope();
            NavigationManager.NavigateTo("/");
        }

    }
}
