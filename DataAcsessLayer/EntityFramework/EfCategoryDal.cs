using DataAcsessLayer.Abstract;
using DataAcsessLayer.Concrete.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataAcsessLayer.EntityFramework
{
    public class EfCategoryDal: GenericRepository<Category>,ICategoryDal
    {
    }
}