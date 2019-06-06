using Epam.Blog.Dal;
using Epam.Blog.Entities;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.WebPages;

namespace Epam.Blog.Bll
{
    public class TagBll
    {
        private readonly TagDal tagDal = new TagDal();
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public IEnumerable<Tag> SelectAllFromTagById(int id)
        {
            logger.Trace("Success");
            return tagDal.SelectAllFromTagById(id);
        }

        public IEnumerable<Tag> SelectAllFromTagByUrlFriendlyName(string urlFriendlyName)
        {
            logger.Trace("Success");
            return tagDal.SelectAllFromTagByUrlFriendlyName(urlFriendlyName);
        }

        public IEnumerable<Tag> GetAllTags(string orderBy = null, string where = null)
        {
            logger.Trace("Success");
            return tagDal.GetAllTags(orderBy, where);
        }

        public void NewTag(string name, string friendlyName)
        {
            logger.Trace("Success");
            tagDal.NewTag(name, friendlyName);
        }

        public void UpdateTag(int id, string name, string friendlyName)
        {
            logger.Trace("Success");
            tagDal.UpdateTag(id, name, friendlyName);
        }

        public void DeleteTagByUrlFriendlyName(string urlFriendlyName)
        {
            logger.Trace("Success");
            tagDal.DeleteTagByUrlFriendlyName(urlFriendlyName);
        }

        private WebPageRenderingBase Page
        {
            get
            {
                logger.Trace("Success");
                return WebPageContext.Current.Page;
            }
        }

        public string Mode
        {
            get
            {
                if (Page.UrlData.Any())
                {
                    logger.Trace(Page.UrlData[0].ToLower());
                    return Page.UrlData[0].ToLower();
                }
                logger.Trace("Success");
                return string.Empty;
            }
        }

        public string FriendlyName
        {
            get
            {
                if (Mode != "new")
                {
                    logger.Trace("New");

                    return Page.UrlData[1];
                }
                logger.Trace("Success");

                return string.Empty;
            }
        }

        public Tag Current
        {
            get
            {

                var result = tagDal.SelectAllFromTagByUrlFriendlyName(FriendlyName);
                logger.Trace("Success");

                return result.Count() != 0 ? result.First() : CreateTagObject();


            }
        }

        private Tag CreateTagObject()
        {
            Tag obj = new Tag();
            obj.Id = 0;
            obj.Name = string.Empty;
            obj.UrlFriendlyName = string.Empty;
            logger.Trace("Success");

            return obj;
        }
    }

}
