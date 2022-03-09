using Microsoft.VisualStudio.TestTools.UnitTesting;
using ObligatoriskOpgave_Car;
using SimpleRESTService.Managers;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleRESTService.Managers.Tests
{
    [TestClass()]
    public class CarManagerTests
    {
        private CarManager _cman;
        
        [TestInitialize]
        public void Setup()
        {
            _cman = new CarManager();
        }

        [TestMethod()]
        public void GetAllCarsTest()
        {
            List<Car> cars = _cman.GetAllCars(1500000);
            foreach (Car c in cars)
            {
                Assert.IsTrue(c.Price <= 1500000);
            }
        }

        [TestMethod()]
        public void TestGetAll()
        {
            Assert.AreEqual(_cman.GetAllCars(1500000).Count, 5);
        }
        [TestMethod()]
         public void GetByIdTest()
         {
            Assert.IsTrue(_cman.GetById(1).Model.Equals("BMW 7-Series 750Li"));
            Assert.IsNull(_cman.GetById(20));
         }
         [TestMethod()]
        public void AddTest()
        {
            int beforeAddCount = _cman.GetAllCars(400000).Count;
            int defaultId = 0;

            Car newCar = new Car(defaultId, "Golf R", 400000, "CV56890");
            Car addResult = _cman.Add(newCar);

            int newid= addResult.id;

            Assert.AreNotEqual(defaultId, newid);
            Assert.AreEqual(beforeAddCount + 1, _cman.GetAllCars(400000).Count);
        }

        [TestMethod()]
        public void DeleteTest()
        {
            int beforeAddCount = _cman.GetAllCars(400000).Count;
            int defaultId = 0;

            Car newCar = new Car(defaultId,"Golf R", 400000, "CV56890");
            Car addResult = _cman.Add(newCar);
            int newID = addResult.id;

            Car deletedCar = _cman.Delete(newID);

            Assert.AreEqual(beforeAddCount, _cman.GetAllCars(400000).Count);
            Assert.IsNull(_cman.Delete(10));

        }
    }
}