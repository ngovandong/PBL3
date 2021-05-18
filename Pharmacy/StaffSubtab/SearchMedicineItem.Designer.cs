
namespace Pharmacy.StaffSubtab
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
            this.NameMedicine = new System.Windows.Forms.Label();
            this.Unit = new System.Windows.Forms.Label();
            this.Id = new System.Windows.Forms.Label();
            this.Price = new System.Windows.Forms.Label();
            this.Available = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // NameMedicine
            // 
            this.NameMedicine.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NameMedicine.Location = new System.Drawing.Point(5, 11);
            this.NameMedicine.Name = "NameMedicine";
            this.NameMedicine.Size = new System.Drawing.Size(286, 23);
            this.NameMedicine.TabIndex = 0;
            this.NameMedicine.Text = "Thuoc so an khang";
            this.NameMedicine.MouseClick += new System.Windows.Forms.MouseEventHandler(this.NameMedicine_MouseClick);
            this.NameMedicine.MouseEnter += new System.EventHandler(this.NameMedicine_MouseEnter);
            this.NameMedicine.MouseLeave += new System.EventHandler(this.NameMedicine_MouseLeave);
            // 
            // Unit
            // 
            this.Unit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(144)))), ((int)(((byte)(218)))));
            this.Unit.Location = new System.Drawing.Point(303, 14);
            this.Unit.Name = "Unit";
            this.Unit.Size = new System.Drawing.Size(74, 17);
            this.Unit.TabIndex = 0;
            this.Unit.Text = "Viên";
            this.Unit.MouseClick += new System.Windows.Forms.MouseEventHandler(this.NameMedicine_MouseClick);
            this.Unit.MouseEnter += new System.EventHandler(this.NameMedicine_MouseEnter);
            this.Unit.MouseLeave += new System.EventHandler(this.NameMedicine_MouseLeave);
            // 
            // Id
            // 
            this.Id.Location = new System.Drawing.Point(9, 43);
            this.Id.Name = "Id";
            this.Id.Size = new System.Drawing.Size(98, 17);
            this.Id.TabIndex = 0;
            this.Id.Text = "SP000555";
            this.Id.MouseClick += new System.Windows.Forms.MouseEventHandler(this.NameMedicine_MouseClick);
            this.Id.MouseEnter += new System.EventHandler(this.NameMedicine_MouseEnter);
            this.Id.MouseLeave += new System.EventHandler(this.NameMedicine_MouseLeave);
            // 
            // Price
            // 
            this.Price.Location = new System.Drawing.Point(120, 43);
            this.Price.Name = "Price";
            this.Price.Size = new System.Drawing.Size(136, 17);
            this.Price.TabIndex = 0;
            this.Price.Text = "Price: 100,000";
            this.Price.MouseClick += new System.Windows.Forms.MouseEventHandler(this.NameMedicine_MouseClick);
            this.Price.MouseEnter += new System.EventHandler(this.NameMedicine_MouseEnter);
            this.Price.MouseLeave += new System.EventHandler(this.NameMedicine_MouseLeave);
            // 
            // Available
            // 
            this.Available.Location = new System.Drawing.Point(262, 44);
            this.Available.Name = "Available";
            this.Available.Size = new System.Drawing.Size(126, 17);
            this.Available.TabIndex = 0;
            this.Available.Text = "Available: 100";
            this.Available.MouseClick += new System.Windows.Forms.MouseEventHandler(this.NameMedicine_MouseClick);
            this.Available.MouseEnter += new System.EventHandler(this.NameMedicine_MouseEnter);
            this.Available.MouseLeave += new System.EventHandler(this.NameMedicine_MouseLeave);
            // 
            // SearchMedicineItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.Available);
            this.Controls.Add(this.Price);
            this.Controls.Add(this.Id);
            this.Controls.Add(this.Unit);
            this.Controls.Add(this.NameMedicine);
            this.Name = "SearchMedicineItem";
            this.Size = new System.Drawing.Size(395, 77);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.SearchMedicineItem_MouseClick);
            this.MouseEnter += new System.EventHandler(this.SearchMedicineItem_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.SearchMedicineItem_MouseLeave);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label NameMedicine;
        private System.Windows.Forms.Label Unit;
        private System.Windows.Forms.Label Id;
        private System.Windows.Forms.Label Price;
        private System.Windows.Forms.Label Available;
    }
}
