using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N5
{
    public class student
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public DateTime BirthDay { get; set; }
        public int Payment { get; set; }
        public string EduType { get; set; }
        public int PaymentAmount { get; set; }
        public int getAge()
        {
            return DateTime.Now.Year-BirthDay.Year;
        }

        public void GetTable(string e)
        {
            if (EduType == e)
            {
                if (Payment < PaymentAmount)
                {
                    Console.WriteLine($"{Id}.\t{FullName.PadRight(45, ' ')}\t{Payment}\t\t{ PaymentAmount}\t\t{PaymentAmount - Payment}(haqdor)");
                }

                else if (Payment > PaymentAmount)
                {
                    Console.WriteLine($"{Id}.\t{FullName.PadRight(45, ' ')}\t{Payment}\t\t{PaymentAmount}\t\t{Payment - PaymentAmount}(qarzdor)");
                }
                else
                {
                    Console.WriteLine($"{Id}.\t{FullName.PadRight(45, ' ')}\t{Payment}\t\t{PaymentAmount}\t\t{PaymentAmount - Payment}");
                }
            }
        }
        
    }
}
