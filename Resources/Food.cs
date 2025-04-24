using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neutrition.Resources
{
    public class Food
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Calories { get; set; }
        public int Protein { get; set; }
        public int Carbs { get; set; }
        public int Fats { get; set; }
        public int Fiber { get; set; }
        public Food()
        {

        }

        public string ToJson()
        {
            return "{ \"Id\": " + Id + ", \"Name\": \"" + Name + "\", \"Calories\": " + Calories + ", \"Protein\": " + Protein + ", \"Carbs\": " + Carbs + ", \"Fats\": " + Fats + ", \"Fiber\": " + Fiber + "}";
        }
    }
}
