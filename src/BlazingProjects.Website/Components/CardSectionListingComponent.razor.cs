using BlazingProjects.Core.Entities;
using BlazingProjects.Core.Models;
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

        protected CardAdd CardAdd { get; set; }

        private ICardSectionRepository CardSectionRepository => Control.GetService<ICardSectionRepository>();
        private ICardRepository CardRepository => Control.GetService<ICardRepository>();

        protected async Task DeleteAsync()
        {
            await CardSectionRepository.DeleteAsync(CardSection.Id);
            OnDelete?.Invoke();
            Control.ClearScope();
        }

        protected override void OnParametersSet()
        {
            if (CardSection != null)
            {
                if (CardSection == null) CardSection.Cards = new List<Card>();
                ResetCardAdd();
            }

            base.OnParametersSet();
        }

        private void ResetCardAdd() => CardAdd = new CardAdd { CardSectionId = CardSection.Id };

        public async Task AddCardAsync()
        {
            var added = await CardRepository.AddAsync(CardAdd);
            CardSection.Cards.Add(added);
            ResetCardAdd();
            Control.ClearScope();
        }

    }
}
