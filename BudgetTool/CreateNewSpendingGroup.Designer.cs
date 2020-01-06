namespace BudgetTool
{
  partial class CreateNewSpendingGroup
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
      this.nameLbl = new System.Windows.Forms.Label();
      this.groupNameTb = new System.Windows.Forms.TextBox();
      this.startingAmtLbl = new System.Windows.Forms.Label();
      this.startingAmtTb = new System.Windows.Forms.TextBox();
      this.annualGroupRbtn = new System.Windows.Forms.RadioButton();
      this.addGroupBtn = new System.Windows.Forms.Button();
      this.cancelBtn = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // nameLbl
      // 
      this.nameLbl.AutoSize = true;
      this.nameLbl.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.nameLbl.Location = new System.Drawing.Point(12, 33);
      this.nameLbl.Name = "nameLbl";
      this.nameLbl.Size = new System.Drawing.Size(67, 17);
      this.nameLbl.TabIndex = 0;
      this.nameLbl.Text = "Group Name";
      // 
      // groupNameTb
      // 
      this.groupNameTb.Location = new System.Drawing.Point(102, 33);
      this.groupNameTb.Name = "groupNameTb";
      this.groupNameTb.Size = new System.Drawing.Size(170, 20);
      this.groupNameTb.TabIndex = 1;
      // 
      // startingAmtLbl
      // 
      this.startingAmtLbl.AutoSize = true;
      this.startingAmtLbl.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.startingAmtLbl.Location = new System.Drawing.Point(12, 69);
      this.startingAmtLbl.Name = "startingAmtLbl";
      this.startingAmtLbl.Size = new System.Drawing.Size(87, 17);
      this.startingAmtLbl.TabIndex = 2;
      this.startingAmtLbl.Text = "Starting Amount";
      // 
      // startingAmtTb
      // 
      this.startingAmtTb.Location = new System.Drawing.Point(102, 66);
      this.startingAmtTb.Name = "startingAmtTb";
      this.startingAmtTb.Size = new System.Drawing.Size(170, 20);
      this.startingAmtTb.TabIndex = 3;
      // 
      // annualGroupRbtn
      // 
      this.annualGroupRbtn.AutoSize = true;
      this.annualGroupRbtn.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.annualGroupRbtn.Location = new System.Drawing.Point(15, 104);
      this.annualGroupRbtn.Name = "annualGroupRbtn";
      this.annualGroupRbtn.Size = new System.Drawing.Size(90, 21);
      this.annualGroupRbtn.TabIndex = 4;
      this.annualGroupRbtn.TabStop = true;
      this.annualGroupRbtn.Text = "Annual Group";
      this.annualGroupRbtn.UseVisualStyleBackColor = true;
      // 
      // addGroupBtn
      // 
      this.addGroupBtn.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.addGroupBtn.Location = new System.Drawing.Point(15, 147);
      this.addGroupBtn.Name = "addGroupBtn";
      this.addGroupBtn.Size = new System.Drawing.Size(125, 23);
      this.addGroupBtn.TabIndex = 5;
      this.addGroupBtn.Text = "Add Group";
      this.addGroupBtn.UseVisualStyleBackColor = true;
      this.addGroupBtn.Click += new System.EventHandler(this.addGroupBtn_Click);
      // 
      // cancelBtn
      // 
      this.cancelBtn.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.cancelBtn.Location = new System.Drawing.Point(148, 147);
      this.cancelBtn.Name = "cancelBtn";
      this.cancelBtn.Size = new System.Drawing.Size(125, 23);
      this.cancelBtn.TabIndex = 6;
      this.cancelBtn.Text = "Cancel";
      this.cancelBtn.UseVisualStyleBackColor = true;
      this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
      // 
      // CreateNewSpendingGroup
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(284, 193);
      this.Controls.Add(this.cancelBtn);
      this.Controls.Add(this.addGroupBtn);
      this.Controls.Add(this.annualGroupRbtn);
      this.Controls.Add(this.startingAmtTb);
      this.Controls.Add(this.startingAmtLbl);
      this.Controls.Add(this.groupNameTb);
      this.Controls.Add(this.nameLbl);
      this.Name = "CreateNewSpendingGroup";
      this.Text = "CreateNewSpendingGroup";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

        #endregion

        private System.Windows.Forms.Label nameLbl;
        private System.Windows.Forms.TextBox groupNameTb;
        private System.Windows.Forms.Label startingAmtLbl;
        private System.Windows.Forms.TextBox startingAmtTb;
        private System.Windows.Forms.RadioButton annualGroupRbtn;
        private System.Windows.Forms.Button addGroupBtn;
        private System.Windows.Forms.Button cancelBtn;
    }
}