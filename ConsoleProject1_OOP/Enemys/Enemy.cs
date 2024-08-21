using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KGA_OOPConsoleProject.Enemys
{
    public class Enemy
    {
        public string Name { get; }
        public string Description { get; }
        public int Damage { get; private set; }
        public int MaxHp { get; }
        public int CurHp { get; private set; }

        public Enemy(string name, string description, int damage, int maxHp)
        {
            Name = name;
            Description = description;
            Damage = damage;
            MaxHp = maxHp;
            CurHp = maxHp;
        }

        public int Attack()
        {
            return Damage;
        }

        public void TakeDamage(int damage)
        {
            CurHp -= damage;
            if (CurHp < 0)
            {
                CurHp = 0;
            }
        }

        public void ReduceDamage()
        {
            Damage /= 2;
        }

        public bool IsDead()
        {
            return CurHp <= 0;
        }

        public void Hack()
        {
            Thread.Sleep(1000);
            Console.WriteLine($"{Name}이(가) 해킹당했습니다! 공격력이 감소합니다.");
            ReduceDamage();
        }
    }
}
