using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    public class InventoryScene : Scene
    {
        public InventoryScene(GameManager gm) : base(gm) { }

        public override void RunScene()
        {
            string choice;
            do
            {
                Console.WriteLine();
                Console.WriteLine("---------행 낭---------");
                Console.WriteLine();
                Console.WriteLine("[보유 금액 {0} 문]", gm.Player.Gold);
                Console.WriteLine();
                Console.WriteLine("[보유 아이템 목록]");
                Console.WriteLine();

                foreach (Item item in gm.Player.Inventory.GetInvenItem)
                {
                    if(item == null)
                    {
                        continue;
                    }
                    if (item.IsEquipped == false)
                    {
                        if (item.ItemType == EItemType.Weapon)
                        {
                            Console.WriteLine($"- {item.Name} | 공격력 +{item.AttIncrease} | {item.Description}");
                        }
                        else
                        {
                            Console.WriteLine($"- {item.Name} | 방어력 +{item.DefIncrease} | {item.Description}");
                        }
                    }
                    else
                    {
                        if (item.ItemType == EItemType.Weapon)
                        {
                            Console.WriteLine($"- [E] {item.Name} | 공격력 +{item.AttIncrease} | {item.Description}");
                        }
                        else
                        {
                            Console.WriteLine($"- [E] {item.Name} | 방어력 +{item.DefIncrease} | {item.Description}");
                        }
                    }
                }

                Console.WriteLine();
                Console.WriteLine("-----------------------");
                Console.WriteLine();
                Console.WriteLine("1. 장착 관리");
                Console.WriteLine("0. 나가기");
                Console.WriteLine();
                Console.WriteLine("무엇을 하시겠소?");
                Console.WriteLine();
                Console.Write(">> ");
                choice = Console.ReadLine();

                if (choice == "1")
                {
                    gm.ChangeScene(gm.EquipScene);
                }
                else if (choice == "0")
                {
                    gm.ChangeScene(gm.MainScene);
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("없는 선택이오. 다시 선택하시오.");
                }
            } while (choice != "0" && choice != "1");
        }
    }
}
