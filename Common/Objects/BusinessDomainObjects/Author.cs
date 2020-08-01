using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace loppinja.Common.Models.Domains
{
    public class Author : BaseModel
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string UserId { get; set; }
        public virtual ICollection<Article> Articles { get; set; }

        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }
        public string Biography { get; set; }
 
    }
}