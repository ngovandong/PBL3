
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbPhone = new System.Windows.Forms.Label();
            this.lbName = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbPhone);
            this.panel1.Controls.Add(this.lbName);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(320, 48);
            this.panel1.TabIndex = 0;
            this.panel1.Click += new System.EventHandler(this.Mouse_Click);
            this.panel1.Enter += new System.EventHandler(this.panel1_MouseEnter);
            this.panel1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Mouse_Click);
            this.panel1.MouseEnter += new System.EventHandler(this.panel1_MouseEnter);
            this.panel1.MouseLeave += new System.EventHandler(this.panel1_MouseLeave);
            // 
            // lbPhone
            // 
            this.lbPhone.AutoSize = true;
            this.lbPhone.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPhone.Location = new System.Drawing.Point(3, 27);
            this.lbPhone.Name = "lbPhone";
            this.lbPhone.Size = new System.Drawing.Size(45, 17);
            this.lbPhone.TabIndex = 53;
            this.lbPhone.Text = "Phone";
            this.lbPhone.Click += new System.EventHandler(this.Mouse_Click);
            this.lbPhone.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Mouse_Click);
            this.lbPhone.MouseEnter += new System.EventHandler(this.panel1_MouseEnter);
            this.lbPhone.MouseLeave += new System.EventHandler(this.panel1_MouseLeave);
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbName.Location = new System.Drawing.Point(3, 3);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(44, 17);
            this.lbName.TabIndex = 52;
            this.lbName.Text = "Name";
            this.lbName.Click += new System.EventHandler(this.Mouse_Click);
            this.lbName.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Mouse_Click);
            this.lbName.MouseEnter += new System.EventHandler(this.panel1_MouseEnter);
            this.lbName.MouseLeave += new System.EventHandler(this.panel1_MouseLeave);
            // 
            // SearchSupplierItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Controls.Add(this.panel1);
            this.Name = "SearchSupplierItem";
            this.Size = new System.Drawing.Size(320, 48);
            this.Click += new System.EventHandler(this.Mouse_Click);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Mouse_Click);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbPhone;
        private System.Windows.Forms.Label lbName;
    }
}
