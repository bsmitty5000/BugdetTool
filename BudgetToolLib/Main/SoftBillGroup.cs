using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetToolLib
{
  public class SoftBillGroup
  {
    public Dictionary<string, SoftBill> SoftBills { get; set; }

    public SoftBillGroup()
    {
      SoftBills = new Dictionary<string, SoftBill>();
    }

    public SoftBillGroup(SoftBillGroup s)
    {
      SoftBills = new Dictionary<string, SoftBill>();
      foreach (var sb in s.SoftBills)
      {
        SoftBills.Add(sb.Key, new SoftBill(sb.Value));
      }
    }

    public Purchase CreatePurchase()
    {
      Purchase purchase = new Purchase();
      foreach (var softBill in SoftBills)
      {
        purchase.SoftBillSplit.Add(softBill.Key, 0);
      }

      return purchase;
    }
  }
}
