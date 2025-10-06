using FileBrowser.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileBrowser.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Folder> Folders { get; set; }
        public DbSet<FileItem> FileItems { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Folder>()
                .HasMany(f => f.SubFolders)
                .WithOne(f => f.ParentFolder)
                .HasForeignKey(f => f.ParentFolderId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Folder>()
                .HasMany(f => f.Files)
                .WithOne(fi => fi.Folder)
                .HasForeignKey(fi => fi.FolderId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
