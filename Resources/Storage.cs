using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Neutrition.Resources
{
    public static class Storage
    {
        public static int fats { get { return AllMeal.Where(x => x.EatDate.Date == DateTime.Now.Date).Sum(x => x.Fats); } }
        public static int carbs { get { return AllMeal.Where(x => x.EatDate.Date == DateTime.Now.Date).Sum(x => x.Carbs); } }
        public static int protein { get { return AllMeal.Where(x => x.EatDate.Date == DateTime.Now.Date).Sum(x => x.Protein); } }
        public static int fiber { get { return AllMeal.Where(x => x.EatDate.Date == DateTime.Now.Date).Sum(x => x.Fiber); } }

        public static ObservableCollection<Meal> Meals { get; set; } = new ObservableCollection<Meal>();
        public static ObservableCollection<Meal> AllMeal { get; set; } = new ObservableCollection<Meal>();



        public static void SaveMeals(IEnumerable<Meal> meals, string path="")
        {
            string jsonTxt = "[";
            foreach (Meal meal in meals)
            {
                jsonTxt += meal.ToJson() + "\n";
                //if not last add ,
                if (meal != meals.Last())
                    jsonTxt += ",";
            }
            jsonTxt += "]";
            System.IO.File.WriteAllText($"Data/meals{path}.json", jsonTxt);
        }
        public static void LoadMeals()
        {
            string json = System.IO.File.ReadAllText("Data/mealsEaten.json");
            if (json == "")
            {
                return;
            }
            JsonDocument jsonArray = JsonSerializer.Deserialize<JsonDocument>(json);
            foreach (JsonElement meal in jsonArray.RootElement.EnumerateArray())
            {
                Meal newMeal = new Meal();
                newMeal.Id = meal.GetProperty("Id").GetInt32();
                newMeal.Name = meal.GetProperty("Name").GetString();
                newMeal.Calories = meal.GetProperty("Calories").GetInt32();
                newMeal.Protein = meal.GetProperty("Protein").GetInt32();
                newMeal.Carbs = meal.GetProperty("Carbs").GetInt32();
                newMeal.Fats = meal.GetProperty("Fats").GetInt32();
                newMeal.Fiber = meal.GetProperty("Fiber").GetInt32();
                AllMeal.Add(newMeal);
            }
        }
        public static void LoadEatenMeals() 
        {
            string json = System.IO.File.ReadAllText("Data/meals.json");
            if (json == "")
            {
                return;
            }
            JsonDocument jsonArray = JsonSerializer.Deserialize<JsonDocument>(json);
            foreach (JsonElement meal in jsonArray.RootElement.EnumerateArray())
            {
                Meal newMeal = new Meal();
                newMeal.Id = meal.GetProperty("Id").GetInt32();
                newMeal.Name = meal.GetProperty("Name").GetString();
                newMeal.Calories = meal.GetProperty("Calories").GetInt32();
                newMeal.Protein = meal.GetProperty("Protein").GetInt32();
                newMeal.Carbs = meal.GetProperty("Carbs").GetInt32();
                newMeal.Fats = meal.GetProperty("Fats").GetInt32();
                newMeal.Fiber = meal.GetProperty("Fiber").GetInt32();
                Meals.Add(newMeal);
            }
        }
    }
}
