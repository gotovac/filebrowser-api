using FileBrowser.Core.Interfaces;
using FileBrowser.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileBrowser.Services
{
    public class FolderService : IFolderService
    {
        private readonly IFolderRepository _folderRepository;

        public FolderService(IFolderRepository folderRepository)
        {
            _folderRepository = folderRepository;
        }

        public async Task<IEnumerable<Folder>> GetAllAsync() => await _folderRepository.GetAllAsync();

        public async Task<Folder?> GetByIdAsync(long id) => await _folderRepository.GetByIdAsync(id);

        public async Task<Folder> CreateAsync(string name, long? parentFolderId)
        {
            var folder = new Folder { Name = name, ParentFolderId = parentFolderId };
            await _folderRepository.AddAsync(folder);
            await _folderRepository.SaveChangesAsync();
            return folder;
        }

        public async Task DeleteAsync(long id)
        {
            var folder = await _folderRepository.GetByIdAsync(id);
            if (folder == null)
                throw new KeyNotFoundException("Folder not found!");

            await _folderRepository.DeleteAsync(folder);
            await _folderRepository.SaveChangesAsync();
        }
    }
}
