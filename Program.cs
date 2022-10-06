using System;
using Blog;
using Blog.Models;
using Blog.Repositories;
using Blog.Screens;
using Blog.Screens.UserScreen;
using Blog.Screens.TagScreens;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;
using Blog.Screens.CategoryScreens;
using Blog.Screens.RoleScreens;

namespace Balta
{
    public class Program : Metodos
    {
        private const string CONNECTION_STRING = @"Server=localhost\SQLEXPRESS;Database=Blog;Trusted_Connection=True;Encrypt=False";
        static void Main(string[] args)
        {
            Database.Connection = new SqlConnection(CONNECTION_STRING);
            var repository = new Repository<User>(Database.Connection);
            var repositoryRole = new Repository<Role>(Database.Connection);
            var repositoryTag = new Repository<Tag>(Database.Connection);
            Database.Connection.Open();
            //dateTime();
            Menu.LoadPrincipal();
            //CreateUser(repository);
            // UpdateUser(repository);
            // DeleteUser(repository);
            // ReadUsers(repository);
            // ReadRoles(repositoryRole);
            // ReadTags(repositoryTag);
            Database.Connection.Close();
        }
        public static void dateTime()
        {
            var datetime = DateTime.Now;
            datetime.ToString("G");
            System.Console.WriteLine(datetime);
        }
    }

}

