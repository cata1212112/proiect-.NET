﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class UserCommentOnPost
    {
        public Guid UserId { get; set; }
        public Guid PostId { get; set; }
        public User User { get; set; }
        public Post Post { get; set; }

        public string Comment { get; set; }
    }
}
