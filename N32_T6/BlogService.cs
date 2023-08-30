using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N32_T6
{
    public class BlogService
    {
        public List<Blog> blogs;
        public BlogService() 
        {
            blogs = new List<Blog>
            {
                new Blog("title1", "body1"),
                new Blog("title2", "body2"),
                new Blog("title3", "body3"),
            };
        }
        public Blog Create(Blog blog)
        {
            if (!Validate(blog))
                throw new ValidationException("Invalid blog!");
            return blog;
        }
        public Blog Get(Guid Id)
        {
            if (blogs.FirstOrDefault(x => x.Id == Id) is null)
                throw new ArgumentOutOfRangeException("Bunday blog mavjud emas!");
            return blogs.FirstOrDefault(x => x.Id == Id);
        }
        public void Update(Blog blog)
        {
            if (!Validate(blog))
                throw new ValidationException("Invalid blog!");
            var b = blogs.FirstOrDefault(x => x.Id == blog.Id);
            if (!Validate(b))
                throw new InvalidOperationException("Invalid blog!");
            b.Title = blog.Title;
            b.Body = blog.Body;
        }
        public void Delete(Guid Id)
        {
            var blog = blogs.FirstOrDefault(x => x.Id == Id);
            if (blog is null)
                throw new ArgumentOutOfRangeException("Bunday blog mavjud emas!");
            blogs.Remove(blog);
        }
        private bool Validate(Blog blog)
        {
            if(string.IsNullOrWhiteSpace(blog.Title) || string.IsNullOrWhiteSpace(blog.Body))
                return false;
            return true;
        }
    }
}
