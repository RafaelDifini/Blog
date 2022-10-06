using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.CategoryScreens
{
    public static class UpdateCategoryScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Atualizando uma categoria");
            Console.WriteLine("-------------");
            Console.Write("Id: ");
            var id = Console.ReadLine();

            Console.Write("Nome: ");
            var name = Console.ReadLine();

            Console.Write("Slug: ");
            var slug = Console.ReadLine();

            Update(new Category
            {
                Id = int.Parse(id),
                Name = name,
                Slug = slug
            });
            Console.ReadKey();
            MenuCategoryScreen.Load();
        }

        public static void Update(Category Category)
        {
            try
            {
                var repository = new Repository<Category>(connection: Database.Connection);
                repository.Update(Category);
                Console.WriteLine("Categoria atualizada com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possível atualizar a Categoria");
                Console.WriteLine(ex.Message);
            }
        }
    }
}