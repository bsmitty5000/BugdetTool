namespace BudgetTool
{
  partial class CreateYearForm
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
      this.components = new System.ComponentModel.Container();
      this.annualSummaryLbl = new System.Windows.Forms.Label();
      this.saveYearBtn = new System.Windows.Forms.Button();
      this.label1 = new System.Windows.Forms.Label();
      this.monthlyGroupsCms = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
      this.annualGroupsCms = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
      this.incomeSourceCms = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.incomeSourcesCmsDelete = new System.Windows.Forms.ToolStripMenuItem();
      this.dividerLbl1 = new System.Windows.Forms.Label();
      this.annualHardBillsLv = new System.Windows.Forms.ListView();
      this.annualHardBillName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.annualHardBillAmount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.annualHardBillAccount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.label2 = new System.Windows.Forms.Label();
      this.annualSoftBillsLv = new System.Windows.Forms.ListView();
      this.annualSoftBillName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.annualSoftBillAmount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.listView1 = new System.Windows.Forms.ListView();
      this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.label3 = new System.Windows.Forms.Label();
      this.listView2 = new System.Windows.Forms.ListView();
      this.monthlyHardBillName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.monthlyHardBillAmount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.monthlyHardBillDay = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.monthlyHardBillAccountName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.label5 = new System.Windows.Forms.Label();
      this.listView3 = new System.Windows.Forms.ListView();
      this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.label6 = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      this.label7 = new System.Windows.Forms.Label();
      this.label8 = new System.Windows.Forms.Label();
      this.annualIncomeLbl = new System.Windows.Forms.TextBox();
      this.annualSpendingLbl = new System.Windows.Forms.TextBox();
      this.label9 = new System.Windows.Forms.Label();
      this.annualDifferenceLbl = new System.Windows.Forms.TextBox();
      this.label10 = new System.Windows.Forms.Label();
      this.monthlyDifferenceLbl = new System.Windows.Forms.TextBox();
      this.label11 = new System.Windows.Forms.Label();
      this.monthlySpendingLbl = new System.Windows.Forms.TextBox();
      this.label12 = new System.Windows.Forms.Label();
      this.monthlyIncomeLbl = new System.Windows.Forms.TextBox();
      this.label13 = new System.Windows.Forms.Label();
      this.monthlyGroupsCms.SuspendLayout();
      this.annualGroupsCms.SuspendLayout();
      this.incomeSourceCms.SuspendLayout();
      this.SuspendLayout();
      // 
      // annualSummaryLbl
      // 
      this.annualSummaryLbl.AutoSize = true;
      this.annualSummaryLbl.Font = new System.Drawing.Font("Franklin Gothic Heavy", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.annualSummaryLbl.Location = new System.Drawing.Point(8, 26);
      this.annualSummaryLbl.Name = "annualSummaryLbl";
      this.annualSummaryLbl.Size = new System.Drawing.Size(137, 21);
      this.annualSummaryLbl.TabIndex = 1;
      this.annualSummaryLbl.Text = "Annual Hard Bills";
      // 
      // saveYearBtn
      // 
      this.saveYearBtn.Enabled = false;
      this.saveYearBtn.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.saveYearBtn.Location = new System.Drawing.Point(126, 916);
      this.saveYearBtn.Name = "saveYearBtn";
      this.saveYearBtn.Size = new System.Drawing.Size(200, 36);
      this.saveYearBtn.TabIndex = 6;
      this.saveYearBtn.Text = "Save Year";
      this.saveYearBtn.UseVisualStyleBackColor = true;
      this.saveYearBtn.Click += new System.EventHandler(this.saveYearBtn_Click);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Font = new System.Drawing.Font("Franklin Gothic Heavy", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label1.Location = new System.Drawing.Point(8, 638);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(129, 21);
      this.label1.TabIndex = 15;
      this.label1.Text = "Income Sources";
      // 
      // monthlyGroupsCms
      // 
      this.monthlyGroupsCms.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
      this.monthlyGroupsCms.Name = "monthlyGroupsCms";
      this.monthlyGroupsCms.Size = new System.Drawing.Size(108, 26);
      // 
      // toolStripMenuItem1
      // 
      this.toolStripMenuItem1.Name = "toolStripMenuItem1";
      this.toolStripMenuItem1.Size = new System.Drawing.Size(107, 22);
      this.toolStripMenuItem1.Text = "Delete";
      this.toolStripMenuItem1.Click += new System.EventHandler(this.monthlyGroupCmsDelete_Click);
      // 
      // annualGroupsCms
      // 
      this.annualGroupsCms.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2});
      this.annualGroupsCms.Name = "annualGroupsCms";
      this.annualGroupsCms.Size = new System.Drawing.Size(108, 26);
      // 
      // toolStripMenuItem2
      // 
      this.toolStripMenuItem2.Name = "toolStripMenuItem2";
      this.toolStripMenuItem2.Size = new System.Drawing.Size(107, 22);
      this.toolStripMenuItem2.Text = "Delete";
      this.toolStripMenuItem2.Click += new System.EventHandler(this.annualGroupCmsDelete_Click);
      // 
      // incomeSourceCms
      // 
      this.incomeSourceCms.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.incomeSourcesCmsDelete});
      this.incomeSourceCms.Name = "incomeSourceCms";
      this.incomeSourceCms.Size = new System.Drawing.Size(108, 26);
      // 
      // incomeSourcesCmsDelete
      // 
      this.incomeSourcesCmsDelete.Name = "incomeSourcesCmsDelete";
      this.incomeSourcesCmsDelete.Size = new System.Drawing.Size(107, 22);
      this.incomeSourcesCmsDelete.Text = "Delete";
      this.incomeSourcesCmsDelete.Click += new System.EventHandler(this.incomeSourcesCmsDelete_Click);
      // 
      // dividerLbl1
      // 
      this.dividerLbl1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      this.dividerLbl1.Location = new System.Drawing.Point(12, 318);
      this.dividerLbl1.Name = "dividerLbl1";
      this.dividerLbl1.Size = new System.Drawing.Size(449, 2);
      this.dividerLbl1.TabIndex = 17;
      // 
      // annualHardBillsLv
      // 
      this.annualHardBillsLv.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.annualHardBillName,
            this.annualHardBillAmount,
            this.annualHardBillAccount});
      this.annualHardBillsLv.HideSelection = false;
      this.annualHardBillsLv.Location = new System.Drawing.Point(12, 50);
      this.annualHardBillsLv.Name = "annualHardBillsLv";
      this.annualHardBillsLv.Size = new System.Drawing.Size(449, 108);
      this.annualHardBillsLv.TabIndex = 22;
      this.annualHardBillsLv.UseCompatibleStateImageBehavior = false;
      this.annualHardBillsLv.View = System.Windows.Forms.View.Details;
      // 
      // annualHardBillName
      // 
      this.annualHardBillName.Text = "Name";
      this.annualHardBillName.Width = 180;
      // 
      // annualHardBillAmount
      // 
      this.annualHardBillAmount.Text = "Amount";
      this.annualHardBillAmount.Width = 116;
      // 
      // annualHardBillAccount
      // 
      this.annualHardBillAccount.Text = "Account Name";
      this.annualHardBillAccount.Width = 133;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Font = new System.Drawing.Font("Franklin Gothic Heavy", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label2.Location = new System.Drawing.Point(8, 170);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(134, 21);
      this.label2.TabIndex = 23;
      this.label2.Text = "Annual Soft Bills";
      // 
      // annualSoftBillsLv
      // 
      this.annualSoftBillsLv.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.annualSoftBillName,
            this.annualSoftBillAmount});
      this.annualSoftBillsLv.HideSelection = false;
      this.annualSoftBillsLv.Location = new System.Drawing.Point(12, 194);
      this.annualSoftBillsLv.Name = "annualSoftBillsLv";
      this.annualSoftBillsLv.Size = new System.Drawing.Size(449, 108);
      this.annualSoftBillsLv.TabIndex = 24;
      this.annualSoftBillsLv.UseCompatibleStateImageBehavior = false;
      this.annualSoftBillsLv.View = System.Windows.Forms.View.Details;
      // 
      // annualSoftBillName
      // 
      this.annualSoftBillName.Text = "Name";
      this.annualSoftBillName.Width = 312;
      // 
      // annualSoftBillAmount
      // 
      this.annualSoftBillAmount.Text = "Amount";
      this.annualSoftBillAmount.Width = 116;
      // 
      // listView1
      // 
      this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader4});
      this.listView1.HideSelection = false;
      this.listView1.Location = new System.Drawing.Point(12, 499);
      this.listView1.Name = "listView1";
      this.listView1.Size = new System.Drawing.Size(449, 108);
      this.listView1.TabIndex = 29;
      this.listView1.UseCompatibleStateImageBehavior = false;
      this.listView1.View = System.Windows.Forms.View.Details;
      // 
      // columnHeader3
      // 
      this.columnHeader3.Text = "Name";
      this.columnHeader3.Width = 308;
      // 
      // columnHeader4
      // 
      this.columnHeader4.Text = "Amount";
      this.columnHeader4.Width = 116;
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Font = new System.Drawing.Font("Franklin Gothic Heavy", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label3.Location = new System.Drawing.Point(8, 475);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(143, 21);
      this.label3.TabIndex = 28;
      this.label3.Text = "Monthly Soft Bills";
      // 
      // listView2
      // 
      this.listView2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.monthlyHardBillName,
            this.monthlyHardBillAmount,
            this.monthlyHardBillDay,
            this.monthlyHardBillAccountName});
      this.listView2.HideSelection = false;
      this.listView2.Location = new System.Drawing.Point(12, 355);
      this.listView2.Name = "listView2";
      this.listView2.Size = new System.Drawing.Size(449, 108);
      this.listView2.TabIndex = 27;
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
      // monthlyHardBillAccountName
      // 
      this.monthlyHardBillAccountName.Text = "Account Name";
      this.monthlyHardBillAccountName.Width = 144;
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Font = new System.Drawing.Font("Franklin Gothic Heavy", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label5.Location = new System.Drawing.Point(8, 331);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(146, 21);
      this.label5.TabIndex = 25;
      this.label5.Text = "Monthly Hard Bills";
      // 
      // listView3
      // 
      this.listView3.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
      this.listView3.HideSelection = false;
      this.listView3.Location = new System.Drawing.Point(12, 662);
      this.listView3.Name = "listView3";
      this.listView3.Size = new System.Drawing.Size(439, 108);
      this.listView3.TabIndex = 30;
      this.listView3.UseCompatibleStateImageBehavior = false;
      this.listView3.View = System.Windows.Forms.View.Details;
      // 
      // columnHeader1
      // 
      this.columnHeader1.Text = "Name";
      this.columnHeader1.Width = 308;
      // 
      // columnHeader2
      // 
      this.columnHeader2.Text = "Amount";
      this.columnHeader2.Width = 116;
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Font = new System.Drawing.Font("Franklin Gothic Heavy", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label6.Location = new System.Drawing.Point(12, 800);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(80, 21);
      this.label6.TabIndex = 31;
      this.label6.Text = "Summary";
      // 
      // label4
      // 
      this.label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      this.label4.Location = new System.Drawing.Point(12, 624);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(449, 2);
      this.label4.TabIndex = 32;
      // 
      // label7
      // 
      this.label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      this.label7.Location = new System.Drawing.Point(12, 788);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(449, 2);
      this.label7.TabIndex = 33;
      // 
      // label8
      // 
      this.label8.AutoSize = true;
      this.label8.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label8.Location = new System.Drawing.Point(9, 825);
      this.label8.Name = "label8";
      this.label8.Size = new System.Drawing.Size(104, 17);
      this.label8.TabIndex = 34;
      this.label8.Text = "Annual Income Total";
      // 
      // annualIncomeLbl
      // 
      this.annualIncomeLbl.Location = new System.Drawing.Point(126, 822);
      this.annualIncomeLbl.Name = "annualIncomeLbl";
      this.annualIncomeLbl.Size = new System.Drawing.Size(100, 20);
      this.annualIncomeLbl.TabIndex = 35;
      // 
      // annualSpendingLbl
      // 
      this.annualSpendingLbl.Location = new System.Drawing.Point(126, 839);
      this.annualSpendingLbl.Name = "annualSpendingLbl";
      this.annualSpendingLbl.Size = new System.Drawing.Size(100, 20);
      this.annualSpendingLbl.TabIndex = 37;
      // 
      // label9
      // 
      this.label9.AutoSize = true;
      this.label9.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label9.Location = new System.Drawing.Point(9, 842);
      this.label9.Name = "label9";
      this.label9.Size = new System.Drawing.Size(115, 17);
      this.label9.TabIndex = 36;
      this.label9.Text = "Annual Spending Total";
      // 
      // annualDifferenceLbl
      // 
      this.annualDifferenceLbl.Location = new System.Drawing.Point(126, 874);
      this.annualDifferenceLbl.Name = "annualDifferenceLbl";
      this.annualDifferenceLbl.Size = new System.Drawing.Size(100, 20);
      this.annualDifferenceLbl.TabIndex = 39;
      // 
      // label10
      // 
      this.label10.AutoSize = true;
      this.label10.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label10.Location = new System.Drawing.Point(9, 877);
      this.label10.Name = "label10";
      this.label10.Size = new System.Drawing.Size(92, 17);
      this.label10.TabIndex = 38;
      this.label10.Text = "Annual Difference";
      // 
      // monthlyDifferenceLbl
      // 
      this.monthlyDifferenceLbl.Location = new System.Drawing.Point(358, 871);
      this.monthlyDifferenceLbl.Name = "monthlyDifferenceLbl";
      this.monthlyDifferenceLbl.Size = new System.Drawing.Size(100, 20);
      this.monthlyDifferenceLbl.TabIndex = 45;
      // 
      // label11
      // 
      this.label11.AutoSize = true;
      this.label11.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label11.Location = new System.Drawing.Point(237, 872);
      this.label11.Name = "label11";
      this.label11.Size = new System.Drawing.Size(98, 17);
      this.label11.TabIndex = 44;
      this.label11.Text = "Monthly Difference";
      // 
      // monthlySpendingLbl
      // 
      this.monthlySpendingLbl.Location = new System.Drawing.Point(358, 836);
      this.monthlySpendingLbl.Name = "monthlySpendingLbl";
      this.monthlySpendingLbl.Size = new System.Drawing.Size(100, 20);
      this.monthlySpendingLbl.TabIndex = 43;
      // 
      // label12
      // 
      this.label12.AutoSize = true;
      this.label12.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label12.Location = new System.Drawing.Point(237, 839);
      this.label12.Name = "label12";
      this.label12.Size = new System.Drawing.Size(121, 17);
      this.label12.TabIndex = 42;
      this.label12.Text = "Monthly Spending Total";
      // 
      // monthlyIncomeLbl
      // 
      this.monthlyIncomeLbl.Location = new System.Drawing.Point(358, 819);
      this.monthlyIncomeLbl.Name = "monthlyIncomeLbl";
      this.monthlyIncomeLbl.Size = new System.Drawing.Size(100, 20);
      this.monthlyIncomeLbl.TabIndex = 41;
      // 
      // label13
      // 
      this.label13.AutoSize = true;
      this.label13.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label13.Location = new System.Drawing.Point(237, 820);
      this.label13.Name = "label13";
      this.label13.Size = new System.Drawing.Size(110, 17);
      this.label13.TabIndex = 40;
      this.label13.Text = "Monthly Income Total";
      // 
      // CreateYearForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(476, 963);
      this.Controls.Add(this.monthlyDifferenceLbl);
      this.Controls.Add(this.label11);
      this.Controls.Add(this.monthlySpendingLbl);
      this.Controls.Add(this.label12);
      this.Controls.Add(this.monthlyIncomeLbl);
      this.Controls.Add(this.label13);
      this.Controls.Add(this.annualDifferenceLbl);
      this.Controls.Add(this.label10);
      this.Controls.Add(this.annualSpendingLbl);
      this.Controls.Add(this.label9);
      this.Controls.Add(this.annualIncomeLbl);
      this.Controls.Add(this.label8);
      this.Controls.Add(this.label7);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.label6);
      this.Controls.Add(this.listView3);
      this.Controls.Add(this.listView1);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.listView2);
      this.Controls.Add(this.label5);
      this.Controls.Add(this.annualSoftBillsLv);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.annualHardBillsLv);
      this.Controls.Add(this.dividerLbl1);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.saveYearBtn);
      this.Controls.Add(this.annualSummaryLbl);
      this.Name = "CreateYearForm";
      this.Text = "CreateYearForm";
      this.Load += new System.EventHandler(this.CreateYearForm_Load);
      this.monthlyGroupsCms.ResumeLayout(false);
      this.annualGroupsCms.ResumeLayout(false);
      this.incomeSourceCms.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

        #endregion
        private System.Windows.Forms.Label annualSummaryLbl;
        private System.Windows.Forms.Button saveYearBtn;
        private System.Windows.Forms.Label label1;
    private System.Windows.Forms.ContextMenuStrip monthlyGroupsCms;
    private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ContextMenuStrip annualGroupsCms;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ContextMenuStrip incomeSourceCms;
        private System.Windows.Forms.ToolStripMenuItem incomeSourcesCmsDelete;
        private System.Windows.Forms.Label dividerLbl1;
        private System.Windows.Forms.ListView annualHardBillsLv;
        private System.Windows.Forms.ColumnHeader annualHardBillName;
        private System.Windows.Forms.ColumnHeader annualHardBillAmount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView annualSoftBillsLv;
        private System.Windows.Forms.ColumnHeader annualSoftBillName;
        private System.Windows.Forms.ColumnHeader annualSoftBillAmount;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.ColumnHeader monthlyHardBillName;
        private System.Windows.Forms.ColumnHeader monthlyHardBillAmount;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ColumnHeader monthlyHardBillDay;
        private System.Windows.Forms.ColumnHeader annualHardBillAccount;
        private System.Windows.Forms.ColumnHeader monthlyHardBillAccountName;
        private System.Windows.Forms.ListView listView3;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox annualIncomeLbl;
        private System.Windows.Forms.TextBox annualSpendingLbl;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox annualDifferenceLbl;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox monthlyDifferenceLbl;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox monthlySpendingLbl;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox monthlyIncomeLbl;
        private System.Windows.Forms.Label label13;
    }
}