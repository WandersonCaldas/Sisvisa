using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace SISVISA.UI.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            GlobalFilters.Filters.Add(new App_Start.AuthorizationFilter());
        }

        void Application_Error(object sender, EventArgs e)
        {
            Exception objErr = Server.GetLastError().GetBaseException();
            if (objErr != null)
            {
                if (SISVISA.Core.Repository.Conexao.GetInstance().GetTransaction != null)
                {
                    SISVISA.Core.Repository.Conexao conexao = SISVISA.Core.Repository.Conexao.GetInstance();
                    conexao.RollbackTrans();
                }

                HttpContext.Current.Session["erro_aplicacao"] = objErr.ToString();
                Server.ClearError();
                Response.Clear();

                var routeData = new RouteData();
                routeData.Values["controller"] = "Home";
                routeData.Values["action"] = "About";
                Response.StatusCode = 500;

                IController controller = new Controllers.HomeController();
                var rc = new RequestContext(new HttpContextWrapper(Context), routeData);
                controller.Execute(rc);
            }
        }
    }
}
