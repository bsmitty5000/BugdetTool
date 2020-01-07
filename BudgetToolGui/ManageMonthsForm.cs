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
    private int _currentMonth;
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
      _currentMonth = 1;

      purchasesLv.MouseUp += new MouseEventHandler(purchasesLv_MouseUp);

      RefreshPage();
    }

    #region Private Helpers
    private void RefreshPage()
    {
      monthlySbLv.Items.Clear();
      foreach (var softBill in _year.BudgetGroups[_currentMonth].SoftBills)
      {
        BalanceEntry firstEntry = softBill.Value.BalanceHistory[0];
        BalanceEntry lastEntry = softBill.Value.BalanceHistory.Last();
        ListViewItem lvi = new ListViewItem(softBill.Key);
        lvi.SubItems.Add(firstEntry.Amount.ToString());
        lvi.SubItems.Add(lastEntry.Amount.ToString());
        lvi.Tag = softBill.Value;
        monthlySbLv.Items.Add(lvi);
      }

      purchasesLv.Items.Clear();
      foreach (var purchase in _year.BudgetGroups[_currentMonth].Purchases)
      {
        ListViewItem lvi = new ListViewItem(purchase.Vendor);
        lvi.SubItems.Add(purchase.Amount.ToString());
        lvi.Tag = purchase;
        purchasesLv.Items.Add(lvi);
      }

      // minus 1 here because months are not zero indexed but the months array is
      currentMonthLbl.Text = string.Format("Current Month: {0}", months[_currentMonth]);
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

        if (_year.BudgetGroups[1].SoftBills.Count > 0)
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
      var editPurchaseForm = new EditPurchaseForm(null, _year, _currentMonth);
      editPurchaseForm.NewPurchaseAdded += NewPurchase_Added;
      editPurchaseForm.Show();
    }
    private void purchasesDelete_Click(object sender, EventArgs e)
    {
      Purchase purchase = purchasesLv.SelectedItems[0].Tag as Purchase;
      int month = purchase.DateOfPurchase.Month;
      _year.BudgetGroups[month].RemovePurchase(purchase);
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
        _year.BudgetGroups[_currentMonth].AddPurchase(e.NewPurchase);
      }
      RefreshPage();
    }
    #endregion

    #region Buttons
    private void prevBtn_Click(object sender, EventArgs e)
    {
      if(_currentMonth > 0)
      {
        _currentMonth--;
      }
      RefreshPage();
    }

    private void nextBtn_Click(object sender, EventArgs e)
    {
      if (_currentMonth < months.Count - 1)
      {
        _currentMonth++;
      }
      RefreshPage();
    }
    #endregion

    private void doneBtn_Click(object sender, EventArgs e)
    {
      this.Close();
    }
  }
}
