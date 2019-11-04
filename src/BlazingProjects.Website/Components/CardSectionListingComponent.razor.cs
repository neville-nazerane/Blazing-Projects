using BlazingProjects.Core.Entities;
using BlazingProjects.DataAccess.Repositories;
using BlazingProjects.Website.Helpers;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazingProjects.Website.Components
{
    public class CardSectionListingComponentVM : ComponentBase
    {

        [Parameter]
        public Action OnDelete { get; set; }

        [Parameter]
        public CardSection CardSection { get; set; }

        [Inject]
        public ScopeControl Control { get; set; }

        private ICardSectionRepository CardSectionRepository => Control.GetService<ICardSectionRepository>();

        protected async Task DeleteAsync()
        {
            await CardSectionRepository.DeleteAsync(CardSection.Id);
            OnDelete?.Invoke();
            Control.ClearScope();
        }

    }
}
