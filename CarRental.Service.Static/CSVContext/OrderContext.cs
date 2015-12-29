using CarRental.Model;
using CarRental.Service.Static.CSVContext.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Service.Static.CSVContext
{
    public class OrderContext : ICSVContext<Order>
    {
        private string next = ";";
        private string _path = @"orders.csv";
        private string context;
        /*
         * UserId=this.UserId,
                CarId=this.CarId,
                RenterId=this.RenterId,
                StartDate=this.StartDate,
                ReturnDate=this.ReturnDate,
                Cost=this.Cost*/
        public void Add(Order item)
        {
            using (StreamWriter file = new StreamWriter(_path))
            {
                context = item.Id + next + item.UserId.ToString() + next + item.RenterId.ToString() + next + item.StartDate.ToString() + next + item.ReturnDate.ToString() + next + item.Cost.ToString();
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

        public List<Order> Get()
        {
            string[] _context = File.ReadAllLines(_path);
            List<Order> oreders = new List<Order>();
            for (int i = 0; i < _context.Length; i++)
            {
                string[] record = _context[i].Split(';');
                oreders.Add(new Order
                {
                    Id = int.Parse(record[0]),
                    UserId=int.Parse(record[1]),
                    RenterId = int.Parse(record[2]),
                    StartDate = DateTime.Parse(record[3]),
                    ReturnDate = DateTime.Parse(record[4]),
                    Cost = int.Parse(record[5])
                 });
            }
            return oreders;
        }

        public Order Get(int id)
        {
            Order oreder = new Order();
            string[] _context = File.ReadAllLines(_path);
            for (int i = 0; i < _context.Length; i++)
            {
                string[] record = _context[i].Split(';');
                if (id == int.Parse(record[0]))
                {
                    oreder = new Order
                    {
                        Id = int.Parse(record[0]),
                        UserId = int.Parse(record[1]),
                        RenterId = int.Parse(record[2]),
                        StartDate = DateTime.Parse(record[3]),
                        ReturnDate = DateTime.Parse(record[4]),
                        Cost = int.Parse(record[5])
                    };
                }
            }
            return oreder;
        }

    }
}
