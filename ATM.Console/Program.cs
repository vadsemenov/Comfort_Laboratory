using System;
using ATM.Core;
using System.Linq;
using System.Text;

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
            ATM atm = new ATM(110);
            bool result = atm.GetMoney(MoneyType.OneThousand, 10);
            result = atm.GiveMoney(MoneyType.OneThousand, 20_000);
            Console.WriteLine(atm.GetATMServiceInfo());


            bool IsExit = false;

            while (!IsExit)
            {
                //ATM atm = new ATM(10);
                Console.WriteLine("");
                Console.WriteLine("Введите номер:");
                
                int choice = 0;
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    continue;
                }

               // switch
            }
        }

        public static string GetReport()
        {
            Console.Clear();
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("----------------------------");
            using (StreamReader sr = new StreamReader("Log.txt"))
            {
                string line;
                while (( line = sr.ReadLine()) !=null)
                {
                    sb.Append(line);
                }
            }

            sb.Append("---------------------------");
            return sb.ToString();
        }
    }
}

