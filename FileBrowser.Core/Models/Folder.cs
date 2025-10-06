using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileBrowser.Core.Models
{
    public class Folder
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public long? ParentFolderId { get; set; }
        public Folder? ParentFolder { get; set; }
        public ICollection<Folder> SubFolders { get; set; } = new List<Folder>();
        public ICollection<FileItem> Files { get; set; } = new List<FileItem>();
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
