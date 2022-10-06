using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.CategoryScreens
{
    public static class ListCategoryScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Lista de categorias");
            Console.WriteLine("-------------");
            List();
            Console.ReadKey();
            MenuCategoryScreen.Load();
        }

        private static void List()
        {
            var repository = new CategoryRepository(Database.Connection);
            var category = repository.ListCategoryWithPosts();
            foreach (var item in category)
            {
                System.Console.WriteLine($"{item.Id} - {item.Name} ({item.Slug})");
                System.Console.WriteLine($"Posts: {item.Posts.Count()}");
            }


        }
    }
}
