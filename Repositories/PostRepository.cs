using System.Collections.Generic;
using System.Linq;
using Blog.Models;
using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog.Repositories
{
    public class PostRepository : Repository<Post>
    {
        //private readonly SqlConnection _connection;

        public PostRepository(SqlConnection connection) : base(connection)
            => Database.Connection = connection;

        public List<Post> ListPostWithUser()
        {
            var query = @"
                SELECT 
                    [Post].*,
                    [User].*
                FROM
                    [Post]
                LEFT JOIN [User] ON [User].[Id] = [Post].[AuthorId]";
            var posts = new List<Post>();
            var items = Database.Connection.Query<Post, User, Post>(
                query,
                (post, user) =>
                {
                    var pst = posts.FirstOrDefault(x => x.Id == post.Id);
                    if (pst == null)
                    {
                        pst = post;
                        if (user != null)
                            pst.Author.Add(user);

                        posts.Add(post);
                    }
                    else
                        pst.Author.Add(user);

                    return post;
                }, splitOn: "Id");
            return posts;
        }
        public List<Post> ListPostWithTag()
        {
            var query = @"
                SELECT
                    [Post].*,
                    [Tag].*
                FROM
                    [Post]
                    LEFT JOIN [PostTag] ON [PostTag].[PostId] = [Post].[Id]
                    LEFT JOIN [Tag] ON [PostTag].[TagId] = [Tag].[Id]";
            var posts = new List<Post>();
            var items = Database.Connection.Query<Post, Tag, Post>(
                query,
                (post, tag) =>
                {
                    var pst = posts.FirstOrDefault(x => x.Id == post.Id);
                    if (pst == null)
                    {
                        pst = post;
                        if (tag != null)
                            pst.Tags.Add(tag);

                        posts.Add(post);
                    }
                    else
                        pst.Tags.Add(tag);

                    return post;
                }, splitOn: "Id");
            return posts;
        }
        public List<Post> ListPostWithCategory()
        {
            var query = @"
                SELECT
                    [Post].*,
                    [Category].*
                FROM
                    [Post]
                    INNER JOIN [Category] ON [CategoryId] = [Category].[Id]";
            var posts = new List<Post>();
            var items = Database.Connection.Query<Post, Category, Post>(
                query,
                (post, category) =>
                {
                    var pst = posts.FirstOrDefault(x => x.Id == post.Id);
                    if (pst == null)
                    {
                        pst = post;
                        if (category != null)
                            pst.Category.Add(category);

                        posts.Add(post);
                    }
                    else
                        pst.Category.Add(category);

                    return post;
                }, splitOn: "Id");
            return posts;
        }
        public void AddTagInPost(int postId, int tagId)
        {
            var postRepository = new Repository<Post>(Database.Connection);
            var post = postRepository.Get(postId);
            var tagRepository = new Repository<Tag>(Database.Connection);
            var tag = tagRepository.Get(tagId);
            var query = @"
                INSERT INTO [PostTag]
                VALUES(@postId,@tagId)";
            var postTag = Database.Connection.Execute(query, new
            {
                postId = post.Id,
                tagId = tag.Id
            });
            System.Console.WriteLine($"{postTag} linhas inseridas");
        }
    }
}