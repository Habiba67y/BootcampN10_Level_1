using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N24_T2
{
    public class MovieService
    {
        public List<Movie> movies = new List<Movie>();
        public List<Movie> Search(string name, string author)
        {
            return movies.Where(
                movie => movie.Name.Contains(name, StringComparison.OrdinalIgnoreCase)
                                && movie.Author.Contains(author, StringComparison.OrdinalIgnoreCase)
                                ).ToList();
        }
        public void Add(string name, string author, int rating)
        {
            if (movies.Find(movie => movie.Name == name && movie.Author == author) == null)
            {
                movies.Add(new Movie { Name = name, Author = author, Rating = rating });
            }
        }
        public List<Movie> GetByRating(int pageSize, int pageToken)
        {
            var mov = movies.OrderByDescending(movie=> movie.Rating).ToList();
            return mov.Skip((pageToken-1)*pageSize).Take(pageSize).ToList();
        }
    }
}
