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
  public partial class EditHardBillForm : Form
  {
    private YearTop _year;
    private HardBill _hardBill;
    public event EventHandler<NewHardBillAddedEventArgs> NewHardBillAdded;
    
    public EditHardBillForm(HardBill hardBill, YearTop year)
    {
      InitializeComponent();

      if (hardBill != null)
      {
        _hardBill = hardBill;
      }
      else
      {
        _hardBill = new HardBill();
      }

      if (year == null)
      {
        throw new ArgumentException("Year has not been initialized yet.");
      }
      else
      {
        _year = year;
      }

      foreach (var account in _year.Accounts)
      {
        accountCb.Items.Add(account.Value.Name);
      }
      accountCb.SelectedItem = accountCb.Items[0];

      RefreshForm();
    }
    private void RefreshForm()
    {
      nameTb.Text = _hardBill.Name;
      amountTb.Text = _hardBill.Amount.ToString();
      accountCb.SelectedItem = _hardBill.PaymentAccount != null ? _hardBill.PaymentAccount.Name : string.Empty;
      dayPaidTb.Text = _hardBill.DayOfMonthPaid.ToString();
    }

    private void nameTb_TextChanged(object sender, EventArgs e)
    {
      _hardBill.Name = nameTb.Text;
    }

    private void amountTb_TextChanged(object sender, EventArgs e)
    {
      _hardBill.Amount = Decimal.Parse(amountTb.Text);
    }

    private void dayPaidTb_TextChanged(object sender, EventArgs e)
    {
      _hardBill.DayOfMonthPaid = Int32.Parse(dayPaidTb.Text);
    }

    private void accountCb_SelectedIndexChanged(object sender, EventArgs e)
    {
      _hardBill.PaymentAccount = _year.Accounts[accountCb.Text];
    }

    private void saveBtn_Click(object sender, EventArgs e)
    {
      NewHardBillAddedEventArgs args = new NewHardBillAddedEventArgs();
      args.NewHardBill = _hardBill;
      OnNewHardBillAdded(args);

      this.Close();
    }

    private void cancelBtn_Click(object sender, EventArgs e)
    {
      this.Close();
    }
    protected virtual void OnNewHardBillAdded(NewHardBillAddedEventArgs e)
    {
      NewHardBillAdded?.Invoke(this, e);
    }
  }
  public class NewHardBillAddedEventArgs : EventArgs
  {
    public HardBill NewHardBill { get; set; }
  }
}
