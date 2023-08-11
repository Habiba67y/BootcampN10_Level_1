using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N22_HT2.Model
{
    public class CrashReport : IReview
    {
        public Guid Id { get; set; }
        private byte _star;
        public byte Star
        {
            get
            {
                return _star;
            }
            set
            {
                if (value >= 1 && value <= 5)
                {
                    _star = value;
                }
            }
        }
        public string Message { get; set; }
        public string Screenshot { get; set; }
        public CrashReport(byte star, string message) 
        {
            Id = Guid.NewGuid();
            Star = star;
            Message = message;
        }
        public override string ToString()
        {
            return $"Star: {Star}\nMessage: {Message}\nScreenshot: {Screenshot}";
        }
    }
}
