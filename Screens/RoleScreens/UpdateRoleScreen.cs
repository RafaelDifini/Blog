using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.RoleScreens
{
    public static class UpdateRoleScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Atualizando um perfil");
            Console.WriteLine("-------------");
            Console.Write("Id: ");
            var id = Console.ReadLine();

            Console.Write("Nome: ");
            var name = Console.ReadLine();

            Console.Write("Slug: ");
            var slug = Console.ReadLine();

            Update(new Role
            {
                Id = int.Parse(id),
                Name = name,
                Slug = slug
            });
            Console.ReadKey();
            MenuRoleScreen.Load();
        }

        public static void Update(Role role)
        {
            try
            {
                var repository = new Repository<Role>(connection: Database.Connection);
                repository.Update(role);
                Console.WriteLine("Perfil atualizado com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possível atualizar o perfil");
                Console.WriteLine(ex.Message);
            }
        }
    }
}