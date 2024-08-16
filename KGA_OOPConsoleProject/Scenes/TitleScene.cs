using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KGA_OOPConsoleProject.Scenes
{
    public class TitleScene : Scene
    {
        public TitleScene(Game game) : base(game) { }

        public override void Enter()
        {
            Console.Clear();
            Render();
        }

        public override void Render()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(" _____ __   ________  _____ ______ ______  _   _  _   _  _   __");
            Console.WriteLine("/  __ \\\\ \\ / /| ___ \\|  ___|| ___ \\| ___ \\| | | || \\ | || | / /");
            Console.WriteLine("| /  \\/ \\ V / | |_/ /| |__  | |_/ /| |_/ /| | | ||  \\| || |/ / ");
            Console.WriteLine("| |      \\ /  | ___ \\|  __| |    / |  __/ | | | || . ` ||    \\ ");
            Console.WriteLine("| \\__/\\  | |  | |_/ /| |___ | |\\ \\ | |    | |_| || |\\  || |\\  \\");
            Console.WriteLine(" \\____/  \\_/  \\____/ \\____/ \\_| \\_|\\_|     \\___/ \\_| \\_/\\_| \\_/");
            Console.WriteLine();
            Thread.Sleep(2000);
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("                 _ _   __|_ _ |   _  _ | _  _ _ ");
            Console.WriteLine("                (_| \\/_\\ | (_||  |_)(_||(_|(_(/_");
            Console.WriteLine("                    /            |              ");
            Console.ResetColor();
            Thread.Sleep(2000);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("             게임을 시작하려면 아무 키나 누르세요.");
        }

        public override void Input()
        {
            Console.ReadKey(true);
            game.ChangeScene(SceneType.Select);
        }


        public override void Exit()
        {
            Console.Clear();
        }
    }
}
