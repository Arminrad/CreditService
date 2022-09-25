using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Clients;

namespace Common.Utilities
{
    public class MemberShip
    {
        public static readonly int SilverBound = 20;
        public static readonly int GoldBound = 100;


        public static MemberShipType GetType(int points)
        {
            if (points < SilverBound)
                return MemberShipType.Bronze;
            if (points < GoldBound)
                return MemberShipType.Silver;
            return MemberShipType.Gold;
        }

    }
}
