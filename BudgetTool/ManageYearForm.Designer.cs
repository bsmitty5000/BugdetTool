namespace BudgetTool
{
  partial class ManageYearForm
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
      this.button1 = new System.Windows.Forms.Button();
      this.annualSummaryLbl = new System.Windows.Forms.Label();
      this.listView1 = new System.Windows.Forms.ListView();
      this.monthlySoftBillsName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.monthlySoftBillsAmountRemaining = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.label3 = new System.Windows.Forms.Label();
      this.listView2 = new System.Windows.Forms.ListView();
      this.monthlyHardBillName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.monthlyHardBillAmount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.monthlyHardBillDay = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.monthlyHardBillPaid = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.label5 = new System.Windows.Forms.Label();
      this.monthTb = new System.Windows.Forms.TextBox();
      this.prevBtn = new System.Windows.Forms.Button();
      this.nextBtn = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // button1
      // 
      this.button1.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.button1.Location = new System.Drawing.Point(12, 12);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(185, 31);
      this.button1.TabIndex = 0;
      this.button1.Text = "Add New Purchase";
      this.button1.UseVisualStyleBackColor = true;
      // 
      // annualSummaryLbl
      // 
      this.annualSummaryLbl.AutoSize = true;
      this.annualSummaryLbl.Font = new System.Drawing.Font("Franklin Gothic Heavy", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.annualSummaryLbl.Location = new System.Drawing.Point(12, 61);
      this.annualSummaryLbl.Name = "annualSummaryLbl";
      this.annualSummaryLbl.Size = new System.Drawing.Size(61, 21);
      this.annualSummaryLbl.TabIndex = 2;
      this.annualSummaryLbl.Text = "Month:";
      // 
      // listView1
      // 
      this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.monthlySoftBillsName,
            this.monthlySoftBillsAmountRemaining});
      this.listView1.HideSelection = false;
      this.listView1.Location = new System.Drawing.Point(16, 260);
      this.listView1.Name = "listView1";
      this.listView1.Size = new System.Drawing.Size(348, 108);
      this.listView1.TabIndex = 33;
      this.listView1.UseCompatibleStateImageBehavior = false;
      this.listView1.View = System.Windows.Forms.View.Details;
      // 
      // monthlySoftBillsName
      // 
      this.monthlySoftBillsName.Text = "Name";
      this.monthlySoftBillsName.Width = 215;
      // 
      // monthlySoftBillsAmountRemaining
      // 
      this.monthlySoftBillsAmountRemaining.Text = "Amount Remaining";
      this.monthlySoftBillsAmountRemaining.Width = 116;
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Font = new System.Drawing.Font("Franklin Gothic Heavy", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label3.Location = new System.Drawing.Point(12, 236);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(143, 21);
      this.label3.TabIndex = 32;
      this.label3.Text = "Monthly Soft Bills";
      // 
      // listView2
      // 
      this.listView2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.monthlyHardBillName,
            this.monthlyHardBillAmount,
            this.monthlyHardBillDay,
            this.monthlyHardBillPaid});
      this.listView2.HideSelection = false;
      this.listView2.Location = new System.Drawing.Point(16, 116);
      this.listView2.Name = "listView2";
      this.listView2.Size = new System.Drawing.Size(348, 108);
      this.listView2.TabIndex = 31;
      this.listView2.UseCompatibleStateImageBehavior = false;
      this.listView2.View = System.Windows.Forms.View.Details;
      // 
      // monthlyHardBillName
      // 
      this.monthlyHardBillName.Text = "Name";
      this.monthlyHardBillName.Width = 108;
      // 
      // monthlyHardBillAmount
      // 
      this.monthlyHardBillAmount.Text = "Amount";
      this.monthlyHardBillAmount.Width = 116;
      // 
      // monthlyHardBillDay
      // 
      this.monthlyHardBillDay.Text = "Day Due";
      // 
      // monthlyHardBillPaid
      // 
      this.monthlyHardBillPaid.Text = "Paid";
      this.monthlyHardBillPaid.Width = 46;
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Font = new System.Drawing.Font("Franklin Gothic Heavy", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label5.Location = new System.Drawing.Point(12, 92);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(146, 21);
      this.label5.TabIndex = 30;
      this.label5.Text = "Monthly Hard Bills";
      // 
      // monthTb
      // 
      this.monthTb.Location = new System.Drawing.Point(79, 62);
      this.monthTb.Name = "monthTb";
      this.monthTb.Size = new System.Drawing.Size(150, 20);
      this.monthTb.TabIndex = 34;
      // 
      // prevBtn
      // 
      this.prevBtn.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.prevBtn.Location = new System.Drawing.Point(252, 62);
      this.prevBtn.Name = "prevBtn";
      this.prevBtn.Size = new System.Drawing.Size(53, 21);
      this.prevBtn.TabIndex = 35;
      this.prevBtn.Text = "Prev";
      this.prevBtn.UseVisualStyleBackColor = true;
      // 
      // nextBtn
      // 
      this.nextBtn.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.nextBtn.Location = new System.Drawing.Point(311, 61);
      this.nextBtn.Name = "nextBtn";
      this.nextBtn.Size = new System.Drawing.Size(53, 21);
      this.nextBtn.TabIndex = 36;
      this.nextBtn.Text = "Next";
      this.nextBtn.UseVisualStyleBackColor = true;
      // 
      // ManageYearForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(677, 557);
      this.Controls.Add(this.nextBtn);
      this.Controls.Add(this.prevBtn);
      this.Controls.Add(this.monthTb);
      this.Controls.Add(this.listView1);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.listView2);
      this.Controls.Add(this.label5);
      this.Controls.Add(this.annualSummaryLbl);
      this.Controls.Add(this.button1);
      this.Name = "ManageYearForm";
      this.Text = "ManageYearForm";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label annualSummaryLbl;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader monthlySoftBillsName;
        private System.Windows.Forms.ColumnHeader monthlySoftBillsAmountRemaining;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.ColumnHeader monthlyHardBillName;
        private System.Windows.Forms.ColumnHeader monthlyHardBillAmount;
        private System.Windows.Forms.ColumnHeader monthlyHardBillDay;
        private System.Windows.Forms.ColumnHeader monthlyHardBillPaid;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox monthTb;
        private System.Windows.Forms.Button prevBtn;
        private System.Windows.Forms.Button nextBtn;
    }
}