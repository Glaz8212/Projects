using KGA_OOPConsoleProject.Enemys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KGA_OOPConsoleProject.Players
{
    public abstract class Player
    {
        protected string name;
        public string Name { get { return name; } }

        protected Lifepath lifepath;
        public Lifepath Lifepath { get { return lifepath; } }

        protected Perk perk;
        public Perk Perk { get { return perk; } }

        protected int maxHp;
        public int MaxHp { get { return maxHp; } }

        protected int curHp;
        public int CurHp { get { return curHp; } }

        protected int str;
        public int STR { get { return str; } }

        protected int intel;
        public int INT { get { return intel; } }

        protected int rfx;
        public int RFX { get { return rfx; } }

        protected int tec;
        public int TEC { get { return tec; } }

        protected int col;
        public int COL { get { return col; } }

        protected Memento memento;
        public Memento Memento { get { return memento; } }

        public Player(string name, Lifepath lifepath)
        {
            this.name = name;
            this.lifepath = lifepath;
            curHp = maxHp;
        }

        public void SetPerk(Perk perk)
        {
            this.perk = perk;

            switch (perk)
            {
                case Perk.Body:
                    maxHp += 20;
                    str += 3;
                    break;

                case Perk.Intelligence:
                    intel += 3;
                    break;

                case Perk.Reflexes:
                    rfx += 3;
                    break;

                case Perk.Tech:
                    tec += 3;
                    break;

                case Perk.Cool:
                    col += 3;
                    break;
            }

            curHp = maxHp;
        }

        public int Attack()
        {
            return STR + new Random().Next(1, 6);
        }

        public void TakeDamage(int damage)
        {
            curHp -= damage;
            if (curHp < 0)
            {
                curHp = 0;
            }
        }

        public bool IsDead()
        {
            return curHp <= 0;
        }

        public void UseMemento()
        {
            if (memento != Memento.Empty)
            {
                Console.WriteLine($"{memento}를 사용했습니다.");
                memento = Memento.Empty;
            }
            else
            {
                Console.WriteLine("사용할 소지품이 없습니다.");
            }
        }

        public void Hack(Enemy enemy)
        {
            if (Utility.RandomSuccess(TEC))
            {
                enemy.Hack();
            }
            else
            {
                Thread.Sleep(1000);
                Console.WriteLine("해킹에 실패했습니다.");
            }
        }

        public void PlusAllStats()
        {
            str++;
            intel++;
            rfx++;
            tec++;
            col++;
        }
        public void RecoverHp()
        {
            curHp = maxHp;
        }

        public void Status()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("===== 플레이어 상태 =====");
            Console.WriteLine($"이름: {Name}");
            Console.WriteLine($"출신: {Translator.GetLifepathName(lifepath)}");
            Console.WriteLine($"체력: {CurHp} / {MaxHp}");
            Console.WriteLine($"소지품: {Translator.GetMementoName(memento)}");
            Console.WriteLine($"특전: {Translator.GetPerkName(perk)}");
            Console.WriteLine("=========================");
            Console.ResetColor();
            Console.WriteLine();
        }
    }
}
