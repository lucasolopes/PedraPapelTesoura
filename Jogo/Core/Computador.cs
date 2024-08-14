using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jogo.Core
{
    public class Computador : Jogador
    {
        Random _random;
        public Computador() 
        {
            _random = new Random();
        }

        public int EscolherMao()
        {

            int movimento = _random.Next(1, 4);

            return movimento;
        }
    }
}
