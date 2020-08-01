using System.Collections.Generic;
using loppinja.Common.Models.Domains;
using loppinja.Common.Objects.InfrastractureObjects;
using loppinja.Models.ViewModels.Partial;

namespace loppinja.Models.ViewModels.ActionViewModels.Articles
{
    public class ListViewModel : ActionBaseViewModel
    {
        public List<Article> Articles { get; set; }
        public int LeftOverCount { get; set; }
        public PagingParameterModel Pagination { get; set; }
    }
}