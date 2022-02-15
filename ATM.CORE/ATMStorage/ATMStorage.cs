
using System.Collections.Generic;
using System.Text;
using ATM.Logger;

namespace ATM.Core
{
    internal class ATMStorage : IStorage
    {
        private Dictionary<MoneyType, int> _moneyStorage = new Dictionary<MoneyType, int>() { };
        private FileLogger _logger = FileLogger.GetLogger();
        private readonly int _limitBills;
        private readonly int _numberOfBills = 100;

        public ATMStorage(int limitNumberOfBill)
        {
            _limitBills = limitNumberOfBill;
            InizializeStorage(_numberOfBills);
        }

        private void InizializeStorage(int numberOfBill)
        {
            _moneyStorage.Add(MoneyType.Ten, numberOfBill);
            _moneyStorage.Add(MoneyType.Fifty, numberOfBill);
            _moneyStorage.Add(MoneyType.OneHundred, numberOfBill);
            _moneyStorage.Add(MoneyType.FifeHundred, numberOfBill);
            _moneyStorage.Add(MoneyType.OneThousand, numberOfBill);
        }

        public bool TryGetMoney(MoneyType moneyType, int numberOfBills)
        {
            if ((_moneyStorage.GetValueOrDefault(moneyType) + numberOfBills) <= _limitBills)
            {
                _moneyStorage[moneyType] += numberOfBills;
                _logger.Log("Принято " + numberOfBills + " купюр");
                return true;

            }
            else
            {
                _logger.Log("Невозможно принять купюры автомат заполнен.");
            }

            return false;
        }

        public bool TryGiveMoney(MoneyType moneyType, int sum)
        {
            int numberOfBills = CalculateNumberOfBillsToGive(moneyType, sum);

            if (_moneyStorage.GetValueOrDefault(moneyType) <= 0)
            {
                _logger.Log("Не достаточно купюр для снятия денег.");
                return false;
            }

            if (_moneyStorage.GetValueOrDefault(moneyType) >= numberOfBills)
            {
                _moneyStorage[moneyType] -= numberOfBills;
                _logger.Log("Выдана сумма:" + sum);
                return true;
            }

            _logger.Log("Не удалось снять " + sum + " со счета.");
            return false;
        }

        private int CalculateNumberOfBillsToGive(MoneyType moneyType, int sum)
        {
            int numberOfBills;
            switch (moneyType)
            {
                case MoneyType.Ten:
                    numberOfBills = sum / 10;
                    break;
                case MoneyType.Fifty:
                    numberOfBills = sum / 50;
                    break;
                case MoneyType.OneHundred:
                    numberOfBills = sum / 100;
                    break;
                case MoneyType.FifeHundred:
                    numberOfBills = sum / 500;
                    break;
                case MoneyType.OneThousand:
                    numberOfBills = sum / 1000;
                    break;
                default:
                    numberOfBills = 0;
                    break;
            }

            return numberOfBills;
        }

        public string GetATMStorageInfo()
        {
            StringBuilder sb = new StringBuilder();

            if (_moneyStorage.Count > 0)
            {
                sb.AppendLine("В банкомате доступны следующие купюры:")
                    .AppendLine("10 рублей - " + _moneyStorage.GetValueOrDefault(MoneyType.Ten) + "шт.")
                    .AppendLine("100 рублей - " + _moneyStorage.GetValueOrDefault(MoneyType.OneHundred) + "шт.")
                    .AppendLine("500 рублей - " + _moneyStorage.GetValueOrDefault(MoneyType.FifeHundred) + "шт.")
                    .AppendLine("1000 рублей - " + _moneyStorage.GetValueOrDefault(MoneyType.OneThousand) + "шт.");
                return sb.ToString();
            }

            return "Деньги отсутствуют в банкомате.";
        }
    }
}
