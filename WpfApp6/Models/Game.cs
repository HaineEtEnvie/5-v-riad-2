using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp6.ViewModels.Base;

namespace WpfApp6.Models
{
    class Game : ViewModel
    {
        private string move = "X";
        public string Move
        {
            get => move;
            set => Set(ref move, value);
        }
        
        public Dictionary<int, string> razmeri = new()
            {
                {15, "15*15"}, {19, "19*19"}
            };

        public Dictionary<int, string> Razmeri
        {
            get => razmeri;
            set => Set(ref razmeri, value);
        }
    }
}
