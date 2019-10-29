using BlazingProjects.Core.Entities;
using BlazingProjects.Core.Mapping;
using BlazingProjects.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BlazingProjects.DataAccess.Repositories
{
    class CardSectionRepository
    {
        private readonly AppDbContext _context;

        public CardSectionRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<CardSection> AddAsync(CardSectionAdd toAdd)
        {
            var cardSection = toAdd.ToEntity();
            cardSection.CreatedOn = DateTime.UtcNow;
            cardSection.Order = await _context.CardSections.DefaultIfEmpty().MaxAsync(c => c.Order) + 1;
            await _context.AddAsync(cardSection);
            await _context.SaveChangesAsync();
            return cardSection;
        }

        public async Task<CardSection> UpdateAsync(CardSectionUpdate toUpdate)
        {
            var cardSection = await _context.CardSections.SingleAsync(c => c.Id == toUpdate.Id);
            cardSection.UpdateFrom(toUpdate);
            cardSection.UpdatedOn = DateTime.UtcNow;
            await _context.SaveChangesAsync();
            return cardSection;
        }

        public async Task DeleteAsync(int id)
        {
            var cardSection = await _context.CardSections.SingleAsync(c => c.Id == id);
            _context.Remove(cardSection);
            await _context.SaveChangesAsync();
        }

        public async IAsyncEnumerable<CardSection> GetAllAsync()
            => await _context.CardSections.AsNoTracking().OrderBy(c => c.Order).ToListAsync();

        public async Task<CardSection> GetAsync(int id)
            => await _context.CardSections.SingleOrDefaultAsync(c => c.Id == id);

    }
}
