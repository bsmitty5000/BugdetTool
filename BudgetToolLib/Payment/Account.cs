using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetToolLib
{
  public class BalanceEntry
  {
    public DateTime Date { get; set; }
    public decimal Amount { get; set; }
  }

  public abstract class Account
  {
    public List<BalanceEntry> BalanceHistory { get; set; }
    public string Name { get; set; }

    public delegate void InsertNewTransaction(BalanceEntry balanceEntry);
    public InsertNewTransaction InsertDebit;
    public InsertNewTransaction InsertCredit;

    public Account()
    {
    }

    public Account(Account account)
    {
      this.BalanceHistory = new List<BalanceEntry>(account.BalanceHistory);
      this.Name = account.Name;
    }

    public Account(string name, decimal startingAmount)
    {
      //Make sure starting entry is the very first
      BalanceEntry startingEntry = new BalanceEntry() { Date = new DateTime(1900, 1, 1), Amount = startingAmount };
      BalanceHistory = new List<BalanceEntry>() { startingEntry };
      Name = name;
    }

    protected void newAdditionEntry(BalanceEntry balanceEntry)
    {
      for(int i = 0; i < BalanceHistory.Count; i++)
      {
        if(BalanceHistory[i].Date == balanceEntry.Date)
        {
          unravelUsingAddition(i, balanceEntry.Amount);
          return;
        }
        else if(BalanceHistory[i].Date < balanceEntry.Date)
        {
          // Create a new BalanceEtnry that carries over the total from the previous day with the new amount added in
          BalanceHistory.Insert(i + 1, new BalanceEntry() { Date = balanceEntry.Date, Amount = (BalanceHistory[i].Amount - balanceEntry.Amount) });

          // after the new entry update all remaining entries
          unravelUsingAddition(i + 2, balanceEntry.Amount);
          return;
        }
      }
      //if we've made it here then the new entry is the latest date
      BalanceHistory.Add(new BalanceEntry() { Date = balanceEntry.Date, Amount = (BalanceHistory[BalanceHistory.Count - 1].Amount - balanceEntry.Amount) });
    }

    private void unravelUsingAddition(int index, decimal amount)
    {
      for (int j = index; j < BalanceHistory.Count; j++)
      {
        BalanceHistory[j].Amount -= amount;
      }
    }

    virtual public void newSubtractionEntry(BalanceEntry balanceEntry)
    {
      for (int i = 0; i < BalanceHistory.Count; i++)
      {
        if (BalanceHistory[i].Date == balanceEntry.Date)
        {
          unravelUsingSubtraction(i, balanceEntry.Amount);
          return;
        }
        else if (BalanceHistory[i].Date < balanceEntry.Date)
        {
          // Create a new BalanceEtnry that carries over the total from the previous day with the new amount added in
          BalanceHistory.Insert(i + 1, new BalanceEntry() { Date = balanceEntry.Date, Amount = (BalanceHistory[i].Amount + balanceEntry.Amount) });

          // after the new entry update all remaining entries
          unravelUsingSubtraction(i + 2, balanceEntry.Amount);
          return;
        }
      }
      //if we've made it here then the new entry is the latest date
      BalanceHistory.Add(new BalanceEntry() { Date = balanceEntry.Date, Amount = (BalanceHistory[BalanceHistory.Count - 1].Amount + balanceEntry.Amount) });
    }
    private void unravelUsingSubtraction(int index, decimal amount)
    {
      for (int j = index; j < BalanceHistory.Count; j++)
      {
        BalanceHistory[j].Amount += amount;
      }
    }
  }
}
