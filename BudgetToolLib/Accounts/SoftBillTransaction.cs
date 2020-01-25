using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetToolLib
{
  [Serializable()]
  public class SoftBillTransaction : Transaction
  {    
    public Dictionary<string, decimal> SoftGroupSplit { get; set; }
    public SoftBillTransaction() : base()
    {
      SoftGroupSplit = new Dictionary<string, decimal>();
    }
    public SoftBillTransaction(SoftBillTransaction sb) : base(sb)
    {
      SoftGroupSplit = new Dictionary<string, decimal>();
      foreach (var kvp in sb.SoftGroupSplit)
      {
        SoftGroupSplit.Add(kvp.Key, kvp.Value);
      }
    }
  }
}
