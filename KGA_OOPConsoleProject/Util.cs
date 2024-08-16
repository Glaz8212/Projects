using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KGA_OOPConsoleProject
{
    public static class Utility
    {
        public static bool RandomSuccess(int successRate)
        {
            Random rand = new Random();
            int roll = rand.Next(1, 11);
            return roll <= successRate;
        }
    }

    public static class Translator
    {
        public static string GetLifepathName(Lifepath lifepath)
        {
            switch (lifepath)
            {
                case Lifepath.Nomad:
                    return "노마드";
                case Lifepath.StreetKid:
                    return "부랑자";
                case Lifepath.Corpo:
                    return "기업인";
                default:
                    return lifepath.ToString();
            }
        }

        public static string GetPerkName(Perk perk)
        {
            switch (perk)
            {
                case Perk.Body:
                    return "신체";
                case Perk.Intelligence:
                    return "지능";
                case Perk.Reflexes:
                    return "반사신경";
                case Perk.Tech:
                    return "기술";
                case Perk.Cool:
                    return "냉정";
                default:
                    return perk.ToString();

            }
        }

        public static string GetMementoName(Memento memento)
        {
            switch (memento)
            {
                case Memento.Tools:
                    return "노마드의 맥가이버칼";
                case Memento.Diary:
                    return "부랑자의 일기장";
                case Memento.IdCard:
                    return "아라사카 기업의 ID카드";
                default:
                    return memento.ToString();
            }
        }
    }
}
