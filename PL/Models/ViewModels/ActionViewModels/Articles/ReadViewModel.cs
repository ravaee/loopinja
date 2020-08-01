using loppinja.Common.Models.Domains;
using loppinja.Models.ViewModels.Partial;

namespace loppinja.Models.ViewModels.ActionViewModels.Articles
{
    public class ReadViewModel : ActionBaseViewModel
    {
        public Article Article { get; set; }
    }
}