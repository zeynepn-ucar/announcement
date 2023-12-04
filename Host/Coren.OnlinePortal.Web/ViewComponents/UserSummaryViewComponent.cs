using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using System.Reflection;

namespace Coren.OnlinePortal.Web.ViewComponents
{
    public class UserSummaryViewComponent : ViewComponent
    {
        public ViewViewComponentResult Invoke(string userName)
        {
            UserDetailsViewModel model = new UserDetailsViewModel
            {
                UserName = userName
            };
            return View(model);
        }
        
    }
}
