namespace FileBrowser.Api.DTOs.File
{
    public class FileCreateDTO
    {
        public string Name { get; set; } = string.Empty;
        public long FolderId { get; set; }
    }
}
