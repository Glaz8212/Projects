using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KGA_OOPConsoleProject.Players
{
    public class Nomad : Player
    {
        public Nomad(string name) : base(name, Lifepath.Nomad)
        {
            this.memento = Memento.Tools;
            this.maxHp = 110;
            this.str = 6;
            this.intel = 4;
            this.rfx = 5;
            this.tec = 6;
            this.col = 3;
            this.curHp = maxHp;
        }
    }
}
