using BusinessLayer.Abstract;
using DataAcsessLayer.Abstract;
using DataAcsessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class HeadingManager : IHeadingService
    {
        IHeadingDal _headingdal;
        public HeadingManager(IHeadingDal headingdal)
        {
            _headingdal= headingdal;
        }
        public Heading GetById(int id)
        {
            return _headingdal.Get(x => x.HeadingID == id);
        }

        public List<Heading> GetList()
        {
            return _headingdal.List();
        }

        public List<Heading> GetListByWriter(int id)
        {
            return _headingdal.List(x => x.WriterID ==id);
        }

        public void HeadingAddBL(Heading heading)
        {
            _headingdal.Insert(heading); 
        }
        public void HeadingDelete(Heading heading)
        {
            _headingdal.Update(heading);
        }
        public void HeadingUpdate(Heading heading)
        {
            _headingdal.Update(heading);
        }
    }
}
