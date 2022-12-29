using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Post : BaseEntity.BaseEntity
    {
        [ReadOnly(true)]
        public string Photo { get; set; }

        public User User { get; set; }
        public ICollection<PostHasDescription> PostHasDescriptionList { get; set; }

        public ICollection<UserLikesPost> UserLikesPostList { get; set; }

        public ICollection<UserCommentOnPost> UserCommentOnPostList { get; set; }
    }
}
