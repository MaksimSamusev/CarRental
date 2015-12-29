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
    public class OrderServiceAsync : DomainServiceAsync<Order>, IOrderServiceAsync
    {
        private readonly List<Order> entities = new List<Order>();

        protected override List<Order> GetEntities()
        {
            return entities;
        }
    }
}
