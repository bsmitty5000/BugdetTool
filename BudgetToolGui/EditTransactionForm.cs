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
  public partial class EditTransactionForm : Form
  {
    //these will point to the same memory. the _sbt is for convenience
    private Transaction _transaction;
    private SoftBillTransaction _sbt;
    private AccountBase _accountBase;
    private YearTop _year;
    public event EventHandler<NewTransactionEventArgs> NewTransactionAdded;
    private bool _eventsOn;

    public EditTransactionForm(Transaction transaction, AccountBase account, YearTop year, int month)
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

      accountLbl.Text = account.Name;


      dateDtp.Value = transaction.Date;
      //dateDtp.MaxDate 

      _transaction = transaction;

      if (transaction.GetType().Name.Contains("SoftBill"))
      {
        sbtInit((SoftBillTransaction)transaction, month);
      }
      else
      {
        _sbt = null;
        softBillSplitTpl.Visible = false;
      }
    }

    #region sbt only events
    private void SoftGroupSplit_TextChanged(object sender, EventArgs e)
    {
      if (!_eventsOn)
        return;

      TextBox textBox = (TextBox)sender;
      string sbKey = textBox.Name.Split('_')[0];

      if (_sbt.SoftGroupSplit.ContainsKey(sbKey))
      {
        _sbt.SoftGroupSplit[sbKey] = Decimal.Parse(textBox.Text);
      }

    }

    private void remainder_Click(object sender, EventArgs e)
    {
      decimal currentTotal = 0;
      string tbpKey = ((Button)sender).Name.Split('_')[0] + "_tb";
      string sbKey = tbpKey.Split('_')[0];
      foreach (var sub in _sbt.SoftGroupSplit.Values)
      {
        currentTotal += sub;
      }

      decimal remainderTotal = _transaction.Amount - currentTotal;
      softBillSplitTpl.Controls[tbpKey].Text = remainderTotal.ToString();
      _sbt.SoftGroupSplit[sbKey] = remainderTotal;
    }

    #endregion

    #region transaction events
    private void descriptionTb_TextChanged(object sender, EventArgs e)
    {
      _transaction.Description = descriptionTb.Text;
    }

    private void amountTb_TextChanged(object sender, EventArgs e)
    {
      decimal localAmt = 0;
      if(decimal.TryParse(amountTb.Text, out localAmt))
      {
        _transaction.Amount = localAmt;
      }
    }

    private void dateDtp_ValueChanged(object sender, EventArgs e)
    {
      _transaction.Date = dateDtp.Value;
    }
    private void saveBtn_Click(object sender, EventArgs e)
    {
      decimal currentTotal = 0;
      NewTransactionEventArgs args = new NewTransactionEventArgs();
      if (_sbt != null)
      {
        foreach (var sub in _sbt.SoftGroupSplit.Values)
        {
          currentTotal += sub;
        }
        if (currentTotal != _transaction.Amount)
        {
          MessageBox.Show("The split doesn't match the total!");
          return;
        }
        foreach (var item in _sbt.SoftGroupSplit.Where(kvp => kvp.Value == 0).ToList())
        {
          _sbt.SoftGroupSplit.Remove(item.Key);
        }
      }

      args.NewTransaction = _transaction;
      OnNewTransactionBillAdded(args);

      this.Close();
    }


    private void cancelBtn_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    protected virtual void OnNewTransactionBillAdded(NewTransactionEventArgs e)
    {
      NewTransactionAdded?.Invoke(this, e);
    }

    #endregion

    private void sbtInit(SoftBillTransaction sbt, int month)
    {
      if (month == 0)
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

      descriptionTb.Text = _sbt.Description;
      amountTb.Text = _sbt.Amount.ToString();
      dateDtp.Value = _sbt.Date;


      int i = 0;
      _eventsOn = false;
      foreach (var kvp in _sbt.SoftGroupSplit)
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
        txtValue.TextChanged += new EventHandler(SoftGroupSplit_TextChanged);
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

  }
  public class NewTransactionEventArgs : EventArgs
  {
    public Transaction NewTransaction { get; set; }
  }
}
