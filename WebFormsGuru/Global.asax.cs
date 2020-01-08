using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace WebFormsGuru
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Código que se ejecuta al iniciar la aplicación
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        void Application_Error(object sender, EventArgs e)
        {
            HttpException lastErrorWrapper = Server.GetLastError() as HttpException;

            if (lastErrorWrapper.GetHttpCode() == 404)
            {
                Server.Transfer("~/ErrorPage.html");
            }

            Exception exc = Server.GetLastError();
            string str = "";
            str = exc.Message;

            string path = @"D:\AllErrors.txt";
            File.WriteAllText(path, str);
            Server.Transfer("~/ErrorPage.html");
        }
    }
}