using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.RoleScreens
{
    public static class DeleteRoleScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Excluir um perfil");
            Console.WriteLine("-------------");
            Console.Write("Qual o id do perfil que deseja exluir? ");
            var id = Console.ReadLine();

            Delete(int.Parse(id));
            Console.ReadKey();
            MenuRoleScreen.Load();
        }

        public static void Delete(int id)
        {
            try
            {
                var repository = new Repository<Role>(Database.Connection);
                repository.Delete(id);
                Console.WriteLine("perfil exluído com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possível exluir o perfil");
                Console.WriteLine(ex.Message);
            }
        }
    }
}