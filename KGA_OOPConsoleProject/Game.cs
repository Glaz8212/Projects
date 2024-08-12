using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KGA_OOPConsoleProject.Scene;
using KGA_OOPConsoleProject.Player;

namespace KGA_OOPConsoleProject
{
    public class Game
    {
        private bool isRunning;

        private Scene[] scenes;
        private Scene curScene;
        public Scene CruScene { get { return curScene; } }

        private Player player;
        public Player Player { get { return player; } set { player = value; } }

        public void Run()
        {
            Start();
            while (isRunning)
            {
                Render();
                Input();
                Update();
            }
            End();
        }

        public void ChangeScene(SceneType sceneType)
        {
            curScene.Exit();
            curScene = scenes[(int)sceneType];
            curScene.Enter();
        }

        public void Over()
        {
            isRunning = false;
        }

        private void Start()
        {
            isRunning = true;

            scenes = new Scene[(int)SceneType.Size];
            scenes[(int)SceneType.Title] = new TitleScene(this);
            scenes[(int)SceneType.Select] = new SelectScene(this);
            scenes[(int)SceneType.Bonfire] = new BonfireScene(this);
            scenes[(int)SceneType.Merchant] = new MerchantScene(this);
            scenes[(int)SceneType.Hidden] = new HiddenScene(this);
            scenes[(int)SceneType.Parish] = new ParishScene(this);
            scenes[(int)SceneType.Ruins] = new RuinsScene(this);
            scenes[(int)SceneType.Garden] = new GardenScene(this);
            scenes[(int)SceneType.Cave] = new CaveScene(this);
            scenes[(int)SceneType.Inventory] = new InventoryScene(this);

            curScene = scenes[(int)SceneType.Title];
            curScene.Enter();
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

        private void Update()
        {
            curScene.Update();
        }
    }
}
