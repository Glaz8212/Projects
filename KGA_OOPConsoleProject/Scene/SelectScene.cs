using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KGA_OOPConsoleProject.Scene
{
    public class SelectScene : Scene
    {
        public SelectScene(Game game) : base(game)
        {
        }

        public override void Enter()
        {
            Console.Clear();
            Console.Write("캐릭터의 이름을 입력하세요 - ");
        }

        public override void Exit()
        {

        }

        public override void Input()
        {
            string characterName = Console.ReadLine();
            game.Player = new Player.Player(characterName);
            game.ChangeScene(SceneType.Bonfire);
        }

        public override void Render()
        {

        }

        public override void Update()
        {

        }
    }
}
