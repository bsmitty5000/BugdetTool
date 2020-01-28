using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using BudgetToolLib;

namespace BudgetToolApp
{
  public partial class EditSbTransactionForm : Form
  {
    private YearTop _year;
    private DateTime _dateSelected;
    private int _monthSelected;
    private bool _annualSelected;
    private decimal _totalAmount;
    private bool _eventsOn;
    private Dictionary<string, decimal> _split;
    public event EventHandler<NewSbTransactionEventArgs> NewTransactionAdded;

    public EditSbTransactionForm(YearTop year, DateTime currentDate)
    {
      InitializeComponent();

      if (year == null)
      {
        throw new ArgumentException("Year must be initialized.");
      }

      _year = year;

      var accounts = _year.GetAccounts();
      foreach (var keyValue in accounts)
      {
        accountCb.Items.Add(keyValue.Name);
      }
      _dateSelected = currentDate;
      _monthSelected = _dateSelected.Month;
      dateDtp.Value = _dateSelected;

      UpdateEntireTpl();
    }

    private bool grabTotalAmount()
    {
      if (!decimal.TryParse(amountTb.Text, out _totalAmount))
      {
        amountTb.Text = 0.ToString();
        MessageBox.Show("Invalid total amount!");
        return false;
      }

      return true;
    }

    private void remainder_Click(object sender, EventArgs e)
    {
      if (grabTotalAmount() && _eventsOn)
      {
        //trying to avoid events each time text is changed
        UpdateSbGroupAmounts();

        decimal currentTotal = 0;
        string tbpKey = ((Button)sender).Name.Split('_')[0] + "_tb";
        string sbKey = tbpKey.Split('_')[0];
        foreach (var sub in _split.Values)
        {
          currentTotal += sub;
        }

        decimal remainderTotal = _totalAmount - currentTotal;

        //+= here means if you hit remainder when the total is already matching
        //nothing happens
        _split[sbKey] += remainderTotal;
        softBillSplitTpl.Controls[tbpKey].Text = _split[sbKey].ToString();
      }
    }


    //private void SoftGroupSplit_TextChanged(object sender, EventArgs e)
    //{
    //  if (_eventsOn)
    //  {
    //    TextBox textBox = (TextBox)sender;
    //    string sbKey = textBox.Name.Split('_')[0];

    //    if (_sbt.SoftGroupSplit.ContainsKey(sbKey))
    //    {
    //      _sbt.SoftGroupSplit[sbKey] = Decimal.Parse(textBox.Text);
    //    }
    //  }
    //}

    private void annualPurchaseCb_CheckedChanged(object sender, EventArgs e)
    {
      _annualSelected = annualPurchaseCb.Checked;

      if (_annualSelected)
      {
        _monthSelected = 0;
      }
      else
      {
        _monthSelected = _dateSelected.Month;
      }
      UpdateEntireTpl();
    }

    private void dateDtp_ValueChanged(object sender, EventArgs e)
    {
      _dateSelected = dateDtp.Value.Date;
      if ((!_annualSelected) && (_monthSelected != _dateSelected.Month))
      {
        _monthSelected = _dateSelected.Month;
        UpdateEntireTpl();
      }
    }

    private void saveAndCloseBtn_Click(object sender, EventArgs e)
    {
      if(!OnNewTransactionBillAdded())
      {
        return;
      }
      this.Close();
    }

    private void cancelAndCloseBtn_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void resetBtn_Click(object sender, EventArgs e)
    {
      ResetPrivateSbt();
    }

    private void logAndNewBtn_Click(object sender, EventArgs e)
    {
      if (!OnNewTransactionBillAdded())
      {
        return;
      }
      ResetPrivateSbt();
    }
    private bool OnNewTransactionBillAdded()
    {
      string description = descriptionTb.Text;
      DateTime date = dateDtp.Value.Date;

      if (!grabTotalAmount())
      {
        return false;
      }

      UpdateSbGroupAmounts();

      decimal splitTotal = 0;
      foreach (var item in _split)
      {
        splitTotal += item.Value;
      }
      if (splitTotal != _totalAmount)
      {
        MessageBox.Show("Split total doesn't match total amount!");
        return false;
      }

      NewSbTransactionEventArgs args = new NewSbTransactionEventArgs();
      args.AccountName = accountCb.Text;
      args.NewTransaction = new SoftBillTransaction(description, _totalAmount, date, _split);

      NewTransactionAdded?.Invoke(this, args);

      return true;
    }

    private void ResetPrivateSbt()
    {
      _split = _split.ToDictionary(p => p.Key, p => (decimal)0);
      UpdateTplText();
    }
    private void UpdateTplText()
    {
      _eventsOn = false;
      foreach (var kvp in _split)
      {
        TextBox txtValue = softBillSplitTpl.Controls[kvp.Key + "_tb"] as TextBox;
        txtValue.Text = kvp.Value.ToString();
      }
      _eventsOn = true;
    }

    private void UpdateEntireTpl()
    {
      int i = 0;
      _eventsOn = false;
      softBillSplitTpl.RowStyles.Clear();
      softBillSplitTpl.Controls.Clear();

      //anytime we get here it means the table has changed
      //or it's the first time
      var softBillNames = _year.GetSoftBillKeys(_monthSelected);
      _split = new Dictionary<string, decimal>();
      foreach (var sb in softBillNames)
      {
        _split.Add(sb, 0);
      }

      foreach (var kvp in _split)
      {
        softBillSplitTpl.RowStyles.Add(new RowStyle(SizeType.Absolute, 28));

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
        //txtValue.TextChanged += new EventHandler(SoftGroupSplit_TextChanged);
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

    private void UpdateSbGroupAmounts()
    {

      List<string> keyList = new List<string>(_split.Keys);

      foreach (var sb in keyList)
      {
        TextBox txtValue = softBillSplitTpl.Controls[sb + "_tb"] as TextBox;
        decimal amount;
        if (decimal.TryParse(txtValue.Text, out amount))
        {
          _split[sb] = amount;
        }
        else
        {
          txtValue.Text = _split[sb].ToString();
          MessageBox.Show(string.Format("Invalid amount in {0}!", sb));
          return;
        }
      }
    }
  }

  public class NewSbTransactionEventArgs : EventArgs
  {
    public string AccountName { get; set; }
    public SoftBillTransaction NewTransaction { get; set; }
  }
}
