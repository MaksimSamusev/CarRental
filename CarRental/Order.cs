using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental
{
    class Order : BaseClass
    {
        public int UserId { get; set; }

        public int CarId { get; set; }

        public int RenterId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime ReturnDate { get; set; }

        public int Cost { get; set; }
    }
}
