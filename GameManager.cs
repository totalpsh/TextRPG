using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    public class GameManager
    {
        private static GameManager instance;
        public static GameManager Instance() 
        {
           if (instance == null)
           {
                instance = new GameManager();
           }

           return instance;
        }
        private GameManager() { }


        // 게임 매니저에서 모든걸 관리 한다.
        // 씬 교체(?) 부터
        Scene currentScene;

        // 게임매니저가 총괄할 데이터들
        public MainScene MainScene { get; private set; }
        public StatusScene StatusScene { get; private set; }
        public ShopScene ShopScene { get; private set; }
        public InventoryScene InventoryScene { get; private set; }
        public EquipScene EquipScene { get; private set; }
        public BuyScene BuyScene { get; private set; }
        public SellScene SellScene { get; private set; }
        public DungeonScene DungeonScene { get; private set; }
        public RestScene RestScene { get; private set; }
        public Player Player { get; set; }

        bool isPlaying = false;

        string inputName;
        public string InputName { get; set; }

        // Main에서 가장 먼저 실행할 함수 여기서 게임 시작을하고
        // 씬들을 재생한다.
        public void GamePlay()
        {
            isPlaying = true;

            Player = new Player();
            MainScene = new MainScene(this);
            StatusScene = new StatusScene(this);
            ShopScene = new ShopScene(this);
            BuyScene = new BuyScene(this);
            SellScene = new SellScene(this);
            InventoryScene = new InventoryScene(this);
            EquipScene = new EquipScene(this);
            DungeonScene = new DungeonScene(this);
            RestScene = new RestScene(this);

            currentScene = new StartScene(this);

            while (isPlaying)
            {
                currentScene.RunScene();
            }
        }

        // 씬을 교체한다.
        public void ChangeScene(Scene newScene)
        {
            currentScene = newScene;
        }

    }
}
