using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.IO;

namespace BudgetToolLib
{
  public class YearTop
  {
    /* Add to dictionary directly */
    public Dictionary<string, AccountBase> Accounts { get; set; }

    /* Add to dictionary directly */
    public Dictionary<string, Income> IncomeSources { get; set; }

    /* BudgetGroups are created in the constructor.
     * SoftBills & HardBills are added later
     */
    public List<SoftBillGroup> MonthlySoftBills { get; set; }
    public Dictionary<string, HardBill> HardBills { get; set; }
    public List<Purchase> Purchases { get; set; }

    public YearTop()
    {
    }
    
    public void InitializeYear()
    {
      MonthlySoftBills = new List<SoftBillGroup>();
      /* BudgetGroup[0] = Year
       * BudgetGroup[1:12] = Months
       */
      for (int i = 0; i < 13; i++)
      {
        MonthlySoftBills.Add(new SoftBillGroup());
      }
      IncomeSources = new Dictionary<string, Income>();
      Accounts = new Dictionary<string, AccountBase>();
      HardBills = new Dictionary<string, HardBill>();
      Purchases = new List<Purchase>();
    }
    static public YearTop LoadFromFile(Stream s)
    {
      YearTop jsonYear = null;

      using (StreamReader sr = new StreamReader(s))
      {
        string line;
        line = sr.ReadToEnd();
        jsonYear = JsonConvert.DeserializeObject<YearTop>(line, new JsonSerializerSettings
        {
          TypeNameHandling = TypeNameHandling.Auto,
          PreserveReferencesHandling = PreserveReferencesHandling.Objects
        });
      }

      return jsonYear;
    }
    public void SaveToFile(Stream s)
    {
      JsonSerializer serializer = new JsonSerializer();
      serializer.Converters.Add(new JavaScriptDateTimeConverter());
      serializer.NullValueHandling = NullValueHandling.Ignore;

      using (StreamWriter sw = new StreamWriter(s))
      {
        string jsonTypeNameAuto = JsonConvert.SerializeObject(this, Formatting.Indented, new JsonSerializerSettings
        {
          TypeNameHandling = TypeNameHandling.Auto,
          PreserveReferencesHandling = PreserveReferencesHandling.Objects
        });

        sw.Write(jsonTypeNameAuto);
      }
    }
    public void RemoveSoftBill(string name)
    {
      foreach (var group in MonthlySoftBills)
      {
        group.SoftBills.Remove(name);
      }
    }

    public void AddSoftBill(string name, decimal startingAmount, Boolean annualGroup)
    {
      if (annualGroup)
      {
        if(MonthlySoftBills[1].SoftBills.ContainsKey(name))
        {
          throw new ArgumentException("This softbill already exists in the monthly groups.");
        }

        if (MonthlySoftBills[0].SoftBills.ContainsKey(name))
        {
          decimal difference = MonthlySoftBills[0].SoftBills[name].BalanceHistory[0].Amount - startingAmount;
          Transaction transaction = new Transaction() { Description = name, Date = MonthlySoftBills[0].SoftBills[name].BalanceHistory[0].Date, Amount = difference };
          MonthlySoftBills[0].SoftBills[name].NewDebitTransaction(transaction);
        }
        else
        {
          MonthlySoftBills[0].SoftBills.Add(name, new SoftBill(name, startingAmount ));
        }
      }
      else
      {
        if (MonthlySoftBills[0].SoftBills.ContainsKey(name))
        {
          throw new ArgumentException("This softbill already exists in the annual group.");
        }

        /* important to start at 1 here */
        for (int i = 1; i < MonthlySoftBills.Count; i++)
        {
          if (MonthlySoftBills[i].SoftBills.ContainsKey(name))
          {
            decimal difference = MonthlySoftBills[i].SoftBills[name].BalanceHistory[0].Amount - startingAmount;
            Transaction transaction = new Transaction() { Description = name, Date = MonthlySoftBills[0].SoftBills[name].BalanceHistory[0].Date, Amount = difference };
            MonthlySoftBills[i].SoftBills[name].NewDebitTransaction(transaction);
          }
          else
          {
            MonthlySoftBills[i].SoftBills.Add(name, new SoftBill(name, startingAmount));
          }
        }
      }
    }
    public void AddSoftBill(SoftBill softBill, Boolean annualGroup)
    {
      if(annualGroup)
      {
        if(MonthlySoftBills[0].SoftBills.ContainsKey(softBill.Name))
        {
          throw new ArgumentException("Group of same name already exists for the year");
        }
        MonthlySoftBills[0].SoftBills.Add(softBill.Name, new SoftBill(softBill));
      }
      else
      {
        /* Use 1 here because logic forces them all to be the same */
        if (MonthlySoftBills[1].SoftBills.ContainsKey(softBill.Name))
        {
          throw new ArgumentException("Group of same name already exists in the months");
        }
        /* important to start at 1 here */
        for (int i = 1; i < MonthlySoftBills.Count; i++)
        {
          MonthlySoftBills[i].SoftBills.Add(softBill.Name, new SoftBill(softBill));
        }
      }
    }
    public Purchase CreatePurchase(DateTime dateOfPurchase, bool annual)
    {
      Purchase purchase;

      if (annual)
      {
        purchase = MonthlySoftBills[0].CreatePurchase();
      }
      else
      {
        purchase = MonthlySoftBills[dateOfPurchase.Month].CreatePurchase();
      }

      return purchase;
    }
    public void AddPurchase(Purchase purchase)
    {
      decimal amount = 0;

      foreach (var softBill in purchase.SoftBillSplit)
      {
        /* first check if any of the split exists in the annual group */
        if (MonthlySoftBills[0].SoftBills.ContainsKey(softBill.Key))
        {
          MonthlySoftBills[0].SoftBills[softBill.Key].NewDebitTransaction(
            new Transaction() { Description = purchase.Vendor, Date = purchase.DateOfPurchase, Amount = softBill.Value });
          amount += softBill.Value;
        }
        else if (MonthlySoftBills[purchase.DateOfPurchase.Month].SoftBills.ContainsKey(softBill.Key))
        {
          MonthlySoftBills[purchase.DateOfPurchase.Month].SoftBills[softBill.Key].NewDebitTransaction(
            new Transaction() { Description = purchase.Vendor, Date = purchase.DateOfPurchase, Amount = softBill.Value });
          amount += softBill.Value;
        }
        else
        {
          throw new ArgumentException("This softbill name does not exist anywhere: " + softBill.Key);
        }
      }

      if (amount != purchase.Amount)
      {
        throw new ArgumentException("SoftBill split doesn't add to total purchase.");
      }

      purchase.PaymentAccount.NewDebitTransaction(new Transaction() { Description = purchase.Vendor, Date = purchase.DateOfPurchase, Amount = purchase.Amount });
      Purchases.Add(purchase);
    }

    public void RemovePurchase(Purchase purchase)
    {
      if (!Purchases.Contains(purchase))
      {
        return;
      }
      else
      {
        foreach (var softBill in purchase.SoftBillSplit)
        {
          /* first the annual group */
          if (MonthlySoftBills[0].SoftBills.ContainsKey(softBill.Key))
          {
            MonthlySoftBills[0].SoftBills[softBill.Key].NewCreditTransaction(
              new Transaction() { Description = purchase.Vendor, Date = purchase.DateOfPurchase, Amount = softBill.Value });
          }
          else if (MonthlySoftBills[purchase.DateOfPurchase.Month].SoftBills.ContainsKey(softBill.Key))
          {
            MonthlySoftBills[purchase.DateOfPurchase.Month].SoftBills[softBill.Key].NewCreditTransaction(
              new Transaction() { Description = purchase.Vendor, Date = purchase.DateOfPurchase, Amount = softBill.Value });
          }
          else
          {
            throw new ArgumentException("This softbill name does not exist anywhere: " + softBill.Key);
          }
        }

        purchase.PaymentAccount.NewCreditTransaction(new Transaction() { Description = purchase.Vendor, Date = purchase.DateOfPurchase, Amount = purchase.Amount });
        Purchases.Remove(purchase);
      }
    }

    public void FastForward(DateTime date)
    {
      foreach (var income in IncomeSources)
      {
        income.Value.MakeDeposits(date);
      }

      foreach (var hb in HardBills)
      {
        hb.Value.PayBill(date);
      }
    }
  }
}
