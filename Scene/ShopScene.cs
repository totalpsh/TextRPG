using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    public class ShopScene : Scene
    {
        private Shop shop;
        private List<Item> sellList;
        private List<Item> ownedItems;

        public BuyScene BuySellScene { get; private set; }

        public ShopScene(GameManager gm) : base(gm) 
        {
            shop = new Shop();
        }

        public override void RunScene()
        {
            string choice;
            sellList = shop.GetShopItems();
            ownedItems = gm.Player.Inventory.GetInvenItem;
            for(int i = 0; i < ownedItems.Count; i++)
            {
                Console.WriteLine(ownedItems[i].Name);
            }

            do
            {
                Console.WriteLine();
                Console.WriteLine("---------장터---------");
                Console.WriteLine();
                Console.WriteLine("[보유 금액 {0} 문]", gm.Player.Gold);
                Console.WriteLine();

                for (int i = 0; i < sellList.Count; i++)
                {
                    //여기서 이게 보유중이 안뜸 수정해야할 문제
                    if (gm.Player.Inventory.HasItemCheck(sellList[i]))
                    {

                        if (sellList[i].ItemType == EItemType.Weapon)
                        {
                            Console.WriteLine($"- {sellList[i].Name} | {sellList[i].Price} 문 | [보유 중]");
                            Console.WriteLine("  공격력 +{0} | {1}", sellList[i].AttIncrease, sellList[i].Description);
                        }
                        else
                        {
                            Console.WriteLine($"- {sellList[i].Name} | {sellList[i].Price} 문 | [보유 중]");
                            Console.WriteLine("  방어력 +{0} | {1}", sellList[i].DefIncrease, sellList[i].Description);
                        }
                    }
                    else
                    {
                        Console.WriteLine($"- {sellList[i].Name} | {sellList[i].Price} 문");
                        if (sellList[i].ItemType == EItemType.Weapon)
                        {
                            Console.WriteLine("  공격력 +{0} | {1}", sellList[i].AttIncrease, sellList[i].Description);
                        }
                        else
                        {
                            Console.WriteLine("  방어력 +{0} | {1}", sellList[i].DefIncrease, sellList[i].Description);
                        }
                    }
                }
                Console.WriteLine();
                Console.WriteLine("----------------------");
                Console.WriteLine();
                Console.WriteLine("1. 구매하기");
                Console.WriteLine("2. 판매하기");
                Console.WriteLine("0. 나가기");
                Console.WriteLine();
                Console.WriteLine("무엇을 하시겠소?");
                Console.WriteLine();
                Console.Write(">> ");
                choice = Console.ReadLine();

                if (choice == "1")
                {
                    gm.ChangeScene(gm.BuyScene);
                    break;
                }
                else if(choice == "2")
                {
                    gm.ChangeScene(gm.SellScene);
                    break;
                }
                else if (choice == "0")
                {
                    gm.ChangeScene(gm.MainScene);
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
