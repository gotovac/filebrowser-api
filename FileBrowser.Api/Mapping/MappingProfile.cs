using AutoMapper;
using FileBrowser.Api.DTOs.File;
using FileBrowser.Api.DTOs.Folder;
using FileBrowser.Core.Models;

namespace FileBrowser.Api.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Folder, FolderResponseDTO>();
            CreateMap<FolderResponseDTO, Folder>();

            CreateMap<FileItem, FileResponseDTO>();
            CreateMap<FileResponseDTO, FileItem>();
        }
    }
}