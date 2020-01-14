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
    public AccountBase PaymentAccount { get; set; }
    public DateTime DateOfPurchase { get; set; }
    public decimal Amount { get; set; }
    public Dictionary<string, decimal> SoftBillSplit { get; set; }

    public Purchase()
    {
      SoftBillSplit = new Dictionary<string, decimal>();
    }

    public Purchase(string vendor, AccountBase paymentAccount, DateTime dateOfPurchase, decimal amount, Dictionary<string, decimal> softBillSplit)
    {
      Vendor = vendor;
      PaymentAccount = paymentAccount;
      DateOfPurchase = dateOfPurchase;
      Amount = amount;
      SoftBillSplit = softBillSplit;
    }

    public Purchase(Purchase p)
    {
      Vendor = string.Copy(p.Vendor);
      PaymentAccount = AccountBaseFactory.CopyAccountBase(p.PaymentAccount);
      DateOfPurchase = p.DateOfPurchase;
      Amount = p.Amount;
      SoftBillSplit = new Dictionary<string, decimal>();
      foreach (var sv in p.SoftBillSplit)
      {
        SoftBillSplit.Add(sv.Key, sv.Value);
      }
    }
  }
}
