using System.Collections.Generic;
using loppinja.Common.Models.Domains;

namespace loppinja.Models.ViewModels.ActionViewModels.Articles
{
    public class IndexViewModel: ActionBaseViewModel
    {
        public List<Article> Articles { get; set;}
        
    }
}