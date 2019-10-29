using BlazingProjects.Core.Entities;
using BlazingProjects.Core.Mapping;
using BlazingProjects.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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

        public async Task<CardSection> AddAsync(CardSectionAdd toAdd, CancellationToken cancellationToken = default)
        {
            var cardSection = toAdd.ToEntity();
            cardSection.CreatedOn = DateTime.UtcNow;
            cardSection.Order = await _context.CardSections.DefaultIfEmpty().MaxAsync(c => c.Order, cancellationToken) + 1;
            await _context.AddAsync(cardSection, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return cardSection;
        }

        public async Task<CardSection> UpdateAsync(CardSectionUpdate toUpdate, CancellationToken cancellationToken = default)
        {
            var cardSection = await _context.CardSections.SingleAsync(c => c.Id == toUpdate.Id, cancellationToken);
            cardSection.UpdateFrom(toUpdate);
            cardSection.UpdatedOn = DateTime.UtcNow;
            await _context.SaveChangesAsync(cancellationToken);
            return cardSection;
        }

        public async Task DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            var cardSection = await _context.CardSections.SingleAsync(c => c.Id == id, cancellationToken);
            _context.Remove(cardSection);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async IAsyncEnumerable<CardSection> GetAllAsync([EnumeratorCancellation]CancellationToken cancellationToken = default)
            => await _context.CardSections.AsNoTracking().OrderBy(c => c.Order).ToListAsync(cancellationToken);

        public async Task<CardSection> GetAsync(int id, CancellationToken cancellationToken = default)
            => await _context.CardSections.SingleOrDefaultAsync(c => c.Id == id, cancellationToken);

    }
}
