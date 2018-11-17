namespace SummerSchoolsApp
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.SettingsBtn = new System.Windows.Forms.Button();
            this.MaintenanceBtn = new System.Windows.Forms.Button();
            this.ContactBtn = new System.Windows.Forms.Button();
            this.EditBtn = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.panelButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // SettingsBtn
            // 
            this.SettingsBtn.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.SettingsBtn.FlatAppearance.BorderSize = 0;
            this.SettingsBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SettingsBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SettingsBtn.Location = new System.Drawing.Point(8, 265);
            this.SettingsBtn.Name = "SettingsBtn";
            this.SettingsBtn.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.SettingsBtn.Size = new System.Drawing.Size(159, 56);
            this.SettingsBtn.TabIndex = 3;
            this.SettingsBtn.Text = "User settings";
            this.SettingsBtn.UseVisualStyleBackColor = false;
            this.SettingsBtn.Click += new System.EventHandler(this.SettingsBtn_Click);
            // 
            // MaintenanceBtn
            // 
            this.MaintenanceBtn.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.MaintenanceBtn.FlatAppearance.BorderSize = 0;
            this.MaintenanceBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MaintenanceBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaintenanceBtn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.MaintenanceBtn.Location = new System.Drawing.Point(8, 179);
            this.MaintenanceBtn.Name = "MaintenanceBtn";
            this.MaintenanceBtn.Size = new System.Drawing.Size(159, 56);
            this.MaintenanceBtn.TabIndex = 2;
            this.MaintenanceBtn.Text = "Maintenance";
            this.MaintenanceBtn.UseVisualStyleBackColor = false;
            this.MaintenanceBtn.Click += new System.EventHandler(this.MaintenanceBtn_Click);
            // 
            // ContactBtn
            // 
            this.ContactBtn.BackColor = System.Drawing.SystemColors.Control;
            this.ContactBtn.FlatAppearance.BorderSize = 0;
            this.ContactBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ContactBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ContactBtn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ContactBtn.Location = new System.Drawing.Point(8, 13);
            this.ContactBtn.Name = "ContactBtn";
            this.ContactBtn.Size = new System.Drawing.Size(159, 56);
            this.ContactBtn.TabIndex = 0;
            this.ContactBtn.Text = "Add new contact";
            this.ContactBtn.UseVisualStyleBackColor = false;
            this.ContactBtn.Click += new System.EventHandler(this.ContactBtn_Click);
            // 
            // EditBtn
            // 
            this.EditBtn.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.EditBtn.FlatAppearance.BorderSize = 0;
            this.EditBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EditBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditBtn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.EditBtn.Location = new System.Drawing.Point(8, 95);
            this.EditBtn.Name = "EditBtn";
            this.EditBtn.Size = new System.Drawing.Size(159, 56);
            this.EditBtn.TabIndex = 0;
            this.EditBtn.Text = "Edit contacts & Manage bookings";
            this.EditBtn.UseVisualStyleBackColor = false;
            this.EditBtn.Click += new System.EventHandler(this.EditBtn_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.AutoScroll = true;
            this.panel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel2.BackColor = System.Drawing.SystemColors.Control;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Location = new System.Drawing.Point(163, 12);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(10);
            this.panel2.Size = new System.Drawing.Size(888, 671);
            this.panel2.TabIndex = 11;
            // 
            // panelButtons
            // 
            this.panelButtons.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panelButtons.Controls.Add(this.ContactBtn);
            this.panelButtons.Controls.Add(this.MaintenanceBtn);
            this.panelButtons.Controls.Add(this.SettingsBtn);
            this.panelButtons.Controls.Add(this.EditBtn);
            this.panelButtons.Location = new System.Drawing.Point(0, 12);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(167, 670);
            this.panelButtons.TabIndex = 13;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(1054, 711);
            this.Controls.Add(this.panelButtons);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "English Book Education CRM";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainFrm_Closing);
            this.panelButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button SettingsBtn;
        private System.Windows.Forms.Button MaintenanceBtn;
        private System.Windows.Forms.Button ContactBtn;
        private System.Windows.Forms.Button EditBtn;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panelButtons;


    }
}

