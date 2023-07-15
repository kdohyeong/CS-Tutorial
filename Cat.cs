using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuteCat 
{
    public class Cat
    {
        public string Name;
        public int Age;

        private int Happiness = 50;

        public Cat(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        
        }

        public void GetBored() {
            Happiness = Happiness - 10;
            
            if (Happiness < 0)
                Happiness = 0;
        }
        public void Play()
        {
            Happiness = Happiness + 10;
           
            if (Happiness > 100)  
                Happiness = 100; 
        }

        public void Eat()
        {
            Happiness = Happiness + 20;

            if (Happiness > 100)
                Happiness = 100;
        }

        public string Express()
        {
            string message = "";

            if (Happiness >= 80)
                message = "I'm very happy";
            else if (Happiness >= 60)
                message = "I'm happy";
            else if (Happiness >= 40)
                message = "I'm so so.";
            else if (Happiness >= 20)
                message = "I'm groomy.";
            else
                message = "I'm very sad.";

            return this.Name + ": " + message;
        }
    }
}
