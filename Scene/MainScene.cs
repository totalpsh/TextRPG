using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    public class MainScene : Scene
    {
        public MainScene(GameManager gm) : base(gm) { }

        public override void RunScene()
        {   
            PrintMenu();            
        }

        void PrintMenu()
        {
            string choice;
            bool next = false;

            do
            {
                Console.WriteLine();
                Console.WriteLine("---------목록---------");
                Console.WriteLine();
                Console.WriteLine("1. 정보 일람");
                Console.WriteLine("2. 행낭 살펴보기.");
                Console.WriteLine("3. 협행 수행");
                Console.WriteLine("4. 장터 가기");
                Console.WriteLine("5. 객잔 방문");
                Console.WriteLine();
                Console.WriteLine("----------------------");
                Console.WriteLine();
                Console.WriteLine("무엇을 하시겠소?");
                Console.WriteLine();
                Console.Write(">> ");

                choice = Console.ReadLine();


                if (choice == "1")
                {
                    gm.ChangeScene(gm.StatusScene);
                    break;
                }
                else if (choice == "2")
                {
                    gm.ChangeScene(gm.InventoryScene);
                    break;
                }
                else if (choice == "3")
                {
                    gm.ChangeScene(gm.DungeonScene);
                    break;
                }
                else if (choice == "4")
                {
                    gm.ChangeScene(gm.ShopScene);
                    break;
                }
                else if (choice == "5")
                {
                    gm.ChangeScene(gm.RestScene);
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
