using System;
using System.Windows.Forms;
using BudgetToolLib;

namespace BudgetToolApp
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
          DateTime.Today,
          HardBillFrequencyEnum.Monthly,
          null,
          false);
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

      nameTb.Text = _hardBill.Name;
      amountTb.Text = _hardBill.Amount.ToString();
      firstBillDueDtp.Value = _hardBill.FirstBillDue;
      frequencyCb.SelectedItem = _hardBill.Frequency.ToString();
      accountCb.SelectedItem = _hardBill.PaymentAccount != null ? _hardBill.PaymentAccount.Name : string.Empty;
      autoPayCb.Checked = _hardBill.AutoPay;
    }

    private void saveBtn_Click(object sender, EventArgs e)
    {
      NewHardBillAddedEventArgs args = new NewHardBillAddedEventArgs();

      decimal amount;
      if (decimal.TryParse(amountTb.Text, out amount))
      {
        _hardBill.Amount = amount;
      }
      else
      {
        amountTb.Text = _hardBill.Amount.ToString();
        MessageBox.Show("Invalid amount!");
        return;
      }
      _hardBill.Name = nameTb.Text;

      HardBillFrequencyEnum enumParse;
      Enum.TryParse(frequencyCb.SelectedItem.ToString(), out enumParse);
      _hardBill.Frequency = enumParse;

      _hardBill.FirstBillDue = firstBillDueDtp.Value;
      _hardBill.NextBillDue = firstBillDueDtp.Value;

      _hardBill.PaymentAccount = _year.Accounts[accountCb.Text];

      _hardBill.AutoPay = autoPayCb.Checked;

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
