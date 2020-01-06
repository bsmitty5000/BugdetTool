using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetToolLib
{
  public class Purchase
  {
    public string Vendor { get; set; }
    public Account PaymentAccount { get; set; }
    public DateTime DateOfPurchase { get; set; }
    public decimal Amount { get; set; }
    public Dictionary<string, decimal> SoftBillSplit { get; set; }

    public Purchase()
    {
      SoftBillSplit = new Dictionary<string, decimal>();
    }

    public override string ToString()
    {
      var sb = new StringBuilder();
      sb.Append(PaymentAccount.Name + ",");
      sb.Append(DateOfPurchase + ",");
      sb.Append(Amount + ",");
      foreach (var bill in SoftBillSplit)
      {
        sb.Append(bill.Key + ":" + bill.Value + ",");
      }

      return sb.ToString();
    }
  }
}
