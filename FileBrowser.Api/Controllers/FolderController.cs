using AutoMapper;
using FileBrowser.Api.DTOs.Folder;
using FileBrowser.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FileBrowser.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FolderController : ControllerBase
    {
        private readonly IFolderService _folderService;
        private readonly IMapper _mapper;

        public FolderController(IFolderService folderService, IMapper mapper)
        {
            _folderService = folderService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var folders = await _folderService.GetAllAsync();
            var response = _mapper.Map<IEnumerable<FolderResponseDTO>>(folders);
            return Ok(response);
        }

        [HttpGet("{id:long}")]
        public async Task<IActionResult> GetById(long id)
        {
            var folder = await _folderService.GetByIdAsync(id);
            if (folder == null)
                return NotFound($"Folder with ID {id} not found.");

            var response = _mapper.Map<FolderResponseDTO>(folder);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] FolderCreateDTO dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Name))
                return BadRequest("Folder name is required.");

            var folder = await _folderService.CreateAsync(dto.Name, dto.ParentFolderId);
            var response = _mapper.Map<FolderResponseDTO>(folder);

            return CreatedAtAction(nameof(GetById), new { id = folder.Id }, response);
        }

        [HttpDelete("{id:long}")]
        public async Task<IActionResult> Delete(long id)
        {
            try
            {
                await _folderService.DeleteAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }
    }
}
