using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetToolLib
{
  public class CheckingAccount : Account
  {
    public CheckingAccount()
    {
    }

    public CheckingAccount(string name, decimal startingAmount) : base(name, startingAmount)
    {
    }
  }
}
