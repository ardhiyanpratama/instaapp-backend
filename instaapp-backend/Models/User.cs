﻿using System;
using System.Collections.Generic;

namespace instaapp_backend.Models
{
    public partial class User
    {
        public long Id { get; set; }
        public Guid? Uuid { get; set; }
        public string Fullname { get; set; } = null!;
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string MobileNumber { get; set; } = null!;
        public bool? Ispost { get; set; }
        public bool? Islike { get; set; }
        public bool? Iscomment { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual Like? Like { get; set; }
        public virtual Posting? Posting { get; set; }
    }
}
