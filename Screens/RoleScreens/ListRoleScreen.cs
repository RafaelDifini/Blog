using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.RoleScreens
{
    public static class ListRoleScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Lista de perfis");
            Console.WriteLine("-------------");
            List();
            Console.ReadKey();
            MenuRoleScreen.Load();
        }

        private static void List()
        {
            var repository = new Repository<Role>(Database.Connection);
            var role = repository.GetAll();
            foreach (var item in role)
                Console.WriteLine($"{item.Id} - {item.Name} ({item.Slug})");
        }
    }
}