using System.Collections.Generic;
using loppinja.Models.Domains;
using loppinja.Models.ViewModels.Partial;

namespace loppinja.Models.ViewModels.ActionViewModels.Articles
{
    public class ReadViewModel : ActionBaseViewModel
    {
        public ArticleDto Article { get; set; }

    }
}