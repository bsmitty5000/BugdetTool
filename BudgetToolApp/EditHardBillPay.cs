using System;
using System.Windows.Forms;
using BudgetToolLib;

namespace BudgetToolApp
{
  public partial class EditHardBillPay : Form
  {
    private IHardBill _hb;
    public event EventHandler<EventArgs> NewHardBillPayEvent;
    public EditHardBillPay(IHardBill hb)
    {
      InitializeComponent();

      if(hb == null)
      {
        throw new ArgumentException("Must select valid hardbill!");
      }

      _hb = hb;

      paymentDateDtp.Value = _hb.NextBillDue;
      amountTb.Text = _hb.Amount.ToString();
    }

    private void payBtn_Click(object sender, EventArgs e)
    {
      decimal amount;
      if (!decimal.TryParse(amountTb.Text, out amount))
      {
        amountTb.Text = _hb.Amount.ToString();
        MessageBox.Show("Invalid amount!");
        return;
      }
      DateTime paymentDate = paymentDateDtp.Value;

      _hb.PayBill(paymentDate, amount);
      OnHardBillPaid(null);
      this.Close();
    }

    private void OnHardBillPaid(object p)
    {
      NewHardBillPayEvent.Invoke(null, null);
    }

    private void cancelBtn_Click(object sender, EventArgs e)
    {
      this.Close();
    }
  }
}
