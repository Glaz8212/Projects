using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KGA_OOPConsoleProject.Item;

namespace KGA_OOPConsoleProject.Boss
{
    public class Boss
    {
        public string name { get; set; }
        public int hp { get; set; }
        public int attack { get; set; }
        public int defense { get; set; }
        private List<Item> items;

        public Boss(string name, int hp, int attack, int defense, List<Item> items)
        {
            this.name = name;
            this.hp = hp;
            this.attack = attack;
            this.defense = defense;
            this.items = items;
        }

        public bool IsDead()
        {
            return hp <= 0;
        }

        public void TakeDamage(int damage)
        {
            hp -= damage;
            if (IsDead())
            {
                Console.WriteLine($"{name}을 처치했습니다!");
                DropItem();
            }
        }

        public void DropItem()
        {
            Random random = new Random();
            foreach (var item in items)
            {
                int dropChance = random.Next(9);

                if ((item.Type == ItemType.Weapon && dropChance == 0) || (item.Type != ItemType.Weapon && dropChance < 2))
                {
                    Console.WriteLine($"{item.Name}을 획득했습니다!");
                }
            }
        }
    }
}
