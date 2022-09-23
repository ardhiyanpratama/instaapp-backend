using System;
using System.Collections.Generic;

namespace instaapp_backend.Models
{
    public partial class Posting
    {
        public long Id { get; set; }
        public Guid? Uuid { get; set; }
        public long UserId { get; set; }
        public string Posts { get; set; } = null!;
        public string Image { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual User IdNavigation { get; set; } = null!;
        public virtual Like? Like { get; set; }
    }
}
