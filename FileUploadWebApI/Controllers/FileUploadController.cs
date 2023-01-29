using FileUploadWebApI.Models;
using FileUploadWebApI.Repositories;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;

namespace FileUploadWebApI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileUploadController : ControllerBase
    {
        private readonly IRepository<UploadFile> _fileRepository;

        private readonly ApplicationDbContext _context;

        public FileUploadController(ApplicationDbContext context,IRepository<UploadFile> repository)
        {
            _fileRepository = repository;
            _context = context;
        }

        [HttpGet]
        [Route("GetFileById/{id}")]
        public async Task<IActionResult>GetFileById(int id)
        {
            var file = await _fileRepository.GetById(id);
            if(file!=null)
            {
                return Ok(file);
            }
            return NotFound();
        }


        [HttpPost]
        [Route("upload")]
        public async Task<IActionResult>Upload(IFormFile file)
        {
            using (var stream=new MemoryStream())
            {
                await file.CopyToAsync(stream);
                var fileBytes = stream.ToArray();
                var uploadfile = new UploadFile
                { 
                    Name=file.FileName,
                    Data= fileBytes,
                    ContentType=file.ContentType
                };
                _context.UploadFiles.Add(uploadfile);
                await _context.SaveChangesAsync();

                var location = Url.Action("GetDocument", new {id=uploadfile.Id});
                return Created(location, uploadfile);

            }
        }


        
    }
}
