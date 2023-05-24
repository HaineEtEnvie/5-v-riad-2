using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using WpfApp1.Models;

namespace WpfApp1.View_Models
{
    public static class Logika
    {
        public static void CreateInformation(string name1, string name2, int razmernost)
        {
            Information.Player1 = new Player(name1);
            Information.Player2 = new Player(name2);
            Information.Razmernost = razmernost;
        }

        public static void Check(string name1, string name2)
        {
            if (name1.Length > 12)
            {
                throw new Exception("Имя первого игрока превышает лимит символов(12)");
            }
            if (name2.Length > 12)
            {
                throw new Exception("Имя второго игрока превышает лимит символов(12)");
            }
            if (string.IsNullOrEmpty(name1))
            {
                throw new Exception("Имя первого игрока введено неверно");
            }
            if (string.IsNullOrEmpty(name2))
            {
                throw new Exception("Имя второго игрока введено неверно");
            }
        }

    }
}
