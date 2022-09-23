namespace instaapp_backend.Dto
{
    public class UserReadDto
    {
        public string Id { get; set; }
        public string? Uuid { get; set; }
        public string Fullname { get; set; } = null!;
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string MobileNumber { get; set; } = null!;
        public bool? Ispost { get; set; }
        public bool? Islike { get; set; }
        public bool? Iscomment { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
