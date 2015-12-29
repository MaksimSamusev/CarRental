using CarRental.Model.Common;
using System;

namespace CarRental.Model
{
    public class Order:BaseClass
    {
        public int UserId { get; set; }
        public int CarId { get; set; }
        public int RenterId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public int Cost { get; set; }
        public override object Clone()
        {
            return new Order
            {
                Id = this.Id,
                UserId=this.UserId,
                CarId=this.CarId,
                RenterId=this.RenterId,
                StartDate=this.StartDate,
                ReturnDate=this.ReturnDate,
                Cost=this.Cost
            };
        }
    }
}
