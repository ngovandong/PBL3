
namespace Pharmacy.StaffSubtab
{
    partial class AddCustomer
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
            this.Phone = new Guna.UI2.WinForms.Guna2TextBox();
            this.CusName = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.SuspendLayout();
            // 
            // Phone
            // 
            this.Phone.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.Phone.DefaultText = "";
            this.Phone.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.Phone.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.Phone.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.Phone.DisabledState.Parent = this.Phone;
            this.Phone.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.Phone.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.Phone.FocusedState.Parent = this.Phone;
            this.Phone.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Phone.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.Phone.HoverState.Parent = this.Phone;
            this.Phone.Location = new System.Drawing.Point(39, 108);
            this.Phone.Name = "Phone";
            this.Phone.PasswordChar = '\0';
            this.Phone.PlaceholderText = "Số điện thoại";
            this.Phone.SelectedText = "";
            this.Phone.ShadowDecoration.Parent = this.Phone;
            this.Phone.Size = new System.Drawing.Size(265, 36);
            this.Phone.TabIndex = 0;
            // 
            // CusName
            // 
            this.CusName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.CusName.DefaultText = "";
            this.CusName.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.CusName.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.CusName.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.CusName.DisabledState.Parent = this.CusName;
            this.CusName.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.CusName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.CusName.FocusedState.Parent = this.CusName;
            this.CusName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.CusName.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.CusName.HoverState.Parent = this.CusName;
            this.CusName.Location = new System.Drawing.Point(39, 39);
            this.CusName.Name = "CusName";
            this.CusName.PasswordChar = '\0';
            this.CusName.PlaceholderText = "Tên";
            this.CusName.SelectedText = "";
            this.CusName.ShadowDecoration.Parent = this.CusName;
            this.CusName.Size = new System.Drawing.Size(265, 36);
            this.CusName.TabIndex = 0;
            // 
            // guna2Button1
            // 
            this.guna2Button1.BorderRadius = 5;
            this.guna2Button1.CheckedState.Parent = this.guna2Button1;
            this.guna2Button1.CustomImages.Parent = this.guna2Button1;
            this.guna2Button1.DisabledState.Parent = this.guna2Button1;
            this.guna2Button1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(173)))), ((int)(((byte)(81)))));
            this.guna2Button1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2Button1.ForeColor = System.Drawing.Color.White;
            this.guna2Button1.HoverState.Parent = this.guna2Button1;
            this.guna2Button1.Location = new System.Drawing.Point(122, 179);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.ShadowDecoration.Parent = this.guna2Button1;
            this.guna2Button1.Size = new System.Drawing.Size(101, 45);
            this.guna2Button1.TabIndex = 1;
            this.guna2Button1.Text = "Lưu";
            this.guna2Button1.Click += new System.EventHandler(this.guna2Button1_Click);
            // 
            // AddCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(348, 255);
            this.Controls.Add(this.guna2Button1);
            this.Controls.Add(this.CusName);
            this.Controls.Add(this.Phone);
            this.Name = "AddCustomer";
            this.Text = "Add Customer";
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2TextBox Phone;
        private Guna.UI2.WinForms.Guna2TextBox CusName;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
    }
}