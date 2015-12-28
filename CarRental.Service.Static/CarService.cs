using CarRental.Model;
using CarRental.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Service.Static
{
    class CarService : ICarService
    {
        private readonly List<Car> _cars = new List<Car>();
        public Car Add(Car item)
        {
            var newCar = (Car)item.Clone();
            newCar.Id = !_cars.Any() ? 1 : _cars.Max(car => car.Id) + 1;
            _cars.Add(newCar);
            return (Car)newCar.Clone();
        }
        public void Delete(int id)
        {
            var rentalCar = _cars.SingleOrDefault(car => car.Id == id);
            if (rentalCar == null)
            {
                throw new NullReferenceException();
            }
            _cars.Remove(rentalCar);
        }
        public List<Car> Get()
        {
            return _cars.
                Select(item => (Car)item.Clone()).ToList();
        }

        public Car Get(int id)
        {
            var car = _cars.SingleOrDefault(item => item.Id == id);
            return car == null ? null : (Car)car.Clone();
        }

        public Car Update(Car item)
        {
            var returnCar = _cars.SingleOrDefault(car => car.Id == item.Id);
            if (returnCar == null)
            {
                throw new NullReferenceException();
            }
            returnCar.Brand = item.Brand;
            return (Car)returnCar.Clone();
        }
    }
}
