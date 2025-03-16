using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace class06_workshop_exercise_03
{
    public class Customer
    {
        public long CardNumber { get; private set; }
        public int Pin { get; private set; }
        public string FullName { get; set; }
        public decimal Balance { get; private set; }
        

        public Customer(long cardNumber, int pin, string fullName, decimal balance)
        {
            CardNumber = cardNumber;
            Pin = pin;
            FullName = fullName;
            Balance = balance;
        }

        public decimal GetBalance()
        {
            return Balance;
        }
        public bool Withdraw(decimal amount)
        {
            if (amount <= Balance)
            {
                Balance -= amount;
                return true;
            }
            return false;
        }
        public void Deposit(decimal amount)
        {
            Balance += amount;
        }


    }
}
