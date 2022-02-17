using System;
using System.Diagnostics;
using System.IO;
using ATMWPF.Core;
using System.Linq;
using System.Text;

namespace ATMWPF
{
    public class ATMRunner
    {
        private static ATM atm = new ATM(110);

        public static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("------------------------");
                Console.WriteLine("Меню:");
                Console.WriteLine("Получить деньги - 1");
                Console.WriteLine("Внести деньги - 2");
                Console.WriteLine("Информация о количестве купюр в банкомате - 3");
                Console.WriteLine("История операций - 4");
                Console.WriteLine("Состояние банкомата - 5");
                Console.WriteLine("Выход из программы - 6");
                Console.WriteLine("Введите номер:");


                int choice = 0;
                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    MenuExecutor(choice);
                }
            }
        }

        private static void MenuExecutor(int choice)
        {
            switch (choice)
            {
                case 1:
                    MenuGetMoney();
                    break;
                case 2:
                    MenuGiveMoney();
                    break;
                case 3:
                    Console.WriteLine(atm.GetATMServiceInfo());
                    break;
                case 4:
                    Console.WriteLine(GetReport());
                    break;
                case 5:
                    Console.WriteLine(atm.Condition);
                    break;
                case 6:
                    Environment.Exit(0);
                    break;
                default:
                    break;
            }

        }

        private static void MenuGetMoney()
        {
            int sum;
            MoneyType moneyType = MoneyType.OneThousand;
            Console.WriteLine("-------------------------");
            Console.WriteLine("Введите сумму для выдачи банкоматом:");
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out sum))
                {
                    break;
                }
            }
            moneyType = GetMoneyType(moneyType);

            Console.WriteLine(atm.GiveMoney(moneyType, sum) ? "Сумма успешно выдана" : "Не удалось выдать сумму");
        }

        private static void MenuGiveMoney()
        {
            int numOfBills = 0;
            MoneyType moneyType = MoneyType.OneThousand;
            Console.WriteLine("-------------------------");
            Console.WriteLine("Введите количество купюр для приема банкоматом:");
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out numOfBills))
                {
                    if (numOfBills > 0)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Сумма должна быть больше 0");
                    }
                }
            }
            moneyType = GetMoneyType(moneyType);

            Console.WriteLine(atm.GetMoney(moneyType, numOfBills) ? "Сумма успешно принята" : "Не удалось принять сумму");
        }

        private static MoneyType GetMoneyType(MoneyType moneyType)
        {
            Console.WriteLine("Выберите купюры:");
            Console.WriteLine("1000 - 1");
            Console.WriteLine("500 - 2");
            Console.WriteLine("100 - 3");
            Console.WriteLine("50 - 4");
            Console.WriteLine("10 - 5");

            bool result = false;
            while (!result)
            {
                if (int.TryParse(Console.ReadLine(), out int numOfChoice))
                {
                    switch (numOfChoice)
                    {
                        case 1:
                            moneyType = MoneyType.OneThousand;
                            result = true;
                            break;
                        case 2:
                            moneyType = MoneyType.FifeHundred;
                            result = true;
                            break;
                        case 3:
                            moneyType = MoneyType.OneHundred;
                            result = true;
                            break;
                        case 4:
                            moneyType = MoneyType.Fifty;
                            result = true;
                            break;
                        case 5:
                            moneyType = MoneyType.Ten;
                            result = true;
                            break;
                        default:
                            Console.WriteLine("Введите число от 1 до 5");
                            break;
                    }
                }
            }

            return moneyType;
        }

        private static string GetReport()
        {
            //Console.Clear();
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("----------------------------");
            try
            {
                using StreamReader sr = new StreamReader("Log.txt");
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    sb.Append(line);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            sb.Append("---------------------------");
            return sb.ToString();
        }
    }
}

