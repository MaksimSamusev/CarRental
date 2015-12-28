using CarRental.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Model
{
    public class Role : BaseClass
    {
        public string RoleType { get; set; }

        public int UserID { get; set; }
        public override object Clone()
        {
            return new Role
            {
                RoleType = this.RoleType,
                UserID = this.UserID,
                Id = this.Id
            };
        }
    }
}
