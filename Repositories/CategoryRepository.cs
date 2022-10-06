using System.Collections.Generic;
using System.Linq;
using Blog.Models;
using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog.Repositories
{
    public class CategoryRepository : Repository<Category>
    {
        public CategoryRepository(SqlConnection connection) : base(connection)
            => Database.Connection = connection;
        public List<Category> ListCategoryWithPosts()
        {
            var query = @"
                SELECT
                    [Category].*,
                    [Post].*
                FROM
                    [Post]
                    RIGHT JOIN [Category] ON [CategoryId] = [Category].[Id]";
            var categories = new List<Category>();
            var items = Database.Connection.Query<Category, Post, Category>(
                query,
                (category, post) =>
                {
                    var ctgr = categories.FirstOrDefault(x => x.Id == category.Id);
                    if (ctgr == null)
                    {
                        ctgr = category;
                        if (post != null)
                            ctgr.Posts.Add(post);

                        categories.Add(category);
                    }
                    else
                        ctgr.Posts.Add(post);

                    return category;
                }, splitOn: "Id");
            return categories;
        }
    }
}