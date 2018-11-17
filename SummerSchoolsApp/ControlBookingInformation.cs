using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SummerSchoolsApp.DBBroker;

namespace SummerSchoolsApp
{
    public partial class ControlBookingInformation : UserControl
    {
        Broker broker;

        public ControlBookingInformation()
        {
            InitializeComponent();

            broker = new Broker();
            DataSet ds_students = broker.GetAllAvailableContacts();

            foreach (DataRow dr in ds_students.Tables[0].Rows)
            {
                if (dr["ContactType"].ToString() == "Student")
                {
                    int contact_number = Convert.ToInt32(dr["contactNumber"]);
                    DataSet contact_bookings = broker.GetBookingsByContact(contact_number);

                    if (contact_bookings.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow booking_row in contact_bookings.Tables[0].Rows)
                        {
                            object[] parameters = new object[5];
                            parameters[0] = dr["FirstName"].ToString() + " " + dr["LastName"].ToString();
                            parameters[1] = booking_row["BookingCode"].ToString();//booking code
                            if (booking_row["IsCancelled"].ToString() == "yes")
                            {
                                parameters[2] = "Cancelled";//booking status
                            }
                            else
                            {
                                parameters[2] = "Active";//booking status
                            }
                            parameters[3] = booking_row["TotalPrice"].ToString();//booking price
                            parameters[4] = booking_row["OutstandingBalance"].ToString();//booking outst. balance

                            dataGridView1.Rows.Add(parameters);
                        }
                    }
                }
            }
        }
    }
}
