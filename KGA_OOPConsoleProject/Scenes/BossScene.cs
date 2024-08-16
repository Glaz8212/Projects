using KGA_OOPConsoleProject.Enemys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KGA_OOPConsoleProject.Scenes
{
    public class BossScene : Scene
    {
        private Enemy boss;

        public BossScene(Game game) : base(game)
        {
            boss = new Enemy("아담 스매셔", "위압감이 넘칩니다. 중무장을 하고 있습니다.", 20, 100);
        }

        public override void Enter()
        {
            Console.Clear();
            Console.WriteLine("===== 보스 전투 시작 =====");
            Console.WriteLine($"{boss.Name}와 마주쳤습니다! {boss.Description}");
            Console.WriteLine("아담 스매셔의 뒤쪽으로 당신이 찾고있던 문서가 보입니다.");
            Console.WriteLine("당신은 임무를 완수하기 위해서 아담 스매셔를 해치워야 합니다.");
        }

        public override void Render()
        {
            Thread.Sleep(1000);
            game.Player.Status();

            Console.WriteLine($"{boss.Name}의 현재 체력: {boss.CurHp}/{boss.MaxHp}");
            Console.WriteLine($"당신의 현재 체력: {game.Player.CurHp}/{game.Player.MaxHp}");
            Console.WriteLine();

            if (game.Player.Lifepath == Lifepath.StreetKid)
            {
                Console.WriteLine("1. 공격하기");
                Console.WriteLine("2. 해킹 시도");
                Console.WriteLine("3. 부랑자의 일기장을 사용하여 히든 엔딩으로 가기");
                Console.WriteLine();
                Console.Write("선택지를 입력하세요 (1-3): ");
            }
            else
            {
                Console.WriteLine("1. 공격하기");
                Console.WriteLine("2. 해킹 시도");
                Console.WriteLine();
                Console.Write("선택지를 입력하세요 (1-2): ");
            }
        }

        public override void Input()
        {
            string input = Console.ReadLine();

            if (game.Player.Lifepath == Lifepath.StreetKid && input == "3")
            {
                Thread.Sleep(1000);
                Console.WriteLine("당신은 부랑자의 일기장을 사용하여 진엔딩으로 진입합니다...");
                game.Player.UseMemento();
                HiddenEnding();
                return;
            }

            switch (input)
            {
                case "1":
                    PlayerAttack();
                    break;
                case "2":
                    PlayerHack();
                    break;
                default:
                    Console.WriteLine("잘못된 입력입니다. 다시 시도하세요.");
                    Input();
                    break;
            }

            if (!boss.IsDead())
            {
                BossAttack();
                Render();
                Input();
            }

            else
            {
                Console.WriteLine($"{boss.Name}를 물리쳤습니다!");
                Console.WriteLine("축하합니다! 게임을 클리어했습니다!");
                Thread.Sleep(1000);
                game.Over();
            }
        }

        private void PlayerAttack()
        {
            int damage = game.Player.Attack();
            boss.TakeDamage(damage);
            Thread.Sleep(1000);
            Console.WriteLine($"당신은 {boss.Name}에게 {damage}의 데미지를 입혔습니다.");
        }

        private void PlayerHack()
        {
            game.Player.Hack(boss);
        }

        private void BossAttack()
        {
            int damage = boss.Attack();
            game.Player.TakeDamage(damage);
            Thread.Sleep(1000);
            Console.WriteLine($"{boss.Name}가 당신에게 {damage}의 데미지를 입혔습니다.");
            Thread.Sleep(1000);

            if (game.Player.IsDead())
            {
                Console.WriteLine("당신은 보스와의 전투에서 패배했습니다...");
                Thread.Sleep(1000);
                game.Over();
            }
        }

        private void HiddenEnding()
        {
            Console.Clear();
            Thread.Sleep(1000);
            Console.WriteLine("당신은 보스와의 전투를 회피하고, 중요한 진실을 발견합니다.");
            Console.WriteLine("이곳의 비리에 대한 모든 정보가 일기장에 기록되어 있습니다.");
            Console.WriteLine("당신은 이 진실을 세상에 알리기로 결심합니다...");
            Thread.Sleep(1000);
            game.Over();
        }


        public override void Exit()
        {
            Console.Clear();
        }
    }
}

