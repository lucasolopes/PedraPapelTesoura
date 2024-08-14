using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jogo.Utils
{
    public class Simbols
    {

        public static string Get(int simbolo)
        {
            switch (simbolo)
            {
                case 1:
                    return "\r\n        .      \r\n  -:   ::      \r\n  : - : :      \r\n  : : - :      \r\n   : =. -.:.   \r\n   -.:.-. : :  \r\n  :  ..- .:.:  \r\n  :  :  .. :   \r\n  :        :   \r\n   :.      :   \r\n     ......    \r\n";
                case 2:
                    return "\r\n\r\n\r\n\r\n \r\n\r\n    .:.:...   \r\n  ..= : : : :  \r\n .. = : : : :  \r\n : .=-:.:.:.-  \r\n  :   ..    :  \r\n   :        :  \r\n    ........  ";
                case 3:
                    return "\r\n      ..:..    \r\n    ..- -  -   \r\n   -  - -  =.: \r\n   -  - -  - : \r\n ..=  - -  - : \r\n - =  . :  : - \r\n-  +         - \r\n-            - \r\n -           - \r\n  :          - \r\n   .:.......:. \r\n";
                case 4:
                    return "\r\n      .                                    .      \r\n -:  . :                                 .- -.:   \r\n : : : :                .               : : : -.. \r\n ..:....            ...- -.-..          : : : : : \r\n  : +.-.-..        : + : : : :        :.- : : : : \r\n  :. .- : :       .  =.- - -.:       .  =       : \r\n : .: :.-.:        : ....    :       .  .       : \r\n :  .     :         :        :        :         : \r\n  :       :          .......:          ..       : \r\n   .......                               ......   ";
                default:
                    throw new ArgumentOutOfRangeException(nameof(simbolo), simbolo, null);
            }
        }
       
    }
}
