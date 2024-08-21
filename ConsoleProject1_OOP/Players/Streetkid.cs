using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KGA_OOPConsoleProject.Players
{
    public class StreetKid : Player
    {
        public StreetKid(string name) : base(name, Lifepath.StreetKid)
        {
            this.memento = Memento.Diary;
            this.maxHp = 100;
            this.str = 5;
            this.intel = 3;
            this.rfx = 7;
            this.tec = 4;
            this.col = 5;
            this.curHp = maxHp;
        }
    }
}
