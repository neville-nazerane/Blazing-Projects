using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using BlazingProjects.Core.Entities;
using BlazingProjects.Core.Models;

namespace BlazingProjects.DataAccess.Repositories
{
    public interface ICardSectionRepository
    {
        Task<CardSection> AddAsync(CardSectionAdd toAdd, CancellationToken cancellationToken = default);
        Task DeleteAsync(int id, CancellationToken cancellationToken = default);
        Task<IEnumerable<CardSection>> GetAllByProjectAsync(int projectId, bool includeCards = false, CancellationToken cancellationToken = default);
        Task<CardSection> GetAsync(int id, CancellationToken cancellationToken = default);
        Task<CardSection> UpdateAsync(CardSectionUpdate toUpdate, CancellationToken cancellationToken = default);
    }
}