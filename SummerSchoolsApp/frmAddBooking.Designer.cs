namespace SummerSchoolsApp
{
    partial class frmAddBooking
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddBooking));
            this.mtbDepartureTime = new System.Windows.Forms.MaskedTextBox();
            this.mtbArrivalTime = new System.Windows.Forms.MaskedTextBox();
            this.VisaGroupBox = new System.Windows.Forms.GroupBox();
            this.VisaTimeTextBox = new System.Windows.Forms.MaskedTextBox();
            this.label34 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.VisaDatePicker = new System.Windows.Forms.DateTimePicker();
            this.VisaApointmentScheduledCheckBox = new System.Windows.Forms.CheckBox();
            this.button7 = new System.Windows.Forms.Button();
            this.comboBoxProducts = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Product = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Discount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StartDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DepartureDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReturnDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ArrivalDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemNote = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VisaCheckBox = new System.Windows.Forms.CheckBox();
            this.label32 = new System.Windows.Forms.Label();
            this.textBoxTotalPrice = new System.Windows.Forms.TextBox();
            this.label31 = new System.Windows.Forms.Label();
            this.PaymentDeadlineDatePicker = new System.Windows.Forms.DateTimePicker();
            this.button4 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxBookingType = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.textBoxNote = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.textBoxDiscount = new System.Windows.Forms.TextBox();
            this.ReturnDatePicker = new System.Windows.Forms.DateTimePicker();
            this.label30 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.StartDatePicker = new System.Windows.Forms.DateTimePicker();
            this.label38 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxSpecialDiscount = new System.Windows.Forms.TextBox();
            this.textBoxDiscountNote = new System.Windows.Forms.TextBox();
            this.VisaGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // mtbDepartureTime
            // 
            this.mtbDepartureTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mtbDepartureTime.Location = new System.Drawing.Point(296, 95);
            this.mtbDepartureTime.Mask = "00:00";
            this.mtbDepartureTime.Name = "mtbDepartureTime";
            this.mtbDepartureTime.Size = new System.Drawing.Size(120, 20);
            this.mtbDepartureTime.TabIndex = 82;
            this.mtbDepartureTime.ValidatingType = typeof(System.DateTime);
            // 
            // mtbArrivalTime
            // 
            this.mtbArrivalTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mtbArrivalTime.Location = new System.Drawing.Point(442, 96);
            this.mtbArrivalTime.Mask = "00:00";
            this.mtbArrivalTime.Name = "mtbArrivalTime";
            this.mtbArrivalTime.Size = new System.Drawing.Size(120, 20);
            this.mtbArrivalTime.TabIndex = 81;
            this.mtbArrivalTime.ValidatingType = typeof(System.DateTime);
            // 
            // VisaGroupBox
            // 
            this.VisaGroupBox.Controls.Add(this.VisaTimeTextBox);
            this.VisaGroupBox.Controls.Add(this.label34);
            this.VisaGroupBox.Controls.Add(this.label33);
            this.VisaGroupBox.Controls.Add(this.VisaDatePicker);
            this.VisaGroupBox.Controls.Add(this.VisaApointmentScheduledCheckBox);
            this.VisaGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VisaGroupBox.Location = new System.Drawing.Point(16, 426);
            this.VisaGroupBox.Name = "VisaGroupBox";
            this.VisaGroupBox.Size = new System.Drawing.Size(288, 140);
            this.VisaGroupBox.TabIndex = 76;
            this.VisaGroupBox.TabStop = false;
            this.VisaGroupBox.Text = "Visa information";
            // 
            // VisaTimeTextBox
            // 
            this.VisaTimeTextBox.Location = new System.Drawing.Point(152, 72);
            this.VisaTimeTextBox.Mask = "00:00";
            this.VisaTimeTextBox.Name = "VisaTimeTextBox";
            this.VisaTimeTextBox.Size = new System.Drawing.Size(120, 20);
            this.VisaTimeTextBox.TabIndex = 6;
            this.VisaTimeTextBox.ValidatingType = typeof(System.DateTime);
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(152, 56);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(103, 13);
            this.label34.TabIndex = 5;
            this.label34.Text = "Time of appointment";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(8, 56);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(103, 13);
            this.label33.TabIndex = 3;
            this.label33.Text = "Date of appointment";
            // 
            // VisaDatePicker
            // 
            this.VisaDatePicker.CustomFormat = "dd/MM/yyyy";
            this.VisaDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.VisaDatePicker.Location = new System.Drawing.Point(8, 72);
            this.VisaDatePicker.Name = "VisaDatePicker";
            this.VisaDatePicker.Size = new System.Drawing.Size(128, 20);
            this.VisaDatePicker.TabIndex = 1;
            // 
            // VisaApointmentScheduledCheckBox
            // 
            this.VisaApointmentScheduledCheckBox.AutoSize = true;
            this.VisaApointmentScheduledCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.VisaApointmentScheduledCheckBox.Location = new System.Drawing.Point(8, 24);
            this.VisaApointmentScheduledCheckBox.Name = "VisaApointmentScheduledCheckBox";
            this.VisaApointmentScheduledCheckBox.Size = new System.Drawing.Size(163, 17);
            this.VisaApointmentScheduledCheckBox.TabIndex = 0;
            this.VisaApointmentScheduledCheckBox.Text = "VISA Appointment Scheduled";
            this.VisaApointmentScheduledCheckBox.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button7.Location = new System.Drawing.Point(758, 209);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(90, 24);
            this.button7.TabIndex = 73;
            this.button7.Text = "Clear items";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // comboBoxProducts
            // 
            this.comboBoxProducts.BackColor = System.Drawing.SystemColors.Window;
            this.comboBoxProducts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxProducts.FormattingEnabled = true;
            this.comboBoxProducts.Location = new System.Drawing.Point(8, 40);
            this.comboBoxProducts.Name = "comboBoxProducts";
            this.comboBoxProducts.Size = new System.Drawing.Size(554, 21);
            this.comboBoxProducts.Sorted = true;
            this.comboBoxProducts.TabIndex = 72;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Product,
            this.Price,
            this.Discount,
            this.StartDate,
            this.DepartureDate,
            this.ReturnDate,
            this.ArrivalDate,
            this.ItemNote});
            this.dataGridView1.Location = new System.Drawing.Point(8, 239);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(840, 136);
            this.dataGridView1.TabIndex = 71;
            // 
            // Product
            // 
            this.Product.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Product.HeaderText = "Product";
            this.Product.Name = "Product";
            this.Product.ReadOnly = true;
            this.Product.Width = 105;
            // 
            // Price
            // 
            this.Price.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Price.HeaderText = "Price";
            this.Price.Name = "Price";
            this.Price.ReadOnly = true;
            this.Price.Width = 70;
            // 
            // Discount
            // 
            this.Discount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Discount.HeaderText = "Discount";
            this.Discount.Name = "Discount";
            this.Discount.ReadOnly = true;
            this.Discount.Width = 70;
            // 
            // StartDate
            // 
            this.StartDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.StartDate.HeaderText = "Start Date";
            this.StartDate.Name = "StartDate";
            this.StartDate.ReadOnly = true;
            this.StartDate.Width = 105;
            // 
            // DepartureDate
            // 
            this.DepartureDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.DepartureDate.HeaderText = "Departure time";
            this.DepartureDate.Name = "DepartureDate";
            this.DepartureDate.ReadOnly = true;
            this.DepartureDate.Width = 105;
            // 
            // ReturnDate
            // 
            this.ReturnDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ReturnDate.HeaderText = "Return Date";
            this.ReturnDate.Name = "ReturnDate";
            this.ReturnDate.ReadOnly = true;
            this.ReturnDate.Width = 105;
            // 
            // ArrivalDate
            // 
            this.ArrivalDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ArrivalDate.HeaderText = "Return time";
            this.ArrivalDate.Name = "ArrivalDate";
            this.ArrivalDate.ReadOnly = true;
            this.ArrivalDate.Width = 105;
            // 
            // ItemNote
            // 
            this.ItemNote.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ItemNote.HeaderText = "Note";
            this.ItemNote.Name = "ItemNote";
            this.ItemNote.ReadOnly = true;
            this.ItemNote.Width = 104;
            // 
            // VisaCheckBox
            // 
            this.VisaCheckBox.AutoSize = true;
            this.VisaCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.VisaCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VisaCheckBox.Location = new System.Drawing.Point(16, 403);
            this.VisaCheckBox.Name = "VisaCheckBox";
            this.VisaCheckBox.Size = new System.Drawing.Size(92, 17);
            this.VisaCheckBox.TabIndex = 77;
            this.VisaCheckBox.Text = "Requires VISA";
            this.VisaCheckBox.UseVisualStyleBackColor = true;
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label32.Location = new System.Drawing.Point(165, 572);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(57, 13);
            this.label32.TabIndex = 75;
            this.label32.Text = "Total price";
            // 
            // textBoxTotalPrice
            // 
            this.textBoxTotalPrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxTotalPrice.Location = new System.Drawing.Point(168, 588);
            this.textBoxTotalPrice.Name = "textBoxTotalPrice";
            this.textBoxTotalPrice.ReadOnly = true;
            this.textBoxTotalPrice.Size = new System.Drawing.Size(128, 20);
            this.textBoxTotalPrice.TabIndex = 74;
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label31.Location = new System.Drawing.Point(23, 572);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(91, 13);
            this.label31.TabIndex = 73;
            this.label31.Text = "Payment deadline";
            // 
            // PaymentDeadlineDatePicker
            // 
            this.PaymentDeadlineDatePicker.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PaymentDeadlineDatePicker.CalendarMonthBackground = System.Drawing.Color.White;
            this.PaymentDeadlineDatePicker.CustomFormat = "dd/MM/yyyy";
            this.PaymentDeadlineDatePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PaymentDeadlineDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.PaymentDeadlineDatePicker.Location = new System.Drawing.Point(26, 588);
            this.PaymentDeadlineDatePicker.Name = "PaymentDeadlineDatePicker";
            this.PaymentDeadlineDatePicker.Size = new System.Drawing.Size(128, 20);
            this.PaymentDeadlineDatePicker.TabIndex = 72;
            // 
            // button4
            // 
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(569, 209);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(90, 24);
            this.button4.TabIndex = 70;
            this.button4.Text = "Add product";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.comboBoxBookingType);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.textBoxNote);
            this.groupBox1.Controls.Add(this.label26);
            this.groupBox1.Controls.Add(this.label27);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.mtbDepartureTime);
            this.groupBox1.Controls.Add(this.mtbArrivalTime);
            this.groupBox1.Controls.Add(this.textBoxDiscount);
            this.groupBox1.Controls.Add(this.ReturnDatePicker);
            this.groupBox1.Controls.Add(this.button7);
            this.groupBox1.Controls.Add(this.label30);
            this.groupBox1.Controls.Add(this.comboBoxProducts);
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Controls.Add(this.label28);
            this.groupBox1.Controls.Add(this.label29);
            this.groupBox1.Controls.Add(this.StartDatePicker);
            this.groupBox1.Controls.Add(this.label38);
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(16, 16);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(856, 381);
            this.groupBox1.TabIndex = 71;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Product details";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(590, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 89;
            this.label1.Text = "Booking type";
            // 
            // comboBoxBookingType
            // 
            this.comboBoxBookingType.BackColor = System.Drawing.SystemColors.Window;
            this.comboBoxBookingType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxBookingType.FormattingEnabled = true;
            this.comboBoxBookingType.Items.AddRange(new object[] {
            "Kopaonik",
            "Malta",
            "Service",
            "UK"});
            this.comboBoxBookingType.Location = new System.Drawing.Point(586, 40);
            this.comboBoxBookingType.Name = "comboBoxBookingType";
            this.comboBoxBookingType.Size = new System.Drawing.Size(262, 21);
            this.comboBoxBookingType.Sorted = true;
            this.comboBoxBookingType.TabIndex = 88;
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(665, 209);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(87, 23);
            this.button2.TabIndex = 87;
            this.button2.Text = "Delete item";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBoxNote
            // 
            this.textBoxNote.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxNote.Location = new System.Drawing.Point(586, 95);
            this.textBoxNote.Name = "textBoxNote";
            this.textBoxNote.Size = new System.Drawing.Size(262, 20);
            this.textBoxNote.TabIndex = 86;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(439, 80);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(61, 13);
            this.label26.TabIndex = 84;
            this.label26.Text = "Return time";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(296, 79);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(76, 13);
            this.label27.TabIndex = 83;
            this.label27.Text = "Departure time";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(583, 80);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(82, 13);
            this.label15.TabIndex = 85;
            this.label15.Text = "Additional notes";
            // 
            // textBoxDiscount
            // 
            this.textBoxDiscount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxDiscount.Location = new System.Drawing.Point(11, 147);
            this.textBoxDiscount.Name = "textBoxDiscount";
            this.textBoxDiscount.Size = new System.Drawing.Size(121, 20);
            this.textBoxDiscount.TabIndex = 80;
            this.textBoxDiscount.Text = "0.00";
            // 
            // ReturnDatePicker
            // 
            this.ReturnDatePicker.CustomFormat = "dd/MM/yyyy";
            this.ReturnDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.ReturnDatePicker.Location = new System.Drawing.Point(152, 95);
            this.ReturnDatePicker.Name = "ReturnDatePicker";
            this.ReturnDatePicker.Size = new System.Drawing.Size(120, 20);
            this.ReturnDatePicker.TabIndex = 79;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(149, 79);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(63, 13);
            this.label30.TabIndex = 78;
            this.label30.Text = "Return date";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.Location = new System.Drawing.Point(8, 80);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(53, 13);
            this.label28.TabIndex = 77;
            this.label28.Text = "Start date";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.Location = new System.Drawing.Point(8, 24);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(73, 13);
            this.label29.TabIndex = 74;
            this.label29.Text = "Product name";
            // 
            // StartDatePicker
            // 
            this.StartDatePicker.CustomFormat = "dd/MM/yyyy";
            this.StartDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.StartDatePicker.Location = new System.Drawing.Point(11, 96);
            this.StartDatePicker.Name = "StartDatePicker";
            this.StartDatePicker.Size = new System.Drawing.Size(120, 20);
            this.StartDatePicker.TabIndex = 76;
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label38.Location = new System.Drawing.Point(8, 131);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(87, 13);
            this.label38.TabIndex = 75;
            this.label38.Text = "Product discount";
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(768, 588);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(91, 39);
            this.button1.TabIndex = 78;
            this.button1.Text = "Save booking";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button3);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.textBoxSpecialDiscount);
            this.groupBox2.Controls.Add(this.textBoxDiscountNote);
            this.groupBox2.Location = new System.Drawing.Point(316, 426);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(548, 140);
            this.groupBox2.TabIndex = 79;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Special discount";
            // 
            // button3
            // 
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Location = new System.Drawing.Point(441, 91);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(90, 23);
            this.button3.TabIndex = 4;
            this.button3.Text = "Add";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Discounted amount";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Reason for discount";
            // 
            // textBoxSpecialDiscount
            // 
            this.textBoxSpecialDiscount.Location = new System.Drawing.Point(13, 94);
            this.textBoxSpecialDiscount.Name = "textBoxSpecialDiscount";
            this.textBoxSpecialDiscount.Size = new System.Drawing.Size(249, 20);
            this.textBoxSpecialDiscount.TabIndex = 1;
            // 
            // textBoxDiscountNote
            // 
            this.textBoxDiscountNote.Location = new System.Drawing.Point(16, 49);
            this.textBoxDiscountNote.Name = "textBoxDiscountNote";
            this.textBoxDiscountNote.Size = new System.Drawing.Size(246, 20);
            this.textBoxDiscountNote.TabIndex = 0;
            // 
            // frmAddBooking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 641);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.VisaGroupBox);
            this.Controls.Add(this.VisaCheckBox);
            this.Controls.Add(this.label32);
            this.Controls.Add(this.textBoxTotalPrice);
            this.Controls.Add(this.label31);
            this.Controls.Add(this.PaymentDeadlineDatePicker);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmAddBooking";
            this.Text = "Add Bookings";
            this.VisaGroupBox.ResumeLayout(false);
            this.VisaGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MaskedTextBox mtbDepartureTime;
        private System.Windows.Forms.MaskedTextBox mtbArrivalTime;
        private System.Windows.Forms.GroupBox VisaGroupBox;
        private System.Windows.Forms.MaskedTextBox VisaTimeTextBox;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.DateTimePicker VisaDatePicker;
        private System.Windows.Forms.CheckBox VisaApointmentScheduledCheckBox;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.ComboBox comboBoxProducts;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.CheckBox VisaCheckBox;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.TextBox textBoxTotalPrice;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.DateTimePicker PaymentDeadlineDatePicker;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.TextBox textBoxDiscount;
        private System.Windows.Forms.DateTimePicker ReturnDatePicker;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.DateTimePicker StartDatePicker;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBoxNote;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxBookingType;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxSpecialDiscount;
        private System.Windows.Forms.TextBox textBoxDiscountNote;
        private System.Windows.Forms.DataGridViewTextBoxColumn Product;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn Discount;
        private System.Windows.Forms.DataGridViewTextBoxColumn StartDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn DepartureDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReturnDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ArrivalDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemNote;
    }
}