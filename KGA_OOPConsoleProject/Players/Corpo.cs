using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KGA_OOPConsoleProject.Players
{
    public class Corpo : Player
    {
        public Corpo(string name) : base(name, Lifepath.Corpo)
        {
            this.memento = Memento.IdCard;
            this.maxHp = 90;
            this.str = 4;
            this.intel = 7;
            this.rfx = 4;
            this.tec = 5;
            this.col = 6;
            this.curHp = maxHp;
        }
    }
}
