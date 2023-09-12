using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N36_HT2
{
    public class ExamScore
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public int Score { get; set; }
        public ExamScore(Guid userId, int score)
        { 
            Id = Guid.NewGuid();
            UserId = userId;
            Score = score;
        }
        public override string ToString() 
        {
            return $"Id: {Id}\nUser Id: {UserId}\nScore {Score}";
        }
    }
}
