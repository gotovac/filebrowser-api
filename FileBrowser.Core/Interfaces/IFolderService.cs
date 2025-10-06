using FileBrowser.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileBrowser.Core.Interfaces
{
    public interface IFolderService
    {
        Task<IEnumerable<Folder>> GetAllAsync();
        Task<Folder?> GetByIdAsync(long id);
        Task<Folder> CreateAsync(string name, long? parentFolderId);
        Task DeleteAsync(long id);
    }
}
