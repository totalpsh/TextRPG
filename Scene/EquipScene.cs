using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    public class EquipScene : Scene
    {
        private Inventory inventory;
        private List<Item> OwnedItems;
        private Item EquipedWeapon;
        private Item EquipedArmor;
        public EquipScene(GameManager gm) : base(gm) { }

        public override void RunScene()
        {
            string choice;
            inventory = gm.Player.Inventory;
            OwnedItems = inventory.GetInvenItem;
            EquipedWeapon = inventory.GetEquipedWeapon;
            EquipedArmor = inventory.GetEquipedArmor;

            do
            {
                Console.WriteLine();
                Console.WriteLine("---------장비 장착---------");
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
                Console.WriteLine("---------------------------");
                Console.WriteLine("장착할 장비의 번호를 입력하시오");
                Console.WriteLine("0. 나가기");

                Console.Write(">> ");
                choice = Console.ReadLine();

                int index = int.Parse(choice);

                if (choice == "0")
                {
                    gm.ChangeScene(gm.InventoryScene);
                }

                if (index > 0 && index <= OwnedItems.Count)
                {
                    if (!OwnedItems[index - 1].IsEquipped)
                    {
                        inventory.EquipItem(OwnedItems[index - 1]);
                    }
                    else
                    {
                        inventory.UnEquipItem(OwnedItems[index - 1]);
                    }
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
