namespace BudgetToolGui
{
  partial class EditTransactionForm
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
      this.label3 = new System.Windows.Forms.Label();
      this.softBillSplitTpl = new System.Windows.Forms.TableLayoutPanel();
      this.dateDtp = new System.Windows.Forms.DateTimePicker();
      this.label5 = new System.Windows.Forms.Label();
      this.cancelBtn = new System.Windows.Forms.Button();
      this.saveBtn = new System.Windows.Forms.Button();
      this.amountTb = new System.Windows.Forms.TextBox();
      this.descriptionTb = new System.Windows.Forms.TextBox();
      this.label4 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.label1 = new System.Windows.Forms.Label();
      this.accountLbl = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(327, 19);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(65, 13);
      this.label3.TabIndex = 43;
      this.label3.Text = "Soft Bill Split";
      // 
      // softBillSplitTpl
      // 
      this.softBillSplitTpl.AutoSize = true;
      this.softBillSplitTpl.ColumnCount = 3;
      this.softBillSplitTpl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 51.33333F));
      this.softBillSplitTpl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 48.66667F));
      this.softBillSplitTpl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 171F));
      this.softBillSplitTpl.Location = new System.Drawing.Point(330, 38);
      this.softBillSplitTpl.Name = "softBillSplitTpl";
      this.softBillSplitTpl.RowCount = 2;
      this.softBillSplitTpl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
      this.softBillSplitTpl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
      this.softBillSplitTpl.Size = new System.Drawing.Size(444, 49);
      this.softBillSplitTpl.TabIndex = 42;
      // 
      // dateDtp
      // 
      this.dateDtp.Location = new System.Drawing.Point(118, 105);
      this.dateDtp.Name = "dateDtp";
      this.dateDtp.Size = new System.Drawing.Size(200, 20);
      this.dateDtp.TabIndex = 41;
      this.dateDtp.ValueChanged += new System.EventHandler(this.dateDtp_ValueChanged);
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(10, 112);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(89, 13);
      this.label5.TabIndex = 40;
      this.label5.Text = "Transaction Date";
      // 
      // cancelBtn
      // 
      this.cancelBtn.Location = new System.Drawing.Point(131, 158);
      this.cancelBtn.Name = "cancelBtn";
      this.cancelBtn.Size = new System.Drawing.Size(75, 23);
      this.cancelBtn.TabIndex = 39;
      this.cancelBtn.Text = "Cancel";
      this.cancelBtn.UseVisualStyleBackColor = true;
      this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
      // 
      // saveBtn
      // 
      this.saveBtn.Location = new System.Drawing.Point(16, 158);
      this.saveBtn.Name = "saveBtn";
      this.saveBtn.Size = new System.Drawing.Size(75, 23);
      this.saveBtn.TabIndex = 38;
      this.saveBtn.Text = "Save";
      this.saveBtn.UseVisualStyleBackColor = true;
      this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
      // 
      // amountTb
      // 
      this.amountTb.Location = new System.Drawing.Point(118, 38);
      this.amountTb.Name = "amountTb";
      this.amountTb.Size = new System.Drawing.Size(100, 20);
      this.amountTb.TabIndex = 36;
      this.amountTb.TextChanged += new System.EventHandler(this.amountTb_TextChanged);
      // 
      // descriptionTb
      // 
      this.descriptionTb.Location = new System.Drawing.Point(118, 12);
      this.descriptionTb.Name = "descriptionTb";
      this.descriptionTb.Size = new System.Drawing.Size(100, 20);
      this.descriptionTb.TabIndex = 35;
      this.descriptionTb.TextChanged += new System.EventHandler(this.descriptionTb_TextChanged);
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(10, 77);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(91, 13);
      this.label4.TabIndex = 34;
      this.label4.Text = "Payment Account";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(10, 45);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(43, 13);
      this.label2.TabIndex = 33;
      this.label2.Text = "Amount";
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(10, 19);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(60, 13);
      this.label1.TabIndex = 32;
      this.label1.Text = "Description";
      // 
      // accountLbl
      // 
      this.accountLbl.AutoSize = true;
      this.accountLbl.Location = new System.Drawing.Point(118, 76);
      this.accountLbl.Name = "accountLbl";
      this.accountLbl.Size = new System.Drawing.Size(47, 13);
      this.accountLbl.TabIndex = 44;
      this.accountLbl.Text = "Account";
      // 
      // EditTransactionForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(800, 450);
      this.Controls.Add(this.accountLbl);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.softBillSplitTpl);
      this.Controls.Add(this.dateDtp);
      this.Controls.Add(this.label5);
      this.Controls.Add(this.cancelBtn);
      this.Controls.Add(this.saveBtn);
      this.Controls.Add(this.amountTb);
      this.Controls.Add(this.descriptionTb);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label1);
      this.Name = "EditTransactionForm";
      this.Text = "EditTransactionForm";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TableLayoutPanel softBillSplitTpl;
        private System.Windows.Forms.DateTimePicker dateDtp;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.TextBox amountTb;
        private System.Windows.Forms.TextBox descriptionTb;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label accountLbl;
    }
}