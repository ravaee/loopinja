using System.Collections.Generic;
using loppinja.Models.Domains;

namespace loppinja.Models.ViewModels.ActionViewModels.Articles
{
    public class IndexViewModel: ActionBaseViewModel
    {

        public List<ArticleDto> Articles { get; set;}
        
        
    }
}