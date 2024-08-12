using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KGA_OOPConsoleProject.Item;

namespace KGA_OOPConsoleProject.Item
{
    public class Item
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int AttackBonus { get; set; }
        public int DefenseBonus { get; set; }
        public ItemType Type { get; set; }

        public Item(string name, string description, int attackBonus, int defenseBonus, ItemType type)
        {
            Name = name;
            Description = description;
            AttackBonus = attackBonus;
            DefenseBonus = defenseBonus;
            Type = type;
        }
    }
}
