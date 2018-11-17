namespace SummerSchoolsApp
{
    partial class ControlBookingInformation
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ContactName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BookingCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BookingStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OutstandingBalance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedHorizontal;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ContactName,
            this.BookingCode,
            this.BookingStatus,
            this.TotalPrice,
            this.OutstandingBalance});
            this.dataGridView1.Location = new System.Drawing.Point(21, 49);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(805, 228);
            this.dataGridView1.TabIndex = 0;
            // 
            // ContactName
            // 
            this.ContactName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ContactName.HeaderText = "Contact Name";
            this.ContactName.Name = "ContactName";
            // 
            // BookingCode
            // 
            this.BookingCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.BookingCode.HeaderText = "Booking Code";
            this.BookingCode.Name = "BookingCode";
            // 
            // BookingStatus
            // 
            this.BookingStatus.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.BookingStatus.HeaderText = "Booking Status";
            this.BookingStatus.Name = "BookingStatus";
            // 
            // TotalPrice
            // 
            this.TotalPrice.HeaderText = "Total Price";
            this.TotalPrice.Name = "TotalPrice";
            // 
            // OutstandingBalance
            // 
            this.OutstandingBalance.HeaderText = "Outst. Balance";
            this.OutstandingBalance.Name = "OutstandingBalance";
            // 
            // BookingInformationControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGridView1);
            this.Name = "BookingInformationControl";
            this.Size = new System.Drawing.Size(846, 399);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ContactName;
        private System.Windows.Forms.DataGridViewTextBoxColumn BookingCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn BookingStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn OutstandingBalance;
    }
}
