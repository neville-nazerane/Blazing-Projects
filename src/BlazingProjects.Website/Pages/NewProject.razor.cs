﻿using BlazingProjects.Core.Models;
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
    public class NewProjectVM : ComponentBase
    {

        [Inject]
        public ScopeControl Control { get; set; }

        [Inject]
        public NavigationContext NavigationContext { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public IProjectRepository ProjectRepository => Control.GetService<IProjectRepository>();

        public ProjectAdd ProjectAdd { get; set; }

        protected override void OnInitialized()
        {
            ProjectAdd = new ProjectAdd();
            base.OnInitialized();
        }

        protected override void OnParametersSet()
        {
            base.OnParametersSet();
        }

        protected async Task AddAsync()
        {
            var project = await ProjectRepository.AddAsync(ProjectAdd);
            ProjectAdd = new ProjectAdd();
            await NavigationContext.OnMenuUpdatedAsync(Control);
            NavigationManager.NavigateTo("/project/" + project.Id);
        }

    }
}
