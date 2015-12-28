using CarRental.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Model
{
     public class Car :BaseClass
    {
        public string Brand { get; set; }

        public string Model { get; set; }

        public  string CarType { get; set; }
     
        public string FuelType { get; set; }


        public override object Clone()
        {
            return new Car
            {
                Id = this.Id,
                Brand=this.Brand,
                Model=this.Model,
                CarType=this.CarType,
                FuelType=this.FuelType
            };
        }
        
    }
}
