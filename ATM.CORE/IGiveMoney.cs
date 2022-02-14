using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    public interface IGiveMoney
    {
        bool TryGiveMoney(MoneyType moneyType, BigInteger sum);
    }
}
