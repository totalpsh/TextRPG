using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace TextRPG
{
    public class Player
    {
        public Inventory Inventory { get; set; }
        public sbyte Level { get; set; }
        public string Name{ get; set; }
        public float Att { get; set; }
        public float Def { get; set; }
        public float Hp { get; set; }
        public int Gold { get; set; }

        public Player()
        {
            Level = 1;
            Att = 10;
            Def = 5;
            Hp = 100;
            Gold = 50000;

            Inventory = new Inventory();
            
        }

        public float DungeonResultHp(bool result, float requiredDef) 
        {
            if (result)
            {
                Random rand = new Random();
                Hp = Hp - (rand.Next((int)(20 - (requiredDef - Def)), (int)(35 - (requiredDef - Def))));
            }
            else
            {
                Hp /= 2;
            }

            return Hp;
        }

        public int DugeonClearReward(int RewardGold)
        {
            Random rand = new Random();

            // 보상 1000 + ((1000/100 ) * (플레이어 공격력 ~ 플레이어 공격력 * 2))
            Gold += RewardGold + (RewardGold / 100) * (rand.Next((int)Att, (int)Att * 2));

            return Gold;
        }

        public void LevelUp()
        {
            Level++;
            Att += 0.5f;
            Def += 1.0f;
            Console.WriteLine();
            Console.WriteLine("Lv UP");
            Console.WriteLine();
            Console.WriteLine("공격력 +0.5, 방어력 +1.0");
            Console.WriteLine();
            Console.WriteLine("\"축하하오. 깨달음이 있었나보군\"");
            Console.WriteLine();
        }

        public void Rest()
        {
            Hp = 100;
        }
    }
}
