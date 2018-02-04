using System.Web;
using System.Web.Mvc;

namespace VidlyNew
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            //This is used to route to error page when application has an error
            filters.Add(new HandleErrorAttribute());

            //This is used to provide Global Authorisation to application
            filters.Add(new AuthorizeAttribute());

            //This is used to RequireHttps to application for secure connection
            filters.Add(new RequireHttpsAttribute());
        }
    }
}
