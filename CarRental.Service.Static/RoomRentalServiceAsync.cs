using CarRental.Model;
using CarRental.Service.Interface;
using CarRental.Service.Static.Common;
using System.Collections.Generic;

namespace CarRental.Service.Static
{
    public class RoomRentalServiceAsync : DomainServiceAsync<RoomRental>, IRoomRentalServiceAsync
    {
        private readonly List<RoomRental> entities = new List<RoomRental>();

        protected override List<RoomRental> GetEntities()
        {
            return entities;
        }
    }
}
