using System;
using System.Collections.Generic;
using loppinja.Models.Utilities;
using loppinja.Models.ViewModels.Partial;

namespace loppinja.Models.ViewModels.ActionViewModels.Articles
{
    public class CreateViewModel: ActionBaseViewModel
    {
        public string Topic { get; set; }
        public string Body { get; set; }
        public DateTime CreateDate { get; set; }



    }
}
