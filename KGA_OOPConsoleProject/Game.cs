using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using KGA_OOPConsoleProject.Players;
using KGA_OOPConsoleProject.Scenes;

namespace KGA_OOPConsoleProject
{
    public class Game
    {
        private bool isRunning;

        private Scene[] scenes;
        private Scene curScene;
        public Scene CurScene { get { return curScene; } }
        
        private Player player;
        public Player Player { get { return player; } set { player = value; } }
        
        public void Run()
        {
            Start();
            while (isRunning)
            {
                Render();
                Input();
            }
            End();
        }

        public void ChangeScene(SceneType sceneType)
        {
            curScene.Exit();
            curScene = scenes[(int)sceneType];
            curScene.Enter();
        }

        private void Start()
        {
            isRunning = true;

            scenes = new Scene[(int)SceneType.Size];
            scenes[(int)SceneType.Title] = new TitleScene(this);
            scenes[(int)SceneType.Select] = new SelectScene(this);
            scenes[(int)SceneType.Confirm] = new ConfirmScene(this);
            scenes[(int)SceneType.Intro] = new IntroScene(this);
            scenes[(int)SceneType.Spaceship] = new SpaceshipScene(this);
            scenes[(int)SceneType.Entrance] = new EntranceScene(this);
            scenes[(int)SceneType.Security] = new SecurityScene(this);
            scenes[(int)SceneType.Battle1] = new Battle1Scene(this);
            scenes[(int)SceneType.Battle2] = new Battle2Scene(this);
            scenes[(int)SceneType.Boss] = new BossScene(this);

            curScene = scenes[(int)SceneType.Title];
        }

        private void End()
        {
            curScene.Exit();
        }

        private void Render()
        {
            curScene.Render();
        }

        private void Input()
        {
            curScene.Input();
        }


        public void Over()
        {
            isRunning = false;

            Console.WriteLine("게임이 종료되었습니다. 메인 메뉴로 돌아갑니다.");

            Thread.Sleep(2000);

            curScene.Exit();
            curScene = scenes[(int)SceneType.Title];
        }
    }
}
