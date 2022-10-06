namespace Blog.Screens.PostScreens
{
    public static class MenuPostScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Gestão de posts");
            Console.WriteLine("--------------");
            Console.WriteLine("O que deseja fazer?");
            Console.WriteLine();
            Console.WriteLine("1 - Listar os posts");
            Console.WriteLine("2 - Criar um Post");
            Console.WriteLine("3 - Atualizar um ost");
            Console.WriteLine("4 - Excluir um post");
            Console.WriteLine();
            Console.WriteLine();

            try
            {
                var option = short.Parse(Console.ReadLine()!);
                switch (option)
                {
                    case 1:
                        ListPostScreen.Load();
                        break;
                    case 2:
                        CreatePostScreen.Load();
                        break;
                    case 3:
                        //UpdatePostScreen.Load();
                        break;
                    case 4:
                        //DeletePostScreen.Load();
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
