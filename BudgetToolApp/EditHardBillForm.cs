using System;
using System.Windows.Forms;
using BudgetToolLib;

namespace BudgetToolApp
{
  public partial class EditHardBillForm : Form
  {
    private YearTop _year;
    private IHardBill _hardBill;
    public event EventHandler<NewHardBillAddedEventArgs> NewHardBillAdded;

    public EditHardBillForm(IHardBill hardBill, YearTop year)
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


      frequencyCb.Items.AddRange(Enum.GetNames(typeof(HardBillFrequencyEnum)));

      var accountList = _year.GetAccountsNames();
      foreach (var account in accountList)
      {
        accountCb.Items.Add(account);
      }

      if (hardBill != null)
      {
        _hardBill = hardBill;
        nameTb.Text = _hardBill.Name;
        nameTb.ReadOnly = true;

        firstBillDueDtp.Value = _hardBill.FirstBillDue;
        firstBillDueDtp.Enabled = false;

        //editable
        amountTb.Text = _hardBill.Amount.ToString();
        frequencyCb.SelectedItem = _hardBill.Frequency.ToString();
        accountCb.SelectedItem = _hardBill.PaymentAccount.Name;
        autoPayCb.Checked = _hardBill.AutoPay;
      }
      else
      {
        _hardBill = null;
      }

    }

    private void saveBtn_Click(object sender, EventArgs e)
    {
      NewHardBillAddedEventArgs args = new NewHardBillAddedEventArgs();

      string name = nameTb.Text;
      DateTime firstBillDue = firstBillDueDtp.Value;

      decimal amount;
      if (!decimal.TryParse(amountTb.Text, out amount))
      {
        amountTb.Text = _hardBill.Amount.ToString();
        MessageBox.Show("Invalid amount!");
        return;
      }

      HardBillFrequencyEnum frequency;
      Enum.TryParse(frequencyCb.SelectedItem.ToString(), out frequency);

      string accountName = accountCb.Text;
      bool autoPay = autoPayCb.Checked;

      if(_hardBill == null)
      {
        args.NewHardBill = new HardBill(name, amount, firstBillDue, frequency, _year.GetAccount(accountName), autoPay);
      }
      else
      {
        _hardBill.Amount = amount;
        _hardBill.Frequency = frequency;
        _hardBill.PaymentAccount = _year.GetAccount(accountName);
        _hardBill.AutoPay = autoPay;
        args.NewHardBill = null;
      }
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
