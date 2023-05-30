﻿using BusinessLayer.Abstract;
using DataAcsessLayer.Abstract;
using DataAcsessLayer.Concrete.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categorydal;

        public CategoryManager(ICategoryDal categorydal)
        {
            _categorydal = categorydal;
        }

        public void CategoryAddBL(Category category)
        {
            _categorydal.Insert(category);
        }

        public void CategoryDeleteBL(Category category)
        {
            _categorydal.Delete(category);
        }

        public void CategoryUpdateBL(Category category)
        {
            _categorydal.Update(category);
        }

        public Category GetByID(int id)
        {
           return _categorydal.Get(x=>x.CategoryID==id);
        }

        public List<Category> GetList()
        {
            return _categorydal.List();
        }
        
    }
}
