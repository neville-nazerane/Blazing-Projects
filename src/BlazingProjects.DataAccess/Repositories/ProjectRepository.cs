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
    class ProjectRepository : IProjectRepository
    {
        private readonly AppDbContext _context;

        public ProjectRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Project> AddAsync(ProjectAdd toAdd, CancellationToken cancellationToken = default)
        {
            var project = toAdd.ToEntity();
            project.CreatedOn = DateTime.UtcNow;
            project.Order = await _context.Projects.MaxAsync(p => (int?)p.Order, cancellationToken) ?? 0 + 1;
            await _context.AddAsync(project, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return project;
        }

        public async Task<Project> UpdateAsync(ProjectUpdate toUpdate, CancellationToken cancellationToken = default)
        {
            var project = await _context.Projects.SingleAsync(p => p.Id == toUpdate.Id, cancellationToken);
            project.UpdateFrom(toUpdate);
            project.UpdatedOn = DateTime.UtcNow;
            await _context.SaveChangesAsync(cancellationToken);
            return project;
        }

        public async Task DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            var project = await _context.Projects.SingleAsync(p => p.Id == id, cancellationToken);
            _context.Remove(project);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<IEnumerable<Project>> GetAllAsync(CancellationToken cancellationToken = default)
            => await _context.Projects.AsNoTracking().OrderBy(p => p.Order).ToListAsync(cancellationToken);

        public async Task<Project> GetAsync(int id, CancellationToken cancellationToken = default)
            => await _context.Projects.AsNoTracking().SingleOrDefaultAsync(p => p.Id == id, cancellationToken);

    }
}
