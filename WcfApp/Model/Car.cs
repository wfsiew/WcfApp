using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WcfApp.Model
{
    public class Car
    {
        public int ID { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public int Doors { get; set; }
        public string Colour { get; set; }
        public double Price { get; set; }
    }
}