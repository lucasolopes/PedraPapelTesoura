
using Jogo.Core;
using Jogo.UI;
using Jogo.Utils;
using System.Data.Common;

namespace Jogo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bem Vindo!");

            Jogador jogador = new Jogador();

            bool continuar = true;

            while (continuar)
            {
                try
                {
                    JoKenPo jogo = new JoKenPo(jogador);
                    Menu.ShowMenuPrincipal();
                    /*
                     1 - Jogo Unico
                     2 - Campeonato
                     3 - Infinito
                     4 - Mostrar Estatísticas
                     5 - Sair
                    */
                    string opcao = Console.ReadLine();

                    InputValidator.IsValidInt(opcao);

                    switch (opcao)
                    {
                        case "1":
                            jogo.StartSingle();
                            break;
                        case "2":
                            jogo.StartInfinito();
                            break;
                        case "3":

                            
                            bool entradaValida = false;
                            while (!entradaValida)
                            {
                                
                                try
                                {
                                    Menu.ShowMenuCampeonato();
                                    string partidas = Console.ReadLine();
                                    InputValidator.IsValidInt(partidas);
                                    switch (partidas)
                                    {
                                        case "1":
                                            jogo.StartCampeonato(3);
                                            entradaValida = true;
                                            break;
                                        case "2":
                                            jogo.StartCampeonato(5);
                                            entradaValida = true;
                                            break;
                                        case "3":
                                            jogo.StartCampeonato(7);
                                            entradaValida = true;
                                            break;
                                        default:
                                            Console.WriteLine("Opção inválida");
                                            break;
                                    }
                                }
                                catch (FormatException E)
                                {
                                    Console.WriteLine(E.Message);
                                }
                            }

                            break;

                        case "4":
                            Estatistica.GerarResultados();
                            break;
                        case "5":
                            Console.WriteLine("Saindo...");
                            continuar = false;
                            break;
                        default:
                            Console.Clear();
                            Console.WriteLine("Opção inválida!");
                            break;
                    }


                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Erro inesperado: " + e.Message);
                }
            }
        }
    }
}