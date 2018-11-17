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
    public partial class frmBooking : Form
    {
        private string m_bookingCode;

        public frmBooking(string bookingCode)
        {
            InitializeComponent();
            this.m_bookingCode = bookingCode;

            ControlBookings bookingControl = new ControlBookings(bookingCode);
            bookingControl.Dock = DockStyle.Fill;
            panel1.Controls.Add(bookingControl);

            Broker broker = new Broker();

            DataSet ds_booking = broker.GetBookingByCode(bookingCode);
            int contactNumber = 0;

            foreach (DataRow dr in ds_booking.Tables[0].Rows)
            {
                contactNumber = Convert.ToInt32(dr["ContactNumber"]);
            }

            DataSet ds_contact = broker.GetContactInfoById(contactNumber);

            foreach (DataRow dr in ds_contact.Tables[0].Rows)
            {
                string firstName = dr["FirstName"].ToString();
                string lastName = dr["LastName"].ToString();

                this.Text = firstName + " " + lastName;
            }
        }
    }
}
