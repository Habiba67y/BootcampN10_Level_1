using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N16_HT2
{
    internal class SmartHomeService
    {
        private List<Temperature> temperatures = new List<Temperature>();
        private bool _isActivated = false;
        private float _currentTemperature;
        public bool IsActivated { get => _isActivated; }
        public string  DeviceName { get; init; }
        public float CurrentTemperature { set
            {
                _currentTemperature = value;
                temperatures.Add(new Temperature(ExpectedTemperature, _currentTemperature));
            }
        }
        public float ExpectedTemperature { get; set; }
        public SmartHomeService(string deviceName) 
        {
            DeviceName = deviceName;
        }
        public void Activate()
        {
            _isActivated = true;
        }
        public void DisplayHomeTemperature()
        {
            if (_isActivated == true)
            {
                foreach (var t in temperatures)
                {
                    Console.WriteLine($"Expected temperature: {t.et} <-> Current Temperature: {t.ct}");
                }
            }
        }
    }
}
