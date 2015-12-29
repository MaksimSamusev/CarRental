using CarRental.Model;
using CarRental.Service.Static.CSVContext.Common;
using System.Collections.Generic;
using System.IO;

namespace CarRental.Service.Static.CSVContext
{
    public class CarContext : ICSVContext<Car>
    {
        private string next = ";";
        private string _path = @"cars.csv";
        private string context;
        public void Add(Car item)
        {
            using (StreamWriter file = new StreamWriter(_path))
            {
                context = item.Id + next + item.Brand +next+ item.Model+ next + item.CarType + next + item.FuelType;
                file.WriteLine(context);
            }

        }

        public void Delete(int id)
        {
            using (StreamWriter file = new StreamWriter(_path, false))
            {
                string[] _context = File.ReadAllLines(_path);
                for (int i = 0; i < _context.Length; i++)
                {
                    string[] record = _context[i].Split(';');

                    if (int.Parse(record[0]) == id)
                    {
                        _context[i] = "";
                    }
                    if (_context[i] != "") file.WriteLine(_context[i]);
                }
            }


        }

        public List<Car> Get()
        {
            string[] _context = File.ReadAllLines(_path);
            List<Car> cars = new List<Car>();
            for (int i = 0; i < _context.Length; i++)
            {
                string[] record = _context[i].Split(';');
                cars.Add(new Car
                {
                    Id = int.Parse(record[0]),
                    Brand = record[1],
                    Model=record[2],
                    CarType=record[3],
                    FuelType=record[4]
                 });
            }
            return cars;
        }

        public Car Get(int id)
        {
            Car car = new Car();
            string[] _context = File.ReadAllLines(_path);
            for (int i = 0; i < _context.Length; i++)
            {
                string[] record = _context[i].Split(';');
                if (id == int.Parse(record[0]))
                {
                    car = new Car
                    {
                        Id = int.Parse(record[0]),
                        Brand = record[1],
                        Model = record[2],
                        CarType = record[3],
                        FuelType = record[4]
                    };
                }
            }
            return car;
        }

    }
}
