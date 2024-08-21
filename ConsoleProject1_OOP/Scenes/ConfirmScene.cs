using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KGA_OOPConsoleProject.Scenes
{
    public class ConfirmScene : Scene
    {
        public ConfirmScene(Game game) : base(game) { }

        public override void Enter()
        {
            Console.Clear();
            Render();
            Input();
        }

        public override void Render()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("===== 캐릭터 설정 확인 =====");
            Console.ResetColor();
            Console.WriteLine();
            Thread.Sleep(1000);
            Console.WriteLine($"이름: {game.Player.Name}");
            Console.WriteLine($"출신: {Translator.GetLifepathName(game.Player.Lifepath)}");
            Console.WriteLine($"특전: {Translator.GetPerkName(game.Player.Perk)}");
            Console.WriteLine($"소지품: {Translator.GetMementoName(game.Player.Memento)}");
            Console.WriteLine();
            Thread.Sleep(1000);
            Console.WriteLine("진행하시겠습니까? (Y/N)");
            Console.WriteLine();
            Console.WriteLine();
        }

        public override void Input()
        {
            string input = Console.ReadLine();

            if (input == "Y" || input == "y")
            {
                Console.WriteLine("게임을 시작합니다.");
                Thread.Sleep(1000);
                game.ChangeScene(SceneType.Intro);
            }
            else if (input == "N" || input == "n")
            {
                Console.WriteLine("캐릭터 선택 화면으로 돌아갑니다.");
                Thread.Sleep(2000);
                game.ChangeScene(SceneType.Select);
            }
            else
            {
                Console.WriteLine("잘못된 입력입니다. (Y/N)을 입력해주세요.");
                Thread.Sleep(1000);
                Input();
            }
        }


        public override void Exit()
        {
            Console.Clear();
        }
    }
}
