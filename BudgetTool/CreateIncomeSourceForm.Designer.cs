namespace BudgetTool
{
  partial class CreateIncomeSourceForm
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.addIncomeSrcBtn = new System.Windows.Forms.Button();
      this.unitAmtTb = new System.Windows.Forms.TextBox();
      this.unitAmtLbl = new System.Windows.Forms.Label();
      this.incomeNameTb = new System.Windows.Forms.TextBox();
      this.nameLbl = new System.Windows.Forms.Label();
      this.incomeFreqLbl = new System.Windows.Forms.Label();
      this.incomeFreqCb = new System.Windows.Forms.ComboBox();
      this.cancelBtn = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // addIncomeSrcBtn
      // 
      this.addIncomeSrcBtn.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.addIncomeSrcBtn.Location = new System.Drawing.Point(15, 207);
      this.addIncomeSrcBtn.Name = "addIncomeSrcBtn";
      this.addIncomeSrcBtn.Size = new System.Drawing.Size(125, 23);
      this.addIncomeSrcBtn.TabIndex = 11;
      this.addIncomeSrcBtn.Text = "Add Income Source";
      this.addIncomeSrcBtn.UseVisualStyleBackColor = true;
      this.addIncomeSrcBtn.Click += new System.EventHandler(this.addIncomeSrcBtn_Click);
      // 
      // unitAmtTb
      // 
      this.unitAmtTb.Location = new System.Drawing.Point(102, 56);
      this.unitAmtTb.Name = "unitAmtTb";
      this.unitAmtTb.Size = new System.Drawing.Size(170, 20);
      this.unitAmtTb.TabIndex = 9;
      // 
      // unitAmtLbl
      // 
      this.unitAmtLbl.AutoSize = true;
      this.unitAmtLbl.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.unitAmtLbl.Location = new System.Drawing.Point(12, 59);
      this.unitAmtLbl.Name = "unitAmtLbl";
      this.unitAmtLbl.Size = new System.Drawing.Size(67, 17);
      this.unitAmtLbl.TabIndex = 8;
      this.unitAmtLbl.Text = "Unit Amount";
      // 
      // incomeNameTb
      // 
      this.incomeNameTb.Location = new System.Drawing.Point(102, 23);
      this.incomeNameTb.Name = "incomeNameTb";
      this.incomeNameTb.Size = new System.Drawing.Size(170, 20);
      this.incomeNameTb.TabIndex = 7;
      // 
      // nameLbl
      // 
      this.nameLbl.AutoSize = true;
      this.nameLbl.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.nameLbl.Location = new System.Drawing.Point(12, 23);
      this.nameLbl.Name = "nameLbl";
      this.nameLbl.Size = new System.Drawing.Size(73, 17);
      this.nameLbl.TabIndex = 6;
      this.nameLbl.Text = "Income Name";
      // 
      // incomeFreqLbl
      // 
      this.incomeFreqLbl.AutoSize = true;
      this.incomeFreqLbl.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.incomeFreqLbl.Location = new System.Drawing.Point(12, 93);
      this.incomeFreqLbl.Name = "incomeFreqLbl";
      this.incomeFreqLbl.Size = new System.Drawing.Size(58, 17);
      this.incomeFreqLbl.TabIndex = 13;
      this.incomeFreqLbl.Text = "Frequency";
      // 
      // incomeFreqCb
      // 
      this.incomeFreqCb.FormattingEnabled = true;
      this.incomeFreqCb.Location = new System.Drawing.Point(102, 93);
      this.incomeFreqCb.Name = "incomeFreqCb";
      this.incomeFreqCb.Size = new System.Drawing.Size(170, 21);
      this.incomeFreqCb.TabIndex = 14;
      // 
      // cancelBtn
      // 
      this.cancelBtn.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.cancelBtn.Location = new System.Drawing.Point(147, 207);
      this.cancelBtn.Name = "cancelBtn";
      this.cancelBtn.Size = new System.Drawing.Size(125, 23);
      this.cancelBtn.TabIndex = 15;
      this.cancelBtn.Text = "Cancel";
      this.cancelBtn.UseVisualStyleBackColor = true;
      this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
      // 
      // CreateIncomeSourceForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(292, 242);
      this.Controls.Add(this.cancelBtn);
      this.Controls.Add(this.incomeFreqCb);
      this.Controls.Add(this.incomeFreqLbl);
      this.Controls.Add(this.addIncomeSrcBtn);
      this.Controls.Add(this.unitAmtTb);
      this.Controls.Add(this.unitAmtLbl);
      this.Controls.Add(this.incomeNameTb);
      this.Controls.Add(this.nameLbl);
      this.Name = "CreateIncomeSourceForm";
      this.Text = "Create Income Source";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

        #endregion

        private System.Windows.Forms.Button addIncomeSrcBtn;
        private System.Windows.Forms.TextBox unitAmtTb;
        private System.Windows.Forms.Label unitAmtLbl;
        private System.Windows.Forms.TextBox incomeNameTb;
        private System.Windows.Forms.Label nameLbl;
        private System.Windows.Forms.Label incomeFreqLbl;
        private System.Windows.Forms.ComboBox incomeFreqCb;
        private System.Windows.Forms.Button cancelBtn;
    }
}