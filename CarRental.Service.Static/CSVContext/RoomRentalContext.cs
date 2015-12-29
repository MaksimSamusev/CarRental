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
    public class RoomRentalContext : ICSVContext<RoomRental>
    {
        private string next = ";";
        private string _path = @"roomRentals.csv";
        private string context;
        /*
                 Id = this.Id,
                Address=this.Address,
                Phone=this.Phone,
                Cars =this.Cars,
         */
        public void Add(RoomRental item)
        {
            using (StreamWriter file = new StreamWriter(_path))
            {
                context = item.Id + next + item.Address+next+item.Phone.ToString();
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

        public List<RoomRental> Get()
        {
            string[] _context = File.ReadAllLines(_path);
            List<RoomRental> role = new List<RoomRental>();
            for (int i = 0; i < _context.Length; i++)
            {
                string[] record = _context[i].Split(';');
                role.Add(new RoomRental
                {
                    Id = int.Parse(record[0]),
                    Address = record[1],
                    Phone= int.Parse(record[2])
                });
            }
            return role;
        }

        public RoomRental Get(int id)
        {
            RoomRental role = new RoomRental();
            string[] _context = File.ReadAllLines(_path);
            for (int i = 0; i < _context.Length; i++)
            {
                string[] record = _context[i].Split(';');
                if (id == int.Parse(record[0]))
                {
                    role = new RoomRental
                    {
                        Id = int.Parse(record[0]),
                        Address = record[1],
                        Phone = int.Parse(record[2])
                    };
                }
            }
            return role;
        }

    }
}
