using FileBrowser.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileBrowser.Core.Interfaces
{
    public interface IFileRepository
    {
        Task<FileItem?> GetByIdAsync(long id);
        Task<IEnumerable<FileItem>> SearchByNameAsync(string startsWith, int limit = 10);
        Task AddAsync(FileItem file);
        Task DeleteAsync(FileItem file);
        Task SaveChangesAsync();
    }
}
