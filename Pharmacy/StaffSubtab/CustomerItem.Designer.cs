
namespace Pharmacy.StaffSubtab
{
    partial class CustomerItem
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
            this.CusName = new System.Windows.Forms.Label();
            this.ID_CUS = new System.Windows.Forms.Label();
            this.Phone = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // CusName
            // 
            this.CusName.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CusName.Location = new System.Drawing.Point(4, 4);
            this.CusName.Name = "CusName";
            this.CusName.Size = new System.Drawing.Size(285, 23);
            this.CusName.TabIndex = 0;
            this.CusName.Text = "ngo van dong";
            this.CusName.MouseClick += new System.Windows.Forms.MouseEventHandler(this.CusName_MouseClick);
            this.CusName.MouseEnter += new System.EventHandler(this.label1_MouseEnter);
            this.CusName.MouseLeave += new System.EventHandler(this.label1_MouseLeave);
            // 
            // ID_CUS
            // 
            this.ID_CUS.Location = new System.Drawing.Point(4, 27);
            this.ID_CUS.Name = "ID_CUS";
            this.ID_CUS.Size = new System.Drawing.Size(202, 23);
            this.ID_CUS.TabIndex = 1;
            this.ID_CUS.Text = "Ma KH:";
            this.ID_CUS.MouseClick += new System.Windows.Forms.MouseEventHandler(this.CusName_MouseClick);
            this.ID_CUS.MouseEnter += new System.EventHandler(this.label1_MouseEnter);
            this.ID_CUS.MouseLeave += new System.EventHandler(this.label1_MouseLeave);
            // 
            // Phone
            // 
            this.Phone.Location = new System.Drawing.Point(295, 4);
            this.Phone.Name = "Phone";
            this.Phone.Size = new System.Drawing.Size(114, 23);
            this.Phone.TabIndex = 2;
            this.Phone.Text = "0935351453";
            this.Phone.MouseClick += new System.Windows.Forms.MouseEventHandler(this.CusName_MouseClick);
            this.Phone.MouseEnter += new System.EventHandler(this.label1_MouseEnter);
            this.Phone.MouseLeave += new System.EventHandler(this.label1_MouseLeave);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.panel1.Location = new System.Drawing.Point(0, 54);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(501, 100);
            this.panel1.TabIndex = 3;
            this.panel1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.CusName_MouseClick);
            this.panel1.MouseEnter += new System.EventHandler(this.label1_MouseEnter);
            this.panel1.MouseLeave += new System.EventHandler(this.label1_MouseLeave);
            // 
            // CustomerItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Phone);
            this.Controls.Add(this.ID_CUS);
            this.Controls.Add(this.CusName);
            this.Name = "CustomerItem";
            this.Size = new System.Drawing.Size(417, 56);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label CusName;
        private System.Windows.Forms.Label ID_CUS;
        private System.Windows.Forms.Label Phone;
        private System.Windows.Forms.Panel panel1;
    }
}
