using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N16_HT1
{
    internal class Spaceship
    {
        private float _fuel;
        private float _trajectory;
        public float Trajectory { set => _trajectory = value; } //write-only
        public float Speed { get; set; } // read-write
        public float Fuel { get => _fuel; } //read-only
        public string Name { get; init; } //init-only
        public Spaceship(string name, float fuel,  float speed, float trajectory)
        {
            Name = name;
            _fuel = fuel;
            Speed = speed;
            Trajectory = trajectory;
        }
    }
}
