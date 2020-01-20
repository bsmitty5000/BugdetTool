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
    private Transaction _transactionToReplace;
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

      _currentDate = DateTime.Today;
      todayDtp.Value = _currentDate;

      _year.FastForward(_currentDate);

      RefreshPage();
    }

    #region Private Helpers
    private void RefreshPage()
    {
      YearTop localYt;
      if(_yearcopy == null)
      {
        localYt = _year;
      }
      else
      {
        localYt = _yearcopy;
      }

      accountsLv.Items.Clear();
      foreach (var account in localYt.Accounts)
      {
        ListViewItem lvi = new ListViewItem(account.Key);
        lvi.SubItems.Add(account.Value.GetType().Name);
        lvi.SubItems.Add(account.Value.GetBalance(_currentDate).ToString());
        lvi.Tag = account.Value;
        accountsLv.Items.Add(lvi);
      }

      monthlySbLv.Items.Clear();
      foreach (var softBill in localYt.MonthlySoftBills[_currentDate.Month].SoftBills)
      {
        ListViewItem lvi = new ListViewItem(softBill.Key);
        lvi.SubItems.Add(softBill.Value.AmountBudgeted.ToString());
        lvi.SubItems.Add((softBill.Value.AmountBudgeted - softBill.Value.AmountUsed).ToString());
        lvi.Tag = softBill.Value;
        monthlySbLv.Items.Add(lvi);
      }

      annualSbLv.Items.Clear();
      foreach (var softBill in localYt.MonthlySoftBills[0].SoftBills)
      {
        ListViewItem lvi = new ListViewItem(softBill.Key);
        lvi.SubItems.Add(softBill.Value.AmountBudgeted.ToString());
        lvi.SubItems.Add((softBill.Value.AmountBudgeted - softBill.Value.AmountUsed).ToString());
        lvi.Tag = softBill.Value;
        annualSbLv.Items.Add(lvi);
      }

      purchasesLv.Items.Clear();
      List<Transaction> displayPurchases = new List<Transaction>();
      if(_showAllPurchases)
      {
        foreach (var account in localYt.Accounts)
        {
          displayPurchases.AddRange(account.Value.Transactions.Where(p => (p.Date.Month == _currentDate.Month)).ToList());
        }
      }
      else
      {
        displayPurchases = localYt.Accounts[_accountSelected.Name].Transactions.Where(p => (p.Date.Month == _currentDate.Month)).ToList();
      }
      foreach (var purchase in displayPurchases)
      {
        ListViewItem lvi = new ListViewItem(purchase.Description);
        lvi.SubItems.Add(purchase.Amount.ToString());
        lvi.SubItems.Add(purchase.Date.ToShortDateString());
        lvi.Tag = purchase;
        purchasesLv.Items.Add(lvi);
      }

      decimal currentAnnualSbTotal = 0;
      foreach (var sbGroup in localYt.MonthlySoftBills[0].SoftBills)
      {
        currentAnnualSbTotal += sbGroup.Value.AmountUsed;
      }
      annualSbRemainingTb.Text = currentAnnualSbTotal.ToString();

      decimal currentMonthSbTotal = 0;
      foreach (var sbGroup in localYt.MonthlySoftBills[_currentDate.Month].SoftBills)
      {
        currentMonthSbTotal += sbGroup.Value.AmountUsed;
      }
      monthlySbRemainingTb.Text = currentMonthSbTotal.ToString();

      /* not sure what to do here yet */
      decimal totalSbSnapshot = 0;
      for(int i = 1; i < _currentDate.Month; i++)
      {
        foreach (var sbGroup in localYt.MonthlySoftBills[i].SoftBills)
        {
          totalSbSnapshot += sbGroup.Value.AmountUsed;
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
    private void addMonthly_Click(object sender, EventArgs e)
    {
      var editTransactionForm = new EditTransactionForm(_year.GetSoftBillTransaction(string.Empty, 0, _currentDate), _accountSelected, _year, _currentDate.Month);
      editTransactionForm.NewTransactionAdded += NewPurchase_Added;
      editTransactionForm.Show();
    }
    private void addAnnual_Click(object sender, EventArgs e)
    {
      var editTransactionForm = new EditTransactionForm(_year.GetSoftBillTransaction(string.Empty, 0, _currentDate), _accountSelected, _year, 0);
      editTransactionForm.NewTransactionAdded += NewPurchase_Added;
      editTransactionForm.Show();
    }
    private void purchasesDelete_Click(object sender, EventArgs e)
    {
      Transaction t = purchasesLv.SelectedItems[0].Tag as Transaction;
      _accountSelected.RemoveTransaction(t);
      RefreshPage();
    }
    private void purchasesEdit_Click(object sender, EventArgs e)
    {
      _transactionToReplace = purchasesLv.SelectedItems[0].Tag as Transaction;

      var editPurchaseForm = new deleteMe(_transactionToReplace, _accountSelected, _year, 0);
      editPurchaseForm.NewTransactionAdded += EditSoftBill_Added;
      editPurchaseForm.ShowDialog();
      RefreshPage();
    }
    private void NewPurchase_Added(object sender, NewTransactionEventArgs e)
    {
      if (e.NewTransaction != null)
      {
        if(e.NewTransaction.GetType().Name.Contains("SoftBill"))
        {
          _year.LogPurchase(e.NewTransaction as SoftBillTransaction, _accountSelected);
        }
        else
        {
          _accountSelected.
        }
      }
      RefreshPage();
    }

    private void EditSoftBill_Added(object sender, NewTransactionEventArgs e)
    {
      _accountSelected.ReplaceTransaction(_transactionToReplace, e.NewTransaction);
    }
    #endregion

    #region Account Stuff
    private void accountsLv_SelectedIndexChanged(object sender, EventArgs e)
    {
      if(selectAllAccountCb.Checked == false)
      {
        _accountSelected = accountsLv.SelectedItems[0].Tag as AccountBase;
        RefreshPage();
      }
    }
    private void selectAllAccountCb_CheckedChanged(object sender, EventArgs e)
    {
      if(selectAllAccountCb.Checked)
      {
        foreach (ListViewItem lv in accountsLv.Items)
        {
          lv.Selected = true;
        }
        _showAllPurchases = true;
      }
      else
      {
        foreach (ListViewItem lv in accountsLv.Items)
        {
          lv.Selected = false;
        }
      }
    }

    #endregion

    #region Assorted
    private void todayDtp_ValueChanged(object sender, EventArgs e)
    {
      _currentDate = todayDtp.Value;

      if(_currentDate > DateTime.Today)
      {
        _yearcopy = new YearTop(_year);
        _yearcopy.FastForward(_currentDate);
      }
      else
      {
        _yearcopy = null;
      }
      RefreshPage();
    }

    #endregion

    private void doneBtn_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void label2_Click(object sender, EventArgs e)
    {

    }

  }
}
