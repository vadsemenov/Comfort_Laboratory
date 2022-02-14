using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Core
{
    public class ATMStorage : IGetMoney, IGiveMoney
    {
        public Dictionary<MoneyType,int> _moneyStorage = new Dictionary<MoneyType,int>(){};
        private int _limitNumberOfMoney = 100;

        public ATMStorage(int limitNumberOfMoney)
        {
            InizializeStorage();
            _limitNumberOfMoney = limitNumberOfMoney;
        }

        private void InizializeStorage()
        { 
            _moneyStorage.Add(MoneyType.Ten,100);
            _moneyStorage.Add(MoneyType.Fifty, 100);
            _moneyStorage.Add(MoneyType.OneHundred, 100);
            _moneyStorage.Add(MoneyType.FifeHundred, 100);
            _moneyStorage.Add(MoneyType.OneThousand, 100);
        }

        public bool TryGetMoney(Dictionary<MoneyType, int> money)
        {
            return false;
        }

        public bool TryGiveMoney(MoneyType moneyType ,BigInteger sum)
        {
            if (_moneyStorage.GetValueOrDefault(moneyType) > 0)
            {

            }

            return false;
        }

        public string GetATMInfo()
        {
            StringBuilder sb = new StringBuilder();

            if (_moneyStorage.Count > 0)
            {
                sb.AppendLine("В банкомате доступны следующие купюры:")
                    .AppendLine("10 рублей - " + _moneyStorage.GetValueOrDefault(MoneyType.Ten) + "шт.")
                    .AppendLine("100 рублей - " + _moneyStorage.GetValueOrDefault(MoneyType.OneHundred) + "шт.")
                    .AppendLine("500 рублей - " + _moneyStorage.GetValueOrDefault(MoneyType.FifeHundred) + "шт.")
                    .AppendLine("1000 рублей - " + _moneyStorage.GetValueOrDefault(MoneyType.FifeHundred) + "шт.");
                return sb.ToString();
            }

            return "Деньги отсутствуют в банкомате.";
        }
    }
}
