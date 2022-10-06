using Blog.Models;
using Blog.Repositories;
using Blog.Screens.TagScreens;
using Blog.Screens.UserScreen;
using Dapper;

namespace Blog.Screens.PostScreens
{
    public class AddPostInUserScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Vinculando um post a uma tag");
            Console.WriteLine("-------------");
            Console.Write("Id do post: ");
            var idPost = int.Parse(Console.ReadLine());
            Console.WriteLine("Insira o Id da tag");
            var idTag = int.Parse(Console.ReadLine());

            var postRepository = new PostRepository(Database.Connection);
            postRepository.AddTagInPost(idPost, idTag);
            System.Console.WriteLine("Perfil Vinculado com sucesso");
            Console.ReadKey();
            MenuTagScreen.Load();
        }
    }
}