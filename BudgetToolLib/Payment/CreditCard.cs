using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetToolLib
{
  public class CreditCard : Account
  {
    public CreditCard()
    {

    }

    public CreditCard(string name, decimal startingAmount) : base(name, startingAmount)
    {

    }

    override public void InsertCreditTransaction(BalanceEntry balanceEntry)
    {
      for (int i = 0; i < BalanceHistory.Count; i++)
      {
        if (BalanceHistory[i].Date == balanceEntry.Date)
        {
          BalanceHistory[i].Amount -= balanceEntry.Amount;
          return;
        }
        else if (BalanceHistory[i].Date < balanceEntry.Date)
        {
          // Create a new BalanceEtnry that carries over the total from the previous day with the new amount added in
          BalanceHistory.Insert(i + 1, new BalanceEntry() { Date = balanceEntry.Date, Amount = (BalanceHistory[i].Amount - balanceEntry.Amount) });

          // after the new entry update all remaining entries
          for (int j = i + 1; j < BalanceHistory.Count; j++)
          {
            BalanceHistory[j].Amount -= balanceEntry.Amount;
          }
          return;
        }
      }
      //if we've made it here then the new entry is the latest date
      BalanceHistory.Add(new BalanceEntry() { Date = balanceEntry.Date, Amount = (BalanceHistory[BalanceHistory.Count - 1].Amount - balanceEntry.Amount) });
    }

    override public void InsertDebitTransaction(BalanceEntry balanceEntry)
    {
      for (int i = 0; i < BalanceHistory.Count; i++)
      {
        if (BalanceHistory[i].Date == balanceEntry.Date)
        {
          BalanceHistory[i].Amount += balanceEntry.Amount;
          return;
        }
        else if (BalanceHistory[i].Date < balanceEntry.Date)
        {
          // Create a new BalanceEtnry that carries over the total from the previous day with the new amount added in
          BalanceHistory.Insert(i + 1, new BalanceEntry() { Date = balanceEntry.Date, Amount = (BalanceHistory[i].Amount + balanceEntry.Amount) });

          // after the new entry update all remaining entries
          for (int j = i + 1; j < BalanceHistory.Count; j++)
          {
            BalanceHistory[j].Amount += balanceEntry.Amount;
          }
          return;
        }
      }
      //if we've made it here then the new entry is the latest date
      BalanceHistory.Add(new BalanceEntry() { Date = balanceEntry.Date, Amount = (BalanceHistory[BalanceHistory.Count - 1].Amount + balanceEntry.Amount) });
    }
  }
}
