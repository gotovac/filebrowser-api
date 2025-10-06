using FileBrowser.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileBrowser.Data
{
    public static class DataSeeder
    {
        public static void Seed(AppDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Folders.Any())
                return;

            var root = new Folder { Name = "Root" };

            var documents = new Folder { Name = "Documents", ParentFolder = root };
            var pictures = new Folder { Name = "Pictures", ParentFolder = root };
            var videos = new Folder { Name = "Videos", ParentFolder = root };

            var reports = new Folder { Name = "Reports", ParentFolder = documents };
            var notes = new Folder { Name = "Notes", ParentFolder = documents };

            context.Folders.AddRange(root, documents, pictures, videos, reports, notes);

            context.FileItems.AddRange(
                new FileItem { Name = "Essay.docx", Folder = documents },
                new FileItem { Name = "Photo.jpg", Folder = pictures },
                new FileItem { Name = "Video.mp4", Folder = videos },
                new FileItem { Name = "Report.pdf", Folder = reports },
                new FileItem { Name = "Notes.txt", Folder = notes }
            );

            context.SaveChanges();
        }
    }
}
