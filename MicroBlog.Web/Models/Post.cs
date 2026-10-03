using System.ComponentModel.DataAnnotations;

namespace MicroBlog.Web
{
    public class Post
    {
        public Guid PostId { get; set; } = Guid.CreateVersion7();
        public string Author { get; set; } = string.Empty;
        
        [Required]
        public string Body { get; set; } = string.Empty;
    }
}
