using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TextRPG
{
    public class StatusScene : Scene
    {
        public StatusScene(GameManager gm) : base(gm) { }

        public override void RunScene()
        {
            string choice;

            do
            {
                Console.WriteLine();
                Console.WriteLine("-------정보 일람-------");
                Console.WriteLine();
                Console.WriteLine("Lv : " + gm.Player.Level);
                Console.WriteLine("이 름 : {0}", gm.Player.Name);
                Console.WriteLine("공격력 : " + gm.Player.Att);
                Console.WriteLine("방어력 : " + gm.Player.Def);
                Console.WriteLine("체 력 : " + gm.Player.Hp);
                Console.WriteLine("보유 금액 : {0} 문", gm.Player.Gold);
                Console.WriteLine();
                Console.WriteLine("----------------------");
                Console.WriteLine();
                Console.WriteLine("나가려면 0을 선택하시오.");
                Console.WriteLine();
                Console.Write(">> ");

                choice = Console.ReadLine();

                if (int.Parse(choice) != 0)
                {
                    Console.WriteLine();
                    Console.WriteLine("잘못된 선택이오. 나가기 밖에 없소이다.");
                }
                else
                {
                    gm.ChangeScene(gm.MainScene);
                }

            } while (choice != "0");
        }
    }
}
