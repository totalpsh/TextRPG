using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    public class BuyScene : Scene
    {
        private Shop shop;
        private List<Item> sellList;
        public BuyScene(GameManager gm) : base(gm)
        {
            shop = new Shop();
        }

        public override void RunScene()
        {
            string choice;
            sellList = shop.GetShopItems();
            do
            {
                Console.WriteLine();
                Console.WriteLine("---------장비 구매---------");
                Console.WriteLine();
                Console.WriteLine("[보유 금액 {0} 문]", gm.Player.Gold);
                Console.WriteLine();

                for (int i = 0; i < sellList.Count; i++)
                {
                    if (gm.Player.Inventory.HasItemCheck(sellList[i]))
                    {
                        Console.WriteLine($"- {i + 1}. {sellList[i].Name} | {sellList[i].Price} 문 | [보유 중]");
                        
                        if (sellList[i].ItemType == EItemType.Weapon)
                        {
                            Console.WriteLine("     공격력 +{0} | {1}", sellList[i].AttIncrease, sellList[i].Description);
                        }
                        else
                        {
                            Console.WriteLine("     방어력 +{0} | {1}", sellList[i].DefIncrease, sellList[i].Description);
                        }
                    }
                    else
                    {
                        Console.WriteLine($"- {i + 1}. {sellList[i].Name} | {sellList[i].Price} 문");
                        if (sellList[i].ItemType == EItemType.Weapon)
                        {
                            Console.WriteLine("     공격력 +{0} | {1}", sellList[i].AttIncrease, sellList[i].Description);
                        }
                        else
                        {
                            Console.WriteLine("     방어력 +{0} | {1}", sellList[i].DefIncrease, sellList[i].Description);
                        }
                    }
                }

                Console.WriteLine();
                Console.WriteLine("--------------------------");
                Console.WriteLine();
                Console.WriteLine("구매할 장비의 번호를 입력하시오");
                Console.WriteLine();
                Console.WriteLine("0. 나가기");
                Console.WriteLine();
                Console.WriteLine("무엇을 하시겠소?");
                Console.WriteLine();
                Console.Write(">> ");
                choice = Console.ReadLine();

                int index = int.Parse(choice);

                if (index == 0)
                {
                    gm.ChangeScene(gm.ShopScene);
                    break;
                }
                else if (index > 0 && index <= sellList.Count)
                {
                    Item selected = sellList[index - 1];

                    if(gm.Player.Inventory.HasItemCheck(selected))
                    {
                        Console.WriteLine();
                        Console.WriteLine("이미 보유 중이오..");
                    }
                    else
                    {
                        if (gm.Player.Gold >= selected.Price)
                        {
                            gm.Player.Gold -= selected.Price;
                            gm.Player.Inventory.AddItem(selected);
                            Console.WriteLine();
                            Console.WriteLine($"{selected.Name}을 구매했소!");
                        }
                        else
                        {
                            Console.WriteLine();
                            Console.WriteLine("돈이 부족하구려..");
                        }
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
