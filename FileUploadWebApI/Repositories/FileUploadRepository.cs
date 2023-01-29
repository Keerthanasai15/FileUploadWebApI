using FileUploadWebApI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace FileUploadWebApI.Repositories
{
    public class FileUploadRepository:IRepository<UploadFile>
    {
        private readonly ApplicationDbContext _context;
        public FileUploadRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<UploadFile> GetById(int id)
        {
            var files = await _context.UploadFiles.Select(x => new UploadFile
            {
                Id = x.Id,
                Name = x.Name,
                ContentType = x.ContentType,
                Data = x.Data

            }).ToListAsync();

            var file= files.FirstOrDefault(x=>x.Id==id);
            if(file!=null)
            {
                return file;
            }
            return null;
        }

        
    }
}
