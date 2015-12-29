using CarRental.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Model
{
    public class Renter : BaseClass
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int PassportId { get; set; }
        public string Address { get; set; }
        public override object Clone()
        {
            return new Renter
            {
                Id = this.Id,
                FirstName=this.FirstName,
                LastName=this.LastName,
                PassportId=this.PassportId,
                Address=this.Address
            };
        }
    }

}
