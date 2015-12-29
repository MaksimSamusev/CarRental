using CarRental.Model;
using CarRental.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Service.Static
{
    public class RenterService : IRenterService
    {
        private readonly List<Renter> _renters = new List<Renter>();
        public Renter Add(Renter item)
        {
            var newRenter = (Renter)item.Clone();
            newRenter.Id = !_renters.Any() ? 1 : _renters.Max(renter => renter.Id) + 1;
            _renters.Add(newRenter);
            return (Renter)newRenter.Clone();
        }
        public void Delete(int id)
        {
            var existRenter = _renters.SingleOrDefault(renter => renter.Id == id);
            if (existRenter == null)
            {
                throw new NullReferenceException();
            }
            _renters.Remove(existRenter);
        }
        public List<Renter> Get()
        {
            return _renters.
                Select(item => (Renter)item.Clone()).ToList();
        }

        public Renter Get(int id)
        {
            var car = _renters.SingleOrDefault(item => item.Id == id);
            return car == null ? null : (Renter)car.Clone();
        }

        public Renter Update(Renter item)
        {
            var existRenter = _renters.SingleOrDefault(renter => renter.Id == item.Id);
            if (existRenter == null)
            {
                throw new NullReferenceException();
            }
            existRenter.FirstName = item.FirstName;
            return (Renter)existRenter.Clone();
        }
    }
}
