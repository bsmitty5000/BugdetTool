using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetToolLib
{
  public class SoftBillTransaction : Transaction
  {
    public event EventHandler<SoftBillTransactionArgs> NewSoftBillEdit;
    public Dictionary<string, decimal> SoftGroupSplit { get; set; }
    public override decimal Amount 
    { 
      get => base.Amount;
      set
      {
        base.Amount = value;
        NewSoftBillEdit?.Invoke(this, new SoftBillTransactionArgs());
      }
    }
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
  public class SoftBillTransactionArgs
  {
  }

  public class SoftBill
  {
    public string Name { get; set; }
    public decimal AmountBudgeted { get; set; }
    public decimal AmountUsed { get; set; }
    public SoftBill()
    {
    }

    public SoftBill(string name, decimal amountBudgeted)
    {
      Name = name;
      AmountBudgeted = amountBudgeted;
      //AmountUsed = 0;
    }

    public SoftBill(SoftBill sb)
    {
      Name = sb.Name;
      AmountBudgeted = sb.AmountBudgeted;
      AmountUsed = sb.AmountUsed;
    }
  }
}
