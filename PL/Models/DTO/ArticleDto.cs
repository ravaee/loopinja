using System;
using loppinja.Models.Utilities;

namespace loppinja.Models.Domains
{
    public class ArticleDto
    {
        public int Id { get; set; }
        public string Topic { get; set; }
        public string Body { get; set; }
        public DateTime CreateDate  { get; set; }

        public static ArticleDto ToArticleDtoMap(Article article) {
            
            return new ArticleDto()
            {
                Id = article.Id,
                Body = article.Body,
                Topic = article.Topic,
                CreateDate = MRPersianDateTime.ToPersianDateTime(article.CreateDate)    
            };
        } 
        
    }
}