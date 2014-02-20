using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace inBloom_2.Utilities
{
    public class RandomGPA
    {
        private static Random random = new Random((int)DateTime.Now.Ticks);
        public double doRandomGPA()
        {

            int first = random.Next(4);
            int second = random.Next(9);
            string randomGPAX = first.ToString() + "." + second.ToString();
            return Convert.ToDouble(randomGPAX);
        }
    }
}