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
    public class RoleServiceAsync : DomainServiceAsync<Role>, IRoleServiceAsync
    {
        private readonly List<Role> entities = new List<Role>();

        protected override List<Role> GetEntities()
        {
            return entities;
        }
    }
}
