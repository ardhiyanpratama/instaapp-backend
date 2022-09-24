using System.ComponentModel.DataAnnotations;

namespace instaapp_backend.Dto
{
    public class PostingWriteDto
    {
        [Required]
        public long UserId { get; set; }

        [Required]
        public string Posts { get; set; }
    }
}
