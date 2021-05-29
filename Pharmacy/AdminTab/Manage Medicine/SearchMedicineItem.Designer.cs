
namespace Pharmacy.AdminTab.Manage_Medicine
{
    partial class SearchMedicineItem
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
            this.Available = new System.Windows.Forms.Label();
            this.Price = new System.Windows.Forms.Label();
            this.code = new System.Windows.Forms.Label();
            this.Unit = new System.Windows.Forms.Label();
            this.NameMedicine = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.Available);
            this.panel1.Controls.Add(this.Price);
            this.panel1.Controls.Add(this.code);
            this.panel1.Controls.Add(this.Unit);
            this.panel1.Controls.Add(this.NameMedicine);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(523, 64);
            this.panel1.TabIndex = 0;
            this.panel1.Click += new System.EventHandler(this.NameMedicine_Click);
            this.panel1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.NameMedicine_MouseClick);
            this.panel1.MouseEnter += new System.EventHandler(this.SearchMedicineItem_MouseEnter);
            this.panel1.MouseLeave += new System.EventHandler(this.SearchMedicineItem_MouseLeave);
            // 
            // Available
            // 
            this.Available.Location = new System.Drawing.Point(320, 40);
            this.Available.Name = "Available";
            this.Available.Size = new System.Drawing.Size(126, 17);
            this.Available.TabIndex = 6;
            this.Available.Text = "Available: 100";
            this.Available.Click += new System.EventHandler(this.NameMedicine_Click);
            this.Available.MouseClick += new System.Windows.Forms.MouseEventHandler(this.NameMedicine_MouseClick);
            // 
            // Price
            // 
            this.Price.Location = new System.Drawing.Point(143, 39);
            this.Price.Name = "Price";
            this.Price.Size = new System.Drawing.Size(136, 17);
            this.Price.TabIndex = 7;
            this.Price.Text = "Price: 100,000";
            this.Price.Click += new System.EventHandler(this.NameMedicine_Click);
            this.Price.MouseClick += new System.Windows.Forms.MouseEventHandler(this.NameMedicine_MouseClick);
            // 
            // code
            // 
            this.code.Location = new System.Drawing.Point(32, 39);
            this.code.Name = "code";
            this.code.Size = new System.Drawing.Size(98, 17);
            this.code.TabIndex = 8;
            this.code.Text = "SP000555";
            this.code.Click += new System.EventHandler(this.NameMedicine_Click);
            this.code.MouseClick += new System.Windows.Forms.MouseEventHandler(this.NameMedicine_MouseClick);
            // 
            // Unit
            // 
            this.Unit.ForeColor = System.Drawing.Color.Black;
            this.Unit.Location = new System.Drawing.Point(320, 10);
            this.Unit.Name = "Unit";
            this.Unit.Size = new System.Drawing.Size(74, 17);
            this.Unit.TabIndex = 9;
            this.Unit.Text = "Viên";
            this.Unit.Click += new System.EventHandler(this.NameMedicine_Click);
            this.Unit.MouseClick += new System.Windows.Forms.MouseEventHandler(this.NameMedicine_MouseClick);
            // 
            // NameMedicine
            // 
            this.NameMedicine.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NameMedicine.Location = new System.Drawing.Point(28, 7);
            this.NameMedicine.Name = "NameMedicine";
            this.NameMedicine.Size = new System.Drawing.Size(286, 23);
            this.NameMedicine.TabIndex = 10;
            this.NameMedicine.Text = "Thuoc so an khang";
            this.NameMedicine.Click += new System.EventHandler(this.NameMedicine_Click);
            this.NameMedicine.MouseClick += new System.Windows.Forms.MouseEventHandler(this.NameMedicine_MouseClick);
            // 
            // SearchMedicineItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panel1);
            this.Name = "SearchMedicineItem";
            this.Size = new System.Drawing.Size(523, 64);
            this.MouseEnter += new System.EventHandler(this.SearchMedicineItem_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.SearchMedicineItem_MouseLeave);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.SearchMedicineItem_MouseMove);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label Available;
        private System.Windows.Forms.Label Price;
        private System.Windows.Forms.Label code;
        private System.Windows.Forms.Label Unit;
        private System.Windows.Forms.Label NameMedicine;
    }
}
