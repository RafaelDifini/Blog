using System.Collections.Generic;
using System.Linq;
using Blog.Models;
using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog.Repositories
{
    public class TagRepository : Repository<Tag>
    {
        public TagRepository(SqlConnection connection) : base(connection)
                    => Database.Connection = connection;

        public List<Tag> ListTagWithPosts()
        {
            var query = @"
                SELECT
                    [Tag].*,
                    [Post].*
                FROM
                    [Tag]
                    LEFT JOIN [PostTag] ON [PostTag].[TagId] = [Tag].[Id]
                    LEFT JOIN [Post] ON [PostTag].[PostId] = [Post].[Id]";
            var tags = new List<Tag>();
            var items = Database.Connection.Query<Tag, Post, Tag>(
                query,
                (tag, post) =>
                {
                    var tg = tags.FirstOrDefault(x => x.Id == tag.Id);
                    if (tg == null)
                    {
                        tg = tag;
                        if (post != null)
                            tg.Posts.Add(post);

                        tags.Add(tag);
                    }
                    else
                        tg.Posts.Add(post);

                    return tag;
                }, splitOn: "Id");
            return tags;
        }
    }
}