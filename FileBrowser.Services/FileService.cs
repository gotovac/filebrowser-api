using FileBrowser.Core.Interfaces;
using FileBrowser.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileBrowser.Services
{
    public class FileService : IFileService
    {
        private readonly IFileRepository _fileRepository;

        public FileService(IFileRepository fileRepository)
        {
            _fileRepository = fileRepository;
        }

        public async Task<FileItem?> GetByIdAsync(long id) => await _fileRepository.GetByIdAsync(id);

        public async Task<FileItem> CreateAsync(string name, long folderId)
        {
            var file = new FileItem { Name = name, FolderId = folderId };
            await _fileRepository.AddAsync(file);
            await _fileRepository.SaveChangesAsync();
            return file;
        }

        public async Task DeleteAsync(long id)
        {
            var file = await _fileRepository.GetByIdAsync(id);
            if (file == null)
                throw new KeyNotFoundException("File not found!");

            await _fileRepository.DeleteAsync(file);
            await _fileRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<FileItem>> SearchAsync(string startsWith)
        {
            return await _fileRepository.SearchByNameAsync(startsWith);
        }
    }
}
