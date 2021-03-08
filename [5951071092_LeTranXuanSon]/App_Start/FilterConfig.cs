using System.Web;
using System.Web.Mvc;

namespace _5951071092_LeTranXuanSon_
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
