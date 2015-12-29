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
    public class RenterContext : ICSVContext<Renter>
    {
        private string next = ";";
        private string _path = @"renters.csv";
        private string context;
        /* 
                Id = this.Id,
                FirstName=this.FirstName,
                LastName=this.LastName,
                PassportId=this.PassportId,
                Address=this.Address
         */
        public void Add(Renter item)
        {
            using (StreamWriter file = new StreamWriter(_path))
            {
                context = item.Id + next + item.FirstName + next + item.LastName + next + item.PassportId.ToString() + next + item.Address;
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

        public List<Renter> Get()
        {
            string[] _context = File.ReadAllLines(_path);
            List<Renter> renters = new List<Renter>();
            for (int i = 0; i < _context.Length; i++)
            {
                string[] record = _context[i].Split(';');
                renters.Add(new Renter
                {
                    Id = int.Parse(record[0]),
                    FirstName=record[1],
                    LastName=record[2],
                    PassportId=int.Parse(record[3]),
                    Address=record[5]
                  
                });
            }
            return renters;
        }

        public Renter Get(int id)
        {
            Renter oreder = new Renter();
            string[] _context = File.ReadAllLines(_path);
            for (int i = 0; i < _context.Length; i++)
            {
                string[] record = _context[i].Split(';');
                if (id == int.Parse(record[0]))
                {
                    oreder = new Renter
                    {
                        Id = int.Parse(record[0]),
                        FirstName = record[1],
                        LastName = record[2],
                        PassportId = int.Parse(record[3]),
                        Address = record[5]
                    };
                }
            }
            return oreder;
        }

    }
}

