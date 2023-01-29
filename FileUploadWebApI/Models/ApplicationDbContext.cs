using Microsoft.EntityFrameworkCore;
namespace FileUploadWebApI.Models
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<UploadFile> UploadFiles { get; set; }
    }
}
