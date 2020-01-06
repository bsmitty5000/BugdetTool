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

namespace BudgetTool
{
  public partial class ManageYearForm : Form
  {
    private YearTop year;
    public ManageYearForm(YearTop year)
    {
      InitializeComponent();

      this.year = year;
    }
  }
}
