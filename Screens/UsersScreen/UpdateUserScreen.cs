using Blog.Models;
using Blog.Repositories;
namespace Blog.Screens.UserScreen
{
    public static class UpdateUserScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Atualizando um usuário");
            Console.WriteLine("-------------");
            Console.Write("Id: ");
            var id = Console.ReadLine();
            System.Console.Write("Nome: ");
            var name = Console.ReadLine();
            Console.Write("Email: ");
            var email = Console.ReadLine();
            Console.Write("Bio: ");
            var bio = Console.ReadLine();
            Console.Write("Slug: ");
            var slug = Console.ReadLine();
            var image = $"https://{name}.jpg";
            var repository = new Repository<User>(Database.Connection);
            var user = repository.Get(int.Parse(id));
            var hash = user.PasswordHash;
            Console.Write("Deseja atualizar a senha?: ");
            System.Console.WriteLine("1 para: SIM | 2 para: NÃO");
            var resposta = int.Parse(Console.ReadLine());
            if (resposta == 1)
            {
                var senha = Console.ReadLine();
                senha = hash;
            }

            Update(new User
            {
                Id = int.Parse(id),
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

        public static void Update(User user)
        {
            try
            {
                var repository = new Repository<User>(Database.Connection);
                repository.Update(user);
                Console.WriteLine("Usuário atulizado com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possível atualizar o usuário");
                Console.WriteLine(ex.Message);
            }
        }
    }
}