using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental
{
    class Car :BaseClass
    {
        public string Brand { get; set; }

        public string Model { get; set; }

        public  List<String> CarType { get; set; }
     
        public string FuelType { get; set; }
        
        
    }
}
