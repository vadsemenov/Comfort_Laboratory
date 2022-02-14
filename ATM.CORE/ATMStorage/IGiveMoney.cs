using System.Numerics;

namespace ATM
{
    internal interface IGiveMoney
    {
        bool TryGiveMoney(MoneyType moneyType, int sum);
    }
}
