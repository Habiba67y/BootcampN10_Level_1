using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace N22_HT2.Model
{
    public class ReviewList<TReview>: IEnumerable<TReview>, IReviewList<TReview> where TReview: IReview
    {
        private readonly List<TReview> _reviewList = new List<TReview>();
        public void Add(TReview review)
        {
            _reviewList.Add(review);
        }
        public void Update(Guid id, byte star, string message)
        {
            foreach (var item in _reviewList)
            {
                if (item.Id == id)
                {
                    item.Message = message;
                    item.Star=star;
                }
            }
        }
        public void Remove(Guid id)
        {
            foreach (var item in _reviewList)
            {
                if (item.Id == id)
                {
                    _reviewList.Remove(item);
                }
            }
        }
        public void Remove(TReview review)
        {
            foreach (var item in _reviewList)
            {
                if (EqualityComparer<TReview>.Default.Equals(item, review))
                {
                    _reviewList.Remove(item);
                }
            }
        }
        public TReview GetReview(Guid id)
        {
            foreach (var item in _reviewList)
            {
                if(item.Id==id)
                {
                    return item;
                }
            }
            return default(TReview);
        }
        public TReview GetReview(string message)
        {
            foreach (var item in _reviewList)
            {
                if (String.Equals(item.Message, message, StringComparison.OrdinalIgnoreCase))
                {
                    return item;
                }
            }
            return default(TReview);
        }
        public string GetOverallReview()
        {
            if (_reviewList.Count() == 0)
            {
                return "Be the first to leave a review for this product";
            }
            else
            {
                if (_reviewList.All(review => review.Star == 5))
                {
                    return "Great news! All reviews for this product are 5-star ratings.";
                }
                if (_reviewList.Any(review => review.Star == 1))
                {
                    return _reviewList.Where(review => review.Star == 1).ToList().First().Message;
                }
                return string.Empty;
            }
        }
        public IEnumerator<TReview> GetEnumerator()
        {
            return _reviewList.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _reviewList.GetEnumerator();
        }
    }
}
