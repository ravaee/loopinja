using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using loppinja.Models.Domains;
using loppinja.Models.Utilities;

namespace loppinja.Common.Models.Domains
{
    public class Article : BaseModel
    {
        public string PictureName { get; set; }
        public string Topic { get; set; }
        public string Body { get; set; }
        public int? AuthorId { get; set; }
        public int? CategoryId { get; set; }
        public DateTime CreateDate { get; set; }
        public virtual ICollection<Comment> SubComments { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }

        [ForeignKey("AuthorId")]
        public virtual Author Author { get; set; }

    }
}