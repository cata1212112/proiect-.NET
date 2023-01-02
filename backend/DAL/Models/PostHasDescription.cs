using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class PostHasDescription
    {
        public Guid PostId { get; set; }
        public Guid DescriptionId { get; set; }
        public Post Post { get; set; }
        public Description Description { get; set; }
    }
}
