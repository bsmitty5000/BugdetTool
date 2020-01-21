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
    public decimal TotalSoftBillAmountBudgeted
    {
      get
      {
        decimal total = 0;
        foreach (var sb in SoftBills)
        {
          total += sb.Value.AmountBudgeted;
        }
        return total;
      }
    }

    public decimal TotalSoftBillAmountUsed
    {
      get
      {
        decimal total = 0;
        foreach (var sb in SoftBills)
        {
          total += sb.Value.AmountUsed;
        }
        return total;
      }
    }

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
    public void EditSoftBill(string softBillName, decimal newAmountBudgeted)
    {
      if(SoftBills.ContainsKey(softBillName))
      {
        SoftBills[softBillName].AmountBudgeted = newAmountBudgeted;
      }
    }
    public SoftBillTransaction CreateSoftBillTransaction()
    {
      SoftBillTransaction sbt = new SoftBillTransaction();
      foreach (var sb in SoftBills)
      {
        sbt.SoftGroupSplit.Add(sb.Key, 0);
      }
      return sbt;
    }
    public List<string> GetSoftBillKeys()
    {
      return SoftBills.Keys.ToList();
    }

  }
}
