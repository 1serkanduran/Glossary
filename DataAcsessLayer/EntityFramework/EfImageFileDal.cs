using DataAcsessLayer.Abstract;
using DataAcsessLayer.Concrete.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcsessLayer.EntityFramework
{
    public class EfImageFileDal : GenericRepository<ImageFile>, IImageFileDal
    {
    }
}
