using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace loppinja.Models.Domains
{
    public class Comment: BaseModel
    {
        public string Body { get; set; }
        public int? ParentId { get;set; }
        public int? ArticleId { get; set; }
        public virtual ICollection<Comment> SubComments { get; set; }
        
        [InverseProperty("SubComments")]
        [ForeignKey("ParentId")]
        public virtual Comment ParentComment { get; set; }

        [ForeignKey("ArticleId")]
        public virtual Article Article { get; set; }

        
        
    }
}