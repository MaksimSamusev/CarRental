using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental
{
    class Renter:BaseClass
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int PassportId { get; set; }

        public string Address { get; set; }
    }

}
