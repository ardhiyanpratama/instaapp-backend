namespace instaapp_backend.Dto
{
    public class PostingReadDto
    {
        public string Id { get; set; }
        public Guid? Uuid { get; set; }
        public string UserId { get; set; }
        public string Posts { get; set; } = null!;
        public string Image { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
