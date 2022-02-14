using ATM.Core;

namespace ATM
{
    public class ATM
    {
        private ATMCondition _condition = ATMCondition.Working;
        private ATMStorage _storage;

        public ATM(int limitOfBills) : this(limitOfBills, ATMCondition.Working)
        {
        }

        public ATM(int limitOfBills, ATMCondition condition)
        {
            _storage = new ATMStorage(limitOfBills);
            _condition = condition;
        }

        public bool GetMoney(MoneyType moneyType, int numberOfBills)
        {

            if (_storage.TryGetMoney( moneyType, numberOfBills))
            {
                return true;
            }

            return false;
        }

        public bool GiveMoney(MoneyType moneyType, int sum)
        {
            if (_storage.TryGiveMoney(moneyType, sum))
            {
                return true;
            }
            return false;
        }

        public void ChangeCondition(ATMCondition condition)
        {
            this._condition = condition;
        }

        public string GetATMServiceInfo()
        {
            return _storage.GetATMStorageInfo();
        }
    }
}
