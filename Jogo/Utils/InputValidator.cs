using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jogo.Utils
{
    public class InputValidator
    {
        public static bool IsValidInt(string input)
        {
            Console.Clear();
            return int.TryParse(input, out int result) ? true : throw new FormatException("Informe um numero do tipo inteiro");
        }
    }
}
