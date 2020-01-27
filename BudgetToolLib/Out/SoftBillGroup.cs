using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetToolLib
{
  [Serializable()]
  public class SoftBillGroup
  {
    public Dictionary<string, decimal> SoftBills { get; set; }
    public decimal TotalSoftBillAmountBudgeted
    {
      get
      {
        decimal total = 0;
        foreach (var sb in SoftBills)
        {
          total += sb.Value;
        }
        return total;
      }
    }
    public SoftBillGroup()
    {
      SoftBills = new Dictionary<string, decimal>();
    }
    //public SoftBillGroup(SoftBillGroup s)
    //{
    //  SoftBills = new Dictionary<string, decimal>();
    //  foreach (var sb in s.SoftBills)
    //  {
    //    SoftBills.Add(sb.Key, sb.Value);
    //  }
    //}
    public IReadOnlyList<string> GetSoftBillKeys()
    {
      return SoftBills.Keys.ToList();
    }

  }
}
