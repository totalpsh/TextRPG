using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    public enum EItemType
    {
        Weapon,
        Armor
    }

    public interface IEquipable
    {
        void Equip(Player player)
        {
            Console.WriteLine("아이템 장착함");
        }
        void Unequip(Player player)
        {
            Console.WriteLine("아이템 해제함");

        }
    }

    public abstract class Item : IEquipable
    {
        public string Name { get; protected set; }
        public string Description { get; protected set; }
        public int Price { get; protected set; }
        public EItemType ItemType { get; protected set; }
        public int DefIncrease { get; protected set; }
        public int AttIncrease { get; protected set; }
        public bool IsEquipped { get; set; }
        public bool IsHas { get; protected set; }

        public Item() 
        {
            IsHas = false;
        }

        public abstract void Equip(Player player);
        public abstract void Unequip(Player player);
    }

    public class Weapon : Item
    {
        public Weapon() 
        {
            ItemType = EItemType.Weapon;
        }

        public override void Equip(Player player)
        {
            player.Att += AttIncrease;
            IsEquipped = true;
        }

        public override void Unequip(Player player)
        {
            player.Att -= AttIncrease;
            IsEquipped = false;
        }
    }

    public class Armor : Item
    {
        public Armor() 
        {
            ItemType = EItemType.Armor;
        }

        public override void Equip(Player player)
        {
            player.Def += DefIncrease;
            IsEquipped = true;
        }

        public override void Unequip(Player player)
        {
            player.Def -= DefIncrease;
            IsEquipped = false;
        }
    }

    public class RustySword : Weapon
    {
        public RustySword()
        {
            Name = "녹슨 철검";
            Description = "녹이 슨 철검. 임시방편으로 쓰기에 좋아보인다.";
            AttIncrease = 5;
            Price = 600;
            IsEquipped = false;
        }

        public override void Equip(Player player)
        {
            base.Equip(player);
            
        }

        public override void Unequip(Player player)
        {
            base.Unequip(player);
            
        }

    }

    public class NormalSpear : Weapon
    {
        public NormalSpear()
        {
            //public string Name { get; protected set; }
            //public string Description { get; protected set; }
            //public int Price { get; protected set; }
            //public EItemType ItemType { get; protected set; }
            //public bool IsEquipped { get; protected set; }

            Name = "이빠진 창";
            Description = "녹슨 철검보다 나아보이는 창이다.";
            AttIncrease = 8;
            Price = 1500;
            IsEquipped = false;
        }

        public override void Equip(Player player)
        {
            base.Equip(player);

        }

        public override void Unequip(Player player)
        {
            base.Unequip(player);

        }

    }

    public class Hwando : Weapon
    {
        public Hwando()
        {
            //public string Name { get; protected set; }
            //public string Description { get; protected set; }
            //public int Price { get; protected set; }
            //public EItemType ItemType { get; protected set; }
            //public bool IsEquipped { get; protected set; }

            Name = "환도";
            Description = "날이 잘 벼린 도. 매우 날카롭다.";
            AttIncrease = 12;
            Price = 2000;
            IsEquipped = false;
        }

        public override void Equip(Player player)
        {
            base.Equip(player);

        }

        public override void Unequip(Player player)
        {
            base.Unequip(player);

        }

    }

    public class BlackGuantlet : Weapon
    {
        public BlackGuantlet()
        {
            //public string Name { get; protected set; }
            //public string Description { get; protected set; }
            //public int Price { get; protected set; }
            //public EItemType ItemType { get; protected set; }
            //public bool IsEquipped { get; protected set; }

            Name = "묵철 권갑";
            Description = "검정빛 권갑이다. 매우 튼튼하며 사용자의 힘을 강하게 만들어준다.";
            AttIncrease = 20;
            Price = 4500;
            IsEquipped = false;
        }

        public override void Equip(Player player)
        {
            base.Equip(player);

        }

        public override void Unequip(Player player)
        {
            base.Unequip(player);

        }

    }

    public class NamgungSword : Weapon
    {
        public NamgungSword()
        {
            //public string Name { get; protected set; }
            //public string Description { get; protected set; }
            //public int Price { get; protected set; }
            //public EItemType ItemType { get; protected set; }
            //public bool IsEquipped { get; protected set; }

            Name = "남궁검";
            Description = "남궁세가 무인들이 사용하는 검. 만병지왕은 검이요. 검중지왕은 남궁세가의 검이라는 말이 있다.";
            AttIncrease = 40;
            Price = 8000;
            IsEquipped = false;
        }

        public override void Equip(Player player)
        {
            base.Equip(player);

        }

        public override void Unequip(Player player)
        {
            base.Unequip(player);

        }

    }

    public class LeatherArmor : Armor
    {
        public LeatherArmor()
        {
            //public string Name { get; protected set; }
            //public string Description { get; protected set; }
            //public int Price { get; protected set; }
            //public EItemType ItemType { get; protected set; }
            //public bool IsEquipped { get; protected set; }

            Name = "낡은 가죽 갑옷";
            Description = "가죽을 덕지덕지 덧댄 호신갑이다.";
            DefIncrease = 5;
            Price = 1000;
            IsEquipped = false;
        }

        public override void Equip(Player player)
        {
            base.Equip(player);

        }

        public override void Unequip(Player player)
        {
            base.Unequip(player);

        }

    }

    public class IronArmor : Armor
    {
        public IronArmor()
        {
            //public string Name { get; protected set; }
            //public string Description { get; protected set; }
            //public int Price { get; protected set; }
            //public EItemType ItemType { get; protected set; }
            //public bool IsEquipped { get; protected set; }

            Name = "철 갑옷";
            Description = "관청 무인들이 입는 갑옷 같다. 무거워 보인다.";
            DefIncrease = 9;
            Price = 1500;
            IsEquipped = false;
        }

        public override void Equip(Player player)
        {
            base.Equip(player);

        }

        public override void Unequip(Player player)
        {
            base.Unequip(player);

        }

    }

    public class HwasanCloth : Armor
    {
        public HwasanCloth()
        {
            //public string Name { get; protected set; }
            //public string Description { get; protected set; }
            //public int Price { get; protected set; }
            //public EItemType ItemType { get; protected set; }
            //public bool IsEquipped { get; protected set; }

            Name = "화산파 도복";
            Description = "화산파 도복. 안쪽에 공격을 막아주는 재료가 덧대어져 있다. 가볍다.";
            DefIncrease = 15;
            Price = 2000;
            IsEquipped = false;
        }

        public override void Equip(Player player)
        {
            base.Equip(player);

        }

        public override void Unequip(Player player)
        {
            base.Unequip(player);

        }

    }
    public class GoldArmor : Armor
    {
        public GoldArmor()
        {
            //public string Name { get; protected set; }
            //public string Description { get; protected set; }
            //public int Price { get; protected set; }
            //public EItemType ItemType { get; protected set; }
            //public bool IsEquipped { get; protected set; }

            Name = "금룡갑";
            Description = "금의위가 입는 갑옷이다. 왜 여깄는지 모르겠지만 매우 튼튼하며 가볍다.";
            DefIncrease = 25;
            Price = 5000;
            IsEquipped = false;
        }

        public override void Equip(Player player)
        {
            base.Equip(player);

        }

        public override void Unequip(Player player)
        {
            base.Unequip(player);

        }

    }

    public class FighterArmor : Armor
    {
        public FighterArmor()
        {
            //public string Name { get; protected set; }
            //public string Description { get; protected set; }
            //public int Price { get; protected set; }
            //public EItemType ItemType { get; protected set; }
            //public bool IsEquipped { get; protected set; }

            Name = "권황의 버려진 호신갑";
            Description = "천하제일십인 안에 있는 권황이 입던 호신갑이다. 매우 튼튼하다.";
            DefIncrease = 40;
            Price = 10000;
            IsEquipped = false;
        }

        public override void Equip(Player player)
        {
            base.Equip(player);

        }

        public override void Unequip(Player player)
        {
            base.Unequip(player);

        }

    }
}
