using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryBrandDal:IBrandDal
    {
        private List<Brand> _brans;

        public InMemoryBrandDal()
        {
            _brans = new List<Brand>
            {
                new Brand{Id = 1,BrandName = "BMW"},
                new Brand{Id = 2,BrandName = "Mercedes"},
                new Brand{Id = 3,BrandName = "Ford"},
                new Brand{Id = 4,BrandName = "Audi"}
            };

        }

        public List<Brand> GetAll()
        {
            return _brans;
        }

        public List<Brand> GetAll(Expression<Func<Brand, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Brand Get(Expression<Func<Brand, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Add(Brand brand)
        {
            _brans.Add(brand);
        }

        public void Update(Brand brand)
        {
            Brand brandToUPdate = _brans.SingleOrDefault(x => x.Id == brand.Id);
            brandToUPdate.BrandName = brand.BrandName;
        }

        public void Delete(Brand brand)
        {
            Brand brandToDelete = _brans.SingleOrDefault(x => x.Id == brand.Id);
            _brans.Remove(brandToDelete);

        }

        public List<Brand> GetById(int brandId)
        {
            return _brans.Where(x => x.Id == brandId).ToList();
        }
    }
}
