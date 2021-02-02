using System;
using System.Collections.Generic;
using System.Linq;
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
                new Brand{BrandId = 1,BrandName = "BMW"},
                new Brand{BrandId = 2,BrandName = "Mercedes"},
                new Brand{BrandId = 3,BrandName = "Ford"},
                new Brand{BrandId = 4,BrandName = "Audi"}
            };

        }

        public List<Brand> GetAll()
        {
            return _brans;
        }

        public void Add(Brand brand)
        {
            _brans.Add(brand);
        }

        public void Update(Brand brand)
        {
            Brand brandToUPdate = _brans.SingleOrDefault(x => x.BrandId == brand.BrandId);
            brandToUPdate.BrandName = brand.BrandName;
        }

        public void Delete(Brand brand)
        {
            Brand brandToDelete = _brans.SingleOrDefault(x => x.BrandId == brand.BrandId);
            _brans.Remove(brandToDelete);

        }

        public List<Brand> GetById(int brandId)
        {
            return _brans.Where(x => x.BrandId == brandId).ToList();
        }
    }
}
