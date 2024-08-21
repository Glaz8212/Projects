using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KGA_OOPConsoleProject.Scenes
{
    public class SecurityScene : Scene
    {
        public SecurityScene(Game game) : base(game) { }

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
            Console.WriteLine("당신은 보안장치가 설치된 방에 도착했습니다.");
            Console.WriteLine("보안장치를 무력화하거나, 전투를 통해 돌파할 수 있습니다.");
            Console.WriteLine();
            Thread.Sleep(1000);

            if (game.Player.Lifepath == Lifepath.Nomad)
            {
                Console.WriteLine("노마드 출신으로 기술자인 당신은 맥가이버칼을 이용해 보안장치를 무력화할 수 있습니다.");
                Console.WriteLine("1. 맥가이버 칼을 사용해, 보안장치를 해제한다. (맥가이버칼 소모)");
                Console.WriteLine("2. 보안 장치를 울려버리고 찾아올 싸움을 대비한다.");
            }
            else
            {
                Console.WriteLine("1. 보안 패널을 만져본다.");
                Console.WriteLine("2. 그딴건 없다. 싸운다.");
            }

            Console.Write("선택지를 입력하세요 (1-2): ");
            Thread.Sleep(1000);
        }

        public override void Input()
        {
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    if (game.Player.Lifepath == Lifepath.Nomad)
                    {
                        AttemptDisable();
                    }
                    else
                    {
                        AttemptHack();
                    }
                    break;
                case "2":
                    Console.WriteLine("당신은 싸우기로 결정했습니다.");
                    Thread.Sleep(1000);
                    game.ChangeScene(SceneType.Battle2);
                    break;
                default:
                    Console.WriteLine("잘못된 입력입니다. (1-2)를 입력해주세요.");
                    Thread.Sleep(1000);
                    Input();
                    break;
            }
        }

        private void AttemptDisable()
        {
            if (Utility.RandomSuccess(9))
            {
                Console.WriteLine("보안장치를 무력화하는 데 성공했습니다.");
                game.Player.UseMemento();
                Thread.Sleep(1000);
                Console.WriteLine("다음 방으로 이동합니다.");
                Thread.Sleep(1000);
                game.ChangeScene(SceneType.Boss);
            }
            else
            {
                Console.WriteLine("보안장치 무력화에 실패했습니다. 아라사카의 경찰이 달려옵니다.");
                Thread.Sleep(1000);
                game.ChangeScene(SceneType.Battle2);
            }
        }

        private void AttemptHack()
        {
            if (Utility.RandomSuccess(game.Player.TEC))
            {
                Console.WriteLine("보안 패널 해킹에 성공했습니다.");
                Thread.Sleep(1000);
                Console.WriteLine("다음 방으로 이동합니다.");
                Thread.Sleep(1000);
                game.ChangeScene(SceneType.Boss);
            }
            else
            {
                Console.WriteLine("해킹에 실패했습니다. 아라사카의 경찰이 달려옵니다.");
                Thread.Sleep(1000);
                game.ChangeScene(SceneType.Battle2);
            }
        }


        public override void Exit()
        {
            Console.Clear();
        }
    }
}
