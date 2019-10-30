using BlazingProjects.Core.Entities;
using BlazingProjects.Core.Mapping;
using BlazingProjects.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Runtime.CompilerServices;

namespace BlazingProjects.DataAccess.Repositories
{
    class CardRepository //: ICardRepository
    {
        private readonly AppDbContext _context;

        public CardRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Card> AddAsync(CardAdd toAdd, CancellationToken cancellationToken = default)
        {
            var card = toAdd.ToEntity();
            card.CreatedOn = DateTime.UtcNow;
            card.Order = await _context.Cards.DefaultIfEmpty().MaxAsync(c => c.Order, cancellationToken) + 1;
            await _context.AddAsync(card, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return card;
        }

        public async Task<Card> UpdateAsync(CardUpdate toUpdate, CancellationToken cancellationToken = default)
        {
            var card = await _context.Cards.SingleAsync(c => c.Id == toUpdate.Id, cancellationToken);
            card.UpdateFrom(toUpdate);
            card.UpdatedOn = DateTime.UtcNow;
            await _context.SaveChangesAsync(cancellationToken);
            return card;
        }

        public async Task DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            var card = await _context.Cards.SingleAsync(c => c.Id == id, cancellationToken);
            _context.Remove(card);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<Card> GetAsync(int id, CancellationToken cancellationToken = default)
            => await _context.Cards.AsNoTracking().SingleOrDefaultAsync(c => c.Id == id, cancellationToken);

        public async IAsyncEnumerable<Card> GetAllAsync([EnumeratorCancellation]CancellationToken cancellationToken = default)
            => await _context.Cards.AsNoTracking().OrderBy(c => c.Order).ToListAsync(cancellationToken);

    }
}
