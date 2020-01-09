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
      InsertDebit = newSubtractionEntry;
      InsertCredit = newAdditionEntry;
    }

    public CreditCard(string name, decimal startingAmount) : base(name, startingAmount)
    {
      InsertDebit = newSubtractionEntry;
      InsertCredit = newAdditionEntry;
    }
  }
}
