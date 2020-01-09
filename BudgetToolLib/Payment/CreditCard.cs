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

    public override void InsertDebitTransaction(BalanceEntry balanceEntry)
    {
      for (int i = 0; i < BalanceHistory.Count; i++)
      {
        if (BalanceHistory[i].Date == balanceEntry.Date)
        {
          unravelRemainingDebitEntries(i, balanceEntry.Amount);
          return;
        }
        else if (BalanceHistory[i].Date < balanceEntry.Date)
        {
          // Create a new BalanceEtnry that carries over the total from the previous day with the new amount added in
          BalanceHistory.Insert(i + 1, new BalanceEntry() { Date = balanceEntry.Date, Amount = (BalanceHistory[i].Amount + balanceEntry.Amount) });

          // after the new entry update all remaining entries
          unravelRemainingDebitEntries(i + 2, balanceEntry.Amount);
          return;
        }
      }
      //if we've made it here then the new entry is the latest date
      BalanceHistory.Add(new BalanceEntry() { Date = balanceEntry.Date, Amount = (BalanceHistory[BalanceHistory.Count - 1].Amount + balanceEntry.Amount) });
    }

    private void unravelRemainingDebitEntries(int index, decimal amount)
    {
      for (int j = index; j < BalanceHistory.Count; j++)
      {
        BalanceHistory[j].Amount += amount;
      }
    }

    public override void InsertCreditTransaction(BalanceEntry balanceEntry)
    {
      for (int i = 0; i < BalanceHistory.Count; i++)
      {
        if (BalanceHistory[i].Date == balanceEntry.Date)
        {
          unravelRemainingCreditEntries(i, balanceEntry.Amount);
          return;
        }
        else if (BalanceHistory[i].Date < balanceEntry.Date)
        {
          // Create a new BalanceEtnry that carries over the total from the previous day with the new amount added in
          BalanceHistory.Insert(i + 1, new BalanceEntry() { Date = balanceEntry.Date, Amount = (BalanceHistory[i].Amount - balanceEntry.Amount) });

          // after the new entry update all remaining entries
          unravelRemainingCreditEntries(i + 2, balanceEntry.Amount);
          return;
        }
      }
      //if we've made it here then the new entry is the latest date
      BalanceHistory.Add(new BalanceEntry() { Date = balanceEntry.Date, Amount = (BalanceHistory[BalanceHistory.Count - 1].Amount - balanceEntry.Amount) });
    }
    private void unravelRemainingCreditEntries(int index, decimal amount)
    {
      for (int j = index; j < BalanceHistory.Count; j++)
      {
        BalanceHistory[j].Amount -= amount;
      }
    }
  }
}
