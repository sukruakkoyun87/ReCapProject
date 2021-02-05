using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryColorDal:IColorDal
    {
        private List<Color> _colors;

        public InMemoryColorDal()
        {
            _colors = new List<Color>
            {
                new Color {Id = 1, ColorName = "Siyah"},
                new Color {Id = 2, ColorName = "Beyaz"},
                new Color {Id = 3, ColorName = "Kırmızı"},
                new Color {Id = 4, ColorName = "Mavi"}
            };
        }

        public List<Color> GetAll()
        {
            return _colors;
        }

        public List<Color> GetAll(Expression<Func<Color, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Color Get(Expression<Func<Color, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Add(Color color)
        {
            _colors.Add(color);
        }

        public void Update(Color color)
        {
            Color colorToUpdate = _colors.SingleOrDefault(x => x.Id == color.Id);
            colorToUpdate.ColorName = color.ColorName;
        }

        public void Delete(Color color)
        {
            Color colorToUpdate = _colors.SingleOrDefault(x => x.Id == color.Id);
            _colors.Remove(colorToUpdate);
        }

        public List<Color> GetById(int colorId)
        {
            return _colors.Where(x => x.Id == colorId).ToList();
        }
    }
}
