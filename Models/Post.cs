using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace Blog.Models
{
    [Table("[Post]")]
    public class Post
    {
        public Post()
        {
            Author = new List<User>();
            Tags = new List<Tag>();
            Category = new List<Category>();
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public string Body { get; set; }
        public string Slug { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastUpdateDate { get; set; }

        public int AuthorId { get; set; }
        [Write(false)]
        public List<User> Author { get; set; }

        public int CategoryId { get; set; }
        [Write(false)]
        public List<Category> Category { get; set; }

        [Write(false)]
        public List<Tag> Tags { get; set; }
    }
}