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
        public int Calories { get; set; }
        public int Protein { get; set; }
        public int Carbs { get; set; }
        public int Fats { get; set; }
        public int Fiber { get; set; }
        public DateTime EatDate { get; set; }

        public Meal(int id, string name, int calories, int protein, int carbs, int fats, int fiber, DateTime eatdate)
        {
            Id = id;
            Name = name;
            Calories = calories;
            Protein = protein;
            Carbs = carbs;
            Fats = fats;
            Fiber = fiber;
            EatDate = eatdate;
        }
        public Meal()
        {
            
        }

        public override string ToString()
        {
            return Name;
        }
        public string ToJson()
        {
            return "{ \"Id\": " + Id + ", \"EatDate\": \""+ EatDate +"\", \"Name\": \"" + Name + "\", \"Calories\": " + Calories + ", \"Protein\": " + Protein + ", \"Carbs\": " + Carbs + ", \"Fats\": " + Fats + ", \"Fiber\": " + Fiber + "}";
        }
    }
}
