using System.Threading.Tasks;

namespace FileUploadWebApI.Repositories
{
    public interface IRepository<T>where T : class
    {
        Task<T>GetById(int id);
    }
}
