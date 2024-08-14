using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jogo.Core
{
    public class Jogador
    {
        public int Vitorias { set; get; } = 0;
        public int Derrotas { set; get; } = 0;
        public int Empates { set; get; } = 0;

        public Jogador()
        {
        }
    }
}
