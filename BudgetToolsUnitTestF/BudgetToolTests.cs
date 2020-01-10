using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BudgetToolLib;
using NUnit.Framework;


namespace BudgetToolsUnitTestF
{
  [TestFixture]
  public class BudgetToolTests
  {
    private AccountBase checking;
    private AccountBase credit;

    private Income salary;
    private Income bonus;

    //annuals
    private HardBill carRegistration;
    private SoftBill vacation;

    //monthlys
    private HardBill electricity;
    private HardBill cable;
    private SoftBill food;
    private SoftBill gas;

    //top
    private YearTop yearTop;

    [SetUp]
    public void Init()
    {
      //create accounts
      checking = new CheckingAccount("checking", 5000);
      credit = new CreditCard("credit", 0);

      //create income
      salary = new Income("salary", 2500, IncomeFrequencyEnum.BiWeekly, new DateTime(2020, 1, 10));
      bonus = new Income("bonus", 1500, IncomeFrequencyEnum.BiAnnualy, new DateTime(2020, 1, 10));

      //annuals
      carRegistration = new HardBill("carRegistration", 1000, 1, credit);
      vacation = new SoftBill("vacation", 7500);

      //monthlys
      electricity = new HardBill("electricity", 150, 15, checking);
      cable = new HardBill("cable", 75, 20, credit);
      food = new SoftBill("food", 500);
      gas = new SoftBill("gas", 400);

      yearTop = new YearTop();
      yearTop.InitializeYear();

      //wire up top
      yearTop.Accounts.Add(checking.Name, checking);
      yearTop.Accounts.Add(credit.Name, credit);

      yearTop.IncomeSources.Add(salary.Name, salary);
      yearTop.IncomeSources.Add(bonus.Name, bonus);

      yearTop.AddHardBill(carRegistration, true);
      yearTop.AddSoftBill(vacation, true);

      yearTop.AddHardBill(electricity, false);
      yearTop.AddHardBill(cable, false);
      yearTop.AddSoftBill(food, false);
      yearTop.AddSoftBill(gas, false);

    }

    [Test]
    public void SimplePurchaseTest()
    {
      decimal creditStarting = yearTop.Accounts["credit"].BalanceHistory.Last().Amount;
      decimal checkingStarting = yearTop.Accounts["checking"].BalanceHistory.Last().Amount;
      decimal total;
      Dictionary<string, decimal> sbSplit = new Dictionary<string, decimal>();
      Purchase purchase;

      total = 100;
      sbSplit = new Dictionary<string, decimal>() { { "food", total } };
      purchase = new Purchase("Grocery Store", credit, new DateTime(2020, 1, 15), total, sbSplit);
      yearTop.BudgetGroups[1].AddPurchase(purchase);

      Assert.AreEqual(creditStarting + total, yearTop.Accounts["credit"].BalanceHistory.Last().Amount);

      total = 150;
      sbSplit = new Dictionary<string, decimal>() { { "gas", total } };
      purchase = new Purchase("Gas Station", checking, new DateTime(2020, 1, 15), total, sbSplit);
      yearTop.BudgetGroups[1].AddPurchase(purchase);

      Assert.AreEqual(checkingStarting - total, yearTop.Accounts["checking"].BalanceHistory.Last().Amount);
    }

    [Test]
    public void SimpleHardBillTest()
    {
      decimal creditStarting = yearTop.Accounts["credit"].BalanceHistory.Last().Amount;
      decimal checkingStarting = yearTop.Accounts["checking"].BalanceHistory.Last().Amount;

      carRegistration.PayBill(new DateTime())

      Assert.AreEqual(creditStarting + total, yearTop.Accounts["credit"].BalanceHistory.Last().Amount);

      total = 150;
      sbSplit = new Dictionary<string, decimal>() { { "gas", total } };
      purchase = new Purchase("Gas Station", checking, new DateTime(2020, 1, 15), total, sbSplit);
      yearTop.BudgetGroups[1].AddPurchase(purchase);

      Assert.AreEqual(checkingStarting - total, yearTop.Accounts["checking"].BalanceHistory.Last().Amount);
    }
  }
}
