namespace SummerSchoolsApp
{
    partial class ControlUserSettings
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button5 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxMasterPword = new System.Windows.Forms.TextBox();
            this.textBoxMasterUname = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button7 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dtSeasonEnd = new System.Windows.Forms.DateTimePicker();
            this.dtSeasonStart = new System.Windows.Forms.DateTimePicker();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBoxMasterPword);
            this.groupBox1.Controls.Add(this.textBoxMasterUname);
            this.groupBox1.Enabled = false;
            this.groupBox1.Location = new System.Drawing.Point(8, 141);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(608, 126);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Master username and password";
            // 
            // button5
            // 
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Location = new System.Drawing.Point(504, 74);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 37);
            this.button5.TabIndex = 4;
            this.button5.Text = "Save new data";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(312, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Master password";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Master username";
            // 
            // textBoxMasterPword
            // 
            this.textBoxMasterPword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxMasterPword.Location = new System.Drawing.Point(312, 45);
            this.textBoxMasterPword.Name = "textBoxMasterPword";
            this.textBoxMasterPword.PasswordChar = '*';
            this.textBoxMasterPword.Size = new System.Drawing.Size(264, 20);
            this.textBoxMasterPword.TabIndex = 1;
            // 
            // textBoxMasterUname
            // 
            this.textBoxMasterUname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxMasterUname.Location = new System.Drawing.Point(16, 45);
            this.textBoxMasterUname.Name = "textBoxMasterUname";
            this.textBoxMasterUname.Size = new System.Drawing.Size(264, 20);
            this.textBoxMasterUname.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button7);
            this.groupBox2.Controls.Add(this.button6);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.dtSeasonEnd);
            this.groupBox2.Controls.Add(this.dtSeasonStart);
            this.groupBox2.Location = new System.Drawing.Point(8, 8);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(608, 127);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Active season settings";
            // 
            // button7
            // 
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button7.Location = new System.Drawing.Point(448, 72);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(128, 40);
            this.button7.TabIndex = 6;
            this.button7.Text = "Set booking status";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button6
            // 
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Location = new System.Drawing.Point(312, 72);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(128, 40);
            this.button6.TabIndex = 5;
            this.button6.Text = "Save season info";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(320, 39);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(118, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Active season ends on:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 39);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(120, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Active season starts on:";
            // 
            // dtSeasonEnd
            // 
            this.dtSeasonEnd.CustomFormat = "dd/MM/yyyy";
            this.dtSeasonEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtSeasonEnd.Location = new System.Drawing.Point(456, 37);
            this.dtSeasonEnd.Name = "dtSeasonEnd";
            this.dtSeasonEnd.Size = new System.Drawing.Size(120, 20);
            this.dtSeasonEnd.TabIndex = 1;
            // 
            // dtSeasonStart
            // 
            this.dtSeasonStart.CustomFormat = "dd/MM/yyyy";
            this.dtSeasonStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtSeasonStart.Location = new System.Drawing.Point(152, 37);
            this.dtSeasonStart.Name = "dtSeasonStart";
            this.dtSeasonStart.Size = new System.Drawing.Size(120, 20);
            this.dtSeasonStart.TabIndex = 0;
            // 
            // ControlUserSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ControlUserSettings";
            this.Size = new System.Drawing.Size(624, 678);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxMasterPword;
        private System.Windows.Forms.TextBox textBoxMasterUname;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtSeasonEnd;
        private System.Windows.Forms.DateTimePicker dtSeasonStart;
        private System.Windows.Forms.Button button7;
    }
}
