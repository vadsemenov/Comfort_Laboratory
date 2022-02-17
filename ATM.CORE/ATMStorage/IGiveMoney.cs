using System.Numerics;

namespace ATMWPF
{
    internal interface IGiveMoney
    {
        bool TryGiveMoney(MoneyType moneyType, int sum);
    }
}
