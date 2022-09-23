using System.ComponentModel.DataAnnotations;

namespace instaapp_backend.Dto
{
    public class UserWriteDto
    {
        [Required]
        [MaxLength(250, ErrorMessage = "{0} can have a max of {1} characters")]
        public string Fullname { get; set; } = null!;

        [Required]
        [MaxLength(250, ErrorMessage = "{0} can have a max of {1} characters")]
        public string Username { get; set; } = null!;

        [Required]
        [StringLength(12, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 6)]
        public string Password { get; set; } = null!;

        [Required]
        [DataType(DataType.PhoneNumber)]
        [StringLength(13, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 12)]
        public string MobileNumber { get; set; } = null!;

        public bool? Ispost { get; set; }
        public bool? Islike { get; set; }
        public bool? Iscomment { get; set; }
    }
}
