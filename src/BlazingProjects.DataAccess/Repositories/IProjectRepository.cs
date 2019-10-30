﻿using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using BlazingProjects.Core.Entities;
using BlazingProjects.Core.Models;

namespace BlazingProjects.DataAccess.Repositories
{
    interface IProjectRepository
    {
        Task<Project> AddAsync(ProjectAdd toAdd, CancellationToken cancellationToken = default);
        Task DeleteAsync(int id, CancellationToken cancellationToken = default);
        IAsyncEnumerable<Project> GetAllAsync([EnumeratorCancellation] CancellationToken cancellationToken = default);
        Task<Project> GetAsync(int id, CancellationToken cancellationToken = default);
        Task<Project> UpdateAsync(ProjectUpdate toUpdate, CancellationToken cancellationToken = default);
    }
}