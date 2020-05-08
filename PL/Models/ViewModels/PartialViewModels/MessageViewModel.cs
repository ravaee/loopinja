using System.Collections.Generic;

namespace loppinja.Models.ViewModels.Partial
{
    public class MessageViewModel: PartialBaseViewModel
    {
        public MessageViewModel()
        {
            this.Errors = new List<string>();            
            this.Messages = new List<string>();
            this.SuccessMessages = new List<string>();
        }
        
        public List<string> Errors { get; set; }
        public List<string> Messages { get; set; }
        public List<string> SuccessMessages { get; set; }
        
    }
}