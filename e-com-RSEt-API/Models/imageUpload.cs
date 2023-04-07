namespace e_com_RSEt_API.Models
{
    public class imageUpload
    {
        public int userId { get; set; }
        public IFormFile files { get; set; } = default!;
    }
}
