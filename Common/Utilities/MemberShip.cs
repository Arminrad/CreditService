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
        public static MemberShipType GetType(int points)
        {
            if (points < 20)
                return MemberShipType.Bronze;
            else if (points < 100)
                return MemberShipType.Silver;
            return MemberShipType.Gold;
        }

    }
}
