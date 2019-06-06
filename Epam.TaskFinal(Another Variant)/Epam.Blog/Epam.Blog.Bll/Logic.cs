using System.Linq;
using System.Web.WebPages;

namespace Epam.Blog.Bll
{
    public class Logic
    {
        private static WebPageRenderingBase Page
        {
            get
            {
                return WebPageContext.Current.Page;
            }
        }

        public static string FriendlyName
        {
            get
            {
                if (Mode != "new")
                {
                    return Page.UrlData[1];
                }
                return string.Empty;
            }
        }


        public static string Mode
        {
            get
            {
                if (Page.UrlData.Any())
                {
                    return Page.UrlData[0].ToLower();
                }
                return string.Empty;
            }
        }
    }
}
