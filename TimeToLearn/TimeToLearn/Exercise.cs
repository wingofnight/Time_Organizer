using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeToLearn
{
    public class Exercise
    {
        public string name;
        public int coast;
        public float time;

        public float allTime;
        public float coastTime;
        public int SumRaito;

        public float realTime;
        public float timeToDay;

        public Exercise()
        {

        }

        public Exercise(string name, int coast, float allTime, int SumRaito)
        {
            this.name = name;
            this.coast = coast;
            this.allTime = allTime;
            this.SumRaito = SumRaito;
            hawMuchTime();
        }

        public void hawMuchTime(float allTime, int SumRaito)
        {
            coastTime = allTime / SumRaito;
            time = coast * coastTime;
            realTime = 60 * time;
            timeToDay = realTime / 7;
        }
        public void hawMuchTime()
        {
            coastTime = allTime / SumRaito;
            time = coast * coastTime;
        }

    }
}
