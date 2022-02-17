using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using ATMWPF.Core;

namespace ATMWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ATM _atm = new ATM(110);
        public MainWindow()
        {
            InitializeComponent();
            InitializeCombo();
        }


        private void InitializeCombo()
        {
            foreach (var moneyType in GetEnumValues<MoneyType>())
            {
                moneyTypeComboBox.Items.Add(moneyType);
                moneyTypeComboBox2.Items.Add(moneyType);
                moneyTypeComboBox.SelectedIndex = 0;
                moneyTypeComboBox2.SelectedIndex = 0;
            }
        }

        private void giveMoneyButton_Click(object sender, RoutedEventArgs e)
        {
            int numberOfBills = 0;
            MoneyType moneyType = (MoneyType)moneyTypeComboBox2.SelectedIndex;

            atmReportBlock.Text = "Состояние банкомата: " + _atm.Condition + Environment.NewLine;
            if (int.TryParse(numberOfBillsTxtBox.Text, out numberOfBills))
            {
                if (_atm.GetMoney(moneyType, numberOfBills))
                {
                    atmReportBlock.Text += "Деньги успешно внесены!" + Environment.NewLine;
                }
                else
                {
                    atmReportBlock.Text += "Не удалось внести деньги!" + Environment.NewLine;
                }
            }
            else
            {
                atmReportBlock.Text += "Проверьте правильность вводимых данных!" + Environment.NewLine;
            }

            atmReportBlock.Text += _atm.GetATMServiceInfo();
            GetLog();
        }

        private void getMoneyButton_Click(object sender, RoutedEventArgs e)
        {
            int sum = 0;
            MoneyType moneyType = (MoneyType)moneyTypeComboBox2.SelectedIndex;

            atmReportBlock.Text = "Состояние банкомата: " + _atm.Condition + Environment.NewLine;
            if (int.TryParse(sumTxtBox.Text, out sum))
            {
                if (_atm.GiveMoney(moneyType, sum))
                {
                    atmReportBlock.Text += "Деньги выданы!" + Environment.NewLine;
                }
                else
                {
                    atmReportBlock.Text += "Не удалось выдать деньги!" + Environment.NewLine;
                }

            }
            else
            {
                atmReportBlock.Text += "Проверьте правильность вводимых данных!" + Environment.NewLine;
            }

            atmReportBlock.Text += _atm.GetATMServiceInfo();
            GetLog();
        }

        private void GetLog()
        {
            StringBuilder sb = new StringBuilder();
            try
            {
                using StreamReader sr = new StreamReader("Log.txt");
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    sb.Append(line);
                }
            }
            catch
            {
                // ignored
            }
            atmLogBlock.Text = sb.ToString();
        }

        public static IEnumerable<T> GetEnumValues<T>() where T : Enum
        {
            return Enum.GetValues(typeof(T)).Cast<T>();
        }

    }
}
