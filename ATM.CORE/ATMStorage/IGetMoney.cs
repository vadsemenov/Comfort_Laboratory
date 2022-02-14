using System.Collections.Generic;

namespace ATM
{
    internal interface IGetMoney
    {
        bool TryGetMoney(MoneyType moneyType, int sum);
    }
}
