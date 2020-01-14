using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BudgetToolLib;

namespace BudgetToolGui
{
  public partial class ManageMonthsForm : Form
  {
    private YearTop _year;
    private YearTop _yearcopy;
    private DateTime _currentDate;
    private bool _showAllPurchases;
    private AccountBase _accountSelected;
    private List<string> months = new List<string>
    {
      "Annual",
      "January",
      "February",
      "March",
      "April",
      "May",
      "June",
      "July",
      "August",
      "September",
      "October",
      "November",
      "December"
    };
    public ManageMonthsForm(YearTop year)
    {
      InitializeComponent();

      if (year == null)
      {
        throw new ArgumentException("Year has not been initialized yet.");
      }
      else
      {
        _year = year;
      }

      purchasesLv.MouseUp += new MouseEventHandler(purchasesLv_MouseUp);
      accountsLv.MouseUp += new MouseEventHandler(accountsLv_MouseUp);

      _currentDate = DateTime.Today;
      todayDtp.Value = _currentDate;
      _yearcopy = new YearTop(_year);
      _year.FastForward(new DateTime(DateTime.Today.Year, 12, 31));

      RefreshPage();
    }

    #region Private Helpers
    private void RefreshPage()
    {
      accountsLv.Items.Clear();
      foreach (var account in _year.Accounts)
      {
        ListViewItem lvi = new ListViewItem(account.Key);
        lvi.SubItems.Add(account.Value.GetType().Name);
        lvi.SubItems.Add(account.Value.GetCurrentBalance(_currentDate).ToString());
        lvi.Tag = account.Value;
        accountsLv.Items.Add(lvi);
      }

      monthlySbLv.Items.Clear();
      foreach (var softBill in _year.MonthlySoftBills[_currentDate.Month].SoftBills)
      {
        BalanceEntry firstEntry = softBill.Value.BalanceHistory[0];
        BalanceEntry lastEntry = softBill.Value.BalanceHistory.Last();
        ListViewItem lvi = new ListViewItem(softBill.Key);
        lvi.SubItems.Add(firstEntry.Amount.ToString());
        lvi.SubItems.Add(lastEntry.Amount.ToString());
        lvi.Tag = softBill.Value;
        monthlySbLv.Items.Add(lvi);
      }

      annualSbLv.Items.Clear();
      foreach (var softBill in _year.MonthlySoftBills[0].SoftBills)
      {
        BalanceEntry firstEntry = softBill.Value.BalanceHistory[0];
        BalanceEntry lastEntry = softBill.Value.BalanceHistory.Last();
        ListViewItem lvi = new ListViewItem(softBill.Key);
        lvi.SubItems.Add(firstEntry.Amount.ToString());
        lvi.SubItems.Add(lastEntry.Amount.ToString());
        lvi.Tag = softBill.Value;
        annualSbLv.Items.Add(lvi);
      }

      purchasesLv.Items.Clear();
      List<Purchase> displayPurchases;
      if(_showAllPurchases)
      {
        displayPurchases = _year.Purchases;
      }
      else
      {
        displayPurchases = _year.Purchases.Where(p => (p.DateOfPurchase.Month == _currentDate.Month)).ToList();
      }
      foreach (var purchase in displayPurchases)
      {
        ListViewItem lvi = new ListViewItem(purchase.Vendor);
        lvi.SubItems.Add(purchase.Amount.ToString());
        lvi.SubItems.Add(purchase.DateOfPurchase.ToShortDateString());
        lvi.Tag = purchase;
        purchasesLv.Items.Add(lvi);
      }

      decimal currentAnnualSbTotal = 0;
      foreach (var sbGroup in _year.MonthlySoftBills[0].SoftBills)
      {
        currentAnnualSbTotal += sbGroup.Value.BalanceHistory.Last().Amount;
      }
      annualSbRemainingTb.Text = currentAnnualSbTotal.ToString();

      decimal currentMonthSbTotal = 0;
      foreach (var sbGroup in _year.MonthlySoftBills[_currentDate.Month].SoftBills)
      {
        currentMonthSbTotal += sbGroup.Value.BalanceHistory.Last().Amount;
      }
      monthlySbRemainingTb.Text = currentMonthSbTotal.ToString();

      /* not sure what to do here yet */
      decimal totalSbSnapshot = 0;
      for(int i = 1; i < _currentDate.Month; i++)
      {
        foreach (var sbGroup in _year.MonthlySoftBills[i].SoftBills)
        {
          totalSbSnapshot += sbGroup.Value.BalanceHistory.Last().Amount;
        }
      }
      totalSbSnapshotTb.Text = totalSbSnapshot.ToString();
    }
    #endregion

    #region Purchase Stuff
    private void purchasesLv_MouseUp(object sender, MouseEventArgs e)
    {
      int index = -1;

      if (e.Button == MouseButtons.Right)
      {
        if (purchasesLv.Items.Count > 0)
        {
          ListViewItem selectedItem = purchasesLv.GetItemAt(e.X, e.Y);
          if (selectedItem != null)
          {
            index = selectedItem.Index;
          }
        }

        if (_year.MonthlySoftBills[1].SoftBills.Count > 0)
        {
          purchasesAdd.Enabled = true;
        }
        else
        {
          purchasesAdd.Enabled = false;
        }

        if (index > -1)
        {
          purchasesDelete.Enabled = true;
          purchasesEdit.Enabled = true;
        }
        else
        {
          purchasesDelete.Enabled = false;
          purchasesEdit.Enabled = false;
        }
        purchasesCms.Show(this, new Point(e.X + ((Control)sender).Left + 20, e.Y + ((Control)sender).Top + 20));
        //accountCms.Show(this, new Point(e.X, e.Y));
      }
    }
    private void purchasesAdd_Click(object sender, EventArgs e)
    {
      var editPurchaseForm = new EditPurchaseForm(null, _year, _currentDate.Month);
      editPurchaseForm.NewPurchaseAdded += NewPurchase_Added;
      editPurchaseForm.Show();
    }
    private void addAnnual_Click(object sender, EventArgs e)
    {
      var editPurchaseForm = new EditPurchaseForm(null, _year, 0);
      editPurchaseForm.NewPurchaseAdded += NewPurchase_Added;
      editPurchaseForm.Show();
    }
    private void purchasesDelete_Click(object sender, EventArgs e)
    {
      Purchase purchase = purchasesLv.SelectedItems[0].Tag as Purchase;
      int month = purchase.DateOfPurchase.Month;
      _year.RemovePurchase(purchase);
      RefreshPage();
    }
    private void purchasesEdit_Click(object sender, EventArgs e)
    {
      Purchase purchase = purchasesLv.SelectedItems[0].Tag as Purchase;

      var editPurchaseForm = new EditPurchaseForm(purchase, _year, 0);
      //editSoftBill.NewSoftBillAdded += NewMonthlySoftBill_Added;
      editPurchaseForm.ShowDialog();
      RefreshPage();
    }
    private void NewPurchase_Added(object sender, NewPurchaseAddedEventArgs e)
    {
      if (e.NewPurchase != null)
      {
        _year.AddPurchase(e.NewPurchase);
      }
      RefreshPage();
    }
    #endregion

    #region Account Stuff
    private void accountsLv_MouseUp(object sender, MouseEventArgs e)
    {
      int index = -1;

      if (e.Button == MouseButtons.Right)
      {
        if (accountsLv.Items.Count > 0)
        {
          ListViewItem selectedItem = accountsLv.GetItemAt(e.X, e.Y);
          if (selectedItem != null)
          {
            index = selectedItem.Index;
          }

          if (index > -1)
          {
            manualCredit.Enabled = true;
            manualDebit.Enabled = true;
          }
          else
          {
            manualCredit.Enabled = false;
            manualDebit.Enabled = false;
          }
        }

        accountCms.Show(this, new Point(e.X + ((Control)sender).Left + 20, e.Y + ((Control)sender).Top + 20));
        //accountCms.Show(this, new Point(e.X, e.Y));
      }
    }
    private void manualCredit_Click(object sender, EventArgs e)
    {
      _accountSelected = accountsLv.SelectedItems[0].Tag as AccountBase;

      var createNewTransaction = new EditTransactionForm(_accountSelected, _currentDate);
      createNewTransaction.NewTransactionAdded += NewCreditTransaction;
      createNewTransaction.Show();
      RefreshPage();
    }

    private void NewCreditTransaction(object sender, NewTransactionAddedEventArgs e)
    {
      e.NewTransaction.Description = "Manual Credit";
      _accountSelected.NewCreditTransaction(e.NewTransaction);
      RefreshPage();
    }

    private void manualDebit_Click(object sender, EventArgs e)
    {
      _accountSelected = accountsLv.SelectedItems[0].Tag as AccountBase;

      var createNewTransaction = new EditTransactionForm(_accountSelected, _currentDate);
      createNewTransaction.NewTransactionAdded += NewDebitTransaction;
      createNewTransaction.Show();
      RefreshPage();
    }

    private void NewDebitTransaction(object sender, NewTransactionAddedEventArgs e)
    {
      e.NewTransaction.Description = "Manual Debit";
      _accountSelected.NewDebitTransaction(e.NewTransaction);
      RefreshPage();
    }

    #endregion

    #region Assorted
    private void todayDtp_ValueChanged(object sender, EventArgs e)
    {
      _currentDate = todayDtp.Value;
      RefreshPage();
    }
    private void showAllPurchasesCb_CheckedChanged(object sender, EventArgs e)
    {
      _showAllPurchases = showAllPurchasesCb.Checked;
      RefreshPage();
    }

    #endregion

    private void doneBtn_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    }
}
