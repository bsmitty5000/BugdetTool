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
        _hardBill = new HardBill(
          string.Empty,
          0,
          DateTimePicker.MinimumDateTime,
          HardBillFrequencyEnum.Monthly,
          null);
      }

      if (year == null)
      {
        throw new ArgumentException("Year has not been initialized yet.");
      }
      else
      {
        _year = year;
      }

      frequencyCb.Items.AddRange(Enum.GetNames(typeof(HardBillFrequencyEnum)));

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
      firstBillDueDtp.Value = _hardBill.FirstBillDue;
      frequencyCb.SelectedItem = _hardBill.Frequency.ToString();
      accountCb.SelectedItem = _hardBill.PaymentAccount != null ? _hardBill.PaymentAccount.Name : string.Empty;
    }

    private void nameTb_TextChanged(object sender, EventArgs e)
    {
      _hardBill.Name = nameTb.Text;
    }
    private void amountTb_TextChanged(object sender, EventArgs e)
    {
      if(amountTb.Text.Equals(string.Empty))
      {
        _hardBill.Amount = 0;
      }
      else
      {
        _hardBill.Amount = Decimal.Parse(amountTb.Text);
      }
    }
    private void accountCb_SelectedIndexChanged(object sender, EventArgs e)
    {
      _hardBill.PaymentAccount = _year.Accounts[accountCb.Text];
    }
    private void firstBillDueDtp_ValueChanged(object sender, EventArgs e)
    {
      _hardBill.FirstBillDue = firstBillDueDtp.Value;
    }
    private void frequencyCb_SelectedIndexChanged(object sender, EventArgs e)
    {
      HardBillFrequencyEnum enumParse;
      Enum.TryParse(frequencyCb.SelectedItem.ToString(), out enumParse);
      _hardBill.Frequency = enumParse;
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
