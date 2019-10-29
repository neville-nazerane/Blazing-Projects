using BlazingProjects.Core.Entities;
using BlazingProjects.Core.Mapping;
using BlazingProjects.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace BlazingProjects.DataAccess.Repositories
{
    class CardRepository
    {
        private readonly AppDbContext _context;

        public CardRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Card> AddAsync(CardAdd toAdd)
        {
            var card = toAdd.ToEntity();
            card.CreatedOn = DateTime.UtcNow;
            card.Order = await _context.Cards.DefaultIfEmpty().MaxAsync(c => c.Order) + 1;
            await _context.AddAsync(card);
            await _context.SaveChangesAsync();
            return card;
        }

        public async Task<Card> UpdateAsync(CardUpdate toUpdate)
        {
            var card = await _context.Cards.SingleAsync(c => c.Id == toUpdate.Id);
            card.UpdateFrom(toUpdate);
            card.UpdatedOn = DateTime.UtcNow;
            await _context.SaveChangesAsync();
            return card;
        }

        public async Task DeleteAsync(int id)
        {
            var card = await _context.Cards.SingleAsync(c => c.Id == id);
            _context.Remove(card);
            await _context.SaveChangesAsync();
        }

        public async Task GetAsync(int id) => await _context.Cards.AsNoTracking().SingleOrDefaultAsync(c => c.Id == id);

        public async Task GetAllAsync() => await _context.Cards.AsNoTracking().OrderBy(c => c.Order).ToListAsync();

    }
}
