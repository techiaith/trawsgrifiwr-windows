using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeepSpeechLib
{
    public class Recaser
    {
        public static String Recase(String orig)
        {
            if (!String.IsNullOrEmpty(orig) && orig.Length>1)            
                return char.ToUpper(orig[0]) + orig.Substring(1);
            return orig;
        }
    }
}
