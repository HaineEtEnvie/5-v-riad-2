using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Models
{
    internal class Information
    {
        public static Player Player1 { get; set; }
        public static Player Player2 { get; set; }
        public static int Razmernost { get; set; }

        public Information(Player player1, Player player2, int razmernost)
        {
            Player1 = player1;
            Player2 = player2;
            Razmernost = razmernost;
        }


    }
}
