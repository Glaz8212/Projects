using KGA_OOPConsoleProject.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KGA_OOPConsoleProject.Scenes
{
    public class SelectScene : Scene
    {
        public SelectScene(Game game) : base(game) { }

        public override void Enter()
        {
            Console.Clear();
            SetPlayerName();
        }

        private void SetPlayerName()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("===== 이름을 입력하세요 =====");
            Console.ResetColor();
            Console.WriteLine();
            Thread.Sleep(1000);
            Console.Write("플레이어의 이름을 입력해주세요: ");
            string playerName = Console.ReadLine();

            game.Player = new Nomad(playerName);
            SelectLifepath(playerName);
        }

        private void SelectLifepath(string playerName)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("===== 출신을 선택하세요 =====");
            Console.ResetColor();
            Console.WriteLine();
            Thread.Sleep(1000);
            Console.WriteLine("1. 노마드");
            Console.WriteLine("   - 황무지에서 떠돌며 살아온 집시들입니다.");
            Console.WriteLine("   - 소지품: 노마드의 맥가이버칼");
            Console.WriteLine();
            Console.WriteLine("2. 부랑자");
            Console.WriteLine("   - 거리의 부랑아들로, 할렘가에서 자라왔습니다.");
            Console.WriteLine("   - 소지품: 부랑자의 일기장");
            Console.WriteLine();
            Console.WriteLine("3. 기업인");
            Console.WriteLine("   - 대기업에서 일하며, 기업의 잔혹한 면모를 익힌 엘리트입니다.");
            Console.WriteLine("   - 소지품: 아라사카 기업의 ID카드");
            Console.WriteLine();
            Thread.Sleep(1000);
            Console.Write("출신을 골라주세요 (1-3): ");

            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    game.Player = new Nomad(playerName);
                    break;
                case "2":
                    game.Player = new StreetKid(playerName);
                    break;
                case "3":
                    game.Player = new Corpo(playerName);
                    break;
                default:
                    Console.WriteLine("잘못된 입력입니다. (1-3)을 입력해주세요.");
                    Thread.Sleep(2000);
                    SelectLifepath(playerName);
                    return;
            }
            SelectPerk();
        }

        private void SelectPerk()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("===== 특전을 선택하세요 =====");
            Console.ResetColor();
            Thread.Sleep(1000);
            Console.WriteLine();
            Console.WriteLine("1. 신체");
            Console.WriteLine("2. 지능");
            Console.WriteLine("3. 반사신경");
            Console.WriteLine("4. 기술");
            Console.WriteLine("5. 냉정");
            Console.WriteLine();
            Thread.Sleep(1000);
            Console.Write("특전을 골라주세요 (1-5): ");

            string input = Console.ReadLine();
            Perk selectedPerk;

            switch (input)
            {
                case "1":
                    selectedPerk = Perk.Body;
                    break;
                case "2":
                    selectedPerk = Perk.Intelligence;
                    break;
                case "3":
                    selectedPerk = Perk.Reflexes;
                    break;
                case "4":
                    selectedPerk = Perk.Tech;
                    break;
                case "5":
                    selectedPerk = Perk.Cool;
                    break;
                default:
                    Console.WriteLine("잘못된 입력입니다. (1-5)을 입력해주세요.");
                    Thread.Sleep(2000);
                    SelectPerk();
                    return;
            }
            game.Player.SetPerk(selectedPerk);
            game.ChangeScene(SceneType.Confirm);
        }

        public override void Input()
        {

        }

        public override void Render()
        {

        }


        public override void Exit()
        {
            Console.Clear();
        }
    }
}
