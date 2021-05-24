
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SearchMedicineItem));
            this.Available = new System.Windows.Forms.Label();
            this.Price = new System.Windows.Forms.Label();
            this.code = new System.Windows.Forms.Label();
            this.Unit = new System.Windows.Forms.Label();
            this.NameMedicine = new System.Windows.Forms.Label();
            this.buttonAddMedicine = new Guna.UI2.WinForms.Guna2ImageButton();
            this.SuspendLayout();
            // 
            // Available
            // 
            this.Available.Location = new System.Drawing.Point(260, 43);
            this.Available.Name = "Available";
            this.Available.Size = new System.Drawing.Size(126, 17);
            this.Available.TabIndex = 1;
            this.Available.Text = "Available: 100";
            // 
            // Price
            // 
            this.Price.Location = new System.Drawing.Point(118, 42);
            this.Price.Name = "Price";
            this.Price.Size = new System.Drawing.Size(136, 17);
            this.Price.TabIndex = 2;
            this.Price.Text = "Price: 100,000";
            // 
            // code
            // 
            this.code.Location = new System.Drawing.Point(7, 42);
            this.code.Name = "code";
            this.code.Size = new System.Drawing.Size(98, 17);
            this.code.TabIndex = 3;
            this.code.Text = "SP000555";
            // 
            // Unit
            // 
            this.Unit.ForeColor = System.Drawing.Color.Black;
            this.Unit.Location = new System.Drawing.Point(260, 13);
            this.Unit.Name = "Unit";
            this.Unit.Size = new System.Drawing.Size(74, 17);
            this.Unit.TabIndex = 4;
            this.Unit.Text = "Viên";
            // 
            // NameMedicine
            // 
            this.NameMedicine.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NameMedicine.Location = new System.Drawing.Point(3, 10);
            this.NameMedicine.Name = "NameMedicine";
            this.NameMedicine.Size = new System.Drawing.Size(286, 23);
            this.NameMedicine.TabIndex = 5;
            this.NameMedicine.Text = "Thuoc so an khang";
            this.NameMedicine.Click += new System.EventHandler(this.NameMedicine_Click);
            this.NameMedicine.MouseClick += new System.Windows.Forms.MouseEventHandler(this.NameMedicine_MouseClick);
            // 
            // buttonAddMedicine
            // 
            this.buttonAddMedicine.BackColor = System.Drawing.Color.White;
            this.buttonAddMedicine.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.buttonAddMedicine.CheckedState.Parent = this.buttonAddMedicine;
            this.buttonAddMedicine.HoverState.ImageSize = new System.Drawing.Size(64, 64);
            this.buttonAddMedicine.HoverState.Parent = this.buttonAddMedicine;
            this.buttonAddMedicine.Image = ((System.Drawing.Image)(resources.GetObject("buttonAddMedicine.Image")));
            this.buttonAddMedicine.ImageRotate = 0F;
            this.buttonAddMedicine.ImageSize = new System.Drawing.Size(38, 38);
            this.buttonAddMedicine.Location = new System.Drawing.Point(468, 13);
            this.buttonAddMedicine.Name = "buttonAddMedicine";
            this.buttonAddMedicine.PressedState.ImageSize = new System.Drawing.Size(64, 64);
            this.buttonAddMedicine.PressedState.Parent = this.buttonAddMedicine;
            this.buttonAddMedicine.Size = new System.Drawing.Size(40, 40);
            this.buttonAddMedicine.TabIndex = 38;
            this.buttonAddMedicine.Click += new System.EventHandler(this.buttonAddMedicine_Click);
            // 
            // SearchMedicineItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.buttonAddMedicine);
            this.Controls.Add(this.Available);
            this.Controls.Add(this.Price);
            this.Controls.Add(this.code);
            this.Controls.Add(this.Unit);
            this.Controls.Add(this.NameMedicine);
            this.Name = "SearchMedicineItem";
            this.Size = new System.Drawing.Size(523, 64);
            this.Click += new System.EventHandler(this.SearchMedicineItem_Click);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.SearchMedicineItem_MouseClick);
            this.MouseEnter += new System.EventHandler(this.SearchMedicineItem_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.SearchMedicineItem_MouseLeave);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.SearchMedicineItem_MouseMove);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label Available;
        private System.Windows.Forms.Label Price;
        private System.Windows.Forms.Label code;
        private System.Windows.Forms.Label Unit;
        private System.Windows.Forms.Label NameMedicine;
        private Guna.UI2.WinForms.Guna2ImageButton buttonAddMedicine;
    }
}
