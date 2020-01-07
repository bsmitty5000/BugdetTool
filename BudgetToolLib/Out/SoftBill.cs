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

    }

    public SoftBill(string name, decimal startingAmount) : base(name, startingAmount)
    {
    }

    public SoftBill(SoftBill sb)
    {
      Name = sb.Name;
      BalanceHistory = new List<BalanceEntry>(sb.BalanceHistory);
    }

  }
}
