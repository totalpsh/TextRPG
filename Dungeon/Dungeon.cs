using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace TextRPG
{
    public abstract class Dungeon
    {
        public abstract string DungeonName { get; }
        public abstract float RequiredDef { get; }

        public abstract int RewardGold { get; }

        public abstract void Enter(Player player);
    }
}
