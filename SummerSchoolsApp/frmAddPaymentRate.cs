using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SummerSchoolsApp.DBBroker;

namespace SummerSchoolsApp
{
    public partial class frmAddPaymentRate : Form
    {
        Broker broker;

        //What should I pass here? I need booking number, rate number
        public frmAddPaymentRate(int BookingNumber)
        {
            InitializeComponent();
            broker = new Broker();
        }

        private void AddRateButton_Click(object sender, EventArgs e)
        {
            //Insert code for rate adding here
            /* if (textBoxRateConversion.Text != "" && textBoxAmountPaid.Text != "")
             {
                 if (Convert.ToDecimal(textBoxAmountPaid.Text) < 0)
                 {
                     MessageBox.Show("You cannot type negative values!");
                 }
                 else
                 {
                     try
                     {
                         //ratesAdded = true;

                         //rateCounter++;

                         PaymentRate rate = new PaymentRate();

                         //it is irrelevant which number we are using, 
                         //it has no effect since it is not stored in the DB.

                         rate.RateNumber = 1; //rateCounter;

                         //IMPORTANT: This parameter needs to be passed here!!!
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
                         rate.date = dateTimePicker1.Value.ToShortDateString();
                         rate.PaymentMethod = comboBoxPayMethod.Text;
                         rate.ConversionValue = Convert.ToDecimal(textBoxRateConversion.Text);
                         rate.RateNote = textBoxRateNote.Text;
                         rate.OriginalCurrency = comboBoxOriginalCurr.Text;
                         rate.VersionCode = 1;

                         if (rate.Currency != "GBP")
                         {
                             decimal convertedValue = rate.AmountPaid / rate.ConversionValue;
                             convertedValue = Math.Round(convertedValue, 2);
                             //The next line needs to be done on the main form.
                             TotalOutstanding -= convertedValue;
                             rate.OriginalValue = convertedValue;
                             rate.VersionCode = 1;
                         }
                         else
                         {
                             //The next line needs to be done on the main form.
                             TotalOutstanding -= rate.AmountPaid;
                             rate.OriginalValue = rate.AmountPaid;
                             //do nothing
                         }

                         //IMPORTANT: This has to be done in the main form!!! Pass reference to the main form
                         //here, then do this.
                         PaymentRates.Add(rate);

                         object[] parameters = new object[7];
                         //parameters[0] = rate.RateNumber;
                         parameters[0] = rate.AmountPaid;
                         parameters[1] = rate.Currency;
                         parameters[2] = rate.OriginalValue;
                         parameters[3] = rate.PaymentMethod;
                         parameters[4] = rate.ConversionValue;
                         parameters[5] = dateTimePicker1.Value.ToString("dd/MM/yyyy");
                         parameters[6] = rate.RateNote;

                         //The next line needs to be done on the main form. This is basically not needed at all.
                         //The created object needs to be visible on the main form. So, after the object is created
                         //and checked, call the main form and refresh it. 
                         dataGridView2.Rows.Add(parameters);

                         //The next line needs to be done on the main form.
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
         }*/
        }
    }

}