using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    public class RestScene : Scene
    {
        public RestScene(GameManager gm) : base(gm) { }

        public override void RunScene()
        {
            string choice;
            do
            {
                Console.WriteLine();
                Console.WriteLine("-------객잔 방문-------");
                Console.WriteLine();
                Console.WriteLine($"500냥으로 하루 묵고 체력을 회복할 수 있소. [보유 골드 : {gm.Player.Gold}]");
                Console.WriteLine();
                Console.WriteLine("1. 묵기");
                Console.WriteLine("0. 나가기");
                Console.WriteLine();
                Console.WriteLine("----------------------");
                Console.WriteLine();
                Console.WriteLine("나가려면 0을 선택하시오.");
                Console.WriteLine();
                Console.Write(">> ");

                choice = Console.ReadLine();

                if(choice == "0")
                {
                    gm.ChangeScene(gm.MainScene);
                    break;
                }
                else if(choice == "1")
                {
                    if (gm.Player.Gold < 500)
                    {
                        Console.WriteLine();
                        Console.WriteLine("돈이 모자르오..");
                    }
                    else
                    {
                        gm.Player.Gold -= 500;
                        gm.Player.Rest();
                    }
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("잘못된 선택이오. 나가기 밖에 없소이다.");
                }

            } while (true);
        }
    }
}
