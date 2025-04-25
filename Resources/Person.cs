using System;
using Neutrition;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Neutrition.Resources
{
    public class Person
    {
        public string Name { get; set; }
        public int StartWeight { get; set; }
        public int CurWeight { get; set; }
        public int GoalWeight { get; set; }
        public int Height { get; set; }
        public int Age { get; set; }
        public DateTime BirthDate { get; set; }
        public string BirthDateFormatted { get { return BirthDate.ToString("yyyy-MM-dd"); } }
        
        public DateTime StartDate { get; set; }
        public float ActivityLevel { get; set; }
        public double BMI { get
            {
                return StartWeight / Math.Pow((double)Height/100, 2);
            } }
        public DateTime GoalDate { get; set; }
        //Mifflin-St Jeor Equation
        public float TDEE { get {  return ((float)(10 * CurWeight + 6.25 * Height - 5 * Age + 5))*ActivityLevel; } }
        public float DailyCaloricIntake { get { return TDEE - (((CurWeight-GoalWeight)*7700)/ (GoalDate - DateTime.Now.Date).Days); } }

        public void Init()
        {

            string json = File.ReadAllText("Data/person.json");
            JsonDocument jsonArray = JsonSerializer.Deserialize<JsonDocument>(json);
            Name = jsonArray.RootElement.GetProperty("Name").GetString();
            if(Name == "")
            {
                //show window
                Register newPerson = new Register();
                newPerson.ShowDialog();
                if(newPerson.DialogResult == false)
                {
                    Application.Current.Shutdown();
                }
                else
                {
                    Name = newPerson.Person.Name;
                    StartWeight = newPerson.Person.StartWeight;
                    CurWeight = StartWeight;
                    GoalWeight = newPerson.Person.GoalWeight;
                    Height = newPerson.Person.Height;
                    //ActivityLevel = newPerson.Person.ActivityLevel;
                    ActivityLevel = 1.2f;
                    //GoalDate = newPerson.Person.GoalDate;
                    GoalDate = DateTime.Now.AddDays((CurWeight - GoalWeight) * 7700 / DailyCaloricIntake);
                    BirthDate = newPerson.Person.BirthDate;
                    Age = DateTime.Now.Year - BirthDate.Year;
                    StartDate = DateTime.Now.Date;
                    SaveToJson();
                }

            }
            else
            {
                LoadFromJson();
            }

        }

        public void SaveToJson()
        {
            JsonObject json = new JsonObject();
            json["Name"] = Name;
            json["StartWeight"] = StartWeight;
            json["CurWeight"] = CurWeight;
            json["GoalWeight"] = GoalWeight;
            json["Height"] = Height;
            json["ActivityLevel"] = ActivityLevel;
            json["GoalDate"] = GoalDate.ToString("yyyy-MM-dd");
            json["BirthDate"] = BirthDate.ToString("yyyy-MM-dd");
            json["StartDate"] = StartDate.ToString("yyyy-MM-dd");
            File.WriteAllText("Data/person.json", json.ToJsonString());
        }

        public void LoadFromJson()
        {
            string json = File.ReadAllText("Data/person.json");
            JsonDocument jsonArray = JsonSerializer.Deserialize<JsonDocument>(json);
            Name = jsonArray.RootElement.GetProperty("Name").GetString();
            StartWeight = jsonArray.RootElement.GetProperty("StartWeight").GetInt32();
            CurWeight = jsonArray.RootElement.GetProperty("CurWeight").GetInt32();
            GoalWeight = jsonArray.RootElement.GetProperty("GoalWeight").GetInt32();
            Height = jsonArray.RootElement.GetProperty("Height").GetInt32();
            ActivityLevel = jsonArray.RootElement.GetProperty("ActivityLevel").GetSingle();
            GoalDate = DateTime.Parse(jsonArray.RootElement.GetProperty("GoalDate").GetString());
            BirthDate = DateTime.Parse(jsonArray.RootElement.GetProperty("BirthDate").GetString());
            StartDate = DateTime.Parse(jsonArray.RootElement.GetProperty("StartDate").GetString());
        }


    }
}
