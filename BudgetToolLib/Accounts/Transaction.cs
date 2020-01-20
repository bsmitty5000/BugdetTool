using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetToolLib
{
  public class Transaction
  {
    public string Description { get; set; }
    public decimal Amount { get; set; }
    public DateTime Date { get; set; }
    public AccountBase AccountUsed { get; set; }

    public Transaction() { }
    public Transaction(string description, decimal amount, DateTime date, AccountBase account)
    {
      Description = description;
      Amount = amount;
      Date = date;
      AccountUsed = account;
    }
    public Transaction(Transaction t)
    {
      Description = string.Copy(t.Description);
      Amount = t.Amount;
      Date = t.Date;
      AccountUsed = t.AccountUsed;
    }
  }
}
