using Epam.Blog.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Blog.Dal.Interface
{
    public interface ITagDal
    {
        IEnumerable<Tag> SelectAllFromTagById(int id);
        IEnumerable<Tag> SelectAllFromTagByUrlFriendlyName(string urlFriendlyName);
        IEnumerable<Tag> GetAllTags(string orderBy = null, string where = null);
        void NewTag(string name, string friendlyName);
        void UpdateTag(int id, string name, string friendlyName);
        void DeleteTagByUrlFriendlyName(string urlFriendlyName);

    }
}
