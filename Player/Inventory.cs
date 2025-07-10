using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    public class Inventory
    {
        // 0번 인덱스 무기, 1번 인덱스 방어구

        Item equipedWeapon;
        Item equipedArmor;
        List<Item> invenItems = new List<Item>();

        public List<Item> GetInvenItem { get { return invenItems; } }
        public Item GetEquipedWeapon { get { return equipedWeapon; } }
        public Item GetEquipedArmor { get { return equipedArmor; } }

        public Inventory() { }

        public void EquipItem(Item target)
        {
            if (target.ItemType == EItemType.Weapon)
            {
                if (GetEquipedWeapon == null)
                {
                    equipedWeapon = target;
                    target.Equip(GameManager.Instance().Player);
                }
                else
                {
                    equipedWeapon.Unequip(GameManager.Instance().Player);
                    target.Equip(GameManager.Instance().Player);
                    equipedWeapon = target;
                }
            }
            else
            {
                if(GetEquipedArmor == null)
                {
                    equipedArmor = target;
                    target.Equip(GameManager.Instance().Player);
                }
                else
                {
                    equipedArmor.Unequip(GameManager.Instance().Player);
                    target.Equip(GameManager.Instance().Player);
                    equipedArmor = target;
                }
            }
        }

        public void UnEquipItem(Item target)
        {
            if (target.ItemType == EItemType.Weapon)
            {
                if (equipedWeapon == target)
                {
                    target.Unequip(GameManager.Instance().Player);
                    equipedWeapon = null;
                }
            }
            else
            {
                if (equipedArmor == target)
                {
                    target.Unequip(GameManager.Instance().Player);
                    equipedArmor = null;
                }
            }
             

        }

        public void AddItem(Item buyItem)
        {
             invenItems.Add(buyItem);
        }

        public void SubItem(Item sellItem, Player player)
        {
            UnEquipItem(sellItem);
 
            if (invenItems.Contains(sellItem))
            {
                for (int i = 0; i < invenItems.Count; i++)
                {
                    if (invenItems[i].Name == sellItem.Name)
                    {
                        player.Gold += sellItem.Price / 100 * 85;
                        invenItems.RemoveAt(i);
                        break;
                    }
                }
            }
        }

        public bool HasItemCheck(Item target)
        {
            if (invenItems.Contains(target))
            {
                return true;
            }
            else
            {
               return false;
            }
        }
    }
}
