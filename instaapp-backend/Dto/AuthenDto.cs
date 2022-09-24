namespace instaapp_backend.Dto
{
    public class AuthenDto
    {
        public string? Id { get; set; }
        public string? access_token { get; set; }
        public string? token_type { get; set; }
        public bool? ispost { get; set; }
        public bool? islike { get; set; }
        public bool? iscomment { get; set; }
        public string? name { get; set; }
        public Guid? token { get; set; }
    }
}
