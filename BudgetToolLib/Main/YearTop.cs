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
    public List<BudgetGroup> BudgetGroups { get; set; }

    public YearTop()
    {
    }
    
    public void InitializeYear()
    {
      BudgetGroups = new List<BudgetGroup>();
      /* BudgetGroup[0] = Year
       * BudgetGroup[1:12] = Months
       * BudgetGroup[13] = Copy of Months
       */
      for (int i = 0; i < 14; i++)
      {
        BudgetGroups.Add(new BudgetGroup());
      }
      IncomeSources = new Dictionary<string, Income>();
      Accounts = new Dictionary<string, AccountBase>();
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
    public void RemoveSoftBill(string name, Boolean annualGroup)
    {
      if (annualGroup)
      {
        BudgetGroups[0].SoftBills.Remove(name);
      }
      else
      {
        for(int i = 0; i < BudgetGroups.Count; i++)
        {
          BudgetGroups[i].SoftBills.Remove(name);
        }
      }
    }
    public void AddSoftBill(string name, decimal startingAmount, Boolean annualGroup)
    {
      if (annualGroup)
      {
        if (BudgetGroups[0].SoftBills.ContainsKey(name))
        {
          decimal difference = BudgetGroups[0].SoftBills[name].BalanceHistory[0].Amount - startingAmount;
          BalanceEntry newStartingEntry = new BalanceEntry() { Date = BudgetGroups[0].SoftBills[name].BalanceHistory[0].Date, Amount = difference };
          BudgetGroups[0].SoftBills[name].NewDebitTransaction(newStartingEntry);
        }
        else
        {
          BudgetGroups[0].SoftBills.Add(name, new SoftBill(name, startingAmount ));
        }
      }
      else
      {
        /* important to start at 1 here */
        for (int i = 1; i < BudgetGroups.Count; i++)
        {
          if (BudgetGroups[i].SoftBills.ContainsKey(name))
          {
            decimal difference = BudgetGroups[i].SoftBills[name].BalanceHistory[0].Amount - startingAmount;
            BalanceEntry newStartingEntry = new BalanceEntry() { Date = BudgetGroups[i].SoftBills[name].BalanceHistory[0].Date, Amount = difference };
            BudgetGroups[i].SoftBills[name].NewDebitTransaction(newStartingEntry);
          }
          else
          {
            if(i < 13)
            {
              BudgetGroups[i].SoftBills.Add(name, new SoftBill(name, startingAmount ));
            }
            else
            {
              //keeping an untouched copy for now just in case.
              BudgetGroups[i].SoftBills.Add(name, new SoftBill(name, startingAmount ));
            }
          }
        }
      }
    }

    public void AddSoftBill(SoftBill softBill, Boolean annualGroup)
    {
      if(annualGroup)
      {
        if(BudgetGroups[0].SoftBills.ContainsKey(softBill.Name))
        {
          throw new ArgumentException("Group of same name already exists for the year");
        }
        BudgetGroups[0].SoftBills.Add(softBill.Name, new SoftBill(softBill));
      }
      else
      {
        /* Use 1 here because logic forces them all to be the same */
        if (BudgetGroups[1].SoftBills.ContainsKey(softBill.Name))
        {
          throw new ArgumentException("Group of same name already exists in the months");
        }
        /* important to start at 1 here */
        for (int i = 1; i < BudgetGroups.Count; i++)
        {
          BudgetGroups[i].SoftBills.Add(softBill.Name, new SoftBill(softBill));
        }
      }
    }
    public void RemoveHardBill(string name, Boolean annualGroup)
    {
      if (annualGroup)
      {
        BudgetGroups[0].HardBills.Remove(name);
      }
      else
      {
        for (int i = 0; i < BudgetGroups.Count; i++)
        {
          BudgetGroups[i].HardBills.Remove(name);
        }
      }
    }
    public void AddHardBill(HardBill bill, Boolean annualGroup)
    {
      if (annualGroup)
      {
        if (BudgetGroups[0].HardBills.ContainsKey(bill.Name))
        {
          RemoveHardBill(bill.Name, annualGroup);
        }
        BudgetGroups[0].HardBills.Add(bill.Name, new HardBill(bill));
      }
      else
      {
        /* Use 1 here because logic forces them all to be the same */
        if (BudgetGroups[1].HardBills.ContainsKey(bill.Name))
        {
          RemoveHardBill(bill.Name, annualGroup);
        }
        for (int i = 1; i < BudgetGroups.Count; i++)
        {
          BudgetGroups[i].HardBills.Add(bill.Name, new HardBill(bill));
        }
      }
    }
    public Purchase CreatePurchase(DateTime dateOfPurchase, bool annual)
    {
      Purchase purchase;

      if (annual)
      {
        purchase = BudgetGroups[0].CreatePurchase();
      }
      else
      {
        purchase = BudgetGroups[dateOfPurchase.Month].CreatePurchase();
      }

      return purchase;
    }
  }
}
