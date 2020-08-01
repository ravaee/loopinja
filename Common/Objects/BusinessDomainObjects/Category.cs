using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using loppinja.Models.Utilities;

namespace loppinja.Common.Models.Domains
{
    public class Category : BaseModel
    {
        public string Name { get; set; }
        public virtual ICollection<Article> Articles { get; set; }
 
    }
}