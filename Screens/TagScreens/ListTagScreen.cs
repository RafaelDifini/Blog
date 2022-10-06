using System;
using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.TagScreens
{
    public static class ListTagScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Lista de tags");
            Console.WriteLine("-------------");
            List();
            Console.ReadKey();
            MenuTagScreen.Load();
        }

        private static void List()
        {
            var postRepository = new TagRepository(Database.Connection);
            var posts = postRepository.ListTagWithPosts();
            foreach (var item in posts)
            {
                System.Console.WriteLine($"{item.Id} {item.Name} ({item.Slug})");
                foreach (var post in item.Posts)
                {
                    System.Console.WriteLine($"Posts: {item.Posts.Count()}");
                }

            }

        }
    }
}