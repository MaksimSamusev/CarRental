using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CarRental.Model;
using CarRental.Service.Interface;
using System.Linq;

namespace CarRental.Service.Static.Test.AsyncTests
{
    [TestClass]
    public class StudentGroupServiceAsyncTests
    {
        private readonly ICarServiceAsync service;

        public StudentGroupServiceAsyncTests()
        {
            this.service = new CarServiceAsync();

            service.AddAsync(new Car
            {
                Brand="Audi",
                Model="C4S4",
                CarType="sport",
                FuelType = "benzine"
                
            }).Wait();

            service.AddAsync(new Car
            {
                Brand = "BMW",
                Model = "M5",
                CarType = "sport",
                FuelType = "benzine"
            }).Wait();
        }

        [TestMethod]
        public void AddTest()
        {
            var brand = Guid.NewGuid().ToString();
            var model = Guid.NewGuid().ToString();
            var typ = Guid.NewGuid().ToString();
            var fuelType = Guid.NewGuid().ToString();

            var newGroup = new Car
            {
                Brand = brand,
                Model = model,
                CarType = typ,
                FuelType = fuelType
            };

            var addedGroupTask = service.AddAsync(newGroup);

            var addedGroup = addedGroupTask.Result;

            Assert.IsNotNull(addedGroup);
            Assert.IsTrue(addedGroup.Id > 0);
            Assert.AreEqual(addedGroup.Brand, brand);
            Assert.AreEqual(addedGroup.Model, model);
            Assert.AreEqual(addedGroup.CarType, typ);
            Assert.AreEqual(addedGroup.FuelType, fuelType);
        }

        [TestMethod]
        public void GetByIdTest()
        {
            var group = service.GetAsync(1).Result;

            Assert.IsNotNull(group);
            Assert.AreEqual(group.Id, 1);
        }
        
        [TestMethod]
        public void GetByIdEditTest()
        {
            var group = service.GetAsync(1).Result;
            var brand= group.Brand;
            var model = group.Model;
            var typ = group.CarType;
            var fuelType = group.FuelType;
            group.Brand = Guid.NewGuid().ToString();
            var newGroup = service.GetAsync(1).Result;
            Assert.AreEqual(newGroup.Brand, brand);
            Assert.AreEqual(newGroup.Model, model);
            Assert.AreEqual(newGroup.CarType, typ);
            Assert.AreEqual(newGroup.FuelType, fuelType);
        }

        [TestMethod]
        public void GetByIdNotFoundTest()
        {
            var group = service.GetAsync(int.MaxValue).Result;

            Assert.IsNull(group);
        }

        [TestMethod]
        public void GetAllTest()
        {
            var groupList = service.GetAsync().Result;

            Assert.IsNotNull(groupList);
            Assert.IsTrue(groupList.Count > 0);
        }

        [TestMethod]
        public void UpdateTest()
        {
            var group = service.GetAsync().Result.First();

            group.Brand = "Mersedes";

            service.UpdateAsync(group).Wait();

            var updatedGroup = service.GetAsync(group.Id).Result;

            Assert.IsNotNull(updatedGroup);
            Assert.AreEqual(updatedGroup.Brand, group.Brand);
        }

        [TestMethod]
        [ExpectedException(typeof(AggregateException))]
        public void UpdateNotFoundTest()
        {
            service.UpdateAsync(new Car
            {
                Id = int.MaxValue
            }).Wait();
        }

        [TestMethod]
        public void DeleteTest()
        {
            var group = service.GetAsync().Result.Last();
            service.DeleteAsync(group.Id).Wait();

            var deletedGroup = service.GetAsync(group.Id).Result;

            Assert.IsNull(deletedGroup);
        }

        [TestMethod]
        [ExpectedException(typeof(AggregateException))]
        public void DeleteNotFoundTest()
        {
            service.DeleteAsync(int.MaxValue)
                .Wait();
        }
    }
}
