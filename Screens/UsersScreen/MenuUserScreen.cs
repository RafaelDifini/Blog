namespace Blog.Screens.UserScreen
{
    public static class MenuUserScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Gestão de Usuarios");
            Console.WriteLine("--------------");
            Console.WriteLine("O que deseja fazer?");
            Console.WriteLine();
            Console.WriteLine("1 - Listar usários");
            Console.WriteLine("2 - Cadastrar usuário");
            Console.WriteLine("3 - Atualizar usuário");
            Console.WriteLine("4 - Excluir usuário");
            Console.WriteLine();
            Console.WriteLine();

            try
            {
                var option = short.Parse(Console.ReadLine()!);
                switch (option)
                {
                    case 1:
                        ListUserScreen.Load();
                        break;
                    case 2:
                        CreateUserScreen.Load();
                        break;
                    case 3:
                        UpdateUserScreen.Load();
                        break;
                    case 4:
                        DeleteUserScreen.Load();
                        break;
                    default: Load(); break;
                }
            }
            catch (Exception ex)
            {
                Menu.LoadPrincipal();
            }
        }
    }
}
