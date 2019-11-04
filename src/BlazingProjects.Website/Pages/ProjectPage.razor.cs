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

        protected ICollection<CardSection> CardSections { get; set; }

        protected CardSectionAdd CardSectionAdd { get; set; }

        protected Project Project { get; set; }

        private IProjectRepository ProjectRepository => Control.GetService<IProjectRepository>();
        private ICardSectionRepository CardSectionRepository => Control.GetService<ICardSectionRepository>();

        protected override void OnInitialized()
        {
            InitAdd();
            base.OnInitialized();
        }

        protected override async Task OnParametersSetAsync()
        {
            Project = await ProjectRepository.GetAsync(ProjectId);
            CardSections = (await CardSectionRepository.GetAllByProjectAsync(ProjectId, includeCards: true)).ToList();
            Control.ClearScope();
            await base.OnParametersSetAsync();
        }

        private void InitAdd() => CardSectionAdd = new CardSectionAdd { ProjectId = ProjectId };

        protected async Task AddSectionAsync()
        {
            var added = await CardSectionRepository.AddAsync(CardSectionAdd);
            InitAdd();
            CardSections.Add(added);
            Control.ClearScope();
        }

        protected async Task DeleteAsync()
        {
            await ProjectRepository.DeleteAsync(ProjectId);
            await NavigationContext.OnMenuUpdatedAsync(Control);
            Control.ClearScope();
            NavigationManager.NavigateTo("/");
        }

        protected void OnDeleteSection(CardSection section)
        {
            CardSections.Remove(section);
            StateHasChanged();
        }

    }
}
