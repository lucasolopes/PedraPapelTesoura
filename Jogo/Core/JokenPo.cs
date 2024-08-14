using Jogo.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jogo.Core
{
    public class JoKenPo
    {
        private Jogador _jogador;
        private Computador _computador;
        private static bool _aniAtiva = true;
        private static int vitoriasJogador = 0;
        private static int vitoriasComputador = 0;
        private static int empates = 0;

        public JoKenPo(Jogador jogador)
        {
            _jogador = jogador;
            _computador = new Computador();
        }

        private void Start() {
            do
            {
                try
                {
                    bool jogoFinalizado = false;
                    
                    _aniAtiva = true;

                    var thread = new Thread(() => AnimacaoEscolhaComputador());
                    thread.Start();

                    string opcao = Console.ReadLine();
                    InputValidator.IsValidInt(opcao);
                    _aniAtiva = false;

                    thread.Join();

                    int escolhaJogador = int.Parse(opcao) > 3 ? throw new ArgumentOutOfRangeException("Insira um Valor Valido!") : int.Parse(opcao);
                    int escolhaComputador = _computador.EscolherMao();
                    var resultado = Regras.Verificar(escolhaJogador, escolhaComputador);



                    Console.Clear();
                    Console.WriteLine($"Jogador escolheu:  {Simbols.Get(escolhaJogador)}");
                    Console.WriteLine($"Computador escolheu:   {Simbols.Get(escolhaComputador)}");

                    if (resultado == "Empate")
                        empates++;

                    else if (resultado == "Jogador")
                        vitoriasJogador++;

                    else
                        vitoriasComputador++;


                    if(resultado != "Empate")
                        Console.WriteLine($"{resultado} foi o Vencedor!");
                    else
                        Console.WriteLine("Empate!");

                    jogoFinalizado = true;

                    if (jogoFinalizado)
                    {
                        Estatistica.AdicionarEstatista(resultado);
                        break;
                    }
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    _aniAtiva = false;
                    Console.Clear();
                    Console.WriteLine(ex.Message);
                }
                catch (FormatException ex)
                {
                    _aniAtiva = false;
                    Console.Clear();
                    Console.WriteLine(ex.Message);
                }
            } while (true);


        }

        private static void AnimacaoEscolhaComputador()
        {
            string[] simbulos = { Simbols.Get(1), Simbols.Get(2), Simbols.Get(3) };
            int indice = 0;

            while (_aniAtiva)
            {
                
                Console.SetCursorPosition(0, 1);
                Console.WriteLine("Placar: ");
                Console.WriteLine($"Jogador: {vitoriasJogador} | Empate: {empates} | Computador: {vitoriasComputador} ");
                Console.WriteLine($"Computador: {simbulos[indice]}");
                Console.WriteLine("Escolha uma opção:");
                Console.WriteLine(Simbols.Get(4));
                Console.Write("1 - Tesoura           ");
                Console.Write("2 - Pedra         ");
                Console.WriteLine("3 - Papel");
                Console.Write("Insira: ");
                indice = (indice + 1) % simbulos.Length;
                Thread.Sleep(250);
            }
        }
        private void resetarEstatisticas()
        {
            vitoriasJogador = 0;
            vitoriasComputador = 0;
            empates = 0;
        }

        public void StartSingle()
        {
            resetarEstatisticas();
            Console.Clear();
            Start();
        }

        public void StartInfinito()
        {
            resetarEstatisticas();
            while (true)
            {
                try
                {
                    Console.Clear();
                    Start();
                    Console.WriteLine("Deseja continuar? 1- S | 2- N)");
                    Console.Write("Insira: ");
                    string opcao = Console.ReadLine();
                    InputValidator.IsValidInt(opcao);
                    if (opcao == "2")
                        break;
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public void StartCampeonato(int partidas)
        {
            resetarEstatisticas();
            while (partidas > 0)
            {
                Console.Clear();
                Start();
                partidas--;
            }
            Console.Clear();
            Console.WriteLine("Fim do Campeonato!");
            Console.WriteLine($"Jogador: {vitoriasJogador} | Empate: {empates} | Computador: {vitoriasComputador} ");
            int resultado = vitoriasJogador > vitoriasComputador ? vitoriasJogador : vitoriasComputador;
            if(resultado == vitoriasJogador)
                Console.WriteLine("Jogador Venceu!");
            else
                Console.WriteLine("Computador Venceu!");

        }

    }
}
