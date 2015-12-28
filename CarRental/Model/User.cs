using CarRental.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Model
{
     public class User : BaseClass
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public DateTime DateOfAdd { get; set; }
        public DateTime LastVisit { get; set; }
        public int FavoriteID { get; set; }

        public override object Clone()
        {
            return new User
            {
                Id = this.Id,
                Login = this.Login,
                Password = this.Password,
                DateOfAdd = this.DateOfAdd,
                LastVisit = this.LastVisit
            };
        }
    }
}
