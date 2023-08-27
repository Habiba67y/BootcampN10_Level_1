using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N32_T3
{
    public class Product
    {
        public Guid Id { get; init; } = Guid.NewGuid();
        private string _name;
        private string _description;
        public string Name { get => _name;
            private set 
            {
                if (string.IsNullOrWhiteSpace(value))
                   throw new Exception("Invalid name");


                _name = value;
            } }
        public string Description { get => _description; 
            private set 
            {
                if (string.IsNullOrWhiteSpace(value))
                   throw new Exception("Invalid description");


                _description = value;
            } }
        public Product(string name, string description)
        {
            Name = name;
            Description = description;
        }
        public Product(Product obj)
        {
            Id = obj.Id;
            _name = obj.Name;
            _description = obj.Description;
        }
        public override string ToString() 
        {
            return $"Name: {Name}\nDescription: {Description}\n";
        }
    }
}
