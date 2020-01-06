using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetToolLib
{
  public class SoftBill
  {
    public string Name { get; set; }
    public decimal Amount { get; set; }

    public SoftBill()
    {

    }

    public SoftBill(decimal amount)
    {
      Amount = amount;
    }

    public SoftBill(SoftBill sb)
    {
      this.Name = sb.Name;
      this.Amount = sb.Amount;
    }
  }
}
