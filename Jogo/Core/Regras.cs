
namespace Jogo.Core
{
    public class Regras
    {
        public static string Verificar(int escolhaJogador, int escolhaComputador)
        {
            if (escolhaJogador == escolhaComputador)
                return "Empate";
            

            if (escolhaJogador == 1 && escolhaComputador == 3)
                return "Jogador";

            if (escolhaJogador == 2 && escolhaComputador == 1)
                return "Jogador";


            if (escolhaJogador == 3 && escolhaComputador == 2)
                return "Jogador";


            return "Computador";
        }
    }
}