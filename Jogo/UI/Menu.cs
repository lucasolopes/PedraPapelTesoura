using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jogo.UI
{
    public class Menu
    {
        public static void ShowMenuPrincipal()
        {
            CreateLine();
            Console.WriteLine("1 - Jogo Unico");
            Console.WriteLine("2 - Infinito");
            Console.WriteLine("3 - Campeonato");
            Console.WriteLine("4 - Mostrar Estatísticas");
            Console.WriteLine("5 - Sair");
            Console.Write("Selecione a Opção Desejada: ");

        }

        public static void ShowMenuCampeonato()
        {
            CreateLine();
            Console.WriteLine("1 - 3 Rounds");
            Console.WriteLine("2 - 5 Rounds");
            Console.WriteLine("3 - 7 Rounds");
            Console.Write("Selecione a Opção Desejada: ");

        }

        public static void ShowMenuEstatisticas()
        {
            CreateLine();
            Console.Write("Estatísticas");

        }

        public static void ShowMenuMarcador()
        {
            CreateLine();
            Console.WriteLine("1 - X");
            Console.WriteLine("2 - O");
            Console.Write("Selecione a Opção Desejada: ");
        }


        private static void CreateLine()
        {
            Console.WriteLine(new string('-', 30));
        }
    }
}
