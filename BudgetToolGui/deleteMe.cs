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
  public partial class deleteMe : Form
  {
    private Transaction _transaction;
    private SoftBillTransaction _sbt;
    private AccountBase _accountBase;
    private YearTop _year;
    public event EventHandler<deleteMeArgs> NewTransactionAdded;
    private bool _eventsOn;

    public deleteMe(SoftBillTransaction transaction, AccountBase account, YearTop year, int month)
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

      if (transaction != null)
      {
        throw new ArgumentException("Transaction cannot be null");
      }
      else
      {
        _sbt = transaction;
        if(month == 0)
        {
          _sbt.Date = new DateTime(DateTime.Today.Year, 1, 1);
          dateDtp.MinDate = _sbt.Date;
          dateDtp.MaxDate = new DateTime(_sbt.Date.Year, 12, 31);
        }
        else
        {
          _sbt.Date = new DateTime(DateTime.Today.Year, month, 1);
          dateDtp.MinDate = _sbt.Date;
          dateDtp.MaxDate = new DateTime(_transaction.Date.Year, _sbt.Date.Month, DateTime.DaysInMonth(_sbt.Date.Year, _sbt.Date.Month));
        }
      }

      vendorTb.Text = _sbt.Description;
      amountTb.Text = _sbt.Amount.ToString();
      dateDtp.Value = _sbt.Date;

      foreach (var a in _year.Accounts)
      {
        accountCb.Items.Add(a.Value.Name);
      }

      if (_sbt.SoftGroupSplit.Count == 0)
      {
        foreach (var sb in _year.MonthlySoftBills[month].SoftBills)
        {
          (_sbt.SoftGroupSplit.Add(sb.Value.Name, 0);
        }
      }

      int i = 0;
      _eventsOn = false;
      foreach (var kvp in _sbt.SoftGroupSplit)
      {
        SoftGroupSplitTpl.RowStyles.Add(new RowStyle(SizeType.AutoSize));

        Label lblTitle = new Label();
        lblTitle.Text = string.Format("{0}:", kvp.Key);
        lblTitle.TabIndex = (i * 2);
        lblTitle.Margin = new Padding(0);
        lblTitle.Dock = DockStyle.Fill;
        SoftGroupSplitTpl.Controls.Add(lblTitle, 0, i);

        TextBox txtValue = new TextBox();
        txtValue.TabIndex = (i * 2) + 1;
        txtValue.Margin = new Padding(0);
        txtValue.Dock = DockStyle.Fill;
        txtValue.TextChanged += new EventHandler(SoftGroupSplit_TextChanged);
        txtValue.Name = kvp.Key + "_tb";
        txtValue.Text = kvp.Value.ToString();
        SoftGroupSplitTpl.Controls.Add(txtValue, 1, i);

        Button remainder = new Button();
        remainder.Text = "Use Remainder";
        remainder.TabIndex = (i * 2) + 2;
        remainder.Margin = new Padding(0);
        remainder.Dock = DockStyle.Fill;
        remainder.Click += new EventHandler(remainder_Click);
        remainder.Name = kvp.Key + "_btn";
        remainder.AutoSize = true;
        SoftGroupSplitTpl.Controls.Add(remainder, 2, i);

        i++;
      }
      _eventsOn = true;

    }

    private void SoftGroupSplit_TextChanged(object sender, EventArgs e)
    {
      if (!_eventsOn)
        return;

      TextBox textBox = (TextBox)sender;
      string sbKey = textBox.Name.Split('_')[0];

      if(_transaction.SoftGroupSplit.ContainsKey(sbKey))
      {
        _transaction.SoftGroupSplit[sbKey] = Decimal.Parse(textBox.Text);
      }

    }
    private void remainder_Click(object sender, EventArgs e)
    {
      decimal currentTotal = 0;
      string tbpKey = ((Button)sender).Name.Split('_')[0] + "_tb";
      string sbKey = tbpKey.Split('_')[0];
      foreach (var sub in _transaction.SoftGroupSplit.Values)
      {
        currentTotal += sub;
      }

      decimal remainderTotal = _transaction.Amount - currentTotal;
      SoftGroupSplitTpl.Controls[tbpKey].Text = remainderTotal.ToString();
      _transaction.SoftGroupSplit[sbKey] = remainderTotal;
    }

    private void vendorTb_TextChanged(object sender, EventArgs e)
    {
      _transaction.Description = vendorTb.Text;
    }

    private void amountTb_TextChanged(object sender, EventArgs e)
    {
      if (amountTb.Text.Equals(string.Empty))
      {
        _transaction.Amount = 0;
      }
      else
      {
        _transaction.Amount = Decimal.Parse(amountTb.Text);
      }
    }

    private void accountCb_SelectedIndexChanged(object sender, EventArgs e)
    {
      _transaction.PaymentAccount = _year.Accounts[accountCb.Text];
    }

    private void dateDtp_ValueChanged(object sender, EventArgs e)
    {
      _transaction.Date = dateDtp.Value;
    }

    private void saveBtn_Click(object sender, EventArgs e)
    {
      decimal currentTotal = 0;
      foreach (var sub in _transaction.SoftGroupSplit.Values)
      {
        currentTotal += sub;
      }
      if(currentTotal != _transaction.Amount)
      {
        MessageBox.Show("The split doesn't match the total!");
        return;
      }
      deleteMeArgs args = new deleteMeArgs();
      foreach (var item in _transaction.SoftGroupSplit.Where(kvp => kvp.Value == 0).ToList())
      {
        _transaction.SoftGroupSplit.Remove(item.Key);
      }
      args.Newtransaction = _transaction;
      OnNewtransactionBillAdded(args);

      this.Close();
    }
    protected virtual void OnNewtransactionBillAdded(deleteMeArgs e)
    {
      NewTransactionAdded?.Invoke(this, e);
    }

    private void cancelBtn_Click(object sender, EventArgs e)
    {
      this.Close();
    }
  }
  public class deleteMeArgs : EventArgs
  {
    public Transaction NewTransaction { get; set; }
  }
}
