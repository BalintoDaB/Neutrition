using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Neutrition.Resources
{
    public static class Storage
    {
        public static int fats { get { return Meals.Where(x => x.EatDate.Date == DateTime.Now.Date).Sum(x => x.Fats); } }
        public static int carbs { get { return Meals.Where(x => x.EatDate.Date == DateTime.Now.Date).Sum(x => x.Carbs); } }
        public static int protein { get { return Meals.Where(x => x.EatDate.Date == DateTime.Now.Date).Sum(x => x.Protein); } }
        public static int fiber { get { return Meals.Where(x => x.EatDate.Date == DateTime.Now.Date).Sum(x => x.Fiber); } }

        public static List<Food> Foods { get; set; } = new List<Food>();
        public static List<Meal> Meals { get; set; } = new List<Meal>();

        public static void Init()
        {
            Foods = new List<Food>();
            Meals = new List<Meal>();
        }

        public static void SaveFoods()
        {
            string jsonTxt = "[";
            foreach (Food food in Foods)
            {
                jsonTxt += food.ToJson() + "\n";
                //if not last add ,
                if (food != Foods.Last())
                    jsonTxt += ",";
            }
            jsonTxt += "]";
            System.IO.File.WriteAllText("Data/foods.json", jsonTxt);
        }
        public static void LoadFoods()
        {
            string json = System.IO.File.ReadAllText("Data/foods.json");
            if(json == "")
            {
                return;
            }
            JsonDocument jsonArray = JsonSerializer.Deserialize<JsonDocument>(json);
            foreach (JsonElement food in jsonArray.RootElement.EnumerateArray())
            {
                Food newFood = new Food();
                newFood.Id = food.GetProperty("Id").GetInt32();
                newFood.Name = food.GetProperty("Name").GetString();
                newFood.Calories = food.GetProperty("Calories").GetInt32();
                newFood.Protein = food.GetProperty("Protein").GetInt32();
                newFood.Carbs = food.GetProperty("Carbs").GetInt32();
                newFood.Fats = food.GetProperty("Fats").GetInt32();
                newFood.Fiber = food.GetProperty("Fiber").GetInt32();
                Foods.Add(newFood);
            }
        }
        public static void SaveMeals()
        {
            string jsonTxt = "[";
            foreach (Meal meal in Meals)
            {
                jsonTxt += meal.ToJson() + "\n";
                //if not last add ,
                if (meal != Meals.Last())
                    jsonTxt += ",";
            }
            jsonTxt += "]";
            System.IO.File.WriteAllText("Data/meals.json", jsonTxt);
        }

        public static void LoadMeals() 
        { 
            string json = System.IO.File.ReadAllText("Data/meals.json");
            if(json == "")
            {
                return;
            }
            JsonDocument jsonArray = JsonSerializer.Deserialize<JsonDocument>(json);
            foreach (JsonElement meal in jsonArray.RootElement.EnumerateArray())
            {
                string name = meal.GetProperty("Name").GetString();
                DateTime EatTime = DateTime.Parse(meal.GetProperty("EatDate").GetString());
                Meal newMeal = new Meal(name, EatTime);
                List<int> foodIds = meal.GetProperty("FoodsId").EnumerateArray()
                    .Select(id => id.GetInt32())
                    .ToList();
                foreach (int Id in foodIds)
                {
                    newMeal.AddFood(Id);
                }

                Meals.Add(newMeal);
            }
        }
    }
}
