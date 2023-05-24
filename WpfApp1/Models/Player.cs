using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Models
{
    internal class Player
    {
        public string Name { get; set; }
        public Player(string name)
        {
            Name = name;
        }
    }
}
