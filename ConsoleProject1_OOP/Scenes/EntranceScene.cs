using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KGA_OOPConsoleProject.Scenes
{
    public class EntranceScene : Scene
    {
        public EntranceScene(Game game) : base(game) { }

        public override void Enter()
        {
            Console.Clear();
            Render();
            Input();
        }

        public override void Render()
        {
            game.Player.Status();

            Console.WriteLine("===== 우주 정거장 입구 =====");
            Thread.Sleep(1000);
            Console.WriteLine();
            Console.WriteLine("당신은 우여곡절 끝에 우주 정거장 '크리스탈 팰리스'의 입구에 도착했습니다.");
            Console.WriteLine("입구에는 아라사카 보안부 직원이 경계 중입니다.");
            Console.WriteLine();
            Thread.Sleep(1000);

            if (game.Player.Lifepath == Lifepath.Corpo)
            {
                Console.WriteLine("기업 출신인 당신은 직원의 낮은 직급을 알아차립니다.");
                Console.WriteLine("아라사카 ID카드를 보여줘 높은 확률로 통과할 수 있습니다.");
                Console.WriteLine();
                Console.Write("ID카드를 사용할까요? (Y/N): ");
            }
            else
            {
                Console.WriteLine("당신은 몇 가지 방법을 떠올립니다.");
                Console.WriteLine();
                Console.WriteLine("1. (냉정) 보안요원을 기만하여 통과한다.");
                Console.WriteLine("2. (기술) 보안 패널을 해킹하여 경보를 무력화한다.");
                Console.WriteLine("3. 그딴 건 없다. 싸운다.");
                Console.WriteLine();
                Console.Write("선택지를 입력해주세요 (1-3): ");
            }
            Thread.Sleep(1000);
        }

        public override void Input()
        {
            string input = Console.ReadLine();

            if (game.Player.Lifepath == Lifepath.Corpo)
            {
                if (input == "Y" || input == "y")
                {
                    if (AttemptCorpo())
                    {
                        Console.WriteLine("당신은 보안요원을 설득하여 무사히 통과했습니다.");
                        game.Player.UseMemento();
                        Thread.Sleep(1000);
                        game.ChangeScene(SceneType.Security);
                    }
                    else
                    {
                        Console.WriteLine("ID카드가 의심받아 전투가 발생했습니다.");
                        game.Player.UseMemento();
                        Thread.Sleep(1000);
                        game.ChangeScene(SceneType.Battle1);
                    }
                }
                else
                {
                    Console.WriteLine("당신은 싸우기로 결정했습니다.");
                    Thread.Sleep(1000);
                    game.ChangeScene(SceneType.Battle1);
                }
            }
            else
            {
                switch (input)
                {
                    case "1":
                        if (AttemptCool())
                        {
                            Console.WriteLine("당신은 보안요원을 속여 무사히 통과했습니다.");
                            Thread.Sleep(1000);
                            game.ChangeScene(SceneType.Security);
                        }
                        else
                        {
                            Console.WriteLine("속이려 했지만 실패했습니다. 보안요원은 전투태세를 취합니다.");
                            Thread.Sleep(1000);
                            game.ChangeScene(SceneType.Battle1);
                        }
                        break;

                    case "2":
                        if (AttemptTech())
                        {
                            Console.WriteLine("당신은 보안 패널을 성공적으로 해킹하여 무사히 통과했습니다.");
                            Thread.Sleep(1000);
                            game.ChangeScene(SceneType.Security);
                        }
                        else
                        {
                            Console.WriteLine("해킹에 실패했습니다. 보안요원이 달려옵니다.");
                            Thread.Sleep(1000);
                            game.ChangeScene(SceneType.Battle1);
                        }
                        break;

                    case "3":
                        Console.WriteLine("당신은 싸우기로 결정했습니다.");
                        Thread.Sleep(1000);
                        game.ChangeScene(SceneType.Battle1);
                        break;

                    default:
                        Console.WriteLine("잘못된 입력입니다. (1-3)을 입력해주세요.");
                        Input();
                        break;
                }
            }
        }

        private bool AttemptCorpo()
        {
            return Utility.RandomSuccess(9);
        }

        private bool AttemptCool()
        {
            return Utility.RandomSuccess(game.Player.COL);
        }

        private bool AttemptTech()
        {
            return Utility.RandomSuccess(game.Player.TEC);
        }

        public override void Exit()
        {
            Console.Clear();
        }
    }
}