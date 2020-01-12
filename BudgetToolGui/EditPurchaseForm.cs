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
  public partial class EditPurchaseForm : Form
  {
    private YearTop _year;
    private Purchase _purchase;
    public event EventHandler<NewPurchaseAddedEventArgs> NewPurchaseAdded;
    private bool _eventsOn;
    public EditPurchaseForm(Purchase purchase, YearTop year, int month)
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

      if (purchase != null)
      {
        _purchase = purchase;
      }
      else
      {
        _purchase = new Purchase();
        if(month == 0)
        {
          _purchase.DateOfPurchase = new DateTime(DateTime.Today.Year, 1, 1);
          dateDtp.MinDate = _purchase.DateOfPurchase;
          dateDtp.MaxDate = new DateTime(_purchase.DateOfPurchase.Year, 12, 31);
        }
        else
        {
          _purchase.DateOfPurchase = new DateTime(DateTime.Today.Year, month, 1);
          dateDtp.MinDate = _purchase.DateOfPurchase;
          dateDtp.MaxDate = new DateTime(_purchase.DateOfPurchase.Year, _purchase.DateOfPurchase.Month, DateTime.DaysInMonth(_purchase.DateOfPurchase.Year, _purchase.DateOfPurchase.Month));
        }
      }

      vendorTb.Text = _purchase.Vendor;
      amountTb.Text = _purchase.Amount.ToString();
      dateDtp.Value = _purchase.DateOfPurchase;

      foreach (var account in _year.Accounts)
      {
        accountCb.Items.Add(account.Value.Name);
      }

      accountCb.SelectedItem = accountCb.Items[0];
      foreach (var item in accountCb.Items)
      {
        if(item.ToString().ToLower().Contains("credit"))
        {
          accountCb.SelectedItem = item;
        }
      }

      if (_purchase.SoftBillSplit.Count == 0)
      {
        foreach (var sb in _year.MonthlySoftBills[month].SoftBills)
        {
          _purchase.SoftBillSplit.Add(sb.Value.Name, 0);
        }
      }

      int i = 0;
      _eventsOn = false;
      foreach (var kvp in _purchase.SoftBillSplit)
      {
        softBillSplitTpl.RowStyles.Add(new RowStyle(SizeType.AutoSize));

        Label lblTitle = new Label();
        lblTitle.Text = string.Format("{0}:", kvp.Key);
        lblTitle.TabIndex = (i * 2);
        lblTitle.Margin = new Padding(0);
        lblTitle.Dock = DockStyle.Fill;
        softBillSplitTpl.Controls.Add(lblTitle, 0, i);

        TextBox txtValue = new TextBox();
        txtValue.TabIndex = (i * 2) + 1;
        txtValue.Margin = new Padding(0);
        txtValue.Dock = DockStyle.Fill;
        txtValue.TextChanged += new EventHandler(softBillSplit_TextChanged);
        txtValue.Name = kvp.Key + "_tb";
        txtValue.Text = kvp.Value.ToString();
        softBillSplitTpl.Controls.Add(txtValue, 1, i);

        Button remainder = new Button();
        remainder.Text = "Use Remainder";
        remainder.TabIndex = (i * 2) + 2;
        remainder.Margin = new Padding(0);
        remainder.Dock = DockStyle.Fill;
        remainder.Click += new EventHandler(remainder_Click);
        remainder.Name = kvp.Key + "_btn";
        remainder.AutoSize = true;
        softBillSplitTpl.Controls.Add(remainder, 2, i);

        i++;
      }
      _eventsOn = true;

    }

    private void softBillSplit_TextChanged(object sender, EventArgs e)
    {
      if (!_eventsOn)
        return;

      TextBox textBox = (TextBox)sender;
      string sbKey = textBox.Name.Split('_')[0];

      if(_purchase.SoftBillSplit.ContainsKey(sbKey))
      {
        _purchase.SoftBillSplit[sbKey] = Decimal.Parse(textBox.Text);
      }

    }
    private void remainder_Click(object sender, EventArgs e)
    {
      decimal currentTotal = 0;
      string tbpKey = ((Button)sender).Name.Split('_')[0] + "_tb";
      string sbKey = tbpKey.Split('_')[0];
      foreach (var sub in _purchase.SoftBillSplit.Values)
      {
        currentTotal += sub;
      }

      decimal remainderTotal = _purchase.Amount - currentTotal;
      softBillSplitTpl.Controls[tbpKey].Text = remainderTotal.ToString();
      _purchase.SoftBillSplit[sbKey] = remainderTotal;
    }

    private void vendorTb_TextChanged(object sender, EventArgs e)
    {
      _purchase.Vendor = vendorTb.Text;
    }

    private void amountTb_TextChanged(object sender, EventArgs e)
    {
      if (amountTb.Text.Equals(string.Empty))
      {
        _purchase.Amount = 0;
      }
      else
      {
        _purchase.Amount = Decimal.Parse(amountTb.Text);
      }
    }

    private void accountCb_SelectedIndexChanged(object sender, EventArgs e)
    {
      _purchase.PaymentAccount = _year.Accounts[accountCb.Text];
    }

    private void dateDtp_ValueChanged(object sender, EventArgs e)
    {
      _purchase.DateOfPurchase = dateDtp.Value;
    }

    private void saveBtn_Click(object sender, EventArgs e)
    {
      NewPurchaseAddedEventArgs args = new NewPurchaseAddedEventArgs();
      foreach (var item in _purchase.SoftBillSplit.Where(kvp => kvp.Value == 0).ToList())
      {
        _purchase.SoftBillSplit.Remove(item.Key);
      }
      args.NewPurchase = _purchase;
      OnNewPurchaseBillAdded(args);

      this.Close();
    }
    protected virtual void OnNewPurchaseBillAdded(NewPurchaseAddedEventArgs e)
    {
      NewPurchaseAdded?.Invoke(this, e);
    }

    private void cancelBtn_Click(object sender, EventArgs e)
    {
      this.Close();
    }
  }
  public class NewPurchaseAddedEventArgs : EventArgs
  {
    public Purchase NewPurchase { get; set; }
  }
}
