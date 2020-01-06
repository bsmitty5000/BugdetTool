using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace BudgetToolLib
{
  public class HardBill
  {
    public string Name { get; set; }
    public decimal Amount { get; set; }
    public int DayOfMonthPaid { get; set; }
    public Account PaymentAccount { get; set; }
    public int LastMonthPaid { get; private set; }

    public HardBill()
    { }

    public HardBill(decimal amount, int dayOfMonthPaid, Account paymentSource)
    {
      Amount = amount;
      DayOfMonthPaid = dayOfMonthPaid;
      PaymentAccount = paymentSource;
      LastMonthPaid = 0;
    }

    public HardBill(HardBill hb)
    {
      this.Name = hb.Name;
      this.Amount = hb.Amount;
      this.DayOfMonthPaid = hb.DayOfMonthPaid;
      this.PaymentAccount = hb.PaymentAccount;
      this.LastMonthPaid = hb.LastMonthPaid;
    }

    public void PayBill(DateTime date)
    {
      var cal = new GregorianCalendar();
      int currentMonthNumber = cal.GetMonth(date);
      int numberOfMonthsToPay = (currentMonthNumber - LastMonthPaid);

      /* Minus 1 here because after the loop we'll check the current month
       * to see if date is past DayOfMonthpaid
       */
      for (int i = 0; i < (numberOfMonthsToPay - 1); i++)
      {
        PaymentAccount.NewDebitTransaction(Amount);
        LastMonthPaid++;
      }

      if(date.Day > DayOfMonthPaid)
      {
        PaymentAccount.NewDebitTransaction(Amount);
        LastMonthPaid++;

        if(LastMonthPaid != currentMonthNumber)
        {
          throw new ArgumentException("Algorithm error bro #1");
        }
      }
      else
      {

        if (LastMonthPaid != (currentMonthNumber - 1))
        {
          throw new ArgumentException("Algorithm error bro #2");
        }
      }
    }
  }
}
