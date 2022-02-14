using System;
using ATM.Core;
using System.Linq;

namespace ATM
{
    public class ATMRunner
    {

        /*1. Разработать программу «Банкомат». Банкомат должен уметь принимать и выдавать 
        деньги, отображать свое состояние.Купюры могут быть разного достоинства(10, 50, 100,
            500 и т.д.). Банкомат должен иметь ограничение по количеству хранимых в нем купюр.
            Перед выдачей купюр банкомат должен спросить у пользователя купюрами какого
            достоинства произвести выдачу.
        2. Решение должно включать Unit-тесты
        3. Требуется реализовать функциональность логирования
        4. Разработать простой UI на WP */

        public static void Main(string[] args)
        {
            Console.WriteLine();
            ATMStorage storage = new ATMStorage(10);
            Console.WriteLine(storage._moneyStorage.GetValueOrDefault(MoneyType.Ten));
            Console.WriteLine(storage.GetATMInfo());
            Console.ReadKey();

        }
    }
}

