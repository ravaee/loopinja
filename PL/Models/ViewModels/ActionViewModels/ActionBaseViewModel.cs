using loppinja.Models.ViewModels.ActionViewModels;
using loppinja.Models.ViewModels.Partial;

namespace loppinja.Models.ViewModels.ActionViewModels
{
    public abstract class ActionBaseViewModel: BaseViewModel
    {
        public ActionBaseViewModel()
        {
        }

        public MapViewModel MapViewModel {get; set;}
        public MessageViewModel MessageViewModel {get; set;}
        
    }
}