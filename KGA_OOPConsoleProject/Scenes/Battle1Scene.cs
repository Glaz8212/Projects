using KGA_OOPConsoleProject.Enemys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KGA_OOPConsoleProject.Scenes
{
    public class Battle1Scene : Scene
    {
        private Enemy enemy;

        public Battle1Scene(Game game) : base(game)
        {
            enemy = new Enemy("아라사카 보안요원", "그리 강해 보이지는 않습니다.", 5, 30);
        }

        public override void Enter()
        {
            Console.Clear();
            Console.WriteLine("===== 전투 시작 =====");
            Console.WriteLine($"{enemy.Name}은 무기를 꺼내듭니다. {enemy.Description}");
        }

        public override void Render()
        {
            Thread.Sleep(1000);
            game.Player.Status();

            Console.WriteLine($"{enemy.Name}의 현재 체력: {enemy.CurHp}/{enemy.MaxHp}");
            Console.WriteLine($"당신의 현재 체력: {game.Player.CurHp}/{game.Player.MaxHp}");
            Console.WriteLine();
            Console.WriteLine("1. 공격하기");
            Console.WriteLine("2. 해킹 시도");
            Console.Write("선택지를 입력하세요 (1-2): ");
        }

        public override void Input()
        {
            while (true)
            {
                string input = Console.ReadLine();

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
                        continue;
                }
                Console.WriteLine();
                if (!enemy.IsDead())
                {
                    EnemyAttack();
                    Console.WriteLine();
                }
                else
                {
                    Thread.Sleep(1000);
                    Console.WriteLine($"{enemy.Name}을 물리쳤습니다!");
                    game.Player.PlusAllStats();
                    game.Player.RecoverHp();
                    Console.WriteLine("모든 스탯이 1씩 증가했습니다. 체력이 완전히 회복되었습니다.");
                    Thread.Sleep(2000);
                    game.ChangeScene(SceneType.Security);
                }
                break;
            }
        }

        private void PlayerAttack()
        {
            int damage = game.Player.Attack();
            enemy.TakeDamage(damage);
            Thread.Sleep(1000);
            Console.WriteLine($"당신은 {enemy.Name}에게 {damage}의 데미지를 입혔습니다.");
        }

        private void PlayerHack()
        {
            game.Player.Hack(enemy);
        }

        private void EnemyAttack()
        {
            int damage = enemy.Attack();
            game.Player.TakeDamage(damage);
            Thread.Sleep(1000);
            Console.WriteLine($"{enemy.Name}이 당신에게 {damage}의 데미지를 입혔습니다.");

            if (game.Player.IsDead())
            {
                Console.WriteLine("당신은 전투에서 패배했습니다...");
                Thread.Sleep(1000);
                game.Over();
            }
        }

        public override void Exit()
        {
            Console.Clear();
        }
    }
}