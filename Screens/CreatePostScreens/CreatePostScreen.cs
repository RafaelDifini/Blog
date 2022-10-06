using Blog.Models;
using Blog.Repositories;
namespace Blog.Screens.PostScreens
{
    public static class CreatePostScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Novo post");
            Console.WriteLine("-------------");
            System.Console.Write("Digite o Id do autor: ");
            var autorResposta = int.Parse(Console.ReadLine());
            var autorRerpository = new Repository<User>(Database.Connection);
            var autor = autorRerpository.Get(autorResposta);
            var autorId = autor.Id;
            System.Console.Write("Digite o Id da categoria para o post: ");
            var categoryReposta = int.Parse(Console.ReadLine());
            var categoryRepository = new Repository<Category>(Database.Connection);
            var category = categoryRepository.Get(categoryReposta);
            var categoryId = category.Id;

            Console.Write("Titulo: ");
            var title = Console.ReadLine();
            Console.Write("Sumário: ");
            var sumaryl = Console.ReadLine();
            Console.Write("Texto: ");
            var body = Console.ReadLine();
            Console.Write("Slug: ");
            var slug = Console.ReadLine();
            var createDate = DateTime.Now;
            var lastUpdate = createDate;
            createDate.ToString("G");
            lastUpdate.ToString("G");
            Create(new Post
            {
                AuthorId = autorId,
                CategoryId = categoryId,
                Title = title,
                Summary = sumaryl,
                Body = body,
                Slug = slug,
                CreateDate = createDate,
                LastUpdateDate = lastUpdate

            });
            Console.ReadKey();
            MenuPostScreen.Load();
        }

        public static void Create(Post post)
        {
            try
            {
                var repository = new Repository<Post>(Database.Connection);
                repository.Create(post);
                Console.WriteLine("Post criado com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possível criar o post");
                Console.WriteLine(ex.Message);
            }
        }
    }
}

