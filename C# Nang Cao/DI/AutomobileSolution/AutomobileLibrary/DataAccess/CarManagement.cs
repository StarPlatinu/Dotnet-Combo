using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomobileLibrary.DataAccess
{
    internal class CarManagement
    {

        //Using Singleton pattern
        private static CarManagement instance = null;
        private static readonly object instanceLock = new object();
        private CarManagement() { }
        public static CarManagement Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new CarManagement();
                    }
                    return instance;
                }
            }
        }

        public IEnumerable<Car> GetCarList()
        {
            List<Car> cars;
            try
            {
                var myStockDB = new MyStockContext();
                cars = myStockDB.Cars.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return cars;
        }

        public Car GetCarById(int carID)
        {
            Car car = null;
            try
            {
                var myStockDB = new MyStockContext();
                car = myStockDB.Cars.SingleOrDefault(car => car.CarId == carID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            return (car);
        }

        public void AddNew(Car car)
        {
            try
            {
                Car _car = GetCarById(car.CarId);
                if (_car != null)
                {
                    var myStockDB = new MyStockContext();
                    myStockDB.Cars.Add(car);
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Update(Car car)
        {
            try
            {
                Car c = GetCarById(car.CarId);
                if (c != null)
                {
                    var myStockDB = new MyStockContext();
                    myStockDB.Entry<Car>(car).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    myStockDB.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        public void Remove(Car car)
        {
            try
            {
                Car _car = GetCarById(car.CarId);
                if (_car != null)
                {
                    var myStock = new MyStockContext();
                    myStock.Cars.Remove(car);
                    myStock.SaveChanges();
                }
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

      
    }

}
