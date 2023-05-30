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
    public class AdminManager : IAdminService
    {
        IAdminDal _admindal;

        public AdminManager(IAdminDal admindal)
        {
            _admindal = admindal;
        }

        public void AdminUpdateBL(Admin admin)
        {
            _admindal.Update(admin);
        }

        public void AdminDeleteBL(Admin admin)
        {
            _admindal.Update(admin);
        }

        public void AdminAddBL(Admin admin)
        {
            _admindal.Insert(admin);
        }

        public Admin GetByID(int id)
        {
            return _admindal.Get(x=>x.AdminID==id);
        }

        public List<Admin> GetList()
        {
            return _admindal.List();
        }
    }
}
