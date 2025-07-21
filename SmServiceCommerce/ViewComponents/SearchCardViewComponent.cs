using Microsoft.AspNetCore.Mvc;

namespace SmServiceCommerce.ViewComponents
{
    public class SearchCardViewComponent: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
    
}
