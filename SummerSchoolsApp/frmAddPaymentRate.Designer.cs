namespace SummerSchoolsApp
{
    partial class frmAddPaymentRate
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
            this.comboBoxOriginalCurr = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.textBoxRateNote = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxAmountPaid = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.comboBoxPayMethod = new System.Windows.Forms.ComboBox();
            this.textBoxRateConversion = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.comboBoxCurrency = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.checkBoxContraRate = new System.Windows.Forms.CheckBox();
            this.AddRateButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBoxOriginalCurr
            // 
            this.comboBoxOriginalCurr.DisplayMember = "1";
            this.comboBoxOriginalCurr.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxOriginalCurr.FormattingEnabled = true;
            this.comboBoxOriginalCurr.Items.AddRange(new object[] {
            "EUR",
            "GBP"});
            this.comboBoxOriginalCurr.Location = new System.Drawing.Point(152, 212);
            this.comboBoxOriginalCurr.Name = "comboBoxOriginalCurr";
            this.comboBoxOriginalCurr.Size = new System.Drawing.Size(121, 21);
            this.comboBoxOriginalCurr.Sorted = true;
            this.comboBoxOriginalCurr.TabIndex = 33;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(17, 215);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(86, 13);
            this.label18.TabIndex = 32;
            this.label18.Text = "Original currency";
            // 
            // textBoxRateNote
            // 
            this.textBoxRateNote.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxRateNote.Location = new System.Drawing.Point(152, 252);
            this.textBoxRateNote.Name = "textBoxRateNote";
            this.textBoxRateNote.Size = new System.Drawing.Size(120, 20);
            this.textBoxRateNote.TabIndex = 31;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(17, 254);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(54, 13);
            this.label16.TabIndex = 30;
            this.label16.Text = "Rate note";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(16, 16);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 13);
            this.label8.TabIndex = 22;
            this.label8.Text = "Payment date";
            // 
            // textBoxAmountPaid
            // 
            this.textBoxAmountPaid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxAmountPaid.Location = new System.Drawing.Point(152, 54);
            this.textBoxAmountPaid.Name = "textBoxAmountPaid";
            this.textBoxAmountPaid.Size = new System.Drawing.Size(120, 20);
            this.textBoxAmountPaid.TabIndex = 21;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(16, 96);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(49, 13);
            this.label10.TabIndex = 24;
            this.label10.Text = "Currency";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(16, 176);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(89, 13);
            this.label12.TabIndex = 27;
            this.label12.Text = "Conversion value";
            // 
            // comboBoxPayMethod
            // 
            this.comboBoxPayMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPayMethod.FormattingEnabled = true;
            this.comboBoxPayMethod.Items.AddRange(new object[] {
            "Cash D",
            "Cash F",
            "Credit Card",
            "Invoiced",
            "Transfer"});
            this.comboBoxPayMethod.Location = new System.Drawing.Point(152, 134);
            this.comboBoxPayMethod.Name = "comboBoxPayMethod";
            this.comboBoxPayMethod.Size = new System.Drawing.Size(120, 21);
            this.comboBoxPayMethod.Sorted = true;
            this.comboBoxPayMethod.TabIndex = 29;
            // 
            // textBoxRateConversion
            // 
            this.textBoxRateConversion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxRateConversion.Location = new System.Drawing.Point(152, 174);
            this.textBoxRateConversion.Name = "textBoxRateConversion";
            this.textBoxRateConversion.Size = new System.Drawing.Size(120, 20);
            this.textBoxRateConversion.TabIndex = 26;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(16, 56);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(66, 13);
            this.label9.TabIndex = 23;
            this.label9.Text = "Amount paid";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "dd/MM/yyyy";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(152, 14);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(120, 20);
            this.dateTimePicker1.TabIndex = 20;
            // 
            // comboBoxCurrency
            // 
            this.comboBoxCurrency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCurrency.FormattingEnabled = true;
            this.comboBoxCurrency.Items.AddRange(new object[] {
            "DIN",
            "EUR",
            "GBP",
            "USD"});
            this.comboBoxCurrency.Location = new System.Drawing.Point(152, 94);
            this.comboBoxCurrency.Name = "comboBoxCurrency";
            this.comboBoxCurrency.Size = new System.Drawing.Size(120, 21);
            this.comboBoxCurrency.Sorted = true;
            this.comboBoxCurrency.TabIndex = 28;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(16, 136);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(86, 13);
            this.label11.TabIndex = 25;
            this.label11.Text = "Payment method";
            // 
            // checkBoxContraRate
            // 
            this.checkBoxContraRate.AutoSize = true;
            this.checkBoxContraRate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBoxContraRate.Location = new System.Drawing.Point(16, 296);
            this.checkBoxContraRate.Name = "checkBoxContraRate";
            this.checkBoxContraRate.Size = new System.Drawing.Size(75, 17);
            this.checkBoxContraRate.TabIndex = 35;
            this.checkBoxContraRate.Text = "Contra rate";
            this.checkBoxContraRate.UseVisualStyleBackColor = true;
            // 
            // AddRateButton
            // 
            this.AddRateButton.Location = new System.Drawing.Point(336, 360);
            this.AddRateButton.Name = "AddRateButton";
            this.AddRateButton.Size = new System.Drawing.Size(75, 39);
            this.AddRateButton.TabIndex = 36;
            this.AddRateButton.Text = "Add Rate";
            this.AddRateButton.UseVisualStyleBackColor = true;
            this.AddRateButton.Click += new System.EventHandler(this.AddRateButton_Click);
            // 
            // frmAddPaymentRate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(421, 414);
            this.Controls.Add(this.AddRateButton);
            this.Controls.Add(this.checkBoxContraRate);
            this.Controls.Add(this.comboBoxOriginalCurr);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.textBoxRateNote);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBoxAmountPaid);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.comboBoxPayMethod);
            this.Controls.Add(this.textBoxRateConversion);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.comboBoxCurrency);
            this.Controls.Add(this.label11);
            this.MaximizeBox = false;
            this.Name = "frmAddPaymentRate";
            this.Text = "Add Payment Rate";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxOriginalCurr;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox textBoxRateNote;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxAmountPaid;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox comboBoxPayMethod;
        private System.Windows.Forms.TextBox textBoxRateConversion;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.ComboBox comboBoxCurrency;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.CheckBox checkBoxContraRate;
        private System.Windows.Forms.Button AddRateButton;
    }
}