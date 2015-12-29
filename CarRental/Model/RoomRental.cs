using CarRental.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Model
{
    public class RoomRental : BaseClass
    {
        public string Address { get; set; }
        public int Phone { get; set; }
        public List<Car> Cars { get; set; }
        public override object Clone()
        {
            return new RoomRental
            {
                Id = this.Id,
                Address=this.Address,
                Phone=this.Phone,
                Cars =this.Cars,
                
            };
        }
    }
}
