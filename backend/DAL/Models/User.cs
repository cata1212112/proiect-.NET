using DAL.Models.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class User : BaseEntity.BaseEntity
    {
        [RegularExpression(@"^[a-zA-Z0-9]*$"), Required]
        public string Username { get; set; } = String.Empty;

        [RegularExpression(@"^[a-zA-Z0-9]*$")]
        public string FirstName { get; set; } = String.Empty;

        [RegularExpression(@"^[a-zA-Z0-9]*$")]
        public string LastName { get; set; } = String.Empty;
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$"), Required]
        public string Email { get; set; } = String.Empty;

        [JsonIgnore]
        public string PasswordHash { get; set; }

        public Role Role { get; set; }

        public ProfilePicture Picture { get; set; }
        public Guid PictueID { get; set; }
        public ICollection<Post> Posts { get; set; }

        public ICollection<UserLikesPost> UserLikesPostList { get; set; }

        public ICollection<UserCommentOnPost> UserCommentOnPostList { get; set; }

    }
}
