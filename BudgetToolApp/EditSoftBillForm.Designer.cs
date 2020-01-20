namespace BudgetToolApp
{
  partial class EditSoftBillForm
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
      this.amountTb = new System.Windows.Forms.TextBox();
      this.nameTb = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.label1 = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // cancelBtn
      // 
      this.cancelBtn.Location = new System.Drawing.Point(145, 78);
      this.cancelBtn.Name = "cancelBtn";
      this.cancelBtn.Size = new System.Drawing.Size(75, 23);
      this.cancelBtn.TabIndex = 27;
      this.cancelBtn.Text = "Cancel";
      this.cancelBtn.UseVisualStyleBackColor = true;
      this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click_1);
      // 
      // saveBtn
      // 
      this.saveBtn.Location = new System.Drawing.Point(37, 78);
      this.saveBtn.Name = "saveBtn";
      this.saveBtn.Size = new System.Drawing.Size(75, 23);
      this.saveBtn.TabIndex = 26;
      this.saveBtn.Text = "Save";
      this.saveBtn.UseVisualStyleBackColor = true;
      this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click_1);
      // 
      // amountTb
      // 
      this.amountTb.Location = new System.Drawing.Point(120, 42);
      this.amountTb.Name = "amountTb";
      this.amountTb.Size = new System.Drawing.Size(100, 20);
      this.amountTb.TabIndex = 25;
      // 
      // nameTb
      // 
      this.nameTb.Location = new System.Drawing.Point(120, 9);
      this.nameTb.Name = "nameTb";
      this.nameTb.Size = new System.Drawing.Size(100, 20);
      this.nameTb.TabIndex = 24;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(12, 42);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(43, 13);
      this.label2.TabIndex = 23;
      this.label2.Text = "Amount";
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(12, 9);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(35, 13);
      this.label1.TabIndex = 22;
      this.label1.Text = "Name";
      // 
      // EditSoftBillForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(256, 130);
      this.Controls.Add(this.cancelBtn);
      this.Controls.Add(this.saveBtn);
      this.Controls.Add(this.amountTb);
      this.Controls.Add(this.nameTb);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label1);
      this.Name = "EditSoftBillForm";
      this.Text = "Soft Bill";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

        #endregion

        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.TextBox amountTb;
        private System.Windows.Forms.TextBox nameTb;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}