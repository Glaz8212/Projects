using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KGA_OOPConsoleProject.Scenes
{
    public class IntroScene : Scene
    {
        public IntroScene(Game game) : base(game) { }

        public override void Enter()
        {
            Console.Clear();
            Render();
            Input();
        }

        public override void Render()
        {
            game.Player.Status();

            Thread.Sleep(500);
            Console.WriteLine();
            Console.WriteLine("이 게임은 '사이버펑크 2077'의 태양 엔딩 이후의 시점을 배경으로 합니다.");
            Thread.Sleep(500);

            Console.WriteLine();
            Console.WriteLine($"{game.Player.Name}은/는 애프터라이프의 제왕이자 용병계의 거물로 성장했습니다.");
            Console.WriteLine($"그러던 어느날, {game.Player.Name}은/는 아라사카 소유의 우주 정거장");
            Console.WriteLine("'크리스탈 팰리스'에 잠입하여 의문의 고객 명부를 탈취하는 임무를 받게 됩니다.");
            Console.WriteLine();
            Thread.Sleep(1000);
            Console.WriteLine("당신은 지금 우주선 'Black Comet'으로 지루한 항해를 하고 있습니다.");
            Console.WriteLine();
            Console.WriteLine();
            Thread.Sleep(2000);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("게임의 모든 선택은 스탯에 따른 확률 계산으로 성공/실패가 나뉘어집니다.");
            Thread.Sleep(500);
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine("시작하시려면 아무 키나 눌러주세요...");
        }

        public override void Input()
        {
            Console.ReadKey(true);
            game.ChangeScene(SceneType.Spaceship);
        }


        public override void Exit()
        {
            Console.Clear();
        }
    }
}
