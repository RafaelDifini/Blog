using Blog.Models;
using Blog.Repositories;
namespace Blog.Screens.PostScreens
{
    public static class ListPostScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Lista de Posts");
            Console.WriteLine("-------------");
            //ListPost();
            ListPostWithUser();
            Console.ReadKey();
            MenuPostScreen.Load();
        }
        private static void ListPostWithUser()
        {
            var repository = new PostRepository(Database.Connection);
            var posts = repository.ListPostWithUser();
            var postWithTag = repository.ListPostWithTag();
            var postWithCategory = repository.ListPostWithCategory();

            foreach (var item in posts)
            {
                Console.WriteLine(@$"
Titulo: {item.Title} 
Sumario: {item.Summary}
Texto: {item.Body}");
                foreach (var autor in item.Author) Console.WriteLine(@$"Autor: {autor.Name}");
            }
            Console.Write("Categorias: ");
            foreach (var item in postWithCategory)
            {
                foreach (var category in item.Category)
                {
                    if (item.Category.Count() >= 1)
                        System.Console.Write($"{category.Name}, ");

                    else
                        System.Console.WriteLine(@$"Categoria: {category.Name}");
                    Console.Write("Id - ");
                    Console.Write($"{category.Id} ");
                }
            }
            foreach (var item in postWithTag)
            {
                foreach (var tag in item.Tags)
                {
                    System.Console.WriteLine("");
                    System.Console.WriteLine(@$"Tags: {tag.Name}");
                }
            }

        }

    }
}
