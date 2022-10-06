using Blog.Models;
using Blog.Repositories;
using Blog.Screens.TagScreens;
using Blog.Screens.UserScreen;
using Dapper;

namespace Blog.Screens.UserScreen
{
    public class AddRoleInUserScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Vinculando um usuário a um perfil");
            Console.WriteLine("-------------");
            Console.Write("Id do usuario: ");
            var idUser = int.Parse(Console.ReadLine());
            Console.WriteLine("Insira o Id do perfil");
            var idPerfil = int.Parse(Console.ReadLine());

            var userRepository = new UserRepository(Database.Connection);
            userRepository.AddRoleInUser(idUser, idPerfil);
            System.Console.WriteLine("Perfil Vinculado com sucesso");
            Console.ReadKey();
            MenuTagScreen.Load();
        }
    }
}