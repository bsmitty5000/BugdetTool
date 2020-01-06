using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using BudgetToolLib;

namespace BudgetTool
{
  public partial class CreateYearForm : Form
  {
    private YearTop _year;
    private decimal annualGroupTotal = 0;
    private decimal monthlyGroupTotal = 0;
    private decimal annualOut = 0;
    private decimal annualIn = 0;
    private decimal annualDiff = 0;

    public CreateYearForm()
    {
      InitializeComponent();

      _year = new YearTop();

      /* Extra event handlers */
      monthlyGroupsLb.MouseDoubleClick += new MouseEventHandler(monthlyGroupsLb_DoubleClick);
      monthlyGroupsLb.MouseDown += new MouseEventHandler(monthlyGroupsLb_RightClick);

      annualGroupsLb.MouseDoubleClick += new MouseEventHandler(annualGroupsLb_DoubleClick);
      annualGroupsLb.MouseDown += new MouseEventHandler(annualGroupsLb_RightClick);

      incomeSourcesLb.MouseDoubleClick += new MouseEventHandler(incomeSourcesLb_DoubleClick);
      incomeSourcesLb.MouseDown += new MouseEventHandler(incomeSourcesLb_RightClick);

      this.FormClosing += CreateYearForm_FormClosing;
    }

    public YearTop Year
    {
      get
      {
        return _year;
      }

      set
      {
        _year = value;
        RefreshPage();
      }
    }
    private void CreateYearForm_FormClosing(Object sender, FormClosingEventArgs e)
    {

      string messageString = "Did you save your work? I'm not smart enough to detect yet.";
      DialogResult dialogResult = MessageBox.Show(messageString, "FormClosing Event", MessageBoxButtons.YesNo);

      e.Cancel = (dialogResult == DialogResult.No);
    }

    private void NewIncome_Added(object sender, NewIncomeAddedEventArgs e)
    {
      if(e.NewIncomeSrc != null)
      {
        Year.IncomeSources.Remove(e.NewIncomeSrc.Name);
        Year.IncomeSources.Add(e.NewIncomeSrc.Name, e.NewIncomeSrc);
      }
      RefreshPage();
    }

    private void NewGroup_Added(object sender, NewGroupAddedEventArgs e)
    {
      if(e.NewGroup != null)
      {
        Year.RemoveSpendingGroup(e.NewGroup);
        Year.AddSpendingGroup(e.NewGroup);
      }
      RefreshPage();
    }
    private void saveYearBtn_Click(object sender, EventArgs e)
    {
      Stream myStream;
      SaveFileDialog saveFileDialog1 = new SaveFileDialog();

      saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
      saveFileDialog1.FilterIndex = 2;
      saveFileDialog1.RestoreDirectory = true;

      if (saveFileDialog1.ShowDialog() == DialogResult.OK)
      {
        if ((myStream = saveFileDialog1.OpenFile()) != null)
        {
          Year.SaveToFile(myStream);
          myStream.Close();
        }
      }
    }

    private void monthlyGroupsLb_DoubleClick(object sender, MouseEventArgs e)
    {
      int index = monthlyGroupsLb.IndexFromPoint(e.Location);

      if (index > -1)
      {
        SpendingCategory groupSel = (SpendingCategory)monthlyGroupsLb.Items[index];

        var createNewGroup = new CreateNewSpendingGroup(groupSel);
        createNewGroup.NewGroupAdded += NewGroup_Added;
        createNewGroup.Show();
      }
      else
      {
        SpendingCategory groupSel = new SpendingCategory(string.Empty, 0, false);

        var createNewGroup = new CreateNewSpendingGroup(groupSel);
        createNewGroup.NewGroupAdded += NewGroup_Added;
        createNewGroup.Show();
      }
    }
    private void annualGroupsLb_DoubleClick(object sender, MouseEventArgs e)
    {
      int index = annualGroupsLb.IndexFromPoint(e.Location);

      if (index > -1)
      {
        SpendingCategory groupSel = (SpendingCategory)annualGroupsLb.Items[index];

        var createNewGroup = new CreateNewSpendingGroup(groupSel);
        createNewGroup.NewGroupAdded += NewGroup_Added;
        createNewGroup.Show();
      }
      else
      {
        SpendingCategory groupSel = new SpendingCategory(string.Empty, 0, true);

        var createNewGroup = new CreateNewSpendingGroup(groupSel);
        createNewGroup.NewGroupAdded += NewGroup_Added;
        createNewGroup.Show();
      }
    }
    private void incomeSourcesLb_DoubleClick(object sender, MouseEventArgs e)
    {
      int index = incomeSourcesLb.IndexFromPoint(e.Location);

      if (index > -1)
      {
        Income incomeSource = (Income)incomeSourcesLb.Items[index];

        var addNewIncome = new CreateIncomeSourceForm(incomeSource);
        addNewIncome.NewIncomeAdded += NewIncome_Added;
        addNewIncome.Show();
      }
      else
      {
        Income incomeSource = new Income(string.Empty, 0, IncomeFrequencyEnum.BiWeekly);

        var addNewIncome = new CreateIncomeSourceForm(incomeSource);
        addNewIncome.NewIncomeAdded += NewIncome_Added;
        addNewIncome.Show();
      }
    }
    private void monthlyGroupsLb_RightClick(object sender, MouseEventArgs e)
    {
      if (e.Button == MouseButtons.Right)
      {
        int index = monthlyGroupsLb.IndexFromPoint(e.Location);

        if (index > -1)
        {
          monthlyGroupsLb.SelectedIndex = index;
          monthlyGroupsCms.Show(this, new Point(e.X + ((Control)sender).Left + 20, e.Y + ((Control)sender).Top + 20));
        }
      }
    }
    private void annualGroupsLb_RightClick(object sender, MouseEventArgs e)
    {
      if (e.Button == MouseButtons.Right)
      {
        int index = annualGroupsLb.IndexFromPoint(e.Location);

        if (index > -1)
        {
          annualGroupsLb.SelectedIndex = index;
          annualGroupsCms.Show(this, new Point(e.X + ((Control)sender).Left + 20, e.Y + ((Control)sender).Top + 20));
        }
      }
    }
    private void incomeSourcesLb_RightClick(object sender, MouseEventArgs e)
    {
      if (e.Button == MouseButtons.Right)
      {
        int index = incomeSourcesLb.IndexFromPoint(e.Location);

        if (index > -1)
        {
          incomeSourcesLb.SelectedIndex = index;
          incomeSourceCms.Show(this, new Point(e.X + ((Control)sender).Left + 20, e.Y + ((Control)sender).Top + 20));
        }
      }
    }
    private void monthlyGroupCmsDelete_Click(object sender, EventArgs e)
    {
      SpendingCategory groupSel = (SpendingCategory)monthlyGroupsLb.SelectedItem;
      Year.RemoveSpendingGroup(groupSel);
      RefreshPage();
    }
    private void annualGroupCmsDelete_Click(object sender, EventArgs e)
    {
      SpendingCategory groupSel = (SpendingCategory)annualGroupsLb.SelectedItem;
      Year.RemoveSpendingGroup(groupSel);
      RefreshPage();
    }
    private void incomeSourcesCmsDelete_Click(object sender, EventArgs e)
    {
      Income incomeSel = (Income)incomeSourcesLb.SelectedItem;
      Year.IncomeSources.Remove(incomeSel.Name);
      RefreshPage();
    }


    #region Private Helpers

    private void RefreshPage()
    {
      monthlyGroupsLb.DataSource  = Year.BudgetGroups[0].MonthlyGroups.Values.ToList();
      annualGroupsLb.DataSource   = Year.AnnualGroups.Values.ToList();
      incomeSourcesLb.DataSource  = Year.IncomeSources.Values.ToList();

      CalculateAnnualTotal();
      CalculateMonthlyTotal();
      AnnualOutUpdate();
      AnnualInUpdate();
      AnnualDiffUpdate();

      if (annualOut > 0)
      {
        saveYearBtn.Enabled = true;
      }
    }

    private void CalculateAnnualTotal()
    {
      annualGroupTotal = 0;
      foreach (var group in Year.AnnualGroups)
      {
        annualGroupTotal += group.Value.Amount;
      }

      annualTotalLbl.Text = "Annual Group Total: $" + annualGroupTotal.ToString();
    }
    private void CalculateMonthlyTotal()
    {
      monthlyGroupTotal = 0;
      foreach (var group in Year.BudgetGroups[0].MonthlyGroups)
      {
        monthlyGroupTotal += group.Value.Amount;
      }

      monthlyTotalLbl.Text = "Monthly Group Total: $" + monthlyGroupTotal.ToString();
    }
    private void AnnualOutUpdate()
    {
      annualOut = 0;
      annualOut += annualGroupTotal;
      annualOut += monthlyGroupTotal * 12;

      annualOutLbl.Text = "Annual Out: $" + annualOut.ToString();
    }
    private void AnnualInUpdate()
    {
      annualIn = 0;
      foreach (var inSource in Year.IncomeSources)
      {
        annualIn += inSource.Value.AnnualAmount;
      }

      annualInLbl.Text = "Annual In: $" + annualIn.ToString();
    }
    private void AnnualDiffUpdate()
    {
      annualDiff = annualIn - annualOut;

      annualDiffLbl.Text = "Difference: $" + annualDiff.ToString();
    }
    #endregion

    private void CreateYearForm_Load(object sender, EventArgs e)
    {

    }
  }
}
