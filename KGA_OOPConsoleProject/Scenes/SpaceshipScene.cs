using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KGA_OOPConsoleProject.Scenes
{
    public class SpaceshipScene : Scene
    {
        public SpaceshipScene(Game game) : base(game) { }

        public override void Enter()
        {
            Console.Clear();
            Render();
            Input();
        }

        public override void Render()
        {
            game.Player.Status();

            Thread.Sleep(1000);
            Console.WriteLine("===== 우주선 내부 =====");
            Console.WriteLine();
            Thread.Sleep(500);
            Console.WriteLine("당신은 지루한 항해를 계속하고 있습니다.");
            Console.WriteLine("도착이 얼마 남지 않았을 때, 갑자기 경고음이 울리기 시작합니다.");
            Console.WriteLine();
            Thread.Sleep(1000);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("비상! 비상! 비상!");
            Console.ResetColor();
            Console.WriteLine();
            Thread.Sleep(500);
            Console.WriteLine("우주선의 항법 장치에 문제가 발생했습니다. 어떻게 하시겠습니까?");
            Console.WriteLine();
            Thread.Sleep(1000);
            Console.WriteLine("1. (지능 + 기술) 수리를 시도한다.");
            Console.WriteLine("2. (반사신경 + 냉정) 침착하게 상황을 판단한 후, 대피한다.");
            Console.WriteLine("3. (힘) 비상 장치를 작동시킨다.");
            Console.WriteLine();
            Thread.Sleep(1000);
            Console.Write("선택지를 입력해주세요 (1-3): ");
            Console.WriteLine();
        }

        public override void Input()
        {
            string input = Console.ReadLine();
            bool success = false;

            switch (input)
            {
                case "1":
                    success = Utility.RandomSuccess(game.Player.INT + game.Player.TEC);
                    break;
                case "2":
                    success = Utility.RandomSuccess(game.Player.RFX + game.Player.COL);
                    break;
                case "3":
                    success = Utility.RandomSuccess(game.Player.STR);
                    break;
                default:
                    Console.WriteLine("잘못된 입력입니다. (1-3)을 입력해주세요.");
                    Input();
                    return;
            }

            if (success)
            {
                Console.WriteLine("상황을 성공적으로 해결했습니다.");
                Thread.Sleep(1000);
                game.ChangeScene(SceneType.Entrance);
            }
            else
            {
                Console.WriteLine("상황을 해결하지 못했습니다. 큰 손상을 입었습니다.");
                game.Player.TakeDamage(10);
                Console.WriteLine($"현재 체력: {game.Player.CurHp}");
                Thread.Sleep(1000);
                game.ChangeScene(SceneType.Entrance);
            }
        }


        public override void Exit()
        {
            Console.Clear();
        }
    }
}