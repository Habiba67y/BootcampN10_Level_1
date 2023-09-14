using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace N38
{
    public class Medicine
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public DateOnly ExpirationDate { get; set; }
        public int Count { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set;}
        public Medicine(string name, float price, DateOnly expirationDate, int count, string decription)
        {
            Id = Guid.NewGuid();
            Name = name;
            Price = price;
            ExpirationDate = expirationDate;
            Count = count;
            Description = decription;
        }
        public override string ToString() 
        {
            return $"\nName: {Name}\nPrice: {Price}\nExpiration date: {ExpirationDate}\nCount: {Count}\nDescription: {Description}\nCreated at: {CreatedAt}\nUpdated at: {UpdatedAt}";
        }
    }
}
