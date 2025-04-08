using Neutrition.Windows;
using System;
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
        public float StartWeight { get; set; }
        public float CurWeight { get; set; }
        public float GoalWeight { get; set; }
        public float Height { get; set; }
        public int Age { get; set; }
        public float ActivityLevel { get; set; }
        public DateTime GoalDate { get; set; }
        //Mifflin-St Jeor Equation
        public float TDEE { get {  return ((float)(10 * CurWeight + 6.25 * Height - 5 * Age + 5))*ActivityLevel; } }
        public float DailyCaloricIntake { get { return TDEE - (((CurWeight-GoalWeight)*7700)/ (GoalDate - DateTime.Now.Date).Days); } }

        public void Init()
        {
            //Read person.json from Data/person.json
            //Deserialize it to Person object
            //Set the properties of the Person object

            string json = File.ReadAllText("Data/person.json");
            JsonDocument jsonArray = JsonSerializer.Deserialize<JsonDocument>(json);
            Name = jsonArray.RootElement.GetProperty("Name").GetString();
            if(Name == "")
            {
                //show window
                NewPerson newPerson = new NewPerson();
                newPerson.ShowDialog();
                if(newPerson.DialogResult == false)
                {
                    Application.Current.Shutdown();
                }

            }

        }


    }
}
