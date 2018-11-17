using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SummerSchoolsApp.DBBroker;
using System.Collections;

namespace SummerSchoolsApp
{
    public partial class ControlBookings : UserControl
    {
        string bcode;
        Broker broker;
        DataSet ds;
        DataSet ds_products;
        decimal TotalAmount;
        ArrayList ItemList;
        ArrayList PaymentRates;
        ArrayList ItemsToRemove;
        ArrayList ItemsToAdd;
        List<PaymentRate> rateSynchronizerList;

        Booking booking;
        BookingItems item;
        PaymentRate rate;
        int itemCounter;
        int rateCounter;
        int numberOfBookingItems;
        bool clearAll;
        bool itemDeleted;
        DateTime DateOfBookingVal;
        DateTime PaymentDeadlineVal;
        decimal TotalOutstanding;
        bool itemsChanged;
        bool ratesAdded;
        bool InsertRatesOK;
        bool InsertItemsOK;
        int BookingVersionCode;
        int ItemVersionCode;
        int RateVersionCode;
        int CurrentBookingNumber;
        string CurrentBookingCode;
        string noProductSelectedNotice = "<no product selected>";
        Contract contract;
        bool contractInfoChnaged = false;

        DbUtil dbUtil;

        //-----------------------------------------------------------------------------------
        public ControlBookings(string bookingCode)
        {
            InitializeComponent();

            broker = new Broker();
            dbUtil = new DbUtil();

            PaymentRates = new ArrayList();
            ItemList = new ArrayList();
            ItemsToRemove = new ArrayList();
            ItemsToAdd = new ArrayList();
            rateSynchronizerList = new List<PaymentRate>();

            this.panel1.Enabled = false;
            this.panel3.Enabled = false;
            this.panel5.Enabled = false;

            ds_products = broker.ReturnProductInfo();
            ArrayList productList = new ArrayList();
            foreach (DataRow row in ds_products.Tables[0].Rows)
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

            deadlineDatePicker.Enabled = false;
            textBoxCancellationReason.Enabled = false;

            itemsChanged = false;
            ratesAdded = false;

            TotalAmount = 0;
            TotalOutstanding = 0;
            rateCounter = 0;
            numberOfBookingItems = 0;
            this.bcode = bookingCode;
            clearAll = false;
            itemDeleted = false;
            cbBusNeeded.Visible = false;

            this.comboBoxBookingType.SelectedIndexChanged += new EventHandler(comboBoxBookingType_SelectedIndexChanged);

            //load the booking data and perform validations
            this.LoadBookingData();

            checkBoxNewDeadline.CheckedChanged += new EventHandler(checkBoxNewDeadline_CheckedChanged);
            checkBoxCancel.CheckedChanged += new EventHandler(checkBoxCancel_CheckedChanged);
            tbContractNumber.TextChanged += new EventHandler(ContractValueChanged);
            tbReceiptNumber.TextChanged += new EventHandler(ContractValueChanged);
            dtpContractDate.ValueChanged += new EventHandler(ContractValueChanged);
            dtpReceiptIssueDate.ValueChanged += new EventHandler(ContractReceiptDateChanged);
        }
        //-----------------------------------------------------------------------------------
        void comboBoxBookingType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxBookingType.Text.Equals("Kopaonik"))
            {
                cbBusNeeded.Visible = true;
                cbBusNeeded.Enabled = true;
            }
            else
            {
                cbBusNeeded.Visible = false;
                cbBusNeeded.Enabled = false;
                cbBusNeeded.Checked = false;
            }
        }
        //-----------------------------------------------------------------------------------
        void checkBoxCancel_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxCancel.Checked)
            {
                textBoxCancellationReason.Enabled = true;
                textBoxCancellationReason.Focus();
            }
            else
            {
                textBoxCancellationReason.Enabled = false;
            }
        }
        //-----------------------------------------------------------------------------------
        //checkbox_changed event
        void checkBoxNewDeadline_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxNewDeadline.Checked == true)
            {
                deadlineDatePicker.Enabled = true;
            }
            else
            {
                deadlineDatePicker.Enabled = false;
            }
        }
        //------------------------------------------------------------------------------------
        //add payment rate
        private void button2_Click(object sender, EventArgs e)
        {
            if (textBoxRateConversion.Text != "" && textBoxAmountPaid.Text != "" &&
                comboBoxCurrency.Text != "" && comboBoxPayMethod.Text != "" && comboBoxOriginalCurr.Text != "")
            {
                if (Convert.ToDecimal(textBoxAmountPaid.Text) < 0)
                {
                    MessageBox.Show("You cannot type negative values!");
                }
                else
                {
                    try
                    {
                        ratesAdded = true;
                        rateCounter++;
                        rate = new PaymentRate();
                        rate.RateNumber = rateCounter;
                        rate.BookingNumber = booking.BookingNumber;
                        if (checkBoxContraRate.Checked == true)
                        {
                            decimal contra_rate = -1 * Convert.ToDecimal(textBoxAmountPaid.Text);
                            rate.AmountPaid = contra_rate;
                        }
                        else
                        {
                            rate.AmountPaid = Convert.ToDecimal(textBoxAmountPaid.Text);
                        }
                        rate.Currency = comboBoxCurrency.Text;
                        rate.date = dbUtil.FormatDate(dateTimePicker1.Value);
                        rate.PaymentMethod = comboBoxPayMethod.Text;
                        rate.ConversionValue = Convert.ToDecimal(textBoxRateConversion.Text);
                        rate.RateNote = textBoxRateNote.Text;
                        rate.OriginalCurrency = comboBoxOriginalCurr.Text;
                        rate.VersionCode = 1;

                        if (rate.Currency != "GBP")
                        {
                            decimal convertedValue = rate.AmountPaid / rate.ConversionValue;
                            convertedValue = Math.Round(convertedValue, 2);
                            TotalOutstanding -= convertedValue;
                            rate.OriginalValue = convertedValue;
                            rate.VersionCode = 1;
                        }
                        else
                        {
                            TotalOutstanding -= rate.AmountPaid;
                            rate.OriginalValue = rate.AmountPaid;
                        }

                        PaymentRates.Add(rate);
                        rateSynchronizerList.Add(rate);

                        object[] parameters = new object[7];
                        parameters[0] = rate.AmountPaid;
                        parameters[1] = rate.Currency;
                        parameters[2] = rate.OriginalValue;
                        parameters[3] = rate.PaymentMethod;
                        parameters[4] = rate.ConversionValue;
                        parameters[5] = dbUtil.ChangeDateToSerbianFormat(rate.date);
                        parameters[6] = rate.RateNote;

                        dataGridView2.Rows.Add(parameters);
                        this.textBoxOutstanding.Text = TotalOutstanding.ToString();

                        textBoxAmountPaid.Clear();
                        comboBoxCurrency.ResetText();
                        comboBoxPayMethod.ResetText();
                        textBoxRateConversion.Clear();
                        textBoxRateNote.Clear();

                        if (checkBoxContraRate.Checked == true)
                        {
                            checkBoxContraRate.Checked = false;
                        }

                    }
                    catch (System.Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
            }
            else
            {
                MessageBox.Show("You must fill all required fields!");
            }
        }
        //-------------------------------------------------------------------------------------
        //save changes button
        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                if (ItemList.Count > 0)
                {
                    InsertItemsOK = true;
                    InsertRatesOK = true;

                    booking.TotalPrice = TotalAmount;

                    if (checkBoxNewDeadline.Checked == true)
                    {
                        booking.PaymentDeadline = dbUtil.FormatDate(deadlineDatePicker.Value);
                    }
                    else
                    {
                        booking.PaymentDeadline = dbUtil.FormatDate(PaymentDeadlineVal);
                    }

                    booking.OutstandingBalance = Convert.ToDecimal(textBoxOutstanding.Text);

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
                        booking.DateOfAppointment = dbUtil.FormatDate(VisaDatePicker.Value);
                        booking.TimeOfAppointment = VisaTimeTextBox.Text;
                    }
                    else
                    {
                        booking.VisaAppointmentScheduled = "no";
                        booking.DateOfAppointment = null;
                        booking.TimeOfAppointment = null;
                    }

                    if (checkBoxVisaObtained.Checked == true)
                    {
                        booking.VisaObtained = "yes";
                    }
                    else
                    {
                        booking.VisaObtained = "no";
                    }

                    if (checkBoxVisaReject.Checked == true)
                    {
                        booking.VisaRejected = "yes";
                    }
                    else
                    {
                        booking.VisaRejected = "no";
                    }

                    if (checkBoxBooked.Checked == true)
                    {
                        booking.IsBooked = "yes";
                    }
                    else
                    {
                        booking.IsBooked = "no";
                    }

                    if (checkBoxCancel.Checked == true)
                    {
                        booking.IsCancelled = "yes";
                        booking.ReasonForCancellation = textBoxCancellationReason.Text;
                        booking.CancellationDate = dbUtil.FormatDate(System.DateTime.Now);
                    }
                    else
                    {
                        booking.IsCancelled = "no";
                        booking.ReasonForCancellation = null;
                        booking.CancellationDate = null;
                    }

                    if (checkBoxVisaDocsSubmitted.Checked == true)
                    {
                        booking.VisaDocumentsObtained = "yes";
                    }
                    else
                    {
                        booking.VisaDocumentsObtained = "no";
                    }

                    if (this.textBoxGwf.Text.Trim().Equals(""))
                    {
                        booking.GWFnumber = null;
                    }
                    else
                    {
                        booking.GWFnumber = this.textBoxGwf.Text;
                    }
                    booking.DateOfBooking = dbUtil.FormatDate(DateOfBookingVal);

                    booking.BookingType = comboBoxBookingType.Text;

                    if (this.cbBusNeeded.Checked)
                    {
                        booking.BusNeeded = "Yes";
                    }
                    else
                    {
                        booking.BusNeeded = null;
                    }

                    DataSet ds_BookingCheck = broker.GetBookingByCode(CurrentBookingCode);

                    bool IsModified = false;

                    if (ds_BookingCheck.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow bookingRow in ds_BookingCheck.Tables[0].Rows)
                        {
                            if (Convert.ToInt32(bookingRow["VersionCode"]) == BookingVersionCode)
                            {
                                booking.VersionCode++;
                            }
                            else
                            {
                                IsModified = true;
                            }
                        }
                    }//go here if the booking is deleted
                    else
                    {
                        IsModified = true;
                    }

                    if (IsModified == false)
                    {
                        int bookingResult = broker.updateBookingById(booking);

                        if (bookingResult != 13)
                        {
                            if (itemsChanged == true)
                            {
                                broker.DeleteBookingItem(booking.BookingNumber);
                                //int i = 1;
                                foreach (BookingItems bi in ItemList)
                                {
                                    int bookingItemResult = broker.InsertItem(bi);

                                    if (bookingItemResult == 13)
                                    {
                                        InsertItemsOK = false;
                                        MessageBox.Show("Insert booking item failed. Please reload the booking!");
                                    }
                                }
                            }

                            if (ratesAdded == true)
                            {
                                foreach (PaymentRate pr in PaymentRates)
                                {
                                    int itemResult = broker.InsertPaymentRate(pr);
                                    if (itemResult == 13)
                                    {
                                        //error message
                                        MessageBox.Show("Insert rate failed! Reload the booking!");
                                        InsertRatesOK = false;
                                    }
                                }
                            }

                            if (InsertItemsOK == true && InsertRatesOK == true)
                            {
                                MessageBox.Show("Booking information sucessfully updated!");
                                this.Enabled = false;
                            }
                            else
                            {
                                MessageBox.Show("Error has been detected. Please reload the booking.");
                                this.Enabled = false;
                            }
                        }
                    }//if booking is modified, go here
                    else
                    {
                        MessageBox.Show("This booking has been modified by another user. Please reload the booking.");
                        this.Enabled = false;
                    }
                }
                else
                {
                    MessageBox.Show("This booking has no items or the Total Price/Outstanding Balance is negative. Please, make corrections!");
                }
            }//end try
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        //-------------------------------------------------------------------------------------
        //add items button
        private void button4_Click(object sender, EventArgs e)
        {
            string productName = comboBoxProducts.Text;

            if (productName == "" || productName.Equals(noProductSelectedNotice))
            {
                MessageBox.Show("You must choose a product!");
            }

            if (this.StartDatePicker.Value >= this.ReturnDatePicker.Value)
            {
                MessageBox.Show("Please change the dates!!");
            }
            else
            {
                itemsChanged = true;

                if (checkBoxContra.Checked == true && textBoxNote.Text == string.Empty)
                {
                    MessageBox.Show("You cannot add contra item without a note!!");
                }
                else
                {
                    foreach (DataRow dr in ds_products.Tables[0].Rows)
                    {
                        if (dr["ProductName"].ToString() == productName)
                        {
                            object[] parameters = new object[9];

                            parameters[0] = dr["ProductName"].ToString();

                            if (checkBoxContra.Checked == true)
                            {
                                decimal contra_amount = -1 * Convert.ToDecimal(dr["ProductPrice"]);
                                parameters[1] = contra_amount;
                            }
                            else
                            {
                                parameters[1] = Convert.ToDecimal(dr["ProductPrice"]);
                            }

                            if (textBoxDiscount.Text == string.Empty)
                            {
                                parameters[2] = Convert.ToDecimal(0.00);
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

                            itemCounter++;

                            dataGridView1.Rows.Add(parameters);

                            item = new BookingItems();

                            item.BookingNumber = booking.BookingNumber;
                            item.ItemName = dr["ProductName"].ToString();
                            item.StartDate = startDateStrShort;//this.StartDatePicker.Value.ToShortDateString();
                            item.ReturnDate = endDateStrShort;//this.ReturnDatePicker.Value.ToShortDateString();

                            if (checkBoxContra.Checked == true)
                            {
                                decimal contra_price = -1 * Convert.ToDecimal(dr["ProductPrice"].ToString());
                                item.ItemPrice = contra_price;
                            }
                            else
                            {
                                item.ItemPrice = Convert.ToDecimal(dr["ProductPrice"].ToString());
                            }

                            item.ItemProvider = dr["ProductProvider"].ToString();
                            item.ArrivalTime = this.mtbDepartureTime.Text;
                            item.DepartueTime = this.mtbArrivalTime.Text;
                            item.BookingNote = this.textBoxNote.Text;
                            item.ItemType = dr["ProductType"].ToString();

                            if (textBoxDiscount.Text == string.Empty)
                            {
                                item.Discount = 0;
                            }
                            else
                            {
                                item.Discount = Convert.ToDecimal(textBoxDiscount.Text);
                            }

                            item.VersionCode = 1;

                            ItemList.Add(item);

                            decimal discountedPrice = item.ItemPrice - item.Discount;
                            TotalAmount += discountedPrice;
                            TotalOutstanding += discountedPrice;
                            this.textBoxTotalPrice.Text = TotalAmount.ToString();
                            this.textBoxOutstanding.Text = TotalOutstanding.ToString();
                        }

                    }//end foreach

                    comboBoxProducts.ResetText();
                    comboBoxProducts.SelectedIndex = 0;
                    textBoxDiscount.Clear();
                    mtbDepartureTime.Clear();
                    mtbArrivalTime.Clear();
                    textBoxNote.Clear();
                    textBoxDiscount.Text = "0.00";
                }
            }
        }
        //------------------------------------------------------------------------------------
        //clear items button
        private void button6_Click(object sender, EventArgs e)
        {
            if (ItemList.Count > 0)
            {
                this.dataGridView1.Rows.Clear();
                this.textBoxTotalPrice.Text = "0";
                this.textBoxOutstanding.Text = "0";
                this.TotalAmount = 0;
                this.TotalOutstanding = 0;
                this.ItemList.Clear();
                itemCounter = 0;
                clearAll = true;
                //numberOfBookingItems = 0;
            }
            else
            {
                MessageBox.Show("There are no items to remove!");
            }
        }
        //-------------------------------------------------------------------------------------
        //delete booking
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult userAction = MessageBox.Show(this, "Are you sure you want to delete this booking?", "Confirm booking deletion", MessageBoxButtons.YesNo);
                if (userAction.Equals(DialogResult.Yes))
                {
                    broker.DeleteBookingRates(booking.BookingNumber);
                    broker.DeleteBookingItem(booking.BookingNumber);
                    broker.DeleteBooking(booking.BookingNumber);

                    MessageBox.Show("Booking is deleted!");

                    this.Enabled = false;
                }

            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        //-----------------------------------------------------------------------------------
        //Load Booking data
        private void LoadBookingData()
        {
            this.panel1.Enabled = true;
            this.panel3.Enabled = true;
            this.panel5.Enabled = true;

            this.dataGridView1.Rows.Clear();
            this.dataGridView2.Rows.Clear();

            string code = bcode;
            booking = new Booking();
            ds = broker.GetBookingByCode(code);

            ItemList.Clear();

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                booking.BookingNumber = Convert.ToInt32(row["BookingNumber"]);
                booking.ContactNumber = Convert.ToInt32(row["ContactNumber"]);
                DateOfBookingVal = Convert.ToDateTime(row["DateOfBooking"]);
                booking.DateOfBooking = DateOfBookingVal.ToString("dd/MM/yyyy");
                booking.TotalPrice = Convert.ToDecimal(row["TotalPrice"]);
                booking.RequiresVisa = row["RequiresVisa"].ToString();
                booking.VisaAppointmentScheduled = row["VisaAppointmentScheduled"].ToString();
                booking.DateOfAppointment = row["DateOfAppointment"].ToString();
                booking.TimeOfAppointment = row["TimeOfAppointment"].ToString();
                booking.VisaObtained = row["VisaObtained"].ToString();
                booking.VisaRejected = row["VisaRejected"].ToString();
                booking.IsBooked = row["Isbooked"].ToString();
                booking.IsCancelled = row["IsCancelled"].ToString();
                booking.ReasonForCancellation = row["ReasonForCancellation"].ToString();
                booking.BookingCode = code;
                PaymentDeadlineVal = Convert.ToDateTime(row["PaymentDeadline"]);
                booking.PaymentDeadline = PaymentDeadlineVal.ToString("dd/MM/yyyy");
                booking.OutstandingBalance = Convert.ToDecimal(row["OutstandingBalance"]);
                booking.GWFnumber = row["GWFnumber"].ToString();
                booking.VisaDocumentsObtained = row["VisaDocsObtained"].ToString();
                booking.VersionCode = Convert.ToInt32(row["VersionCode"]);
                booking.BookingType = row["BookingStringA"].ToString();
                booking.BusNeeded = row["BookingStringB"].ToString();

                CurrentBookingNumber = booking.BookingNumber;
                CurrentBookingCode = booking.BookingCode;
                BookingVersionCode = booking.VersionCode;
            }

            TotalAmount = booking.TotalPrice;

            ds = broker.GetBookingItemsByBookingNumber(booking.BookingNumber);

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                item = new BookingItems();
                item.BookingNumber = booking.BookingNumber;
                item.ItemNumber = Convert.ToInt32(row["ItemNumber"]);
                item.ItemName = row["ItemName"].ToString();
                item.StartDate = dbUtil.FormatDate(Convert.ToDateTime(row["StartDate"]));
                item.ReturnDate = dbUtil.FormatDate(Convert.ToDateTime(row["ReturnDate"]));
                item.ItemPrice = Convert.ToDecimal(row["ItemPrice"]);
                item.Discount = Convert.ToDecimal(row["Discount"]);
                item.ArrivalTime = row["ArrivalTime"].ToString();
                item.DepartueTime = row["DepartureTime"].ToString();
                item.ItemProvider = row["ItemProvider"].ToString();
                item.BookingNote = row["Note"].ToString();
                item.ItemType = row["ItemType"].ToString();
                ItemList.Add(item);
                itemCounter++;
            }

            //loading booking rates
            ds = broker.GetPaymentRatesByBookingNumber(booking.BookingNumber);

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                rate = new PaymentRate();
                rate.BookingNumber = booking.BookingNumber;
                rate.RateNumber = Convert.ToInt32(row["RateNumber"]);
                rate.date = dbUtil.FormatDate(Convert.ToDateTime(row["RateDate"]));
                rate.AmountPaid = Convert.ToDecimal(row["AmountPaid"]);
                rate.Currency = row["Currency"].ToString();
                rate.PaymentMethod = row["PaymentMethod"].ToString();
                rate.ConversionValue = Convert.ToDecimal(row["ConversionValue"]);
                rate.RateNote = row["RateNote"].ToString();
                rate.OriginalValue = Convert.ToDecimal(row["OriginalValue"]);
                PaymentRates.Add(rate);
                rateSynchronizerList.Add(rate);
                rateCounter++;
            }

            textBox1.Text = code;
            textBoxBookingDate.Text = booking.DateOfBooking;
            textBoxTotalPrice.Text = booking.TotalPrice.ToString();
            textBoxOutstanding.Text = booking.OutstandingBalance.ToString();
            textBoxPaymentDeadline.Text = booking.PaymentDeadline;
            comboBoxBookingType.Text = booking.BookingType;

            TotalAmount = booking.TotalPrice;
            TotalOutstanding = booking.OutstandingBalance;

            textBoxGwf.Text = booking.GWFnumber;

            if (broker.ReturnVisaDocStatus(booking.ContactNumber) == "yes")
            {
                this.checkBoxVisaDocsSubmitted.Checked = true;
            }

            if (booking.IsBooked == "yes")
            {
                checkBoxBooked.Checked = true;
            }
            else
            {
                checkBoxBooked.Checked = false;
            }

            if (booking.IsCancelled == "yes")
            {
                checkBoxCancel.Checked = true;
                textBoxCancellationReason.Text = booking.ReasonForCancellation;
            }
            else
            {
                checkBoxCancel.Checked = false;
                textBoxCancellationReason.Clear();
            }

            if (booking.RequiresVisa == "yes")
            {
                VisaCheckBox.Checked = true;
            }
            else
            {
                VisaCheckBox.Checked = false;
            }

            if (booking.VisaAppointmentScheduled == "yes")
            {
                VisaApointmentScheduledCheckBox.Checked = true;
                VisaTimeTextBox.Text = booking.TimeOfAppointment;
                VisaDatePicker.Value = Convert.ToDateTime(booking.DateOfAppointment);
            }
            else
            {
                VisaApointmentScheduledCheckBox.Checked = false;
                VisaTimeTextBox.Clear();
            }

            if (booking.VisaDocumentsObtained == "yes")
            {
                checkBoxVisaDocsSubmitted.Checked = true;
            }
            else
            {
                checkBoxVisaDocsSubmitted.Checked = false;
            }

            if (booking.VisaObtained == "yes")
            {
                checkBoxVisaObtained.Checked = true;
            }
            else
            {
                checkBoxVisaObtained.Checked = false;
            }

            if (booking.VisaRejected == "yes")
            {
                checkBoxVisaReject.Checked = true;
            }
            else
            {
                checkBoxVisaReject.Checked = false;
            }

            if (booking.BookingType.Equals("Kopaonik"))
            {
                cbBusNeeded.Visible = true;
                cbBusNeeded.Enabled = true;

                if (booking.BusNeeded.Equals("Yes"))
                {
                    cbBusNeeded.Checked = true;
                }
            }

            if (ItemList.Count > 0)
            {
                foreach (BookingItems item in ItemList)
                {
                    object[] parameters = new object[8];
                    parameters[0] = item.ItemName;
                    parameters[1] = item.ItemPrice;
                    parameters[2] = item.Discount;
                    if (item.StartDate.Equals(string.Empty) || item.StartDate == null)
                    {
                        parameters[3] = null;
                        parameters[5] = null;
                    }
                    else
                    {
                        parameters[3] = item.StartDate;
                        parameters[5] = item.ReturnDate;
                    }
                    parameters[4] = item.DepartueTime;
                    parameters[6] = item.ArrivalTime;
                    parameters[7] = item.BookingNote;

                    dataGridView1.Rows.Add(parameters);
                }
            }

            if (PaymentRates.Count > 0)
            {
                foreach (PaymentRate rate in PaymentRates)
                {
                    object[] parameters = new object[7];
                    parameters[0] = rate.AmountPaid;
                    parameters[1] = rate.Currency;
                    parameters[2] = rate.OriginalValue;
                    parameters[3] = rate.PaymentMethod;
                    parameters[4] = rate.ConversionValue;
                    parameters[5] = dbUtil.ChangeDateToSerbianFormat(rate.date);
                    parameters[6] = rate.RateNote;
                    dataGridView2.Rows.Add(parameters);
                }
            }

            //show contract data
            contract = broker.GetContractByBookingNumber(booking.BookingNumber);
            if (contract != null)
            {
                tbContractNumber.Text = contract.ContractNumber;
                tbReceiptNumber.Text = contract.ReceiptNumber.ToString();
                dtpContractDate.Value = Convert.ToDateTime(contract.ContractDate);
                
                if (!contract.ReceiptIssueDate.Equals(String.Empty))
                {
                    dtpReceiptIssueDate.Value = Convert.ToDateTime(contract.ReceiptIssueDate);
                    dtpReceiptIssueDate.Format = DateTimePickerFormat.Short;
                }
                else
                {
                    dtpReceiptIssueDate.Format = DateTimePickerFormat.Custom;
                    dtpReceiptIssueDate.CustomFormat = " ";
                }
                
                btnDeleteContract.Enabled = true;
            }
            else
            {
                btnDeleteContract.Enabled = false;
            }

            this.contractInfoChnaged = false;

            //RUNNING CONSISTENCY CHECKS

            bool BookingHasErrors = CheckIfbookingHasItems(ItemList);

            bool BookingPriceNotOK = CheckIfBookingPriceIsCorrect(ItemList, TotalAmount);

            bool BookingBalanceNotOK = CheckIfOutstandingBalanceIsCorrect(PaymentRates, TotalOutstanding, TotalAmount);

            if (BookingHasErrors == true || BookingPriceNotOK == true || BookingBalanceNotOK == true)
            {
                //1. Lock the UI
                this.panel1.Enabled = false;
                this.panel3.Enabled = false;
                this.panel5.Enabled = false;
                this.button5.Enabled = false;

                //2. Show the message, depending on what was wrong with the booking. 

                if (BookingHasErrors == true)
                {
                    MessageBox.Show("This booking contains the following error: booking has no items.");
                }

                if (BookingBalanceNotOK == true)
                {
                    MessageBox.Show("This booking contains the following error: the outstanding balance is negative.");
                }

                if (BookingPriceNotOK == true)
                {
                    MessageBox.Show("This booking contains the following error: the booking price is not correct.");
                }

            }

            PaymentRates.Clear();

        }
        //-----------------------------------------------------------------------------------
        //delete item button
        private void button1_Click(object sender, EventArgs e)
        {
            if (ItemList.Count > 0)
            {
                int curr = dataGridView1.CurrentRow.Index;

                DataGridViewRow selectedRow = dataGridView1.CurrentRow;
                Decimal price = Convert.ToDecimal(selectedRow.Cells[1].Value.ToString());
                Decimal discount = Convert.ToDecimal(selectedRow.Cells[2].Value.ToString());

                ItemList.RemoveAt(curr);

                dataGridView1.Rows.Remove(selectedRow);

                //edit total price
                decimal finalPrice = price - discount;
                this.TotalAmount -= finalPrice;
                this.TotalOutstanding -= finalPrice;

                this.textBoxTotalPrice.Text = TotalAmount.ToString();
                this.textBoxOutstanding.Text = TotalOutstanding.ToString();

                //itemDeleted = true;
                itemsChanged = true;
            }
            else
            {
                MessageBox.Show("There are no items to remove!");
            }
        }

        //consistency check method 1
        private bool CheckIfbookingHasItems(ArrayList ItemList)
        {
            bool result = false;

            if (ItemList.Count == 0)
            {
                DataSet ds_itemsExist = broker.GetBookingItemsByBookingNumber(booking.BookingNumber);
                if (ds_itemsExist.Tables[0].Rows.Count == 0)
                {
                    result = true;
                }
            }

            return result;
        }

        //consistency check method 2
        public bool CheckIfBookingPriceIsCorrect(ArrayList ItemList, decimal TotalAmount)
        {
            bool result = false;

            decimal priceTest = 0;

            foreach (BookingItems item in ItemList)
            {
                decimal itemValueTest = item.ItemPrice - item.Discount;
                priceTest += itemValueTest;
            }

            if (priceTest != TotalAmount || TotalAmount <= 0)
            {
                result = true;
            }

            return result;
        }

        public bool CheckIfOutstandingBalanceIsCorrect(ArrayList PaymentRates, decimal TotalOutstanding, decimal TotalPrice)
        {
            bool result = false;

            decimal outstandingBalanceTest = 0;

            if (PaymentRates.Count > 0)
            {
                foreach (PaymentRate rate in PaymentRates)
                {
                    decimal BalanceTest = rate.OriginalValue;
                    outstandingBalanceTest += BalanceTest;
                }
            }

            decimal PaidAmount = TotalPrice - TotalOutstanding;

            if ((outstandingBalanceTest != PaidAmount) || (TotalOutstanding < -30))
            {
                result = true;
            }
            return result;
        }

        private void button7_Click(object sender, EventArgs e)
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
                    itemsChanged = true;

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
                    item.BookingNumber = booking.BookingNumber;
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
                    TotalOutstanding += discountedPrice;
                    this.textBoxOutstanding.Text = TotalOutstanding.ToString();
                }
            }
            catch (System.FormatException)
            {
                MessageBox.Show("Please check the special discount field! It must be a decimal value!");
            }
        }

        private void btnSaveContract_Click(object sender, EventArgs e)
        {
            if (tbContractNumber.Text.Equals("") || dtpContractDate.Text.Equals(" "))
            {
                MessageBox.Show("Please fill the mandatory fields!", "MISSING MANDATORY FIELDS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Contract newContract = new Contract();
                newContract.BookingNumber = booking.BookingNumber;
                newContract.ContractNumber = tbContractNumber.Text;
                newContract.ContractDate = dbUtil.FormatDate(dtpContractDate.Value);
                
                int receiptNumber;
                if (tbReceiptNumber.Text != null && Int32.TryParse(tbReceiptNumber.Text, out receiptNumber))
                {
                    newContract.ReceiptNumber = receiptNumber;
                }
                else if(tbReceiptNumber.Text.Equals(String.Empty)) 
                {
                    newContract.ReceiptNumber = null;
                }
                else
                {
                    MessageBox.Show("Receipt number must be numerical value!", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.contractInfoChnaged = false;
                    contract = null;
                }

                if (dtpReceiptIssueDate.Text.Equals(" "))
                {
                    newContract.ReceiptIssueDate = null;
                }
                else
                {
                    newContract.ReceiptIssueDate = dbUtil.FormatDate(dtpReceiptIssueDate.Value);
                }

                if (contractInfoChnaged && contract == null)
                {
                    if (broker.AddContract(newContract) != 13)
                    {
                        MessageBox.Show("Contract added to this booking!", "SUCCESS!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.contract = newContract;
                        btnDeleteContract.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("Contract cannot be created!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    this.contractInfoChnaged = false;
                }
                else if (contractInfoChnaged && contract != null)
                {
                    if (broker.UpdateContract(newContract) != 13)
                    {
                        MessageBox.Show("Contract updated!", "SUCCESS!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.contract = newContract;
                        btnDeleteContract.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("Contract cannot be updated!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    this.contractInfoChnaged = false;
                }
                else
                {
                    MessageBox.Show("No changes have been made!", "DATA NOT MODIFIED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void ContractValueChanged(object sender, EventArgs e)
        {
            this.contractInfoChnaged = true;
        }

        private void ContractReceiptDateChanged(object sender, EventArgs e)
        {
            this.contractInfoChnaged = true;
            this.dtpReceiptIssueDate.Format = DateTimePickerFormat.Short;
        }

        private void btnDeleteContract_Click(object sender, EventArgs e)
        {
            if (contract != null)
            {
                broker.DeleteContract(contract);
                MessageBox.Show("Contract deleted!", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.contract = null;
                btnDeleteContract.Enabled = false;
                tbContractNumber.Clear();
                tbReceiptNumber.Clear();
                dtpContractDate.Value = DateTime.Today;
                dtpReceiptIssueDate.Value = DateTime.Today;
                dtpReceiptIssueDate.Format = DateTimePickerFormat.Custom;
                dtpReceiptIssueDate.CustomFormat = " ";
            }
            else
            {
                MessageBox.Show("Contract cannot be deleted!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PaymentRatesContextMenu(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int currentMouseOverRow = dataGridView2.HitTest(e.X, e.Y).RowIndex;
                if (currentMouseOverRow >= 0)
                {
                    foreach (DataGridViewRow row in dataGridView2.Rows)
                    {
                        row.Selected = false;
                    }
                    dataGridView2.Rows[currentMouseOverRow].Selected = true;
                    ctxMenuRatesDelete.Enabled = true;
                }
                else
                {
                    ctxMenuRatesDelete.Enabled = false;
                }

                paymentRatesContextualMenu.Show(dataGridView2, new Point(e.X, e.Y));
            }
        }

        private void HandleRatesCtxMenuClick(object sender, ToolStripItemClickedEventArgs e)
        {
            //1. extract the data from the datagrid row
            //2. remove the row itself
            //3. update the booking information (number of rates, outstanding balance, etc.)
        }

        private void ctxMenuRatesCancel_Click(object sender, EventArgs e)
        {
            if (paymentRatesContextualMenu.Visible)
            {
                paymentRatesContextualMenu.Close();
            }
        }
    }
}
