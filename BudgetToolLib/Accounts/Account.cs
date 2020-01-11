﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetToolLib
{
  public static class ListExtensions
  {
    public static int BinarySearchForMatch<T>(this IList<T> list,
     Func<T, int> comparer)
    {
      int min = 0;
      int max = list.Count - 1;

      while (min <= max)
      {
        int mid = (min + max) / 2;
        int comparison = comparer(list[mid]);
        if (comparison == 0)
        {
          return mid;
        }
        if (comparison < 0)
        {
          min = mid + 1;
        }
        else
        {
          max = mid - 1;
        }
      }
      return ~min;
    }
  }

  public class BalanceEntry
  {
    public DateTime Date { get; set; }
    public decimal Amount { get; set; }
  }

  public class Transaction
  {
    public string Description { get; set; }
    public decimal Amount { get; set; }
    public DateTime Date { get; set; }
  }

  public abstract class AccountBase
  {
    public List<BalanceEntry> BalanceHistory { get; set; }
    public List<Transaction> Transactions { get; set; }
    public string Name { get; set; }

    public delegate void NewTransaction(Transaction transaction);

    /* Set by derived classes */
    public NewTransaction NewDebitTransaction;
    public NewTransaction NewCreditTransaction;

    public AccountBase()
    {
    }

    public AccountBase(AccountBase account)
    {
      BalanceHistory = new List<BalanceEntry>(account.BalanceHistory);
      Transactions = new List<Transaction>(account.Transactions);
      Name = account.Name;
    }

    public AccountBase(string name, decimal startingAmount, DateTime? startingDate = null)
    {
      DateTime _startingDate = startingDate ?? DateTime.MinValue;

      //Make sure starting entry is the very first
      BalanceEntry startingEntry = new BalanceEntry() { Date = _startingDate, Amount = startingAmount };
      BalanceHistory = new List<BalanceEntry>() { startingEntry };
      Transactions = new List<Transaction>();
      Name = name;
    }

    protected void addTransactionAmount(Transaction transaction)
    {
      //insert the transaction. Transactions is ordered by date
      int insertIndex = Transactions.BinarySearchForMatch<Transaction>((x) => x.Date.CompareTo(transaction.Date));
      if (insertIndex < 0) insertIndex = ~insertIndex;
      Transactions.Insert(insertIndex, transaction);

      insertIndex = BalanceHistory.BinarySearchForMatch<BalanceEntry>((x) => x.Date.CompareTo(transaction.Date));
      if (insertIndex > 0)
      {
        unravelUsingAddition(insertIndex, transaction.Amount);
      }
      else
      {
        insertIndex = ~insertIndex;
        // Create a new BalanceEtnry that carries over the total from the previous day with the new amount added in
        BalanceHistory.Insert(insertIndex, new BalanceEntry() { Date = transaction.Date, Amount = (BalanceHistory[insertIndex-1].Amount + transaction.Amount) });

        // after the new entry update all remaining entries
        unravelUsingAddition(insertIndex + 1, transaction.Amount);
      }

      return;
    }

    private void unravelUsingAddition(int index, decimal amount)
    {
      for (int j = index; j < BalanceHistory.Count; j++)
      {
        BalanceHistory[j].Amount += amount;
      }
    }

    virtual public void subtractTransactionAmount(Transaction transaction)
    {
      //insert the transaction. Transactions is ordered by date
      int insertIndex = Transactions.BinarySearchForMatch<Transaction>((x) => x.Date.CompareTo(transaction.Date)); 
      if (insertIndex < 0) insertIndex = ~insertIndex;
      Transactions.Insert(insertIndex, transaction);

      insertIndex = BalanceHistory.BinarySearchForMatch<BalanceEntry>((x) => x.Date.CompareTo(transaction.Date));
      if (insertIndex > 0)
      {
        unravelUsingSubtraction(insertIndex, transaction.Amount);
      }
      else
      {
        insertIndex = ~insertIndex;
        // Create a new BalanceEtnry that carries over the total from the previous day with the new amount added in
        BalanceHistory.Insert(insertIndex, new BalanceEntry() { Date = transaction.Date, Amount = (BalanceHistory[insertIndex - 1].Amount - transaction.Amount) });

        // after the new entry update all remaining entries
        unravelUsingSubtraction(insertIndex + 1, transaction.Amount);
      }

      return;
    }
    private void unravelUsingSubtraction(int index, decimal amount)
    {
      for (int j = index; j < BalanceHistory.Count; j++)
      {
        BalanceHistory[j].Amount -= amount;
      }
    }
  }
}
