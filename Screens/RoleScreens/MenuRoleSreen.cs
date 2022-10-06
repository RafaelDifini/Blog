
namespace Blog.Screens.RoleScreens

{
    public static class MenuRoleScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Gestão de perfis");
            Console.WriteLine("--------------");
            Console.WriteLine("O que deseja fazer?");
            Console.WriteLine();
            Console.WriteLine("1 - Listar perfil");
            Console.WriteLine("2 - Cadastrar perfil");
            Console.WriteLine("3 - Atualizar perfil");
            Console.WriteLine("4 - Excluir perfil");
            Console.WriteLine();
            Console.WriteLine();

            try
            {
                var option = short.Parse(Console.ReadLine()!);
                switch (option)
                {
                    case 1:
                        ListRoleScreen.Load();
                        break;
                    case 2:
                        CreateRoleScreen.Load();
                        break;
                    case 3:
                        UpdateRoleScreen.Load();
                        break;
                    case 4:
                        DeleteRoleScreen.Load();
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
