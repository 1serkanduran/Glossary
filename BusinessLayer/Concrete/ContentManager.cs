using BusinessLayer.Abstract;
using DataAcsessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ContentManager : IContentService
    {
        IContentDal _contentDal;

        public ContentManager(IContentDal _contentdal)
        {
            _contentDal = _contentdal;
        }

        public void ContentAddBL(Content content)
        {
            _contentDal.Insert(content);
        }

        public void ContentDeleteBL(Content content)
        {
            throw new NotImplementedException();
        }

        public void ContentUpdateBL(Content content)
        {
            throw new NotImplementedException();
        }

        public Content GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<Content> GetList(string p)
        {
            return _contentDal.List(x=>x.ContentValue.Contains(p)); // arama işlemi
        }

        public List<Content> GetListByID(int id)
        {
            return _contentDal.List(x => x.HeadingID == id); //başlığa göre içeriklerin listelenmesi
        }

        public List<Content> GetListByWriter(int id)
        {
            return _contentDal.List(x => x.WriterID== id); // yazara göre içeriklerin listelenmesi
        }
    }
}
