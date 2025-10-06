using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileBrowser.Core.Models
{
    public class FileItem
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public long FolderId { get; set; }
        public Folder Folder { get; set; } = null!;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
