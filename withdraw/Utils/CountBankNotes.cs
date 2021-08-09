using System;
using System.Linq;
using withdraw.Models;

namespace withdraw.Utils
{
    public class CountBankNotes
    {
        private DBConnection dbConnection = new DBConnection();

        /*COUNT BANK NOTES*/
        public Withdraw GetWithdraw(int value, string id)
        {
            int tempValue = value;
            int x100 = 0;
            int x50 = 0;
            int x20 = 0;
            int x10 = 0;

            Withdraw withdraw = new Withdraw();

            x100 = Convert.ToInt32(tempValue / 100);
            tempValue = (tempValue - (x100 * 100));

            x50 = Convert.ToInt32(tempValue / 50);
            tempValue = (tempValue - (x50 * 50));

            x20 = Convert.ToInt32(tempValue / 20);
            tempValue = (tempValue - (x20 * 20));

            x10 = Convert.ToInt32(tempValue / 10);
            tempValue = tempValue - (x10 * 10);

            if (tempValue == 0)
            {
                if (x100 > 0)
                {
                    withdraw.bankNote100 = x100;
                }
                if (x50 > 0)
                {
                    withdraw.bankNote050 = x50;
                }
                if (x20 > 0)
                {
                    withdraw.bankNote020 = x20;
                }
                if (x10 > 0)
                {
                    withdraw.bankNote010 = x10;
                }
                int currentBankBalance = dbConnection.getCustomerBankBalance(id).First<int>() - value;
                int newBankBalance = dbConnection.setCustomerBankBalance(id, currentBankBalance).First<int>();
                withdraw.accountBalance = newBankBalance;
                withdraw.message = "Withdraw with success";
                return withdraw;
            }
            else
            {
                int currentBankBalance = dbConnection.getCustomerBankBalance(id).First<int>() - value;
                withdraw.accountBalance = currentBankBalance;
                withdraw.message = "Incompatible values: select value with avaiable bank notes";
                return withdraw;
            }

        }

    }
}
