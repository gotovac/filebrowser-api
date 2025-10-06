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
    public class FolderRepository : IFolderRepository
    {
        private readonly AppDbContext _context;

        public FolderRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Folder?> GetByIdAsync(long id)
        {
            return await _context.Folders
                .Include(f => f.SubFolders)
                .Include(f => f.Files)
                .FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task<IEnumerable<Folder>> GetAllAsync()
        {
            return await _context.Folders
                .Include(f => f.SubFolders)
                .Include(f => f.Files)
                .Where(f => f.ParentFolderId == null)
                .ToListAsync();
        }

        public async Task AddAsync(Folder folder)
        {
            await _context.Folders.AddAsync(folder);
        }

        public async Task DeleteAsync(Folder folder)
        {
            _context.Folders.Remove(folder);
            await Task.CompletedTask;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
