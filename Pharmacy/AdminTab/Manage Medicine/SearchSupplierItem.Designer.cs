
namespace Pharmacy.AdminTab.Manage_Medicine
{
    partial class SearchSupplierItem
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbName = new System.Windows.Forms.Label();
            this.lbPhone = new System.Windows.Forms.Label();
            this.guna2Separator2 = new Guna.UI2.WinForms.Guna2Separator();
            this.SuspendLayout();
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbName.Location = new System.Drawing.Point(3, 3);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(44, 17);
            this.lbName.TabIndex = 0;
            this.lbName.Text = "Name";
            this.lbName.Click += new System.EventHandler(this.Mouse_Click);
            this.lbName.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Mouse_Click);
            // 
            // lbPhone
            // 
            this.lbPhone.AutoSize = true;
            this.lbPhone.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPhone.Location = new System.Drawing.Point(3, 24);
            this.lbPhone.Name = "lbPhone";
            this.lbPhone.Size = new System.Drawing.Size(45, 17);
            this.lbPhone.TabIndex = 1;
            this.lbPhone.Text = "Phone";
            this.lbPhone.Click += new System.EventHandler(this.Mouse_Click);
            this.lbPhone.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Mouse_Click);
            // 
            // guna2Separator2
            // 
            this.guna2Separator2.FillColor = System.Drawing.Color.DimGray;
            this.guna2Separator2.Location = new System.Drawing.Point(0, 41);
            this.guna2Separator2.Name = "guna2Separator2";
            this.guna2Separator2.Size = new System.Drawing.Size(286, 10);
            this.guna2Separator2.TabIndex = 51;
            // 
            // SearchSupplierItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Controls.Add(this.guna2Separator2);
            this.Controls.Add(this.lbPhone);
            this.Controls.Add(this.lbName);
            this.Name = "SearchSupplierItem";
            this.Size = new System.Drawing.Size(286, 48);
            this.Click += new System.EventHandler(this.Mouse_Click);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Mouse_Click);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.Label lbPhone;
        private Guna.UI2.WinForms.Guna2Separator guna2Separator2;
    }
}
