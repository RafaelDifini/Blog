using System;
using Blog.Models;
using Blog.Repositories;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Balta
{
    public class Metodos

    {
        //ROLE METHODS
        public static void ListWithRole(SqlConnection connection)
        {
            var repository = new UserRepository(connection);
            var users = repository.ListWithRole();

            foreach (var user in users)
            {
                Console.WriteLine(user.Email);
                foreach (var role in user.Roles) Console.WriteLine($" - {role.Slug}");
            }
        }
        public static void ReadRoles(Repository<Role> repository)
        {
            var items = repository.GetAll();

            foreach (var item in items)
                System.Console.WriteLine(item.Name);
        }
        //TAG METHODS
        public static void ReadTags(Repository<Tag> repository)
        {
            var items = repository.GetAll();

            foreach (var item in items)
                System.Console.WriteLine(item.Name);
        }
        //USER METHODS
        public static void ReadUsers(Repository<User> repository)
        {
            var users = repository.GetAll();
            foreach (var item in users)
                Console.WriteLine(item.Email);
        }
        public static void ReadUser(Repository<User> repository)
        {
            var user = repository.Get(2);
            Console.WriteLine(user?.Email);
        }
        public static void CreateUser(Repository<User> repository)
        {
            var user = new User
            {
                Bio = "Equipe StarLink",
                Email = "Ellon@tesla.io",
                Image = "https://starlink.com",
                Name = "Ellon Musk",
                Slug = "ellon-musk",
                PasswordHash = Guid.NewGuid().ToString()
            };

            repository.Create(user);

        }
        public static void UpdateUser(Repository<User> repository)
        {
            var user = repository.Get(2);
            user.Email = "Ellon@tesla.com";
            repository.Update(user);

            Console.WriteLine(user?.Email);
        }
        public static void DeleteUser(Repository<User> repository)
        {
            var user = repository.Get(5);
            repository.Delete(user);
            System.Console.WriteLine("Exclusão realizado com sucesso");
        }

        // public static void ReadUser()
        // {
        //     using (var connection = new SqlConnection(CONNECTION_STRING))
        //     {
        //         var user = connection.Get<User>(1);

        //         System.Console.WriteLine(user.Name);
        //     }
        // }
        // public static void CreateUser()
        // {
        //     var user = new User
        //     {
        //         Bio = "Equipe RafaelDifini",
        //         Email = "SuporteRafa@gmail.com",
        //         Image = "https://...",
        //         Name = "Equipe Rafael Difini",
        //         PasswordHash = "HASH",
        //         Slug = "equipe-rafa"

        //     };
        //     using (var connection = new SqlConnection(CONNECTION_STRING))
        //     {
        //         connection.Insert<User>(user);
        //         System.Console.WriteLine("Cadastro realizado com sucesso");
        //     }
        // }
        // public static void UpdateUser()
        // {
        //     var user = new User
        //     {
        //         Id = 2,
        //         Bio = "Equipe | RafaelDifini",
        //         Email = "SuporteRafa@gmail.com",
        //         Image = "https://...",
        //         Name = "Equipe de suporte Rafael Difini",
        //         PasswordHash = "HASH",
        //         Slug = "equipe-rafa"

        //     };
        //     using (var connection = new SqlConnection(CONNECTION_STRING))
        //     {
        //         connection.Update<User>(user);
        //         System.Console.WriteLine("Atualização realizado com sucesso");
        //     }
        // }
        // public static void DeleteUser()
        // {

        //     using (var connection = new SqlConnection(CONNECTION_STRING))
        //     {
        //         var user = connection.Get<User>(2);
        //         connection.Delete<User>(user);
        //         System.Console.WriteLine("Exclusão realizado com sucesso");
        //     }
        // }
    }
}
