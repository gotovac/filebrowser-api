namespace FileBrowser.Api.DTOs.File
{
    public class FileResponseDTO
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public long FolderId { get; set; }
    }
}
