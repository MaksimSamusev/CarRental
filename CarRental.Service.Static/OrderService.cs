using CarRental.Model;
using CarRental.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarRental.Service.Static
{
    public class OrderService : IOrderService
    {
        private readonly List<Order> _orders = new List<Order>();
        public Order Add(Order item)
        {
            var newOredr = (Order)item.Clone();
            newOredr.Id = !_orders.Any() ? 1 : _orders.Max(order => order.Id) + 1;
            _orders.Add(newOredr);
            return (Order)newOredr.Clone();
        }
        public void Delete(int id)
        {
            var delOreder = _orders.SingleOrDefault(order => order.Id == id);
            if (delOreder == null)
            {
                throw new NullReferenceException();
            }
            _orders.Remove(delOreder);
        }
        public List<Order> Get()
        {
            return _orders.
                Select(item => (Order)item.Clone()).ToList();
        }

        public Order Get(int id)
        {
            var order = _orders.SingleOrDefault(item => item.Id == id);
            return order == null ? null : (Order)order.Clone();
        }

        public Order Update(Order item)
        {
            var renewOrder = _orders.SingleOrDefault(order => order.Id == item.Id);
            if (renewOrder == null)
            {
                throw new NullReferenceException();
            }
            renewOrder.Id = item.Id;
            return (Order)renewOrder.Clone();
        }
    }
}
