using System.Collections.Generic;

namespace MyMusaca.Web.ViewModels
{
    public class UserProfileViewModel
    {
        public IEnumerable<UserProfileOrderViewModel> Orders { get; set; }
       
    }
}