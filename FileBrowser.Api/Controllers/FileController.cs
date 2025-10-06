using AutoMapper;
using FileBrowser.Api.DTOs.File;
using FileBrowser.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FileBrowser.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FileController : ControllerBase
    {
        private readonly IFileService _fileService;
        private readonly IMapper _mapper;

        public FileController(IFileService fileService, IMapper mapper)
        {
            _fileService = fileService;
            _mapper = mapper;
        }

        [HttpGet("{id:long}")]
        public async Task<IActionResult> GetById(long id)
        {
            var file = await _fileService.GetByIdAsync(id);
            if (file == null)
                return NotFound($"File with ID {id} not found.");

            var response = _mapper.Map<FileResponseDTO>(file);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] FileCreateDTO dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Name))
                return BadRequest("File name is required.");

            var file = await _fileService.CreateAsync(dto.Name, dto.FolderId);
            var response = _mapper.Map<FileResponseDTO>(file);

            return CreatedAtAction(nameof(GetById), new { id = file.Id }, response);
        }

        [HttpDelete("{id:long}")]
        public async Task<IActionResult> Delete(long id)
        {
            try
            {
                await _fileService.DeleteAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] string query)
        {
            if (string.IsNullOrWhiteSpace(query))
                return BadRequest("Search query is required.");

            var results = await _fileService.SearchAsync(query);
            var response = _mapper.Map<IEnumerable<FileResponseDTO>>(results);

            return Ok(response);
        }
    }
}
