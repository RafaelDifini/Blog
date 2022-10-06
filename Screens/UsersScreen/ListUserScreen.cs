using Blog.Models;
using Blog.Repositories;
namespace Blog.Screens.UserScreen
{
    public static class ListUserScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Lista de usuários");
            Console.WriteLine("-------------");
            ListWithRole();
            Console.ReadKey();
            MenuUserScreen.Load();
        }
        private static void ListWithRole()
        {
            var repository = new UserRepository(Database.Connection);
            var users = repository.ListWithRole();

            foreach (var item in users)
            {
                Console.WriteLine(@$"{item.Id} - {item.Name} 
    {item.Slug}
    {item.Bio}
    Email:{item.Email}");
                foreach (var role in item.Roles) Console.WriteLine($"    Perfil: {role.Name}");
            }
        }
    }
}