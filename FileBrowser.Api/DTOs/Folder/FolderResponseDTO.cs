using FileBrowser.Api.DTOs.File;

namespace FileBrowser.Api.DTOs.Folder
{
    public class FolderResponseDTO
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public long? ParentFolderId { get; set; }
        public List<FolderResponseDTO> SubFolders { get; set; } = new();
        public List<FileResponseDTO> Files { get; set; } = new();
    }
}
