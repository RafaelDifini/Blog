using Blog.Models;
using Blog.Repositories;
namespace Blog.Screens.UserScreen
{
    public static class CreateUserScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Novo usuario");
            Console.WriteLine("-------------");
            Console.Write("Nome: ");
            var name = Console.ReadLine();
            Console.Write("Email: ");
            var email = Console.ReadLine();
            Console.Write("Bio: ");
            var bio = Console.ReadLine();
            Console.Write("Slug: ");
            var slug = Console.ReadLine();
            Console.Write("Crie uma senha: ");
            var hash = Console.ReadLine();
            var image = $"https://{name}.jpg";

            Create(new User
            {
                Name = name,
                Email = email,
                Bio = bio,
                PasswordHash = hash,
                Slug = slug,
                Image = image
            });
            Console.ReadKey();
            MenuUserScreen.Load();
        }

        public static void Create(User user)
        {
            try
            {
                var repository = new Repository<User>(Database.Connection);
                repository.Create(user);
                Console.WriteLine("Usuário cadastrado com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possível cadastrar o usuário");
                Console.WriteLine(ex.Message);
            }
        }
    }
}

