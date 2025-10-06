using FileBrowser.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileBrowser.Core.Interfaces
{
    public interface IFolderRepository
    {
        Task<Folder?> GetByIdAsync(long id);
        Task<IEnumerable<Folder>> GetAllAsync();
        Task AddAsync(Folder folder);
        Task DeleteAsync(Folder folder);
        Task SaveChangesAsync();
    }
}
