using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace N17_HT1
{
    internal class CarRentalManagement
    {
        public List<CarRental> Cars { get; set; }
       
        public void Add(CarRental car)
        {
            Cars.Add(car);
        }
        public async void Rent(string brandName)
        {
            foreach (var c in Cars)
            {
                if (c.BrandName==brandName)
                {
                    c.RentStartTime = DateTime.Now;
                    c.isRented = true;
                    await Task.Delay(1000 * c.RentStartTime.Second);
                    return;
                }
            }
            Console.WriteLine("Uzr, hozirda ijaraga moshina yo'q");
        }
        public void Return(CarRental car)
        {
            foreach (var c in Cars)
            {
                if (car.Id == c.Id)
                {
                    c.isRented = false;
                    if (car is Bmw bmw)
                    {
                        bmw.Balance = bmw.RentPricePerHour * (DateTime.Now - bmw.RentStartTime).Seconds;
                        Console.WriteLine(bmw.Balance);
                    }
                    if (car is Audi audi)
                    {
                        audi.Balance = audi.RentPricePerHour * (DateTime.Now - audi.RentStartTime).Seconds;
                        Console.WriteLine(audi.Balance);
                    }
                    return;
                }
            }
        }
        public void CalculateBalance()
        {
            var sum = 0f;
            foreach (var c in Cars)
            {
                sum+=c.Balance;
            }
            Console.WriteLine("All balaces: $" + sum);
        }
        public CarRentalManagement()
        {
            Cars = new List<CarRental>();
        }
    }
}