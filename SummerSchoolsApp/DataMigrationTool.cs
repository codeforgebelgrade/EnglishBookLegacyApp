using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using SummerSchoolsApp.DBBroker;

namespace SummerSchoolsApp
{
    public partial class DataMigrationTool : Form
    {
        Broker broker;
        SqlConnection conn;
        SqlTransaction trans;
        string newDatabaseConnStr = ConfigurationManager.AppSettings["NewConnStr"].ToString();

        public DataMigrationTool()
        {
            InitializeComponent();
            broker = new Broker();
            conn = new SqlConnection(newDatabaseConnStr);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Broker broker = new Broker();

            string newDatabaseConnStr = ConfigurationManager.AppSettings["NewConnStr"].ToString();
            string oldDatabaseConnStr = ConfigurationManager.AppSettings["ConnStr"].ToString();

            conn = new SqlConnection(newDatabaseConnStr);

            DataSet ds_OldUSers = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Contacts", oldDatabaseConnStr);
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            adapter.Fill(ds_OldUSers, "Contacts");

            foreach (DataRow contact_dr in ds_OldUSers.Tables[0].Rows)
            {
                listBox1.Items.Add("------------------------");
                //1. insert contact
                Contact contact = new Contact();
                int newContactNumber = 0;

                int oldContactNumber = Convert.ToInt32(contact_dr["ContactNumber"].ToString());
                
                contact.FirstName = contact_dr["FirstName"].ToString();
                contact.LastName = contact_dr["LastName"].ToString();
                contact.DateOfBirth = contact_dr["DateOfBirth"].ToString();
                contact.PassportNumber = contact_dr["PassportNum"].ToString();
                contact.Address = contact_dr["ContactAddress"].ToString();
                contact.City = contact_dr["City"].ToString();
                contact.PoBox = contact_dr["PoBox"].ToString();
                contact.Phone = contact_dr["Phone"].ToString();
                contact.MobilePhone = contact_dr["MobilePhone"].ToString();
                contact.Email = contact_dr["Email"].ToString();
                contact.MotherName = contact_dr["MotherName"].ToString();
                contact.FatherName = contact_dr["FatherName"].ToString();
                contact.MotherPhone = contact_dr["MotherPhone"].ToString();
                contact.FatherPhone = contact_dr["FatherPhone"].ToString();
                contact.ContactType = contact_dr["ContactType"].ToString();
                contact.GroupLeader = contact_dr["GroupLeader"].ToString();
                contact.SchoolName = contact_dr["SchoolName"].ToString();
                contact.SchoolAddress = contact_dr["SchoolAddress"].ToString();
                contact.TeacherPhone = contact_dr["TeacherPhone"].ToString();
                contact.AgencyName = contact_dr["AgencyName"].ToString();
                contact.EBClubMember = contact_dr["EBClubMember"].ToString();
                contact.PromoCodeMember = contact_dr["PromoCodeMember"].ToString();
                contact.MarketingSource = contact_dr["MarketingMaterial"].ToString();
                contact.VersionCode = 1;

                int result = this.InsertContact(contact);

                if (result != 13)
                {
                    newContactNumber = this.GetLastContactRecord();
                    listBox1.Items.Add("CONTACT ADDED!!");
                }
                else
                {
                    listBox1.Items.Add("INSERT CONTACT FAILED!!");
                }

                //3. check for bookings
                DataSet ds_oldBookings = broker.GetBookingsByContact(oldContactNumber);

                //-----REPEAT FOR EVERY BOOKING-----

                if (ds_oldBookings.Tables[0].Rows.Count > 0)
                {
                    //4. get booking
                    foreach (DataRow bookingRow in ds_oldBookings.Tables[0].Rows)
                    {
                        //5. insert booking, using NEW user code
                        Booking booking = new Booking();

                        int oldBookingNumber = Convert.ToInt32(bookingRow["BookingNumber"]);
                        booking.ContactNumber = newContactNumber;
                        //DateTime DateOfBookingVal = Convert.ToDateTime(bookingRow["DateOfBooking"]);
                        booking.DateOfBooking = bookingRow["DateOfBooking"].ToString();
                        booking.TotalPrice = Convert.ToDecimal(bookingRow["TotalPrice"]);
                        booking.RequiresVisa = bookingRow["RequiresVisa"].ToString();
                        booking.VisaAppointmentScheduled = bookingRow["VisaAppointmentScheduled"].ToString();
                        booking.DateOfAppointment = bookingRow["DateOfAppointment"].ToString();
                        booking.TimeOfAppointment = bookingRow["TimeOfAppointment"].ToString();
                        booking.VisaObtained = bookingRow["VisaObtained"].ToString();
                        booking.VisaRejected = bookingRow["VisaRejected"].ToString();
                        booking.IsBooked = bookingRow["Isbooked"].ToString();
                        booking.IsCancelled = bookingRow["IsCancelled"].ToString();
                        booking.ReasonForCancellation = bookingRow["ReasonForCancellation"].ToString();
                        booking.BookingCode = bookingRow["BookingCode"].ToString();
                        //DateTime PaymentDeadlineVal = Convert.ToDateTime(bookingRow["PaymentDeadline"]);
                        booking.PaymentDeadline = bookingRow["PaymentDeadline"].ToString();
                        booking.OutstandingBalance = Convert.ToDecimal(bookingRow["OutstandingBalance"]);
                        booking.GWFnumber = bookingRow["GWFnumber"].ToString();
                        booking.VersionCode = 1;

                        //6. get new booking number
                        int result2 = this.InsertBooking(booking);

                        if (result2 != 13)
                        {
                            listBox1.Items.Add("BOOKING ADDED!!");
                        }
                        else
                        {
                            listBox1.Items.Add("INSERT BOOKING FAILED!!");
                        }

                        int newBookingNumber = this.GetLastBookingRecord();

                        //7. get items
                        DataSet ds_OldItems = broker.GetBookingItemsByBookingNumber(oldBookingNumber);

                        //-----ADDING ITEMS-----
                        if (ds_OldItems.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow itemRow in ds_OldItems.Tables[0].Rows)
                            {
                                //8. insert items using NEW booking number
                                BookingItems item = new BookingItems();

                                item.BookingNumber = newBookingNumber;
                                //sada ovde treba izvaditi sifru proizvoda
                                item.ItemName = itemRow["ItemName"].ToString();
                                item.ItemNumber = 0;
                                //item.ItemNumber = this.ReturnNewProductCode(item.ItemName);
                                item.StartDate = itemRow["StartDate"].ToString();
                                item.ReturnDate = itemRow["ReturnDate"].ToString();
                                item.Qty = Convert.ToInt32(itemRow["Qty"]);
                                item.ItemPrice = Convert.ToDecimal(itemRow["ItemPrice"]);
                                item.Discount = Convert.ToDecimal(itemRow["Discount"]);
                                item.ArrivalTime = itemRow["ArrivalTime"].ToString();
                                item.DepartueTime = itemRow["DepartureTime"].ToString();
                                item.ItemProvider = itemRow["ItemProvider"].ToString();
                                item.BookingNote = itemRow["Note"].ToString();
                                item.ItemType = itemRow["ItemType"].ToString();
                                item.VersionCode = 1;

                                int itemResult = this.InsertItem(item);

                                if (itemResult != 13)
                                {
                                    this.listBox1.Items.Add("ITEM ADDED TO BOOKING!");
                                }
                                else
                                {
                                    this.listBox1.Items.Add("ITEM INSERT FAILED!");
                                }
                            }
                        }
                        //9. get rates
                        //10. insert rates using NEW booking number
                        
                        //-----ADDING RATES-----
                        DataSet ds_rates = broker.GetPaymentRatesByBookingNumber(oldBookingNumber);

                        if (ds_rates.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow rateRow in ds_rates.Tables[0].Rows)
                            {
                                PaymentRate rate = new PaymentRate();

                                rate.BookingNumber = newBookingNumber;
                                //rate.RateNumber = Convert.ToInt32(rateRow["RateNumber"]);
                                rate.date = rateRow["RateDate"].ToString();
                                rate.AmountPaid = Convert.ToDecimal(rateRow["AmountPaid"]);
                                rate.Currency = rateRow["Currency"].ToString();
                                rate.PaymentMethod = rateRow["PaymentMethod"].ToString();
                                rate.ConversionValue = Convert.ToDecimal(rateRow["ConversionValue"]);
                                rate.RateNote = rateRow["RateNote"].ToString();
                                rate.OriginalValue = Convert.ToDecimal(rateRow["OriginalValue"]);
                                rate.OriginalCurrency = "CURRENCY";

                                int rateResult = this.InsertPaymentRate(rate);

                                if (rateResult != 13)
                                {
                                    listBox1.Items.Add("RATE ADDED!!");
                                }
                                else
                                {
                                    listBox1.Items.Add("RATE INSERT FAILED!");
                                }
                            }
                        }
                    }
                }
            }
            
        }

        public int InsertContact(Contact contact)
        {
            try
            {
                conn.Open();
                trans = conn.BeginTransaction();
                SqlCommand cmd = new SqlCommand("AddContact", conn);
                cmd.Transaction = trans;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@FirstName", contact.FirstName));
                cmd.Parameters.Add(new SqlParameter("@LastName", contact.LastName));
                cmd.Parameters.Add(new SqlParameter("@DateOfBirth", contact.DateOfBirth));
                cmd.Parameters.Add(new SqlParameter("@PassportNum", contact.PassportNumber));
                cmd.Parameters.Add(new SqlParameter("@ContactAddress", contact.Address));
                cmd.Parameters.Add(new SqlParameter("@City", contact.City));
                cmd.Parameters.Add(new SqlParameter("@PoBox", contact.PoBox));
                cmd.Parameters.Add(new SqlParameter("@Phone", contact.Phone));
                cmd.Parameters.Add(new SqlParameter("@MobilePhone", contact.MobilePhone));
                cmd.Parameters.Add(new SqlParameter("@Email", contact.Email));
                cmd.Parameters.Add(new SqlParameter("@MotherName", contact.MotherName));
                cmd.Parameters.Add(new SqlParameter("@FatherName", contact.FatherName));
                cmd.Parameters.Add(new SqlParameter("@MotherPhone", contact.MotherPhone));
                cmd.Parameters.Add(new SqlParameter("@FatherPhone", contact.FatherPhone));
                cmd.Parameters.Add(new SqlParameter("@ContactType", contact.ContactType));
                cmd.Parameters.Add(new SqlParameter("@GroupLeader", contact.GroupLeader));
                cmd.Parameters.Add(new SqlParameter("@SchoolName", contact.SchoolName));
                cmd.Parameters.Add(new SqlParameter("@SchoolAddress", contact.SchoolAddress));
                cmd.Parameters.Add(new SqlParameter("@TeacherPhone", contact.TeacherPhone));
                cmd.Parameters.Add(new SqlParameter("@EBClubMember", contact.EBClubMember));
                cmd.Parameters.Add(new SqlParameter("@PromoCodeMember", contact.PromoCodeMember));
                cmd.Parameters.Add(new SqlParameter("@AgencyName", contact.AgencyName));
                cmd.Parameters.Add(new SqlParameter("@MarketingMaterial", contact.MarketingSource));
                cmd.Parameters.Add(new SqlParameter("@VersionCode", contact.VersionCode));

                /*SqlParameter retVal = new SqlParameter("retVal", SqlDbType.Int);
                retVal.Direction = ParameterDirection.ReturnValue;
                cmd.Parameters.Add(retVal);*/

                int result = cmd.ExecuteNonQuery();
                trans.Commit();
                return result;
            }
            catch (System.Exception)
            {
                trans.Rollback();
                return 13;
            }
            finally
            {
                conn.Close();
            }
        }

        public int GetLastContactRecord()
        {
            conn.Open();
            SqlCommand command = new SqlCommand("GetLastRecordFromClients", conn);
            command.CommandType = CommandType.StoredProcedure;

            SqlDataReader reader = command.ExecuteReader();
            int result = 0;

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    result = Convert.ToInt32(reader[0]);
                }
                reader.Close();
                conn.Close();
                return result;
            }
            else
            {
                conn.Close();
                return result;
            }
        }

        public int InsertBooking(Booking booking)
        {
            try
            {
                conn.Open();
                trans = conn.BeginTransaction();
                SqlCommand cmd = new SqlCommand("AddBooking", conn);
                cmd.Transaction = trans;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@ContactNumber", booking.ContactNumber));
                cmd.Parameters.Add(new SqlParameter("@DateOfBooking", booking.DateOfBooking));
                cmd.Parameters.Add(new SqlParameter("@TotalPrice", booking.TotalPrice));
                cmd.Parameters.Add(new SqlParameter("@RequiresVisa", booking.RequiresVisa));
                cmd.Parameters.Add(new SqlParameter("@VisaAppointmentScheduled", booking.VisaAppointmentScheduled));
                cmd.Parameters.Add(new SqlParameter("@DateOfAppointment", booking.DateOfAppointment));
                cmd.Parameters.Add(new SqlParameter("@TimeOfAppointment", booking.TimeOfAppointment));
                cmd.Parameters.Add(new SqlParameter("@VisaObtained", booking.VisaObtained));
                cmd.Parameters.Add(new SqlParameter("@VisaRejected", booking.VisaRejected));
                cmd.Parameters.Add(new SqlParameter("@IsBooked", booking.IsBooked));
                cmd.Parameters.Add(new SqlParameter("@IsCancelled", booking.IsCancelled));
                cmd.Parameters.Add(new SqlParameter("@ReasonForCancellation", booking.ReasonForCancellation));
                cmd.Parameters.Add(new SqlParameter("@BookingCode", booking.BookingCode));
                cmd.Parameters.Add(new SqlParameter("@PaymentDeadline", booking.PaymentDeadline));
                cmd.Parameters.Add(new SqlParameter("@OutstandingBalance", booking.OutstandingBalance));
                cmd.Parameters.Add(new SqlParameter("@Active", booking.Active));
                cmd.Parameters.Add(new SqlParameter("@GWFnumber", booking.GWFnumber));
                cmd.Parameters.Add(new SqlParameter("@CancellationDate", booking.CancellationDate));
                cmd.Parameters.Add(new SqlParameter("@VersionCode", booking.VersionCode));


                int result = cmd.ExecuteNonQuery();
                trans.Commit();
                //conn.Close();
                return result;
            }
            catch (System.Exception)
            {
                trans.Rollback();
                return 13;
            }
            finally
            {
                conn.Close();
            }
        }

        public int GetLastBookingRecord()
        {
            conn.Open();
            SqlCommand command = new SqlCommand("GetLastRecordFromBookings", conn);
            command.CommandType = CommandType.StoredProcedure;

            SqlDataReader reader = command.ExecuteReader();
            int result = 0;

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    result = Convert.ToInt32(reader[0]);
                }
                reader.Close();
                conn.Close();
                return result;
            }
            else
            {
                conn.Close();
                return result;
            }
        }

        public int InsertItem(BookingItems item)
        {
            try
            {
                conn.Open();
                trans = conn.BeginTransaction();
                SqlCommand cmd = new SqlCommand("AddBookingItem", conn);
                cmd.Transaction = trans;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@BookingNumber", item.BookingNumber));
                cmd.Parameters.Add(new SqlParameter("@ProductNumber", item.ItemNumber));
                cmd.Parameters.Add(new SqlParameter("@ItemName", item.ItemName));
                cmd.Parameters.Add(new SqlParameter("@StartDate", item.StartDate));
                cmd.Parameters.Add(new SqlParameter("@ReturnDate", item.ReturnDate));
                //cmd.Parameters.Add(new SqlParameter("@Qty", item.Qty));
                cmd.Parameters.Add(new SqlParameter("@ItemPrice", item.ItemPrice));
                cmd.Parameters.Add(new SqlParameter("@Discount", item.Discount));
                cmd.Parameters.Add(new SqlParameter("@ArrivalTime", item.ArrivalTime));
                cmd.Parameters.Add(new SqlParameter("@DepartureTime", item.DepartueTime));
                cmd.Parameters.Add(new SqlParameter("@ItemProvider", item.ItemProvider));
                cmd.Parameters.Add(new SqlParameter("@BookingNote", item.BookingNote));
                cmd.Parameters.Add(new SqlParameter("@ItemType", item.ItemType));
                cmd.Parameters.Add(new SqlParameter("@VersionCode", item.VersionCode));

                int result = cmd.ExecuteNonQuery();
                trans.Commit();
                //conn.Close();
                return result;
            }
            catch (System.Exception)
            {
                trans.Rollback();
                return 13;
            }
            finally
            {
                conn.Close();
            }
        }

        public int InsertProvider(Provider provider)
        {
            try
            {
                conn.Open();
                trans = conn.BeginTransaction();
                SqlCommand cmd = new SqlCommand("AddProviders", conn);
                cmd.Transaction = trans;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@ProviderName", provider.providerName));
                cmd.Parameters.Add(new SqlParameter("@ProviderAddress", provider.providerAddress));
                cmd.Parameters.Add(new SqlParameter("@ContactPerson", provider.contactPerson));
                cmd.Parameters.Add(new SqlParameter("@ContactPosition", provider.contactPosition));
                cmd.Parameters.Add(new SqlParameter("@ContactEmail", provider.contactEmail));
                cmd.Parameters.Add(new SqlParameter("@ContactPhone", provider.contactPhone));
                cmd.Parameters.Add(new SqlParameter("@ContactPerson2", provider.contactPerson2));
                cmd.Parameters.Add(new SqlParameter("@ContactPosition2", provider.contactPosition2));
                cmd.Parameters.Add(new SqlParameter("@ContactEmail2", provider.contactEmail2));
                cmd.Parameters.Add(new SqlParameter("@ContactPhone2", provider.contactPhone2));
                cmd.Parameters.Add(new SqlParameter("@ContactPerson3", provider.contactPerson3));
                cmd.Parameters.Add(new SqlParameter("@ContactPosition3", provider.contactPosition3));
                cmd.Parameters.Add(new SqlParameter("@ContactEmail3", provider.contactEmail3));
                cmd.Parameters.Add(new SqlParameter("@ContactPhone3", provider.contactPhone3));
                cmd.Parameters.Add(new SqlParameter("@ContactPerson4", provider.contactPerson4));
                cmd.Parameters.Add(new SqlParameter("@ContactPosition4", provider.contactPosition4));
                cmd.Parameters.Add(new SqlParameter("@ContactEmail4", provider.contactEmail4));
                cmd.Parameters.Add(new SqlParameter("@ContactPhone4", provider.contactPhone4));
                cmd.Parameters.Add(new SqlParameter("@ContactPerson5", provider.contactPerson5));
                cmd.Parameters.Add(new SqlParameter("@ContactPosition5", provider.contactPosition5));
                cmd.Parameters.Add(new SqlParameter("@ContactEmail5", provider.contactEmail5));
                cmd.Parameters.Add(new SqlParameter("@ContactPhone5", provider.contactPhone5));
                cmd.Parameters.Add(new SqlParameter("@VersionCode", provider.VersionCode));

                int result = cmd.ExecuteNonQuery();
                trans.Commit();
                //conn.Close();
                return result;
            }
            catch (System.Exception)
            {
                trans.Rollback();
                return 13;
            }
            finally
            {
                conn.Close();
            }
        }

        public int InsertPaymentRate(PaymentRate rate)
        {
            try
            {
                conn.Open();
                trans = conn.BeginTransaction();
                SqlCommand cmd = new SqlCommand("AddPaymentRate", conn);
                cmd.Transaction = trans;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@BookingNumber", rate.BookingNumber));
                //cmd.Parameters.Add(new SqlParameter("@RateNumber", rate.RateNumber));
                cmd.Parameters.Add(new SqlParameter("@RateDate", rate.date));
                cmd.Parameters.Add(new SqlParameter("@AmountPaid", rate.AmountPaid));
                cmd.Parameters.Add(new SqlParameter("@Currency", rate.Currency));
                cmd.Parameters.Add(new SqlParameter("@PaymentMethod", rate.PaymentMethod));
                cmd.Parameters.Add(new SqlParameter("@ConversionValue", rate.ConversionValue));
                cmd.Parameters.Add(new SqlParameter("@RateNote", rate.RateNote));
                cmd.Parameters.Add(new SqlParameter("@OriginalValue", rate.OriginalValue));
                cmd.Parameters.Add(new SqlParameter("@OriginalCurrency", rate.OriginalCurrency));
                cmd.Parameters.Add(new SqlParameter("@VersionCode", rate.VersionCode));

                int result = cmd.ExecuteNonQuery();
                trans.Commit();
                //conn.Close();
                return result;
            }
            catch (System.Exception)
            {
                trans.Rollback();
                return 13;
            }
            finally
            {
                conn.Close();
            }
        }

        public void AddProviders()
        {
            DataSet ds_OldProviders = broker.ReturnProviderInfo();

            foreach (DataRow row in ds_OldProviders.Tables[0].Rows)
            {
                Provider provider = new Provider();

                provider.providerName = row["ProviderName"].ToString();
                provider.providerAddress = row["ProviderAddress"].ToString();
                provider.contactPerson = row["ContactPerson"].ToString();
                provider.contactPosition = row["ContactPosition"].ToString();
                provider.contactPhone = row["ContactPhone"].ToString();
                provider.contactEmail = row["ContactEmail"].ToString();
                provider.contactPerson2 = row["ContactPerson2"].ToString();
                provider.contactPosition2 = row["ContactPosition2"].ToString();
                provider.contactPhone2 = row["ContactPhone2"].ToString();
                provider.contactEmail2 = row["ContactEmail2"].ToString();
                provider.contactPerson3 = row["ContactPerson3"].ToString();
                provider.contactPosition3 = row["ContactPosition3"].ToString();
                provider.contactPhone3 = row["ContactPhone3"].ToString();
                provider.contactEmail3 = row["ContactEmail3"].ToString();
                provider.contactPerson4 = row["ContactPerson4"].ToString();
                provider.contactPosition4 = row["ContactPosition4"].ToString();
                provider.contactPhone4 = row["ContactPhone4"].ToString();
                provider.contactEmail4 = row["ContactEmail4"].ToString();
                provider.contactPerson5 = row["ContactPerson5"].ToString();
                provider.contactPosition5 = row["ContactPosition5"].ToString();
                provider.contactPhone5 = row["ContactPhone5"].ToString();
                provider.contactEmail4 = row["ContactEmail5"].ToString();
                provider.VersionCode = 1;

                int result = this.InsertProvider(provider);

                if (result != 13)
                {
                    this.listBox1.Items.Add("Insert provider OK!");
                }
                else
                {
                    this.listBox1.Items.Add("Insert provider FAILED!");
                }
            }

        }

        public int InsertProduct(Product product)
        {
            try
            {
                conn.Open();
                trans = conn.BeginTransaction();
                SqlCommand cmd = new SqlCommand("AddProducts", conn);
                cmd.Transaction = trans;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@ProductName", product.productName));
                cmd.Parameters.Add(new SqlParameter("@ProductProvider", product.provider));
                cmd.Parameters.Add(new SqlParameter("@ProductPrice", product.price));
                cmd.Parameters.Add(new SqlParameter("@Currency", product.currency));
                cmd.Parameters.Add(new SqlParameter("@ProductType", product.productType));
                cmd.Parameters.Add(new SqlParameter("@VersionCode", product.VersionCode));

                int result = cmd.ExecuteNonQuery();
                trans.Commit();
                //conn.Close();
                return result;
            }
            catch (System.Exception)
            {
                trans.Rollback();
                return 13;
            }
            finally
            {
                conn.Close();
            }
        }

        public void AddProducts()
        {
            DataSet ds_oldProducts = broker.ReturnProductInfo();

            foreach (DataRow row in ds_oldProducts.Tables[0].Rows)
            {
                Product product = new Product();

                product.productName = row["ProductName"].ToString();
                product.price = Convert.ToDecimal(row["ProductPrice"]);
                product.provider = row["ProductProvider"].ToString();
                product.currency = row["Currency"].ToString();
                product.productType = row["ProductType"].ToString();
                product.VersionCode = 1;

                int result = this.InsertProduct(product);

                if (result != 13)
                {
                    this.listBox1.Items.Add("Item added OK!");
                }
                else
                {
                    this.listBox1.Items.Add("Item add FAILED!");
                }
            }   
        }

        public int ReturnNewProductCode(string productName)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Product", newDatabaseConnStr);
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            adapter.Fill(ds, "Product");

            int result = 0;

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                if (productName == row["ProductName"].ToString())
                {
                    result = Convert.ToInt32(row["ProductCode"]);
                }
            }

            return result;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.AddProviders();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.AddProducts();
        }
    }
}
