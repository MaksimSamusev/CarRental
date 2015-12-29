using CarRental.Model;
using CarRental.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Service.Static
{
    public class RoomRentalService : IRoomRentalService
    {
        private readonly List<RoomRental> _roomRentals = new List<RoomRental>();
        public RoomRental Add(RoomRental item)
        {
            var newRoomRental = (RoomRental)item.Clone();
            newRoomRental.Id = !_roomRentals.Any() ? 1 : _roomRentals.Max(car => car.Id) + 1;
            _roomRentals.Add(newRoomRental);
            return (RoomRental)newRoomRental.Clone();
        }
        public void Delete(int id)
        {
            var existRoomRental = _roomRentals.SingleOrDefault(roomRental => roomRental.Id == id);
            if (existRoomRental == null)
            {
                throw new NullReferenceException();
            }
            _roomRentals.Remove(existRoomRental);
        }
        public List<RoomRental> Get()
        {
            return _roomRentals.
                Select(item => (RoomRental)item.Clone()).ToList();
        }

        public RoomRental Get(int id)
        {
            var car = _roomRentals.SingleOrDefault(item => item.Id == id);
            return car == null ? null : (RoomRental)car.Clone();
        }

        public RoomRental Update(RoomRental item)
        {
            var existRoomRental = _roomRentals.SingleOrDefault(roomRental => roomRental.Id == item.Id);
            if (existRoomRental == null)
            {
                throw new NullReferenceException();
            }
            existRoomRental.Address = item.Address;
            return (RoomRental)existRoomRental.Clone();
        }
    }
}
