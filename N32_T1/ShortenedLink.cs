using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N32_T1
{
    public class ShortenedLink
    {
        public Guid Id { get; set; }
        public string OriginalUrl { get; set; }
        public string ShortenedUrl { get; set; }
        public override int GetHashCode()
        {
            return OriginalUrl.GetHashCode() + ShortenedUrl.GetHashCode();
        }
        public override bool Equals(object? obj)
        {
            return GetHashCode() == obj.GetHashCode();
        }
        public ShortenedLink(string o, string s)
        {
            Id = Guid.NewGuid();
            OriginalUrl = o;
            ShortenedUrl = s;
        }
    }
}
