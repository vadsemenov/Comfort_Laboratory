using System.Collections.Generic;

namespace ATMWPF
{
    internal interface IGetMoney
    {
        bool TryGetMoney(MoneyType moneyType, int sum);
    }
}
