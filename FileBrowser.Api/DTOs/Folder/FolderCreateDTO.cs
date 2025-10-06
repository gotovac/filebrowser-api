namespace FileBrowser.Api.DTOs.Folder
{
    public class FolderCreateDTO
    {
        public string Name { get; set; } = string.Empty;
        public long? ParentFolderId { get; set; }
    }
}
