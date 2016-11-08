using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Snake1
{
    class Level
    {public int kolvo_edi;
   public int kolvo_prepjat;
    public int ball;
    public int dt;
       public void SetLevel(int level) {
           kolvo_edi = 10 * level;
           kolvo_prepjat = 10 * level;
           ball = 50 * level;
           dt = 500 - 20 * level;
        }
    }
}
