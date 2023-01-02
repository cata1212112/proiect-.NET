using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Description : BaseEntity.BaseEntity
    {
        [RegularExpression(@"^[a-zA-Z]*$")]
        public string Attribute { get; set; } = string.Empty;

        public ICollection<PostHasDescription> PostHasDescriptionList { get; set; }
    }
}
