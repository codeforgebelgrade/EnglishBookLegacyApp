namespace SummerSchoolsApp
{
    partial class frmAddItemToBooking
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
            this.checkBoxContra = new System.Windows.Forms.CheckBox();
            this.textBoxNote = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.mtbDepartureTime = new System.Windows.Forms.MaskedTextBox();
            this.mtbArrivalTime = new System.Windows.Forms.MaskedTextBox();
            this.textBoxDiscount = new System.Windows.Forms.TextBox();
            this.ReturnDatePicker = new System.Windows.Forms.DateTimePicker();
            this.label30 = new System.Windows.Forms.Label();
            this.comboBoxProducts = new System.Windows.Forms.ComboBox();
            this.label28 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.StartDatePicker = new System.Windows.Forms.DateTimePicker();
            this.label38 = new System.Windows.Forms.Label();
            this.AddItemToBookingButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // checkBoxContra
            // 
            this.checkBoxContra.AutoSize = true;
            this.checkBoxContra.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBoxContra.Location = new System.Drawing.Point(8, 272);
            this.checkBoxContra.Name = "checkBoxContra";
            this.checkBoxContra.Size = new System.Drawing.Size(80, 17);
            this.checkBoxContra.TabIndex = 133;
            this.checkBoxContra.Text = "Contra entry";
            this.checkBoxContra.UseVisualStyleBackColor = true;
            // 
            // textBoxNote
            // 
            this.textBoxNote.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxNote.Location = new System.Drawing.Point(8, 224);
            this.textBoxNote.Name = "textBoxNote";
            this.textBoxNote.Size = new System.Drawing.Size(352, 20);
            this.textBoxNote.TabIndex = 120;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(8, 208);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(82, 13);
            this.label15.TabIndex = 119;
            this.label15.Text = "Additional notes";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(192, 144);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(61, 13);
            this.label26.TabIndex = 132;
            this.label26.Text = "Return time";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(8, 144);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(76, 13);
            this.label27.TabIndex = 131;
            this.label27.Text = "Departure time";
            // 
            // mtbDepartureTime
            // 
            this.mtbDepartureTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mtbDepartureTime.Location = new System.Drawing.Point(192, 160);
            this.mtbDepartureTime.Mask = "00:00";
            this.mtbDepartureTime.Name = "mtbDepartureTime";
            this.mtbDepartureTime.Size = new System.Drawing.Size(168, 20);
            this.mtbDepartureTime.TabIndex = 130;
            this.mtbDepartureTime.ValidatingType = typeof(System.DateTime);
            // 
            // mtbArrivalTime
            // 
            this.mtbArrivalTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mtbArrivalTime.Location = new System.Drawing.Point(8, 160);
            this.mtbArrivalTime.Mask = "00:00";
            this.mtbArrivalTime.Name = "mtbArrivalTime";
            this.mtbArrivalTime.Size = new System.Drawing.Size(168, 20);
            this.mtbArrivalTime.TabIndex = 129;
            this.mtbArrivalTime.ValidatingType = typeof(System.DateTime);
            // 
            // textBoxDiscount
            // 
            this.textBoxDiscount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxDiscount.Location = new System.Drawing.Point(376, 32);
            this.textBoxDiscount.Name = "textBoxDiscount";
            this.textBoxDiscount.Size = new System.Drawing.Size(120, 20);
            this.textBoxDiscount.TabIndex = 128;
            this.textBoxDiscount.Text = "0.00";
            // 
            // ReturnDatePicker
            // 
            this.ReturnDatePicker.CustomFormat = "dd/MM/yyyy";
            this.ReturnDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.ReturnDatePicker.Location = new System.Drawing.Point(192, 96);
            this.ReturnDatePicker.Name = "ReturnDatePicker";
            this.ReturnDatePicker.Size = new System.Drawing.Size(168, 20);
            this.ReturnDatePicker.TabIndex = 127;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(192, 80);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(63, 13);
            this.label30.TabIndex = 126;
            this.label30.Text = "Return date";
            // 
            // comboBoxProducts
            // 
            this.comboBoxProducts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxProducts.FormattingEnabled = true;
            this.comboBoxProducts.Location = new System.Drawing.Point(8, 32);
            this.comboBoxProducts.Name = "comboBoxProducts";
            this.comboBoxProducts.Size = new System.Drawing.Size(352, 21);
            this.comboBoxProducts.Sorted = true;
            this.comboBoxProducts.TabIndex = 121;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.Location = new System.Drawing.Point(8, 80);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(53, 13);
            this.label28.TabIndex = 125;
            this.label28.Text = "Start date";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.Location = new System.Drawing.Point(8, 16);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(73, 13);
            this.label29.TabIndex = 122;
            this.label29.Text = "Product name";
            // 
            // StartDatePicker
            // 
            this.StartDatePicker.CustomFormat = "dd/MM/yyyy";
            this.StartDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.StartDatePicker.Location = new System.Drawing.Point(8, 96);
            this.StartDatePicker.Name = "StartDatePicker";
            this.StartDatePicker.Size = new System.Drawing.Size(168, 20);
            this.StartDatePicker.TabIndex = 124;
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label38.Location = new System.Drawing.Point(376, 16);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(49, 13);
            this.label38.TabIndex = 123;
            this.label38.Text = "Discount";
            // 
            // AddItemToBookingButton
            // 
            this.AddItemToBookingButton.Location = new System.Drawing.Point(416, 320);
            this.AddItemToBookingButton.Name = "AddItemToBookingButton";
            this.AddItemToBookingButton.Size = new System.Drawing.Size(80, 40);
            this.AddItemToBookingButton.TabIndex = 134;
            this.AddItemToBookingButton.Text = "button1";
            this.AddItemToBookingButton.UseVisualStyleBackColor = true;
            this.AddItemToBookingButton.Click += new System.EventHandler(this.AddItemToBookingButton_Click);
            // 
            // frmAddItemToBooking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(508, 373);
            this.Controls.Add(this.AddItemToBookingButton);
            this.Controls.Add(this.checkBoxContra);
            this.Controls.Add(this.textBoxNote);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.label27);
            this.Controls.Add(this.mtbDepartureTime);
            this.Controls.Add(this.mtbArrivalTime);
            this.Controls.Add(this.textBoxDiscount);
            this.Controls.Add(this.ReturnDatePicker);
            this.Controls.Add(this.label30);
            this.Controls.Add(this.comboBoxProducts);
            this.Controls.Add(this.label28);
            this.Controls.Add(this.label29);
            this.Controls.Add(this.StartDatePicker);
            this.Controls.Add(this.label38);
            this.Name = "frmAddItemToBooking";
            this.Text = "Add Items to Booking";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBoxContra;
        private System.Windows.Forms.TextBox textBoxNote;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.MaskedTextBox mtbDepartureTime;
        private System.Windows.Forms.MaskedTextBox mtbArrivalTime;
        private System.Windows.Forms.TextBox textBoxDiscount;
        private System.Windows.Forms.DateTimePicker ReturnDatePicker;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.ComboBox comboBoxProducts;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.DateTimePicker StartDatePicker;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.Button AddItemToBookingButton;
    }
}