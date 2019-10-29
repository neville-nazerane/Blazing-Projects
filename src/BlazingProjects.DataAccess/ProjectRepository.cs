using BlazingProjects.Core.Entities;
using BlazingProjects.Core.Mapping;
using BlazingProjects.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazingProjects.DataAccess
{
    class ProjectRepository
    {
        private readonly AppDbContext _context;

        public ProjectRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Project> AddAsync(ProjectAdd toAdd)
        {
            var project = toAdd.ToEntity();
            project.CreatedOn = DateTime.UtcNow;
            project.Order = await _context.Projects.DefaultIfEmpty().MaxAsync(p => p.Order) + 1;
            await _context.AddAsync(project);
            await _context.SaveChangesAsync();
            return project;
        }

        public async Task<Project> UpdateAsync(ProjectUpdate toUpdate)
        {
            var project = await GetProjectInternalAsync(toUpdate.Id);
            project.UpdateFrom(toUpdate);
            project.UpdatedOn = DateTime.UtcNow;
            await _context.SaveChangesAsync();
            return project;
        }

        public async Task DeleteAsync(int id)
        {
            var project = await GetProjectInternalAsync(id);
            _context.Remove(project);
            await _context.SaveChangesAsync();
        }

        public async IAsyncEnumerable<Project> GetAllAsync() => await _context.Projects.AsNoTracking().ToListAsync();

        public async Task<Project> GetAsync(int id) => await _context.Projects.AsNoTracking().SingleOrDefaultAsync(p => p.Id == id);

        private async Task<Project> GetProjectInternalAsync(int id) => await _context.Projects.SingleAsync(p => p.Id == id);

    }
}
