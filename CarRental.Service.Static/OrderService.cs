using CarRental.Model;
using CarRental.Service.Interface;
using CarRental.Service.Static.Common;
using CarRental.Service.Static.CSVContext;
using CarRental.Service.Static.CSVContext.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarRental.Service.Static
{
    public class OrderService :DomainService<Order>, IOrderService
    {
        private readonly ICSVContext<Order> _orderes = new OrderContext();
        protected override List<Order> GetEntities()
        {
            return _orderes.Get();
        }
    }
}
