﻿using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using BlazingProjects.Core.Entities;
using BlazingProjects.Core.Models;

namespace BlazingProjects.DataAccess.Repositories
{
    public interface ICardRepository
    {
        Task<Card> AddAsync(CardAdd toAdd, CancellationToken cancellationToken = default);
        Task DeleteAsync(int id, CancellationToken cancellationToken = default);
        Task<IEnumerable<Card>> GetAllForSectionAsync(int sectionId, CancellationToken cancellationToken = default);
        Task<Card> GetAsync(int id, CancellationToken cancellationToken = default);
        Task<Card> UpdateAsync(CardUpdate toUpdate, CancellationToken cancellationToken = default);
    }
}