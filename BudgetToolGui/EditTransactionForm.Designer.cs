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
      this.dateDtp = new System.Windows.Forms.DateTimePicker();
      this.label5 = new System.Windows.Forms.Label();
      this.amountTb = new System.Windows.Forms.TextBox();
      this.label4 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.cancelBtn = new System.Windows.Forms.Button();
      this.saveBtn = new System.Windows.Forms.Button();
      this.accountTb = new System.Windows.Forms.TextBox();
      this.SuspendLayout();
      // 
      // dateDtp
      // 
      this.dateDtp.Location = new System.Drawing.Point(120, 65);
      this.dateDtp.Name = "dateDtp";
      this.dateDtp.Size = new System.Drawing.Size(200, 20);
      this.dateDtp.TabIndex = 35;
      this.dateDtp.ValueChanged += new System.EventHandler(this.dateDtp_ValueChanged);
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(12, 72);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(89, 13);
      this.label5.TabIndex = 34;
      this.label5.Text = "Transaction Date";
      // 
      // amountTb
      // 
      this.amountTb.Location = new System.Drawing.Point(120, 39);
      this.amountTb.Name = "amountTb";
      this.amountTb.Size = new System.Drawing.Size(100, 20);
      this.amountTb.TabIndex = 32;
      this.amountTb.TextChanged += new System.EventHandler(this.amountTb_TextChanged);
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(12, 18);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(91, 13);
      this.label4.TabIndex = 31;
      this.label4.Text = "Payment Account";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(12, 46);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(43, 13);
      this.label2.TabIndex = 30;
      this.label2.Text = "Amount";
      // 
      // cancelBtn
      // 
      this.cancelBtn.Location = new System.Drawing.Point(175, 117);
      this.cancelBtn.Name = "cancelBtn";
      this.cancelBtn.Size = new System.Drawing.Size(75, 23);
      this.cancelBtn.TabIndex = 37;
      this.cancelBtn.Text = "Cancel";
      this.cancelBtn.UseVisualStyleBackColor = true;
      this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
      // 
      // saveBtn
      // 
      this.saveBtn.Location = new System.Drawing.Point(60, 117);
      this.saveBtn.Name = "saveBtn";
      this.saveBtn.Size = new System.Drawing.Size(75, 23);
      this.saveBtn.TabIndex = 36;
      this.saveBtn.Text = "Save";
      this.saveBtn.UseVisualStyleBackColor = true;
      this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
      // 
      // accountTb
      // 
      this.accountTb.Location = new System.Drawing.Point(120, 11);
      this.accountTb.Name = "accountTb";
      this.accountTb.ReadOnly = true;
      this.accountTb.Size = new System.Drawing.Size(100, 20);
      this.accountTb.TabIndex = 38;
      // 
      // EditTransactionForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(388, 180);
      this.Controls.Add(this.accountTb);
      this.Controls.Add(this.cancelBtn);
      this.Controls.Add(this.saveBtn);
      this.Controls.Add(this.dateDtp);
      this.Controls.Add(this.label5);
      this.Controls.Add(this.amountTb);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.label2);
      this.Name = "EditTransactionForm";
      this.Text = "EditTransactionForm";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

        #endregion

        private System.Windows.Forms.DateTimePicker dateDtp;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox amountTb;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.TextBox accountTb;
    }
}