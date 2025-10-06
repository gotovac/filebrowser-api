using FileBrowser.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileBrowser.Core.Interfaces
{
    public interface IFileService
    {
        Task<FileItem?> GetByIdAsync(long id);
        Task<FileItem> CreateAsync(string name, long folderId);
        Task DeleteAsync(long id);
        Task<IEnumerable<FileItem>> SearchAsync(string startsWith);
    }
}
