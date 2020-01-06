using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetToolLib
{
  public class BudgetGroup
  {
    public Dictionary<string, HardBill> HardBills { get; set; }
    public Dictionary<string, SoftBill> SoftBills { get; set; }
    //public Dictionary<string, decimal> SoftBillCurrValue { get; set; }
    //has to be a public property for the json stuff to work
    public List<Purchase> Purchases { get; set; }

    public BudgetGroup()
    {
      HardBills = new Dictionary<string, HardBill>();
      SoftBills = new Dictionary<string, SoftBill>();
      //SoftBillCurrValue = new Dictionary<string, decimal>();
      Purchases = new List<Purchase>();
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

    public void AddPurchase(Purchase purchase)
    {
      decimal amount = 0;
      foreach (var softBill in purchase.SoftBillSplit)
      {
        if(!SoftBills.ContainsKey(softBill.Key))
        {
          throw new ArgumentException("Purchase contains key but month does not: " + softBill.Key);
        }
        amount += softBill.Value;
      }

      if(amount != purchase.Amount)
      {
        throw new ArgumentException("SoftBill split doesn't add to total purchase.");
      }

      foreach (var softBill in purchase.SoftBillSplit)
      {
        SoftBills[softBill.Key].Amount -= softBill.Value;
      }
      Purchases.Add(purchase);
    }

    public void RemovePurchase(Purchase purchase)
    {
      if(!Purchases.Contains(purchase))
      {
        return;
      }
      else
      {
        Purchases.Remove(purchase);

        foreach (var softBill in purchase.SoftBillSplit)
        {
          SoftBills[softBill.Key].Amount += softBill.Value;
        }
      }
    }

    public override string ToString()
    {
      var sb = new StringBuilder();
      foreach (var bill in HardBills)
      {
        sb.Append("(");
        sb.Append(bill.Key + ",");
        sb.Append(bill.Value.Amount + ",");
        sb.Append(bill.Value.PaymentAccount.Name + ",");
        sb.Append(bill.Value.DayOfMonthPaid + ",");
        sb.Append(bill.Value.LastMonthPaid);
        sb.Append(")");
      }
      foreach (var bill in SoftBills)
      {
        sb.Append("(");
        sb.Append(bill.Key + ",");
        sb.Append(bill.Value.Amount);
        sb.Append(")");
      }

      return sb.ToString();
    }
  }
}
