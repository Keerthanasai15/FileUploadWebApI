using Microsoft.AspNetCore.Http;

namespace FileUploadWebApI.Models
{
    public class UploadFile
    {
        public int Id { get; set; }
        public string Name { get; set; }
       
       public byte[] Data { get; set; }
        public string ContentType { get; set; }
    }
}
