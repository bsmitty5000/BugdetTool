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
    string[] Months = 
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

    private bool _showAnnual;
    private bool _allAccountTransactions;
    private bool _allDatesTransactions;
    private YearTop _year;
    private bool _fastForwardNoEditing;
    private DateTime _dateSelected;
    private int _monthSelected;
    private List<string> _selectedAccounts;
    IAccountBase _selectedAccount;
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
      var accounts = _year.GetAccounts();
      _selectedAccount = accounts.First();

      if(accounts.Count <= 0)
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
      softBillsLv.MouseUp += new MouseEventHandler(softBillsLv_MouseUp);

      accountsLv.Items.Clear();
      foreach (var account in accounts)
      {
        ListViewItem lvi = new ListViewItem(account.Name);
        accountsLv.Items.Add(lvi);
      }
      accountsLv.Items[0].Checked = true;

      _skipRefreshing = false;
      RefreshPage();
    }

    #region soft bills
    private void softBillsLv_MouseUp(object sender, MouseEventArgs e)
    {
      int index = -1;

      if (e.Button == MouseButtons.Right)
      {
        if (softBillsLv.Items.Count > 0)
        {
          ListViewItem selectedItem = softBillsLv.GetItemAt(e.X, e.Y);
          if (selectedItem != null)
          {
            index = selectedItem.Index;
          }
        }

        if (_year.GetAccounts().Count > 0)
        {
          sbAdd.Enabled = true;
        }
        else
        {
          sbAdd.Enabled = false;
        }

        if (index > -1)
        {
          sbDelete.Enabled = true;
          sbEdit.Enabled = true;
        }
        else
        {
          sbDelete.Enabled = false;
          sbEdit.Enabled = false;
        }
        sbCms.Show(this, new Point(e.X + ((Control)sender).Left + 20, e.Y + ((Control)sender).Top + 20));
        //accountCms.Show(this, new Point(e.X, e.Y));
      }
    }
    private void sbAdd_Click(object sender, EventArgs e)
    {
      var editSoftBill = new EditSoftBillForm(string.Empty, 0);
      editSoftBill.NewSoftBillAdded += NewSoftBill_Added;
      editSoftBill.Show();
    }
    private void sbDelete_Click(object sender, EventArgs e)
    {
      string name = softBillsLv.SelectedItems[0].SubItems[0].Text;
      _year.RemoveSoftBill(name, _monthSelected);
      RefreshPage();
    }
    private void sbEdit_Click(object sender, EventArgs e)
    {
      string name = softBillsLv.SelectedItems[0].SubItems[0].Text;
      decimal amount = decimal.Parse(softBillsLv.SelectedItems[0].SubItems[1].Text);

      var editSoftBill = new EditSoftBillForm(name, amount);
      editSoftBill.NewSoftBillAdded += NewSoftBill_Added;
      editSoftBill.ShowDialog();
      RefreshPage();
    }
    private void NewSoftBill_Added(object sender, NewSoftBillAddedEventArgs e)
    {
      _year.AddSoftBill(e.Name, e.Amount, _monthSelected);
      RefreshPage();
    }
    #endregion

    #region hard bills
    private void hardBillsLv_MouseUp(object sender, MouseEventArgs e)
    {
      int index = -1;
      IHardBill hardBill = null;

      if (e.Button == MouseButtons.Right)
      {
        if (hardBillsLv.Items.Count > 0)
        {
          ListViewItem selectedItem = hardBillsLv.GetItemAt(e.X, e.Y);
          if (selectedItem != null)
          {
            index = selectedItem.Index;
            hardBill = _year.GetHardBill(selectedItem.SubItems[0].Text);
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
    private void hbPay_Click(object sender, EventArgs e)
    {
      string hb = hardBillsLv.SelectedItems[0].SubItems[0].Text;
      EditHardBillPay editHardBillPay = new EditHardBillPay(_year.GetHardBill(hb));
      editHardBillPay.NewHardBillPayEvent += RefreshPage_Handler;
      editHardBillPay.Show();
      RefreshPage();
    }
    #endregion

    #region transactions
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

        if ((!_fastForwardNoEditing) && index > -1)
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
      if(!_year.GetAccount(accountName).RemoveTransaction(t.TransactionId))
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
      var editSbTransactionForm = new EditSbTransactionForm(_year, _dateSelected);
      editSbTransactionForm.NewTransactionAdded += NewSbTransaction_Added;
      editSbTransactionForm.Show();
    }
    private void NewSbTransaction_Added(object sender, NewSbTransactionEventArgs e)
    {
      if (e.NewTransaction != null)
      {
        _year.GetAccount(e.AccountName).NewDebitTransaction(e.NewTransaction);
      }
      RefreshPage();
    }
    #endregion

    #region accounts
    private void AccountsLv_ItemChecked(object sender, ItemCheckedEventArgs e)
    {
      _selectedAccounts = new List<string>();
      foreach (ListViewItem lvi in accountsLv.CheckedItems)
      {
        _selectedAccounts.Add(lvi.Text);
      }
      RefreshPage();
    }

    #endregion

    private void RefreshPage()
    {
      if (_skipRefreshing)
        return;

      //i wonder if i'll ever notice how slow this is..
      YearTop localYt;
      if (_dateSelected > DateTime.Today)
      {
        localYt = _year.Copy();
        localYt.FastForward(_dateSelected);
        _fastForwardNoEditing = true;
      }
      else
      {
        localYt = _year;
        _fastForwardNoEditing = false;
      }

      //using accountsLv here so the order matches up
      //accountsLv is for name & selection
      //accountInfoLv is to display any info for each of those accounts
      accountInfoLv.Items.Clear();
      foreach (ListViewItem item in accountsLv.Items)
      {
        if (item == null)
          continue;
        ListViewItem lvi = new ListViewItem(localYt.GetAccount(item.Text).GetBalance(_dateSelected).ToString());
        accountInfoLv.Items.Add(lvi);
      }

      var softBillUsage = localYt.GetSoftBillUsed(_monthSelected);
      softBillsLbl.Text = string.Format("Soft Bills Month: {0}", Months[_monthSelected]);
      //update softbilllbl
      softBillsLv.Items.Clear();
      foreach (var softBill in localYt.GetSoftBillGroup(_monthSelected))
      {
        ListViewItem lvi = new ListViewItem(softBill.Key);
        lvi.SubItems.Add(softBill.Value.ToString());
        lvi.SubItems.Add((softBill.Value - softBillUsage[softBill.Key]).ToString());
        lvi.Tag = softBill.Value;
        softBillsLv.Items.Add(lvi);
      }

      List<Transaction> displayTransactions = new List<Transaction>();
      List<IAccountBase> displayAccounts = new List<IAccountBase>();

      if (_allAccountTransactions)
      {
        var accounts = localYt.GetAccounts();
        foreach (var account in accounts)
        {
          displayAccounts.Add(account);
        }
      }
      else
      {
        foreach (var account in _selectedAccounts)
        {
          displayAccounts.Add(localYt.GetAccount(account));
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

      var hbList = localYt.GetHardBills();
      hbList.Sort((pair1, pair2) => pair1.NextBillDue.CompareTo(pair2.NextBillDue));

      foreach (var hb in hbList)
      {
        ListViewItem lvi = new ListViewItem(hb.Name);
        lvi.SubItems.Add(hb.Amount.ToString());
        lvi.SubItems.Add(hb.NextBillDue.ToShortDateString());
        if((hb.AutoPay == false) && (hb.NextBillDue <= _dateSelected))
        {
          lvi.BackColor = Color.Red;
        }
        else if(hb.AutoPay)
        {
          lvi.BackColor = Color.LightGreen;
        }
        hardBillsLv.Items.Add(lvi);
      }
    }

    #region misc
    private void dateDtp_ValueChanged(object sender, EventArgs e)
    {
      _dateSelected = dateDtp.Value;

      if(!showAnnualCb.Checked)
      {
        _monthSelected = dateDtp.Value.Month;
      }

      RefreshPage();
    }
    private void showAnnualCb_CheckedChanged(object sender, EventArgs e)
    {
      _showAnnual = showAnnualCb.Checked;

      if(_showAnnual)
      {
        _monthSelected = 0;
      }
      else
      {
        _monthSelected = _dateSelected.Month;
      }

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
    #endregion
  }
}
