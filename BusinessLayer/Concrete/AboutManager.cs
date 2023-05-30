using BusinessLayer.Abstract;
using DataAcsessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AboutManager : IAboutService
    {
        IAboutDal _aboutdal;
        public AboutManager(IAboutDal aboutdal )
        {
            _aboutdal = aboutdal;
        }
        public void AboutAddBL(About about)
        {
            _aboutdal.Insert(about);
        }

        public void AboutDeleteBL(About about)
        {
            _aboutdal.Update(about);
        }

        public void AboutUpdateBL(About about)
        {
            _aboutdal.Update(about);
        }

        public About GetById(int id)
        {
            return _aboutdal.Get(x => x.AboutID == id);
        }

        public List<About> GetList()
        {
            return _aboutdal.List();
        }
    }
}
