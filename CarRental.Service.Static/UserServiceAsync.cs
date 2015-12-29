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
    public class UserServiceAsync : DomainServiceAsync<User>, IUserServiceAsync
    {
        private readonly List<User> entities = new List<User>();

        protected override List<User> GetEntities()
        {
            return entities;
        }
    }
}