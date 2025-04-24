using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neutrition.Resources
{
    public class Meal
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<int> FoodsId { get; set; }
        public List<Food> Foods { get; set; } = new List<Food>();
        public int Calories { get { return Foods.Sum(x => x.Calories); } }
        public int Protein { get { return Foods.Sum(x => x.Protein); } }
        public int Carbs { get { return Foods.Sum(x => x.Carbs); } }
        public int Fats { get { return Foods.Sum(x => x.Fats); } }
        public int Fiber { get { return Foods.Sum(x => x.Fiber); } }

        public Meal(string name)
        {
            Name = name;
            Foods = new List<Food>();
            FoodsId = new List<int>();
        }

        public void AddFood(int foodId)
        {
            FoodsId.Add(foodId);
            Food food = Storage.Foods.FirstOrDefault(x => x.Id == foodId);
            if (food != null)
            {
                Foods.Add(food);
            }
        }

        public void RemoveFood(int foodId)
        {
            FoodsId.Remove(foodId);
            Food food = Foods.FirstOrDefault(x => x.Id == foodId);
            if (food != null)
            {
                Foods.Remove(food);
            }
        }
        public void ClearFoods()
        {
            Foods.Clear();
            FoodsId.Clear();
        }

        public string ToJson()
        {
            string jsonTxt = "{ \"Id\": " + Id + ", \"Name\": \"" + Name + "\", \"FoodsId\": [";
            foreach (int foodId in FoodsId)
            {
                jsonTxt += foodId + ",";
            }
            jsonTxt = jsonTxt.TrimEnd(',') + "] }";
            return jsonTxt;
        }
    }
}
