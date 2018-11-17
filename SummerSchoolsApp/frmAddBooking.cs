using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SummerSchoolsApp.DBBroker;
using System.Collections;
using System.Globalization;
using System.Threading;

namespace SummerSchoolsApp
{
    public partial class frmAddBooking : Form
    {
        Broker broker;
        DbUtil dbUtil;

        int contactNum;
        DataSet ds;
        decimal TotalAmount;
        ArrayList ItemList;
        BookingItems item;
        int m_contact;

        string noProductSelectedNotice = "<no product selected>";



        public frmAddBooking(int contactNumber)
        {
            InitializeComponent();

            broker = new Broker();
            dbUtil = new DbUtil();

            TotalAmount = 0;

            ItemList = new ArrayList();

            ds = broker.ReturnProductInfo();
            ArrayList productList = new ArrayList();
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                productList.Add(row["ProductName"]);
            }
            
            comboBoxProducts.Items.Add(noProductSelectedNotice);
            foreach (string productName in productList)
            {
                comboBoxProducts.Items.Add(productName);
            }
            comboBoxProducts.SelectedIndex = 0;

            comboBoxBookingType.SelectedIndex = 0;

            this.m_contact = contactNumber;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string productName = comboBoxProducts.Text;

            if (productName.Equals(string.Empty) ||
                productName.Equals(noProductSelectedNotice))
            {
                MessageBox.Show("You must choose a product!");
            }
   
            if (this.StartDatePicker.Value >= this.ReturnDatePicker.Value)
            {
                MessageBox.Show("Please check the start and return date!");
            }
            else
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    if (dr["ProductName"].ToString() == productName)
                    {
                        object[] parameters = new object[8];
                        parameters[0] = dr["ProductName"].ToString();
                        parameters[1] = dr["ProductPrice"].ToString();

                        if (textBoxDiscount.Text == string.Empty)
                        {
                            parameters[2] = 0.00;
                        }
                        else
                        {
                            parameters[2] = Convert.ToDecimal(textBoxDiscount.Text);
                        }

                        string startDateStrShort = dbUtil.FormatDate(this.StartDatePicker.Value);
                        string endDateStrShort = dbUtil.FormatDate(this.ReturnDatePicker.Value);

                        parameters[3] = startDateStrShort;
                        parameters[4] = this.mtbDepartureTime.Text;
                        parameters[5] = endDateStrShort;
                        parameters[6] = this.mtbArrivalTime.Text;
                        parameters[7] = this.textBoxNote.Text;

                        item = new BookingItems();
                        item.ItemName = dr["ProductName"].ToString();
                        item.StartDate = startDateStrShort;
                        item.ReturnDate = endDateStrShort;
                        item.ItemPrice = Convert.ToDecimal(dr["ProductPrice"].ToString());
                        item.ItemProvider = dr["ProductProvider"].ToString();
                        item.ArrivalTime = this.mtbArrivalTime.Text;
                        item.DepartueTime = this.mtbDepartureTime.Text;
                        item.BookingNote = this.textBoxNote.Text;
                        item.ItemType = dr["ProductType"].ToString();

                        if (item.ItemType.Equals("Course")) 
                        {
                            PaymentDeadlineDatePicker.Value = StartDatePicker.Value.AddDays(-14);
                        }

                        if (textBoxDiscount.Text == string.Empty)
                        {
                            item.Discount = 0;
                        }
                        else
                        {
                            item.Discount = Convert.ToDecimal(textBoxDiscount.Text);
                        }
                        
                        item.VersionCode = 1;

                        dataGridView1.Rows.Add(parameters);

                        ItemList.Add(item);

                        decimal discountedPrice = item.ItemPrice - item.Discount;
                        TotalAmount += discountedPrice;
                        this.textBoxTotalPrice.Text = TotalAmount.ToString();
                    }
                }
                comboBoxProducts.ResetText();
                comboBoxProducts.SelectedIndex = 0;
                textBoxDiscount.Clear();
                mtbDepartureTime.Clear();
                mtbArrivalTime.Clear();
                textBoxNote.Clear();
                textBoxDiscount.Text = "0.00";
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.dataGridView1.Rows.Clear();
            this.textBoxTotalPrice.Text = "0";
            this.TotalAmount = 0;
            this.ItemList.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.Rows.Count > 0)
                {
                    //ADDING NEW BOOKING
                    Booking booking = new Booking();

                    int lastContact = m_contact;

                    booking.ContactNumber = lastContact;

                    string bookingDateStrShort = dbUtil.FormatDate(System.DateTime.Now.Date);
                    string paymentDeadlineStrShort = dbUtil.FormatDate(this.PaymentDeadlineDatePicker.Value);

                    booking.DateOfBooking = bookingDateStrShort; 
                    booking.TotalPrice = Convert.ToDecimal(textBoxTotalPrice.Text);
                    booking.PaymentDeadline = paymentDeadlineStrShort; 
                    booking.OutstandingBalance = booking.TotalPrice;
                    booking.Active = "yes";
                    booking.IsCancelled = "no";
                    booking.IsBooked = "no";

                    if (VisaCheckBox.Checked == true)
                    {
                        booking.RequiresVisa = "yes";

                    }
                    else
                    {
                        booking.RequiresVisa = "no";
                    }

                    if (VisaApointmentScheduledCheckBox.Checked == true)
                    {
                        booking.VisaAppointmentScheduled = "yes";
                        booking.DateOfAppointment = dbUtil.FormatDate(this.VisaDatePicker.Value);
                        booking.TimeOfAppointment = VisaTimeTextBox.Text;
                    }
                    else
                    {
                        booking.VisaAppointmentScheduled = "no";
                        booking.DateOfAppointment = null;
                        booking.TimeOfAppointment = null;
                    }

                    booking.VisaDocumentsObtained = "no";

                    booking.BookingType = comboBoxBookingType.Text;

                    booking.VersionCode = 1;

                    int result2 = broker.InsertBooking(booking);

                    if (result2 != 13)
                    {

                        int lastBooking = broker.GetLastBookingRecord();

                        string BookingCode = "B" + booking.DateOfBooking + lastBooking.ToString().PadLeft(5, '0');
                        BookingCode = BookingCode.Replace("/", "");
                        broker.updateBookingCode(lastBooking, BookingCode);

                        //ADDING BOOKING ITEMS
                        if (lastBooking != 0)
                        {

                            foreach (BookingItems item in ItemList)
                            {
                                item.ItemNumber = 0;
                                item.BookingNumber = lastBooking;
                                broker.InsertItem(item);
                            }

                            MessageBox.Show("New booking added!");
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Unable to get the information from the server! Booking cannot be saved at this time!");
                            broker.DeleteBooking(lastBooking);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Database error!");
                    }
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int curr = dataGridView1.CurrentRow.Index;

            DataGridViewRow selectedRow = dataGridView1.CurrentRow;
            Decimal price = Convert.ToDecimal(selectedRow.Cells[1].Value.ToString());
            Decimal discount = Convert.ToDecimal(selectedRow.Cells[2].Value.ToString());

            ItemList.RemoveAt(curr);

            dataGridView1.Rows.Remove(selectedRow);
            decimal finalPrice = price - discount;
            this.TotalAmount -= finalPrice;

            this.textBoxTotalPrice.Text = TotalAmount.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                Decimal specialDiscount = Convert.ToDecimal(textBoxSpecialDiscount.Text);
                if (specialDiscount > TotalAmount || ItemList.Count == 0)
                {
                    MessageBox.Show("Special discount is too high or the booking contains no items!");
                }
                else
                {
                    string startDateStrShort = dbUtil.FormatDate(this.StartDatePicker.Value);
                    string endDateStrShort = dbUtil.FormatDate(this.ReturnDatePicker.Value);

                    object[] parameters = new object[8];
                    parameters[0] = "Special discount";
                    parameters[1] = 0.00;
                    parameters[2] = textBoxSpecialDiscount.Text; ;
                    parameters[3] = startDateStrShort;
                    parameters[4] = endDateStrShort;
                    parameters[5] = null;
                    parameters[6] = null;
                    parameters[7] = textBoxDiscountNote.Text;

                    item = new BookingItems();
                    item.ItemName = "Special discount";
                    item.StartDate = dbUtil.FormatDate(this.StartDatePicker.Value);
                    item.ReturnDate = dbUtil.FormatDate(this.ReturnDatePicker.Value);
                    item.ItemPrice = 0;
                    item.Discount = Convert.ToDecimal(textBoxSpecialDiscount.Text);
                    item.ItemProvider = null;
                    item.ArrivalTime = null;
                    item.DepartueTime = null;
                    item.BookingNote = this.textBoxDiscountNote.Text;
                    item.ItemType = "Special discount";
                    item.VersionCode = 1;

                    ItemList.Add(item);

                    dataGridView1.Rows.Add(parameters);
                    decimal discountedPrice = item.ItemPrice - item.Discount;
                    TotalAmount += discountedPrice;
                    this.textBoxTotalPrice.Text = TotalAmount.ToString();
                }
            }
            catch (System.FormatException)
            {
                MessageBox.Show("Please check the special discount! It must be a decimal value!");
            }

            
        }
    }
}
