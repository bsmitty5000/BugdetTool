namespace BudgetToolApp
{
  partial class EditHardBillPay
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
      this.paymentDateDtp = new System.Windows.Forms.DateTimePicker();
      this.label5 = new System.Windows.Forms.Label();
      this.payBtn = new System.Windows.Forms.Button();
      this.amountTb = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.cancelBtn = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // paymentDateDtp
      // 
      this.paymentDateDtp.Location = new System.Drawing.Point(92, 21);
      this.paymentDateDtp.Name = "paymentDateDtp";
      this.paymentDateDtp.Size = new System.Drawing.Size(200, 20);
      this.paymentDateDtp.TabIndex = 56;
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(12, 27);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(74, 13);
      this.label5.TabIndex = 58;
      this.label5.Text = "Payment Date";
      // 
      // payBtn
      // 
      this.payBtn.Location = new System.Drawing.Point(46, 86);
      this.payBtn.Name = "payBtn";
      this.payBtn.Size = new System.Drawing.Size(75, 23);
      this.payBtn.TabIndex = 57;
      this.payBtn.Text = "Pay";
      this.payBtn.UseVisualStyleBackColor = true;
      this.payBtn.Click += new System.EventHandler(this.payBtn_Click);
      // 
      // amountTb
      // 
      this.amountTb.Location = new System.Drawing.Point(92, 51);
      this.amountTb.Name = "amountTb";
      this.amountTb.Size = new System.Drawing.Size(100, 20);
      this.amountTb.TabIndex = 55;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(43, 58);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(43, 13);
      this.label2.TabIndex = 59;
      this.label2.Text = "Amount";
      // 
      // cancelBtn
      // 
      this.cancelBtn.Location = new System.Drawing.Point(198, 86);
      this.cancelBtn.Name = "cancelBtn";
      this.cancelBtn.Size = new System.Drawing.Size(75, 23);
      this.cancelBtn.TabIndex = 60;
      this.cancelBtn.Text = "Cancel";
      this.cancelBtn.UseVisualStyleBackColor = true;
      this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
      // 
      // EditHardBillPay
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(342, 155);
      this.Controls.Add(this.cancelBtn);
      this.Controls.Add(this.paymentDateDtp);
      this.Controls.Add(this.label5);
      this.Controls.Add(this.payBtn);
      this.Controls.Add(this.amountTb);
      this.Controls.Add(this.label2);
      this.Name = "EditHardBillPay";
      this.Text = "EditHardBillPay";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

        #endregion

        private System.Windows.Forms.DateTimePicker paymentDateDtp;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button payBtn;
        private System.Windows.Forms.TextBox amountTb;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button cancelBtn;
    }
}