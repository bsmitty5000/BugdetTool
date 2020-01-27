using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BudgetToolLib;

namespace BudgetToolApp
{
  public partial class EditSbTransactionForm : Form
  {
    private SoftBillTransaction _sbt;
    private YearTop _year;
    private DateTime _selectedDate;
    private bool _eventsOn;
    public event EventHandler<NewSbTransactionEventArgs> NewTransactionAdded;

    public EditSbTransactionForm(YearTop year)
    {
      InitializeComponent();

      if (year == null)
      {
        throw new ArgumentException("Year must be initialized.");
      }

      _year = year;

      _sbt = _year.GetSoftBillTransaction(string.Empty, 0, DateTime.Today.Month);

      var accounts = _year.GetAccounts();
      foreach (var keyValue in accounts)
      {
        accountCb.Items.Add(keyValue.Name);
      }
      dateDtp.Value = DateTime.Today;

      UpdateEntireTpl();
    }

    private void remainder_Click(object sender, EventArgs e)
    {
      if(_eventsOn)
      {
        //trying to avoid events each time text is changed
        UpdateSbGroupAmounts();

        decimal currentTotal = 0;
        string tbpKey = ((Button)sender).Name.Split('_')[0] + "_tb";
        string sbKey = tbpKey.Split('_')[0];
        foreach (var sub in _sbt.SoftGroupSplit.Values)
        {
          currentTotal += sub;
        }

        decimal remainderTotal = _sbt.Amount - currentTotal;
        softBillSplitTpl.Controls[tbpKey].Text = remainderTotal.ToString();
        _sbt.SoftGroupSplit[sbKey] = remainderTotal;
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
      if(annualPurchaseCb.Checked)
      {
        _sbt.SoftGroupSplit = new Dictionary<string, decimal>();
        foreach (var key in _year.GetSoftBillKeys(0))
        {
          _sbt.SoftGroupSplit.Add(key, 0);
        }
      }
      else
      {
        _sbt.SoftGroupSplit = new Dictionary<string, decimal>();
        foreach (var key in _year.GetSoftBillKeys(_selectedDate.Month))
        {
          _sbt.SoftGroupSplit.Add(key, 0);
        }
      }
      UpdateEntireTpl();
    }

    private void dateDtp_ValueChanged(object sender, EventArgs e)
    {
      _selectedDate = dateDtp.Value;
      if(!annualPurchaseCb.Checked && (_selectedDate.Month != _sbt.Date.Month))
      {
        _sbt = _year.GetSoftBillTransaction(_sbt.Description, _sbt.Amount, _selectedDate.Month);
        UpdateEntireTpl();
      }
    }

    private void saveAndCloseBtn_Click(object sender, EventArgs e)
    {
      OnNewTransactionBillAdded();
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
      OnNewTransactionBillAdded();
      ResetPrivateSbt();
    }
    protected virtual void OnNewTransactionBillAdded()
    {
      SaveOffUIFields();
      NewSbTransactionEventArgs args = new NewSbTransactionEventArgs();
      args.AccountName = accountCb.Text;
      args.NewTransaction = _sbt;

      NewTransactionAdded?.Invoke(this, args);
    }

    #region helpers
    private void ResetPrivateSbt()
    {
      //not copying here to clear out the softbill groups
      //but keep the account and date the same, seems like it would be
      //convenient that way
      SoftBillTransaction temp;
      if (annualPurchaseCb.Checked)
      {
        temp = _year.GetSoftBillTransaction(string.Empty, 0, 0);
      }
      else
      {
        temp = _year.GetSoftBillTransaction(string.Empty, 0, _selectedDate.Month);
      }
      temp.Date = _selectedDate;
      _sbt = temp;
      UpdateTplText();
    }
    private void UpdateTplText()
    {
      _eventsOn = false;
      foreach (var kvp in _sbt.SoftGroupSplit)
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
      foreach (var kvp in _sbt.SoftGroupSplit)
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

    private void SaveOffUIFields()
    {
      _sbt.Description = descriptionTb.Text;
      _sbt.Date = dateDtp.Value;

      decimal amount;
      if (decimal.TryParse(amountTb.Text, out amount))
      {
        _sbt.Amount = amount;
      }
      else
      {
        amountTb.Text = _sbt.Amount.ToString();
        MessageBox.Show("Invalid amount!");
        return;
      }

      UpdateSbGroupAmounts();
    }
    private void UpdateSbGroupAmounts()
    {

      List<string> keyList = new List<string>(_sbt.SoftGroupSplit.Keys);

      foreach (var sb in keyList)
      {
        TextBox txtValue = softBillSplitTpl.Controls[sb + "_tb"] as TextBox;
        decimal amount;
        if (decimal.TryParse(txtValue.Text, out amount))
        {
          _sbt.SoftGroupSplit[sb] = amount;
        }
        else
        {
          txtValue.Text = _sbt.SoftGroupSplit[sb].ToString();
          MessageBox.Show("Invalid amount!");
          return;
        }
      }
    }

    #endregion

    private void amountTb_TextChanged(object sender, EventArgs e)
    {
      decimal amount;
      if (decimal.TryParse(amountTb.Text, out amount))
      {
        _sbt.Amount = amount;
      }
      else
      {
        amountTb.Text = _sbt.Amount.ToString();
        MessageBox.Show("Invalid amount!");
        return;
      }
    }
  }
  public class NewSbTransactionEventArgs : EventArgs
  {
    public string AccountName { get; set; }
    public SoftBillTransaction NewTransaction { get; set; }
  }
}
