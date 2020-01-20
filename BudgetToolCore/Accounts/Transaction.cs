using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetToolCore
{
  public class Transaction
  {
    public string Description { get; set; }
    public decimal Amount { get; set; }
    public DateTime Date { get; set; }

    public Transaction() { }
    public Transaction(Transaction t)
    {
      Description = t.Description;
      Amount = t.Amount;
      Date = t.Date;
    }
  }
}
