using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N38
{
    public class MedicineServcei
    {
        public List<Medicine> medicines = new List<Medicine>();
        public Guid Create(string name, float price, DateOnly date, int count, string description)
        {
            var medicine = new Medicine(name, price, date, count, description);
            medicines.Add(medicine);
            medicine.CreatedAt = DateTime.Now;
            return medicine.Id;
        }
        public IEnumerable<Medicine> Read()
        {
            return medicines;
        }
        public Medicine? Update(Medicine medicine)
        {
            var foundMedicine = medicines.FirstOrDefault(x => x.Id == medicine.Id);
            if (foundMedicine != null)
            {
                foundMedicine.Name = medicine.Name;
                foundMedicine.Price = medicine.Price;
                foundMedicine.ExpirationDate = medicine.ExpirationDate;
                foundMedicine.Count = medicine.Count;
                foundMedicine.Description = medicine.Description;
                foundMedicine.UpdatedAt = DateTime.Now;
            }
            return foundMedicine;
        }
        public bool Delete(Guid id) 
        {
            var medicine = medicines.FirstOrDefault(x => x.Id == id);
            if (medicine != null)
            {
                medicines.Remove(medicine);
                return true;
            }
            return false;
        }
        public bool Sell(Guid id)
        {
            var medicine = medicines.FirstOrDefault(x => x.Id == id);
            if (medicine != null)
            {
                medicine.Count -= 1;
                return true;
            }
            return false;
        }
        public bool Get(Medicine medicine) 
        {
            var foundMedicine = medicines.FirstOrDefault(x => x.Id == medicine.Id);
            if (foundMedicine != null)
            {
                foundMedicine.Count += 1;
                return true;
            }
            return false;
        }
    }
}
