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
      InsertDebit = newAdditionEntry;
      InsertCredit = newSubtractionEntry;
    }

    public CheckingAccount(string name, decimal startingAmount) : base(name, startingAmount)
    {
      InsertDebit = newAdditionEntry;
      InsertCredit = newSubtractionEntry;
    }
  }
}
