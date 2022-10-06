using System.Collections.Generic;
using System.Linq;
using Blog.Models;
using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog.Repositories
{
    public class UserRepository : Repository<User>
    {
        //private readonly SqlConnection _connection;

        public UserRepository(SqlConnection connection) : base(connection)
            => Database.Connection = connection;

        public List<User> ListWithRole()
        {
            var query = @"
                SELECT
                    [User].*,
                    [Role].*
                FROM
                    [User]
                    LEFT JOIN [UserRole] ON [UserRole].[UserId] = [User].[Id]
                    LEFT JOIN [Role] ON [UserRole].[RoleId] = [Role].[Id]";

            var users = new List<User>();
            var items = Database.Connection.Query<User, Role, User>(
                query,
                (user, role) =>
                {
                    var usr = users.FirstOrDefault(x => x.Id == user.Id);
                    if (usr == null)
                    {
                        usr = user;
                        if (role != null)
                            usr.Roles.Add(role);

                        users.Add(usr);
                    }
                    else
                        usr.Roles.Add(role);

                    return user;
                }, splitOn: "Id");
            return users;
        }
        public void AddRoleInUser(int userId, int roleId)
        {
            var userRepository = new Repository<User>(Database.Connection);
            var user = userRepository.Get(userId);
            var roleRepository = new Repository<Role>(Database.Connection);
            var role = roleRepository.Get(roleId);
            var query = @"
                INSERT INTO [UserRole]
                VALUES(@userId,@roleId)";
            var userRole = Database.Connection.Execute(query, new
            {
                userId = user.Id,
                roleId = role.Id
            });
            System.Console.WriteLine($"{userRole} linhas inseridas");
        }
    }
}