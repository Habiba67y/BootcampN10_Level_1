using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N36_HT2
{
    public class ExamScoreService
    {
        public List<ExamScore> scores;
        public ExamScoreService()
        {
            scores = new List<ExamScore>();
        }
        public void Create(Guid id, int score)
        {
            scores.Add(new ExamScore(id, score));
        }
        public void Read()
        {
            scores.ForEach(Console.WriteLine);
        }
        public ExamScore? Update(ExamScore score)
        {
            var examScore = scores.FirstOrDefault(x => x.Id == score.Id);
            if (examScore != null) 
            {
                examScore.UserId = score.UserId;
                examScore.Score = score.Score;
            }
            return examScore;
        }
        public ExamScore? Delete(Guid id)
        {
            var score = scores.FirstOrDefault(x => x.Id == id);
            if(score != null)
                scores.Remove(score);
            return score;
        }
    }
}
