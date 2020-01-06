namespace BudgetTool
{
  partial class TopForm
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
      this.manageYearBtn = new System.Windows.Forms.Button();
      this.createYearBtn = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // manageYearBtn
      // 
      this.manageYearBtn.Enabled = false;
      this.manageYearBtn.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.manageYearBtn.Location = new System.Drawing.Point(28, 29);
      this.manageYearBtn.Name = "manageYearBtn";
      this.manageYearBtn.Size = new System.Drawing.Size(200, 36);
      this.manageYearBtn.TabIndex = 7;
      this.manageYearBtn.Text = "Manage Year";
      this.manageYearBtn.UseVisualStyleBackColor = true;
      this.manageYearBtn.Click += new System.EventHandler(this.manageYearBtn_Click);
      // 
      // createYearBtn
      // 
      this.createYearBtn.Enabled = false;
      this.createYearBtn.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.createYearBtn.Location = new System.Drawing.Point(28, 92);
      this.createYearBtn.Name = "createYearBtn";
      this.createYearBtn.Size = new System.Drawing.Size(200, 36);
      this.createYearBtn.TabIndex = 8;
      this.createYearBtn.Text = "Create Year";
      this.createYearBtn.UseVisualStyleBackColor = true;
      this.createYearBtn.Click += new System.EventHandler(this.createYearBtn_Click);
      // 
      // TopForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(260, 155);
      this.Controls.Add(this.createYearBtn);
      this.Controls.Add(this.manageYearBtn);
      this.Name = "TopForm";
      this.Text = "TopForm";
      this.ResumeLayout(false);

    }

        #endregion

        private System.Windows.Forms.Button manageYearBtn;
        private System.Windows.Forms.Button createYearBtn;
    }
}