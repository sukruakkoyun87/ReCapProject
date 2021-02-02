using System;
using System.Collections.Generic;
using System.Linq;
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
                new Color {ColorId = 1, ColorName = "Siyah"},
                new Color {ColorId = 2, ColorName = "Beyaz"},
                new Color {ColorId = 3, ColorName = "Kırmızı"},
                new Color {ColorId = 4, ColorName = "Mavi"}
            };
        }

        public List<Color> GetAll()
        {
            return _colors;
        }

        public void Add(Color color)
        {
            _colors.Add(color);
        }

        public void Update(Color color)
        {
            Color colorToUpdate = _colors.SingleOrDefault(x => x.ColorId == color.ColorId);
            colorToUpdate.ColorName = color.ColorName;
        }

        public void Delete(Color color)
        {
            Color colorToUpdate = _colors.SingleOrDefault(x => x.ColorId == color.ColorId);
            _colors.Remove(colorToUpdate);
        }

        public List<Color> GetById(int colorId)
        {
            return _colors.Where(x => x.ColorId == colorId).ToList();
        }
    }
}
