using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetToolLib
{
  public class SoftBill : Account
  {
    public SoftBill()
    {
      InsertDebit = newAdditionEntry;
      InsertCredit = newSubtractionEntry;
    }

    public SoftBill(string name, decimal startingAmount) : base(name, startingAmount)
    {
      InsertDebit = newAdditionEntry;
      InsertCredit = newSubtractionEntry;
    }

    public SoftBill(SoftBill sb)
    {
      InsertDebit = newAdditionEntry;
      InsertCredit = newSubtractionEntry;
      Name = sb.Name;
      BalanceHistory = new List<BalanceEntry>(sb.BalanceHistory);
    }

  }
}
