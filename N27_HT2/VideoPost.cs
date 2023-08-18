using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N27_HT2
{
    public class VideoPost
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Likes { get; set; }
        public int DisLikes { get; set; }
        public Topics Topic { get; set; }
        public VideoPost(string title, string description, int likes, int disLikes, Topics topic)
        {
            Id = Guid.NewGuid();
            Title = title;
            Description = description;
            Likes = likes;
            DisLikes = disLikes;
            Topic = topic;
        }
        public override string ToString()
        {
            return $"Title: {Title}\nDescription: {Description}\nLikes: {Likes}\nDislike {DisLikes}\nTopic: {Topic}\n";
        }
    }
}
