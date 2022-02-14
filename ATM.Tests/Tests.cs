using System;
using Xunit;
using ATM.Core;
using Xunit.Abstractions;

namespace ATM.Tests
{
    public class Tests
    {

        [Fact]
        public void WhenGet1000By10ThenTrue()
        {
            ATM atm = new ATM(110);
            bool result = atm.GetMoney(MoneyType.OneThousand, 10);

            Assert.True(result);
        }


        [Fact]
        public void WhenGet1000By10AndGive20_000By1000ThenTrue()
        {
            ATM atm = new ATM(110);
            bool result = atm.GetMoney(MoneyType.OneThousand, 10);
            Assert.True(result);
            result = atm.GiveMoney(MoneyType.OneThousand, 20_000);
            Assert.True(result);
        }


        [Fact]
        public void WhenGet1000By10AndGive20_000By500ThenTrue()
        {
            ATM atm = new ATM(110);
            bool result = atm.GetMoney(MoneyType.OneThousand, 10);
            Assert.True(result);
            result = atm.GiveMoney(MoneyType.FifeHundred, 20_000);
            Assert.True(result);
        }

        [Fact]
        public void WhenGive1000By20ThenFalse()
        {
            ATM atm = new ATM(100);
            bool result = atm.GetMoney(MoneyType.OneThousand, 10);
            Assert.False(result);
        }

    }
}