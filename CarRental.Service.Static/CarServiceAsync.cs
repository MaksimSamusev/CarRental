using CarRental.Model;
using CarRental.Service.Interface;
using CarRental.Service.Static.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Service.Static
{
    public class CarServiceAsync : DomainServiceAsync<Car>, ICarServiceAsync
    {
        private readonly List<Car> entities = new List<Car>();

        protected override List<Car> GetEntities()
        {
            return entities;
        }
    }
}
