using FileBrowser.Core.Interfaces;
using FileBrowser.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileBrowser.Data.Repositories
{
    public class FileRepository : IFileRepository
    {
        private readonly AppDbContext _context;

        public FileRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<FileItem?> GetByIdAsync(long id)
        {
            return await _context.FileItems.FindAsync(id);
        }

        public async Task<IEnumerable<FileItem>> SearchByNameAsync(string startsWith, int limit = 10)
        {
            return await _context.FileItems
                .Where(f => f.Name.StartsWith(startsWith))
                .OrderBy(f => f.Name)
                .Take(limit)
                .ToListAsync();
        }

        public async Task AddAsync(FileItem file)
        {
            await _context.FileItems.AddAsync(file);
        }

        public async Task DeleteAsync(FileItem file)
        {
            _context.FileItems.Remove(file);
            await Task.CompletedTask;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
