using BusinessLayer.Abstract;
using DataAcsessLayer.Abstract;
using DataAcsessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ContactManager : IContactService
    {
        IContactDal _contactdal;
        public ContactManager(IContactDal contactdal)
        {
            _contactdal = contactdal;
        }

        public void Add(Contact contact)
        {
            _contactdal.Insert(contact);
        }

        public void Delete(Contact contact)
        {
            _contactdal.Delete(contact);
        }

        public List<Contact> GetAll()
        {
            return _contactdal.List();
        }

        public Contact GetById(int id)
        {
            return _contactdal.Get(x => x.ContactID == id);
        }

        public void Update(Contact contact)
        {
            _contactdal.Update(contact);
        }
    }
}
