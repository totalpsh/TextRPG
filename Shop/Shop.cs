using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    public class Shop
    {
        private List<Item> shopItems;

        public Shop()
        {
            shopItems = new List<Item>
            {
                new RustySword(),
                new NormalSpear(),
                new Hwando(),
                new BlackGuantlet(),
                new NamgungSword(),
                new LeatherArmor(),
                new IronArmor(),
                new HwasanCloth(),
                new GoldArmor(),
                new FighterArmor(),
            };
        }

        public List<Item> GetShopItems()
        {
            return shopItems;
        }
    }
}
