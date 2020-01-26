using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BudgetToolLib;

namespace BudgetToolApp
{
  public partial class ManageBudget : Form
  {
    private bool _showAnnual;
    private bool _allAccountTransactions;
    private bool _allDatesTransactions;
    private YearTop _year;
    private YearTop _yearFastForward;
    private DateTime _dateSelected;
    private List<string> _selectedAccounts;
    AccountBase _selectedAccount;
    private bool _skipRefreshing;

    public ManageBudget(YearTop year)
    {
      _skipRefreshing = true;

      InitializeComponent();

      if(year == null)
      {
        throw new ArgumentException("Uninitialized year!");
      }

      _year = year;
      _dateSelected = DateTime.Today;
      _showAnnual = false;
      _allAccountTransactions = false;
      _allDatesTransactions = false;
      _selectedAccounts = new List<string>();
      _selectedAccount = year.Accounts.First().Value;

      if(_year.Accounts.Count <= 0)
      {
        throw new ArgumentException("Must instantiate at least one account.");
      }
      dateDtp.Value = DateTime.Today;
      showAnnualCb.Checked = false;
      allAccountsCb.Checked = false;
      allDatesCb.Checked = false;

      _year.FastForward(DateTime.Today);

      accountsLv.ItemChecked += AccountsLv_ItemChecked;
      transactionsLv.MouseUp += new MouseEventHandler(purchasesLv_MouseUp);
      hardBillsLv.MouseUp += new MouseEventHandler(hardBillsLv_MouseUp);

      accountsLv.Items.Clear();
      foreach (var account in _year.Accounts)
      {
        ListViewItem lvi = new ListViewItem(account.Key);
        accountsLv.Items.Add(lvi);
      }
      accountsLv.Items[0].Checked = true;

      _skipRefreshing = false;
      RefreshPage();
    }

    private void hardBillsLv_MouseUp(object sender, MouseEventArgs e)
    {
      int index = -1;
      HardBill hardBill = null;

      if (e.Button == MouseButtons.Right)
      {
        if (hardBillsLv.Items.Count > 0)
        {
          ListViewItem selectedItem = hardBillsLv.GetItemAt(e.X, e.Y);
          if (selectedItem != null)
          {
            index = selectedItem.Index;
            hardBill = selectedItem.Tag as HardBill;
          }
        }

        if ((hardBill != null) && (!hardBill.AutoPay))
        {
          hbPay.Enabled = true;
          //purchasesEdit.Enabled = true;
        }
        else
        {
          hbPay.Enabled = false;
          //purchasesEdit.Enabled = false;
        }
        hbCms.Show(this, new Point(e.X + ((Control)sender).Left + 20, e.Y + ((Control)sender).Top + 20));
        //accountCms.Show(this, new Point(e.X, e.Y));
      }
    }

    private void purchasesLv_MouseUp(object sender, MouseEventArgs e)
    {
      int index = -1;

      if (e.Button == MouseButtons.Right)
      {
        if (transactionsLv.Items.Count > 0)
        {
          ListViewItem selectedItem = transactionsLv.GetItemAt(e.X, e.Y);
          if (selectedItem != null)
          {
            index = selectedItem.Index;
          }
        }

        if (index > -1)
        {
          purchasesDelete.Enabled = true;
          //purchasesEdit.Enabled = true;
        }
        else
        {
          purchasesDelete.Enabled = false;
          //purchasesEdit.Enabled = false;
        }
        purchasesCms.Show(this, new Point(e.X + ((Control)sender).Left + 20, e.Y + ((Control)sender).Top + 20));
        //accountCms.Show(this, new Point(e.X, e.Y));
      }
    }
    private void purchasesDelete_Click(object sender, EventArgs e)
    {
      Transaction t = transactionsLv.SelectedItems[0].Tag as Transaction;
      string accountName = transactionsLv.SelectedItems[0].SubItems[2].Text;
      if(!_year.Accounts[accountName].Remove(t))
      {
        throw new ArgumentException("Could not find transaction!");
      }
      RefreshPage();
    }

    private void purchasesEdit_Click(object sender, EventArgs e)
    {
      //_transToEdit = transactionsLv.SelectedItems[0].Tag as Transaction;

      //var editPurchaseForm = new EditTransactionForm()
      //editPurchaseForm.NewTransactionAdded += EditSoftBill_Added;
      //editPurchaseForm.ShowDialog();
      //RefreshPage();
    }
    private void logPurchaseBtn_Click(object sender, EventArgs e)
    {
      var editSbTransactionForm = new EditSbTransactionForm(_year);
      editSbTransactionForm.NewTransactionAdded += NewSbTransaction_Added;
      editSbTransactionForm.Show();
    }

    private void NewSbTransaction_Added(object sender, NewSbTransactionEventArgs e)
    {
      if (e.NewTransaction != null)
      {
        if(!_year.Accounts.ContainsKey(e.AccountName))
        {
          throw new ArgumentException("could not find that account! Transaction not added.");
        }
        _year.Accounts[e.AccountName].NewDebitTransaction(e.NewTransaction);
      }
      RefreshPage();
    }

    private void AccountsLv_ItemChecked(object sender, ItemCheckedEventArgs e)
    {
      _selectedAccounts = new List<string>();
      foreach (ListViewItem lvi in accountsLv.CheckedItems)
      {
        _selectedAccounts.Add(lvi.Text);
      }
      RefreshPage();
    }

    private void RefreshPage()
    {
      if (_skipRefreshing)
        return;

      YearTop localYt;
      if (_yearFastForward == null)
      {
        localYt = _year;
      }
      else
      {
        localYt = _yearFastForward;
      }

      //using accountsLv here so the order matches up
      //accountsLv is for name & selection
      //accountInfoLv is to display any info for each of those accounts
      accountInfoLv.Items.Clear();
      foreach (ListViewItem item in accountsLv.Items)
      {
        if (item == null)
          continue;
        ListViewItem lvi = new ListViewItem(localYt.Accounts[item.Text].GetBalance(_dateSelected).ToString());
        accountInfoLv.Items.Add(lvi);
      }

      int monthSelected;
      if(_showAnnual)
      {
        monthSelected = 0;
      }
      else
      {
        monthSelected = _dateSelected.Month;
      }

      softBillsLv.Items.Clear();
      foreach (var softBill in localYt.MonthlySoftBills[monthSelected].SoftBills)
      {
        ListViewItem lvi = new ListViewItem(softBill.Key);
        lvi.SubItems.Add(softBill.Value.ToString());
        lvi.SubItems.Add((softBill.Value/* - softBill.Value.AmountUsed*/).ToString());
        lvi.Tag = softBill.Value;
        softBillsLv.Items.Add(lvi);
      }

      List<Transaction> displayTransactions = new List<Transaction>();
      List<AccountBase> displayAccounts = new List<AccountBase>();

      if (_allAccountTransactions)
      {
        foreach (var account in localYt.Accounts)
        {
          displayAccounts.Add(account.Value);
        }
      }
      else
      {
        foreach (var account in _selectedAccounts)
        {
          displayAccounts.Add(localYt.Accounts[account]);
        }
      }

      transactionsLv.Items.Clear();
      foreach (var account in displayAccounts)
      {
        if (_allDatesTransactions)
        {
          displayTransactions = account.GetTransactions().ToList();
        }
        else
        {
          displayTransactions = account.GetTransactions().Where(p => (p.Date.Month == _dateSelected.Month)).ToList();
        }

        foreach (var t in displayTransactions.OrderBy(t => t.Date).ToList())
        {
          ListViewItem lvi = new ListViewItem(t.Description);
          lvi.SubItems.Add(t.Amount.ToString());
          lvi.SubItems.Add(account.Name); //subitems 2?
          lvi.SubItems.Add(t.Date.ToShortDateString());
          lvi.Tag = t;
          if(t.Date < account.StartingDate)
          {
            lvi.BackColor = Color.LightGray;
          }
          transactionsLv.Items.Add(lvi);
        }
      }

      hardBillsLv.Items.Clear();

      var hbList = localYt.HardBills.ToList();
      hbList.Sort((pair1, pair2) => pair1.Value.NextBillDue.CompareTo(pair2.Value.NextBillDue));

      foreach (var hb in hbList)
      {
        ListViewItem lvi = new ListViewItem(hb.Key);
        lvi.SubItems.Add(hb.Value.Amount.ToString());
        lvi.SubItems.Add(hb.Value.NextBillDue.ToShortDateString());
        if((hb.Value.AutoPay == false) && (hb.Value.NextBillDue <= _dateSelected))
        {
          lvi.BackColor = Color.Red;
        }
        else if(hb.Value.AutoPay)
        {
          lvi.BackColor = Color.LightGreen;
        }
        lvi.Tag = hb.Value;
        hardBillsLv.Items.Add(lvi);
      }
    }

    private void dateDtp_ValueChanged(object sender, EventArgs e)
    {
      _dateSelected = dateDtp.Value;

      if (_dateSelected > DateTime.Today)
      {
        _yearFastForward = new YearTop(_year);
        _yearFastForward.FastForward(_dateSelected);
      }
      else
      {
        _yearFastForward = null;
      }
      RefreshPage();
    }

    private void showAnnualCb_CheckedChanged(object sender, EventArgs e)
    {
      _showAnnual = showAnnualCb.Checked;
      RefreshPage();
    }

    private void allAccountsCb_CheckedChanged(object sender, EventArgs e)
    {
      _allAccountTransactions = allAccountsCb.Checked;
      RefreshPage();
    }

    private void allDatesCb_CheckedChanged(object sender, EventArgs e)
    {
      _allDatesTransactions = allDatesCb.Checked;
      RefreshPage();
    }

    private void editBudgetBtn_Click(object sender, EventArgs e)
    {
      var editBudgetTop = new EditBudgetTop(_year);
      this.Close();
      editBudgetTop.Show();
    }

    private void RefreshPage_Handler(object sender, EventArgs e)
    {
      RefreshPage();
    }
    private void hbPay_Click(object sender, EventArgs e)
    {
      HardBill hb = hardBillsLv.SelectedItems[0].Tag as HardBill;
      EditHardBillPay editHardBillPay = new EditHardBillPay(hb);
      editHardBillPay.NewHardBillPayEvent += RefreshPage_Handler;
      editHardBillPay.Show();
      RefreshPage();
    }
  }
}
