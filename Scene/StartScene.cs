using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    public class StartScene : Scene
    {
        string choice;

        int[,] logo = new int[10, 15] {
            { 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 0, 1},
            { 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 1},
            { 1, 0, 0, 0, 0, 0, 1, 0, 1, 1, 1, 1, 1, 0, 1},
            { 1, 0, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 0, 1},
            { 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 0, 1},
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
            { 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1},
            { 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1},
            { 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1},
            { 0, 0, 0, 1, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1}
            };
        
        public StartScene(GameManager gm) : base(gm) { }

        public override void RunScene()
        {
            Console.WriteLine("반갑소!");
            Console.WriteLine("여기는");

            for(int i = 0; i < 10; i++)
            {
                for(int j = 0; j < 15; j++)
                {
                    if (logo[i, j] == 1)
                    {
                        Console.Write("■");
                    }
                    else if (logo[i, j] == 0)
                    {
                        Console.Write(" ");
                    }
                }
                if (i != 9) Console.WriteLine();
                else Console.Write("");
            }
            Console.WriteLine("이오");

            do
            {
                Console.WriteLine();
                Console.WriteLine("시작하시겠소?");
                Console.WriteLine("1. 새로 시작한다.");
                Console.WriteLine("2. 저장된 게임을 불러온다. (미구현)");
                Console.WriteLine("3. 아니오 (선택 시 종료되오.)");
                Console.WriteLine();
                Console.Write(">> ");

                choice = Console.ReadLine();
                
                if (choice == "1")
                {
                    Console.WriteLine();
                    Console.WriteLine("당신의 이름은 무엇이오? ");
                    Console.WriteLine();
                    Console.Write(">> ");
                    string inputName = Console.ReadLine();
                    Console.WriteLine();
                    Console.WriteLine(inputName + "이라 맘에 드는군!");
                    gm.Player.Name = inputName;

                    gm.ChangeScene(gm.MainScene);
                }
                else if (choice == "2")
                {
                    // 저장된 데이터 불러오기
                }
                else if (choice == "3")
                {
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("없는 선택이오. 다시 선택하시오.");
                }

            } while (choice != "1" && choice != "2" && choice != "3");

            
        }
    }
}
