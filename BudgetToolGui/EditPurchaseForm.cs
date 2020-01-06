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
    public EditPurchaseForm(Purchase purchase, YearTop year)
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
      }

      foreach (var account in _year.Accounts)
      {
        accountCb.Items.Add(account.Value.Name);
      }
      accountCb.SelectedItem = accountCb.Items[0];

      if (_purchase.SoftBillSplit.Count == 0)
      {
        foreach (var sb in _year.BudgetGroups[0].SoftBills)
        {
          _purchase.SoftBillSplit.Add(sb.Value.Name, 0);
        }
        /* this works because all months are the same
         * if the option to change softbills each month is
         * added this must be updated
         */
        foreach (var sb in _year.BudgetGroups[1].SoftBills)
        {
          _purchase.SoftBillSplit.Add(sb.Value.Name, 0);
        }
      }

      int i = 0;
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
        softBillSplitTpl.Controls.Add(remainder, 2, i);

        i++;
      }
    }

    private void softBillSplit_TextChanged(object sender, EventArgs e)
    {
      TextBox textBox = (TextBox)sender;
      string name = textBox.Name.Split('_')[0];

      if(_purchase.SoftBillSplit.ContainsKey(textBox.Name))
      {
        _purchase.SoftBillSplit[textBox.Name] = Decimal.Parse(textBox.Text);
      }

    }
    private void remainder_Click(object sender, EventArgs e)
    {
      decimal currentTotal = 0;
      string tbpKey = ((Button)sender).Name.Split('_')[0] + "_tb";
      foreach (var sub in _purchase.SoftBillSplit.Values)
      {
        currentTotal += sub;
      }

      decimal remainderTotal = _purchase.Amount - currentTotal;
      softBillSplitTpl.Controls[tbpKey].Text = remainderTotal.ToString();
    }

    private void vendorTb_TextChanged(object sender, EventArgs e)
    {
      _purchase.Vendor = vendorTb.Text;
    }

    private void amountTb_TextChanged(object sender, EventArgs e)
    {
      _purchase.Amount = Decimal.Parse(amountTb.Text);
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
      foreach (var kvp in _purchase.SoftBillSplit)
      {
        if(kvp.Value == 0)
        {
          _purchase.SoftBillSplit.Remove(kvp.Key);
        }
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
