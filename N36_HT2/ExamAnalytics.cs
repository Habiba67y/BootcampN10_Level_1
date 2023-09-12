using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N36_HT2
{
    public class ExamAnalytics
    {
        private UserService _userService;
        private ExamScoreService _examScoreService;
        public ExamAnalytics(UserService userService, ExamScoreService examScoreService)
        {
            _userService = userService;
            _examScoreService = examScoreService;
        }
        public IEnumerable<(string FullName, int Score)> GetScores()
        {
            var scores = new List<(string FullName, int Score)>();
            var userScores = _userService.users.Join(_examScoreService.scores, u => u.Id, s => s.UserId, (user, score) => new { User = user, Score = score });
            foreach (var item in userScores)
                scores.Add((FullName: $"{item.User.FirstName} {item.User.LastName}", Score: item.Score.Score));
            return scores;
        }
    }
}
