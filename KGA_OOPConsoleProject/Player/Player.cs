using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KGA_OOPConsoleProject.Player
{
    public class Player
    {
        protected string name;
        public string Name { get { return name; } }

        protected int curHP;
        public int CurHP { get { return curHP; } }

        protected int maxHP;
        public int MaxHP { get { return maxHP; } }

        protected int attack;
        public int Attack { get { return attack; } }

        protected int defense;
        public int Defense { get { return defense; } }

        protected int soul;
        public int Soul { get { return soul; } set { soul = value; } }

        public Player(string name)
        { 
            this.name = name;
            this.curHP = 100;
            this.maxHP = 100;
            this.attack = 10;
            this.defense = 10;
            this.soul = 0;    
        }

        public void ShowInfo()
        {
            Console.SetCursorPosition(0, 20);
            Console.WriteLine("==========================================");
            Console.WriteLine($" 이름 : {name,-6}");
            Console.WriteLine($" 체력 : {curHP,+3} / {maxHP}  공격 : {attack,-3} / 방어 : {defense,-3}");
            Console.WriteLine($" 소울 : {soul,+5}");
            Console.WriteLine("==========================================");
            Console.WriteLine();
            Console.SetCursorPosition(0, 0);
        }
    }
}
