using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    public class DungeonScene : Scene
    {
        public DungeonScene(GameManager gm) : base(gm) { }
        List<Dungeon> dungeons = new List<Dungeon>
        {
            new EasyDungeon(),
            new MediumDungeon(),
            new HardDungeon()
        };

        public override void RunScene()
        {
            string choice;

            do
            {
                Console.WriteLine();
                Console.WriteLine("---------협행 수행---------");
                Console.WriteLine();
                Console.WriteLine($"1. {dungeons[0].DungeonName}  |  난이도 쉬움  |  방어력 {dungeons[0].RequiredDef}이상 권장");
                Console.WriteLine($"2. {dungeons[1].DungeonName}  |  난이도 보통  |  방어력 {dungeons[1].RequiredDef}이상 권장");
                Console.WriteLine($"3. {dungeons[2].DungeonName}  |  난이도 어려움  |  방어력 {dungeons[2].RequiredDef}이상 권장");
                Console.WriteLine();
                Console.WriteLine("--------------------------");
                Console.WriteLine();
                Console.WriteLine("무엇을 하시겠소?");
                Console.WriteLine();
                Console.WriteLine("0. 나가기");
                Console.WriteLine();
                Console.Write(">> ");

                choice = Console.ReadLine();

                if(choice == "0")
                {
                    gm.ChangeScene(gm.MainScene);
                    break;
                }
                else if (choice == "1")
                {
                    dungeons[0].Enter(gm.Player);
                    break;
                }
                else if (choice == "2")
                {
                    dungeons[1].Enter(gm.Player);
                    break;
                }
                else if (choice == "3")
                {
                    dungeons[2].Enter(gm.Player);
                    break;
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("없는 선택이오. 다시 선택하시오.");
                }

            } while (true);


        }
    }
}
