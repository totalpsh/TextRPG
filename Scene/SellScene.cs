using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    public class SellScene : Scene
    {
        private Shop shop;
        private List<Item> OwnedItems;
        public SellScene(GameManager gm) : base(gm) { }

        public override void RunScene()
        {
            string choice;
            OwnedItems = GameManager.Instance().Player.Inventory.GetInvenItem;

            do
            {
                Console.WriteLine();
                Console.WriteLine("---------장비 판매---------");
                Console.WriteLine();
                Console.WriteLine("[보유 금액 {0} 문]", gm.Player.Gold);
                Console.WriteLine();

                for (int i = 0; i < OwnedItems.Count; i++)
                {
                    if (OwnedItems[i] == null)
                    {
                        continue;
                    }
                    if (OwnedItems[i].IsEquipped == false)
                    {
                        if (OwnedItems[i].ItemType == EItemType.Weapon)
                        {
                            Console.WriteLine($"-{i + 1}. {OwnedItems[i].Name} | 공격력 +{OwnedItems[i].AttIncrease} | {OwnedItems[i].Description}");
                        }
                        else
                        {
                            Console.WriteLine($"-{i + 1}. {OwnedItems[i].Name} | 방어력 +{OwnedItems[i].DefIncrease} | {OwnedItems[i].Description}");
                        }
                    }
                    else
                    {
                        if (OwnedItems[i].ItemType == EItemType.Weapon)
                        {
                            Console.WriteLine($"-{i + 1}. [E] {OwnedItems[i].Name} | 공격력 +{OwnedItems[i].AttIncrease} | {OwnedItems[i].Description}");
                        }
                        else
                        {
                            Console.WriteLine($"-{i + 1}. [E] {OwnedItems[i].Name} | 방어력 +{OwnedItems[i].DefIncrease} | {OwnedItems[i].Description}");
                        }
                    }
                }

                Console.WriteLine();
                Console.WriteLine("--------------------------");
                Console.WriteLine();
                Console.WriteLine("판매할 장비의 번호를 입력하시오");
                Console.WriteLine();
                Console.WriteLine("0. 나가기");
                Console.WriteLine();
                Console.WriteLine("무엇을 하시겠소?");
                Console.WriteLine();
                Console.Write(">> ");

                choice = Console.ReadLine();

                int index = int.Parse(choice);

                if (choice == "0")
                {
                    gm.ChangeScene(gm.ShopScene);
                    break;
                }

                if (index > 0 && index <= OwnedItems.Count)
                {
                    Item selected = OwnedItems[index - 1];

                    if(gm.Player.Inventory.HasItemCheck(selected))
                    {
                        gm.Player.Inventory.SubItem(selected, gm.Player);
                    }
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
