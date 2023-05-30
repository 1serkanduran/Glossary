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
    public class WriterManager : IWriterService
    {
        IWriterDal _writerdal;
        public WriterManager(IWriterDal writerDal)
        {
            _writerdal = writerDal;
        }
        public Writer GetById(int id)
        {
            return _writerdal.Get(x=>x.WriterID == id);
        }

        public List<Writer> GetList()
        {
            return _writerdal.List();
        }

        public void WriterAddBL(Writer writer)
        {
            _writerdal.Insert(writer);
        }

        public void WriterDeleteBL(Writer writer)
        {
            _writerdal.Delete(writer);
        }

        public void WriterUpdateBL(Writer writer)
        {
            _writerdal.Update(writer);
        }
    }
}
