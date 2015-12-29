using CarRental.Model;
using CarRental.Service.Interface;
using CarRental.Service.Static.Common;
using System.Collections.Generic;

namespace CarRental.Service.Static
{
    public class RenterServiceAsync : DomainServiceAsync<Renter>, IRenterServiceAsync
    {
        private readonly List<Renter> entities = new List<Renter>();

        protected override List<Renter> GetEntities()
        {
            return entities;
        }
    }
}
