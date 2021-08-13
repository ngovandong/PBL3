
namespace Pharmacy.AdminTab
{
    partial class dashBoard
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
            this.ButtonDashBoard = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button10 = new Guna.UI2.WinForms.Guna2Button();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.report1 = new Pharmacy.AdminTab.DashBoard.report();
            this.genneral1 = new Pharmacy.AdminTab.DashBoard.Genneral();
            this.panel6.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ButtonDashBoard
            // 
            this.ButtonDashBoard.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.ButtonDashBoard.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(165)))), ((int)(((byte)(173)))));
            this.ButtonDashBoard.CheckedState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(35)))), ((int)(((byte)(67)))));
            this.ButtonDashBoard.CheckedState.Parent = this.ButtonDashBoard;
            this.ButtonDashBoard.CustomImages.Parent = this.ButtonDashBoard;
            this.ButtonDashBoard.Dock = System.Windows.Forms.DockStyle.Left;
            this.ButtonDashBoard.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(107)))), ((int)(((byte)(135)))));
            this.ButtonDashBoard.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.ButtonDashBoard.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(165)))), ((int)(((byte)(173)))));
            this.ButtonDashBoard.HoverState.Parent = this.ButtonDashBoard;
            this.ButtonDashBoard.Location = new System.Drawing.Point(0, 0);
            this.ButtonDashBoard.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ButtonDashBoard.Name = "ButtonDashBoard";
            this.ButtonDashBoard.ShadowDecoration.Parent = this.ButtonDashBoard;
            this.ButtonDashBoard.Size = new System.Drawing.Size(226, 60);
            this.ButtonDashBoard.TabIndex = 2;
            this.ButtonDashBoard.Text = "Tổng quan";
            this.ButtonDashBoard.Click += new System.EventHandler(this.ButtonDashBoard_Click);
            // 
            // guna2Button10
            // 
            this.guna2Button10.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.guna2Button10.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(165)))), ((int)(((byte)(173)))));
            this.guna2Button10.CheckedState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(35)))), ((int)(((byte)(67)))));
            this.guna2Button10.CheckedState.Parent = this.guna2Button10;
            this.guna2Button10.CustomImages.Parent = this.guna2Button10;
            this.guna2Button10.Dock = System.Windows.Forms.DockStyle.Left;
            this.guna2Button10.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(107)))), ((int)(((byte)(135)))));
            this.guna2Button10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.guna2Button10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(165)))), ((int)(((byte)(173)))));
            this.guna2Button10.HoverState.Parent = this.guna2Button10;
            this.guna2Button10.Location = new System.Drawing.Point(226, 0);
            this.guna2Button10.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.guna2Button10.Name = "guna2Button10";
            this.guna2Button10.ShadowDecoration.Parent = this.guna2Button10;
            this.guna2Button10.Size = new System.Drawing.Size(199, 60);
            this.guna2Button10.TabIndex = 2;
            this.guna2Button10.Text = "Báo cáo";
            this.guna2Button10.Click += new System.EventHandler(this.guna2Button10_Click);
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(107)))), ((int)(((byte)(135)))));
            this.panel6.Controls.Add(this.guna2Button10);
            this.panel6.Controls.Add(this.ButtonDashBoard);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(1079, 60);
            this.panel6.TabIndex = 9;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.report1);
            this.panel1.Controls.Add(this.genneral1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 60);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1079, 869);
            this.panel1.TabIndex = 10;
            // 
            // report1
            // 
            this.report1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.report1.Location = new System.Drawing.Point(0, 0);
            this.report1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.report1.Name = "report1";
            this.report1.Size = new System.Drawing.Size(1079, 869);
            this.report1.TabIndex = 1;
            // 
            // genneral1
            // 
            this.genneral1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.genneral1.Location = new System.Drawing.Point(0, 0);
            this.genneral1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.genneral1.Name = "genneral1";
            this.genneral1.Size = new System.Drawing.Size(1079, 869);
            this.genneral1.TabIndex = 0;
            // 
            // dashBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel6);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "dashBoard";
            this.Size = new System.Drawing.Size(1079, 929);
            this.panel6.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel6;
        private Guna.UI2.WinForms.Guna2Button guna2Button10;
        private Guna.UI2.WinForms.Guna2Button ButtonDashBoard;
        private DashBoard.Genneral genneral1;
        private DashBoard.report report1;
    }
}
