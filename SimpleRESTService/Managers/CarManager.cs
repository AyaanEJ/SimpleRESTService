using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using ObligatoriskOpgave_Car;

namespace SimpleRESTService.Managers
{
    public class CarManager
    {
        public static int _nextId = 1;

        public static readonly List<Car> Data = new List<Car>()
        {
            new Car{id = _nextId++, Model = "BMW 7-Series 750Li", Price = 650000, LicensePlate = "QD76001"},
            new Car{id = _nextId++, Model = "Audi e-tron GT", Price = 900000, LicensePlate = "XB10225"},
            new Car{id = _nextId++, Model = "Mercedes-Benz SL-Class SL 63 AMG", Price = 1500000, LicensePlate = "MB63123"},
            new Car{id = _nextId++, Model = "Lamborghini Huracan", Price = 920000, LicensePlate = "LH92510"},
        };

        public List<Car> GetAllCars(int? maxPrice) // "?" betyder den gerne må være 0
        {
            {
                if (maxPrice != 0)
                {
                    return Data.FindAll(car => car.Price <= maxPrice);
                }
                else return new List<Car>(Data);
            }
        }
        // return specific Car from the List
            public Car GetById(int id)
            {
                return Data.Find(Car => Car.id == id);
            }
            
            //adds a new Car to the list
            public Car Add(Car newCar)
            {
                newCar.id = _nextId++;
                Data.Add(newCar);
                return newCar;
            }
             
            //deletes the Car from the List
            public Car Delete(int id)
            {
                Car _car = Data.Find(Car => Car.id == id);
                if (_car == null) return null;
                Data.Remove(_car);
                return _car;
            }
        }
    }

