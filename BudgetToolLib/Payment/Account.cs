using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetToolLib
{
  public abstract class Account
  {
    public decimal Balance { get; set; }
    public string Name { get; set; }

    public Account()
    {
    }

    public void NewDebitTransaction(decimal amount)
    {
      Balance -= amount;
    }

    public void NewCreditTransaction(decimal amount)
    {
      Balance += amount;
    }

    public override string ToString()
    {
      var sb = new StringBuilder();
      sb.Append(Name + "\t");
      sb.Append(Balance);

      return sb.ToString();
    }
  }
}
