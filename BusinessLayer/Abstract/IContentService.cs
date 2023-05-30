using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IContentService
    {
        List<Content> GetList(string p); //arama işlemi için
        List<Content> GetListByWriter(int id); // yazara göre başlık içeriklerini getirme
        List<Content> GetListByID(int id); //başlığa göre içerikleri getirme
        void ContentAddBL(Content content);
        Content GetByID(int id);

        void ContentDeleteBL(Content content);
        void ContentUpdateBL(Content content);
    }
}
