using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N28_HT2.Models
{
    public class StorageFile: ICloneable
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Size { get; set; }

        public object Clone()
        {
            return MemberwiseClone();
        }
        public StorageFile(string name, string description, int size)
        {
            Id = Guid.NewGuid();
            Name = name;
            Description = description;
            Size = size;
        }
        public override string ToString() 
        {
            return $"Id: {Id}\nName: {Name}\nDescription: {Description}\nSize: {Size}\n";
        }
    }
}
