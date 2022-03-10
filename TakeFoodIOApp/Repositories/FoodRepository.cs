using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TakeFoodIOApp.Data.Models;

namespace TakeFoodIOApp.Repositories
{
    public class FoodRepository
    {
        Context c = new Context();

        public void FoodAdd(Food f)
        {
            c.Foods.Add(f);
            c.SaveChanges();
        }

        public void FoodDelete(Food f)
        {
            c.Foods.Remove(f);
            c.SaveChanges();
        }

        public void FoodUpdate(Food f)
        {
            c.Foods.Update(f);
            c.SaveChanges();
        }

        public List<Food> FoodList()
        {
            return c.Foods.ToList();
        }

        public void GetFood(int id)
        {
            c.Foods.Find(id);
        }
    }
}
