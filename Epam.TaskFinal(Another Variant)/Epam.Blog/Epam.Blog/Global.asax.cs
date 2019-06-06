using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace Epam.Blog
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {

        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {
            HttpContext oHttpContext;
            Exception oException;

            oHttpContext = HttpContext.Current;

            oException = oHttpContext.Server.GetLastError();

            if (oException is HttpException)
            {
                switch ((oException as HttpException).GetHttpCode())
                {
                    case 404:

                        oHttpContext.Response.StatusCode = 404;
                        oHttpContext.Response.StatusDescription = "Not Found";
                        oHttpContext.Response.Charset = "windows-1251";
                        oHttpContext.Server.Execute("~/404.html");

                        oHttpContext.Server.ClearError();

                        break;

                    case 401:

                        oHttpContext.Response.StatusCode = 401;
                        oHttpContext.Response.StatusDescription = "You must login to do this";
                        oHttpContext.Response.Charset = "windows-1251";
                        oHttpContext.Server.Execute("~/401.html");

                        oHttpContext.Server.ClearError();

                        break;
                    case 402:

                        oHttpContext.Response.StatusCode = 402;
                        oHttpContext.Response.StatusDescription = "You do not have permission to do this.";
                        oHttpContext.Response.Charset = "windows-1251";
                        oHttpContext.Server.Execute("~/402.html");

                        oHttpContext.Server.ClearError();

                        break;

                    case 403:

                        oHttpContext.Response.StatusCode = 403;
                        oHttpContext.Response.StatusDescription = "You must login to do this.";
                        oHttpContext.Response.Charset = "windows-1251";
                        oHttpContext.Server.Execute("~/403.html");

                        oHttpContext.Server.ClearError();

                        break;

                    case 405:

                        oHttpContext.Response.StatusCode = 405;
                        oHttpContext.Response.StatusDescription = "New tag musn't be empty.";
                        oHttpContext.Response.Charset = "windows-1251";
                        oHttpContext.Server.Execute("~/error/405.html");

                        oHttpContext.Server.ClearError();

                        break;

                    case 406:

                        oHttpContext.Response.StatusCode = 406;
                        oHttpContext.Response.StatusDescription = "Tag is already in use.";
                        oHttpContext.Response.Charset = "windows-1251";
                        oHttpContext.Server.Execute("~/error/406.html");

                        oHttpContext.Server.ClearError();

                        break;

                    case 407:

                        oHttpContext.Response.StatusCode = 407;
                        oHttpContext.Response.StatusDescription = "Post does not exist.";
                        oHttpContext.Response.Charset = "windows-1251";
                        oHttpContext.Server.Execute("~/error/407.html");

                        oHttpContext.Server.ClearError();

                        break;

                    case 408:

                        oHttpContext.Response.StatusCode = 408;
                        oHttpContext.Response.StatusDescription = "Password cannot be blank.";
                        oHttpContext.Response.Charset = "windows-1251";
                        oHttpContext.Server.Execute("~/error/408.html");

                        oHttpContext.Server.ClearError();

                        break;

                    case 409:

                        oHttpContext.Response.StatusCode = 409;
                        oHttpContext.Response.StatusDescription = "User is already exists.";
                        oHttpContext.Response.Charset = "windows-1251";
                        oHttpContext.Server.Execute("~/error/409.html");

                        oHttpContext.Server.ClearError();

                        break;

                    case 410:

                        oHttpContext.Response.StatusCode = 410;
                        oHttpContext.Response.StatusDescription = "User does not exist.";
                        oHttpContext.Response.Charset = "windows-1251";
                        oHttpContext.Server.Execute("~/error/410.html");

                        oHttpContext.Server.ClearError();

                        break;

                    case 411:

                        oHttpContext.Response.StatusCode = 411;
                        oHttpContext.Response.StatusDescription = "Role is already in use.";
                        oHttpContext.Response.Charset = "windows-1251";
                        oHttpContext.Server.Execute("~/error/411.html");

                        oHttpContext.Server.ClearError();

                        break;

                    case 412:

                        oHttpContext.Response.StatusCode = 412;
                        oHttpContext.Response.StatusDescription = "Role does not exist.";
                        oHttpContext.Response.Charset = "windows-1251";
                        oHttpContext.Server.Execute("~/error/412.html");

                        oHttpContext.Server.ClearError();

                        break;

                    case 413:

                        oHttpContext.Response.StatusCode = 413;
                        oHttpContext.Response.StatusDescription = "Slug is already in use.";
                        oHttpContext.Response.Charset = "windows-1251";
                        oHttpContext.Server.Execute("~/error/413.html");

                        oHttpContext.Server.ClearError();

                        break;

                    case 414:

                        oHttpContext.Response.StatusCode = 414;
                        oHttpContext.Response.StatusDescription = "Passwords do not match.";
                        oHttpContext.Response.Charset = "windows-1251";
                        oHttpContext.Server.Execute("~/error/414.html");

                        oHttpContext.Server.ClearError();

                        break;

                    case 415:

                        oHttpContext.Response.StatusCode = 415;
                        oHttpContext.Response.StatusDescription = "Email cannot be blank.";
                        oHttpContext.Response.Charset = "windows-1251";
                        oHttpContext.Server.Execute("~/error/415.html");

                        oHttpContext.Server.ClearError();

                        break;

                    case 416:

                        oHttpContext.Response.StatusCode = 416;
                        oHttpContext.Response.StatusDescription = "Username cannot be blank.";
                        oHttpContext.Response.Charset = "windows-1251";
                        oHttpContext.Server.Execute("~/error/416.html");

                        oHttpContext.Server.ClearError();

                        break;

                    case 417:

                        oHttpContext.Response.StatusCode = 417;
                        oHttpContext.Response.StatusDescription = "Password cannot be blank.";
                        oHttpContext.Response.Charset = "windows-1251";
                        oHttpContext.Server.Execute("~/error/417.html");

                        oHttpContext.Server.ClearError();

                        break;

                }
            }
            //Response.Redirect("~/Error");

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}