using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    public class HardDungeon : Dungeon
    {
        public override string DungeonName
        {
            get { return "마교 척결"; }
        }

        public override float RequiredDef
        {
            get { return 20; }
        }

        public override int RewardGold
        {
            get { return 2000; }
        }
        public HardDungeon() { }

        public override void Enter(Player player)
        {
            ResultPrint(player);
        }

        private void ResultPrint(Player player)
        {
            Random rand = new Random();


            // 현재 플레이어 방어력과 권장 방어력을 비교
            // 플레이어 방어력  < 권장 방어력
            if (player.Def < RequiredDef)
            {
                // 랜덤 -> 40%로 던전 실패->보상x, 체력 감소 절반
                int successRandom = rand.Next(1, 101);

                if (successRandom <= 40)
                {
                    string choice;

                    Console.WriteLine();
                    Console.WriteLine("마교 척결 실패!");
                    Console.WriteLine();
                    Console.WriteLine("[결과]");
                    Console.WriteLine();
                    Console.WriteLine($"체력 : {player.Hp} -> {player.DungeonResultHp(false, RequiredDef)}");
                    Console.WriteLine();
                    Console.WriteLine("0. 나가기");
                    Console.WriteLine();
                    Console.Write(">> ");
                    choice = Console.ReadLine();
                    if (choice == "0")
                    {
                        GameManager.Instance().ChangeScene(GameManager.Instance().DungeonScene);
                    }
                }
                // 플레이어 방어력 > 권장방어력
                else
                {
                    // 20-(권장 방어력 - 플레이어 방어력) ~ 35-(권장 방어력-플레이어 방어력)
                    // 보상 1000 + ((1000/100 ) * (플레이어 공격력 ~ 플레이어 공격력 * 2))
                    DungeonClearResultPrint(player);
                }
            }
            else
            {
                DungeonClearResultPrint(player);
            }
        }

        private void DungeonClearResultPrint(Player player)
        {
            string choice;

            Console.WriteLine();
            Console.WriteLine("마교 척결 완료!!");
            Console.WriteLine();
            Console.WriteLine("[결과]");
            Console.WriteLine();
            Console.WriteLine($"체력 : {player.Hp} -> {player.DungeonResultHp(true, RequiredDef)}");
            Console.WriteLine($"보유 금액 : {player.Gold} -> {player.DugeonClearReward(RewardGold)}");
            player.LevelUp();
            Console.WriteLine();
            Console.WriteLine("0. 나가기");
            Console.Write(">> ");
            choice = Console.ReadLine();
            if (choice == "0")
            {
                GameManager.Instance().ChangeScene(GameManager.Instance().DungeonScene);
            }
        }
    }
}
