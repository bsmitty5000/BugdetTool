using System;
using System.IO;
using System.Windows.Forms;
using BudgetToolLib;

namespace BudgetToolApp
{
  public partial class MainLaunch : Form
  {
    private string _selectedBudgetFilepath;
    private string _budgetDirectory;
    public MainLaunch()
    {
      InitializeComponent();

      this.FormClosing += MainLaunch_FormClosing;

      _selectedBudgetFilepath = (string)Properties.Settings.Default["BudgetFile"];
      _budgetDirectory = (string)Properties.Settings.Default["BudgetDir"];

      RefreshPage();
    }

    private void RefreshPage()
    {
      selectedBudgetLbl.Text = string.Format("Selected Budget: {0}", _selectedBudgetFilepath);
      Properties.Settings.Default["BudgetFile"] = _selectedBudgetFilepath;
      
      try
      {
        Properties.Settings.Default["BudgetDir"] = Path.GetDirectoryName(_selectedBudgetFilepath);
      }
      catch(ArgumentException e)
      {
        Properties.Settings.Default["BudgetDir"] = Path.GetTempPath();
      }
    }

    private void changeSelectedBtn_Click(object sender, EventArgs e)
    {
      var fileContent = string.Empty;
      var filePath = string.Empty;

      using (OpenFileDialog openFileDialog = new OpenFileDialog())
      {
        openFileDialog.InitialDirectory = _budgetDirectory;
        openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
        openFileDialog.FilterIndex = 2;
        openFileDialog.RestoreDirectory = true;

        if (openFileDialog.ShowDialog() == DialogResult.OK)
        {
          //Get the path of specified file
          _selectedBudgetFilepath = openFileDialog.FileName;
        }
      }

      RefreshPage();
    }

    private void MainLaunch_FormClosing(Object sender, FormClosingEventArgs e)
    {
      Properties.Settings.Default.Save();
    }

    private void editBudgetBtn_Click(object sender, EventArgs e)
    {
      var editBudgetTop = new EditBudgetTop(YearTop.LoadFromFile(_selectedBudgetFilepath));
      editBudgetTop.ShowDialog();
    }

    private void newBudgetBtn_Click(object sender, EventArgs e)
    {
      var editBudgetTop = new EditBudgetTop(null);
      editBudgetTop.ShowDialog();
    }
  }
}
