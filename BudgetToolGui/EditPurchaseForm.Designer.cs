namespace BudgetToolGui
{
  partial class EditPurchaseForm
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
      this.cancelBtn = new System.Windows.Forms.Button();
      this.saveBtn = new System.Windows.Forms.Button();
      this.accountCb = new System.Windows.Forms.ComboBox();
      this.amountTb = new System.Windows.Forms.TextBox();
      this.vendorTb = new System.Windows.Forms.TextBox();
      this.label4 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.label1 = new System.Windows.Forms.Label();
      this.dateDtp = new System.Windows.Forms.DateTimePicker();
      this.label5 = new System.Windows.Forms.Label();
      this.softBillSplitTpl = new System.Windows.Forms.TableLayoutPanel();
      this.label3 = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // cancelBtn
      // 
      this.cancelBtn.Location = new System.Drawing.Point(133, 155);
      this.cancelBtn.Name = "cancelBtn";
      this.cancelBtn.Size = new System.Drawing.Size(75, 23);
      this.cancelBtn.TabIndex = 27;
      this.cancelBtn.Text = "Cancel";
      this.cancelBtn.UseVisualStyleBackColor = true;
      this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
      // 
      // saveBtn
      // 
      this.saveBtn.Location = new System.Drawing.Point(18, 155);
      this.saveBtn.Name = "saveBtn";
      this.saveBtn.Size = new System.Drawing.Size(75, 23);
      this.saveBtn.TabIndex = 26;
      this.saveBtn.Text = "Save";
      this.saveBtn.UseVisualStyleBackColor = true;
      this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
      // 
      // accountCb
      // 
      this.accountCb.FormattingEnabled = true;
      this.accountCb.Location = new System.Drawing.Point(120, 66);
      this.accountCb.Name = "accountCb";
      this.accountCb.Size = new System.Drawing.Size(121, 21);
      this.accountCb.TabIndex = 25;
      this.accountCb.SelectedIndexChanged += new System.EventHandler(this.accountCb_SelectedIndexChanged);
      // 
      // amountTb
      // 
      this.amountTb.Location = new System.Drawing.Point(120, 35);
      this.amountTb.Name = "amountTb";
      this.amountTb.Size = new System.Drawing.Size(100, 20);
      this.amountTb.TabIndex = 24;
      this.amountTb.TextChanged += new System.EventHandler(this.amountTb_TextChanged);
      // 
      // vendorTb
      // 
      this.vendorTb.Location = new System.Drawing.Point(120, 9);
      this.vendorTb.Name = "vendorTb";
      this.vendorTb.Size = new System.Drawing.Size(100, 20);
      this.vendorTb.TabIndex = 23;
      this.vendorTb.TextChanged += new System.EventHandler(this.vendorTb_TextChanged);
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(12, 74);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(91, 13);
      this.label4.TabIndex = 22;
      this.label4.Text = "Payment Account";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(12, 42);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(43, 13);
      this.label2.TabIndex = 21;
      this.label2.Text = "Amount";
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(12, 16);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(41, 13);
      this.label1.TabIndex = 20;
      this.label1.Text = "Vendor";
      // 
      // dateDtp
      // 
      this.dateDtp.Location = new System.Drawing.Point(120, 102);
      this.dateDtp.Name = "dateDtp";
      this.dateDtp.Size = new System.Drawing.Size(200, 20);
      this.dateDtp.TabIndex = 29;
      this.dateDtp.ValueChanged += new System.EventHandler(this.dateDtp_ValueChanged);
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(12, 109);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(89, 13);
      this.label5.TabIndex = 28;
      this.label5.Text = "Transaction Date";
      // 
      // softBillSplitTpl
      // 
      this.softBillSplitTpl.AutoSize = true;
      this.softBillSplitTpl.ColumnCount = 3;
      this.softBillSplitTpl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 51.33333F));
      this.softBillSplitTpl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 48.66667F));
      this.softBillSplitTpl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 165F));
      this.softBillSplitTpl.Location = new System.Drawing.Point(332, 35);
      this.softBillSplitTpl.Name = "softBillSplitTpl";
      this.softBillSplitTpl.RowCount = 2;
      this.softBillSplitTpl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
      this.softBillSplitTpl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
      this.softBillSplitTpl.Size = new System.Drawing.Size(444, 49);
      this.softBillSplitTpl.TabIndex = 30;
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(329, 16);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(65, 13);
      this.label3.TabIndex = 31;
      this.label3.Text = "Soft Bill Split";
      // 
      // EditPurchaseForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(800, 324);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.softBillSplitTpl);
      this.Controls.Add(this.dateDtp);
      this.Controls.Add(this.label5);
      this.Controls.Add(this.cancelBtn);
      this.Controls.Add(this.saveBtn);
      this.Controls.Add(this.accountCb);
      this.Controls.Add(this.amountTb);
      this.Controls.Add(this.vendorTb);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label1);
      this.Name = "EditPurchaseForm";
      this.Text = "EditPurchaseForm";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

        #endregion

        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.ComboBox accountCb;
        private System.Windows.Forms.TextBox amountTb;
        private System.Windows.Forms.TextBox vendorTb;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateDtp;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TableLayoutPanel softBillSplitTpl;
        private System.Windows.Forms.Label label3;
    }
}