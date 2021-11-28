using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace laba9
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btn1_1_Click(object sender, EventArgs e)
        {
            int number1 = 1;
            int number2 = 1;
            int balance = 1;
            Account acc = Account.Сберегательный;
            BankAccount bank = new BankAccount();
            bank.GetInfo(number1, balance, acc);
            number1 = bank.accountNumber;
            
            balance = bank.accountBalance;
            tB1_1.Text = Convert.ToString(number1);
            tB1_2.Text = Convert.ToString(balance);
            richTextBox1.Text = $"Номер Счета: {number1}\nБаланс: {balance}$\nТип счета: {acc}";

            BankAccount bank2 = new BankAccount();
            bank2.GetInfo(number2, balance, acc);
            number2 = bank.accountNumber+1;
            tB1_4.Text = Convert.ToString(number2);
            tB1_5.Text = Convert.ToString(balance);

        }

        private void btn1_2_Click(object sender, EventArgs e)
        {
            try
            {
                int number = Convert.ToInt32( tB1_1.Text);
                int balance = Convert.ToInt32(tB1_2.Text);
                string h = $"Номер счета: {number}\nБаланс: {balance}$";
                BankAccount bank = new BankAccount();
                bank.SetInfo(number, balance, h);
                richTextBox1.Text = $"{h}\nТип счета: {Account.Сберегательный}";
            }
            catch
            {
                MessageBox.Show("Введите значения");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int amount = Convert.ToInt32(tB1_3.Text);
            int balance = Convert.ToInt32(tB1_2.Text);
            BankAccount bank2 = new BankAccount();
            tB1_2.Text = Convert.ToString(bank2.TakeBalance(amount,balance));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int amount = Convert.ToInt32(tB1_3.Text);
            int balance = Convert.ToInt32(tB1_2.Text);
            BankAccount bank3 = new BankAccount();
            tB1_2.Text = Convert.ToString(bank3.PutBalance(amount, balance));
        }

        private void btnBuild_Click(object sender, EventArgs e)
        {
            try
            {
                int floorCount = Convert.ToInt32(tB2_3.Text);
                int buildheight = Convert.ToInt32(tB2_2.Text);
                Building build = new Building();
                tB2_1.Text = Convert.ToString(build.GetBuildNumber());
                richTextBox2.Text = $"Высота здания: {buildheight}м\nКол-во этажей: {floorCount}\nВысота этажа: {build.GetBuildFloorHeight(floorCount, buildheight)}м";
            }
            catch
            {
                MessageBox.Show("Введите значения");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int accSum1 = Convert.ToInt32(tB1_2.Text);
            int sum = Convert.ToInt32(tB1_3.Text);
            BankAccount bank = new BankAccount();
            tB1_5.Text = Convert.ToString(bank.Remittance(ref accSum1, sum));
            int acc = accSum1 - sum;
            tB1_2.Text = Convert.ToString(acc);

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string str = tB10_2.Text;
            Laba10 letter = new Laba10();
            richTextBox3.Text = $"Revers: {letter.Reverse(str)}";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                int temp = Convert.ToInt32(tB10_4.Text);
                Temperature t = new Temperature(temp);
                CheckArgImplementInterface(t);
                richTextBox4.Text = $"{t}";
            }
            catch
            {
                MessageBox.Show("Введите температуру");
            }
            
        }
        private void CheckArgImplementInterface(Temperature t)
        {
            IFormattable form;

            if (t is IFormattable)
            {
                form = (IFormattable)t;
            }
            else
            {
                form = null;
            }

            if (form is null)
            {
                MessageBox.Show("Не реализует IFormattable");
            }
            else
            {
                MessageBox.Show("Реализует IFormattable");
            }

        }

    }
    enum Account { Сберегательный, Накопительный };                         //Task1
    class BankAccount
    {
        public int accountNumber { get; private set; }
        public int accountBalance { get; private set; }
        Account Type { get; set; }
        static int accNumber1 = 1;
        public void GetInfo (int accNum, int accBal, Account type)
        {
            accountNumber = accNumber1;
            accNumber1++;
            accountBalance = 8686;
            accNum = accountNumber;
            accBal = accountBalance;
        }
        public string SetInfo(int accNum,int accBal, string h)
        {
            accountNumber = accNum;
            accountBalance = accBal;
            h = " ";
            return h;
        }

        public int GetNumberAcc()                               //Task2
        {
            return accountNumber;
        }

        public int TakeBalance(int acc, int balance)             //Task3
        {
            if (acc <= balance)
            {
                balance -= acc;
                return balance;
            }
            else
            {
                MessageBox.Show("Вы ввели слишком большую сумму для вывода");
            }
            return balance;
        }
        public int PutBalance(int acc, int balance)
        {
            balance += acc;
            return balance;
        }
        public int Remittance(ref int accNum1, int sum)                 //Laba10Task1
        {
            int result = accNum1;
            accountBalance = accNum1;
            if (accNum1 >= sum)
            {
                result =  accNum1 + sum;
                return result;
            }
            else
            {
                MessageBox.Show("Слишком большая сумма" ,"Ошиб очка");
            }
            return result;
        }
    }

    class Building
    {
        public int buildNumber { get; private set; }
        public int buildHeight { get; private set; }
        public int buildFloor { get; private set; }
        public int buildApartments { get; private set; }
        public int buildEntrance { get; private set; }

        static int bNum = 1;

        public int GetBuildNumber()
        {
            buildNumber = bNum;
            bNum++;
            return buildNumber;
        }
        public int GetBuildFloorHeight(int floorCount, int buildheight)
        {
            int result = buildheight/floorCount;
            return result;
        }
    }

    class Laba10
    {
        public string Reverse(string str)                               //Laba10Task2
        {
            char[] letter = str.ToCharArray();
            Array.Reverse(letter);
            str = new string(letter);
            return str;
        }
    }
    public class Temperature : IFormattable
    {
        private decimal temp;
        public Temperature(decimal temperature)
        {
            if (temperature < -273.15m)
                throw new ArgumentOutOfRangeException(String.Format("{0} is less than absolute zero.",
                                                    temperature));
            this.temp = temperature;
        }

        public string ToString(string format, IFormatProvider provider)
        {
            return temp.ToString("F2", provider) + " °C";
        }
        
    }
}
