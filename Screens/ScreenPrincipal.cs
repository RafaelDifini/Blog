using Blog.Screens.CategoryScreens;
using Blog.Screens.RoleScreens;
using Blog.Screens.TagScreens;
using Blog.Screens.UserScreen;
using Blog.Screens.PostScreens;

namespace Blog.Screens
{
    public static class Menu
    {
        public static void LoadPrincipal()
        {
            Console.Clear();
            Console.WriteLine("Meu Blog");
            Console.WriteLine("-----------------");
            Console.WriteLine("O que deseja fazer?");
            Console.WriteLine();
            Console.WriteLine("1 - Gestão de usuário");
            Console.WriteLine("2 - Gestão de perfil");
            Console.WriteLine("3 - Gestão de categoria");
            Console.WriteLine("4 - Gestão de tag");
            Console.WriteLine("5 - Vincular perfil/usuário");
            Console.WriteLine("6 - Gestão de Posts");
            Console.WriteLine("7 - Vincular post/tag");
            Console.WriteLine();
            Console.WriteLine();
            var option = short.Parse(Console.ReadLine()!);

            switch (option)
            {
                case 1:
                    MenuUserScreen.Load();
                    break;
                case 2:
                    MenuRoleScreen.Load();
                    break;
                case 3:
                    MenuCategoryScreen.Load();
                    break;
                case 4:
                    MenuTagScreen.Load();
                    break;
                case 5:
                    AddRoleInUserScreen.Load();
                    break;
                case 6:
                    MenuPostScreen.Load();
                    break;
                case 7:
                    AddPostInUserScreen.Load();
                    break;
                default: LoadPrincipal(); break;
            }

        }
    }
}