using System;
using System.Collections.Generic;

namespace instaapp_backend.Models
{
    public partial class Like
    {
        public long Id { get; set; }
        public Guid? Uuid { get; set; }
        public long PostingId { get; set; }
        public long UserId { get; set; }
        public bool UserLike { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual User Id1 { get; set; } = null!;
        public virtual Posting IdNavigation { get; set; } = null!;
    }
}
