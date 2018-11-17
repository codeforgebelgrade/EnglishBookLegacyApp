using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Configuration;
using System.Resources;

namespace SummerSchoolsApp.DBBroker
{
    public class Broker
    {
        string ConnStr = string.Empty;
        private SqlConnection conn;
        private SqlTransaction trans;
        
        public Broker()
        {
            ConnStr = ConfigurationManager.ConnectionStrings["SummerSchoolsApp.Properties.Settings.SummerSchoolTestConnectionString"].ToString();
            conn = new SqlConnection(ConnStr);
        }

        public SqlConnection GetActiveConnection()
        {
            return this.conn;
        }

        public SqlTransaction GetActiveTransaction()
        {
            return this.trans;
        }

        public DataSet ReturnProductInfo()
        {
            DataSet ds = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Product", ConnStr);
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            adapter.Fill(ds, "Product");
            return ds;
        }

        public DataSet GetAllAvailableContacts()
        {
            DataSet ds = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Contacts", ConnStr);
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            adapter.Fill(ds, "Contacts");
            return ds;
        }

        public DataSet ReturnUserInfo()
        {
            DataSet ds = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Users", ConnStr);
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            adapter.Fill(ds, "Users");
            return ds;
        }

        public DataSet ReturnProviderInfo()
        {
            DataSet ds = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Providers", ConnStr);
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            adapter.Fill(ds, "Providers");
            return ds;
        }

        public DataSet ReturnMarketingSourceInfo()
        {
            DataSet ds = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT msNumber, msName, msContact, msDetails, msPrice FROM MarketingSources", ConnStr);
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            adapter.Fill(ds, "MarketingSources");
            return ds;
        }

        public DataSet ReturnSeasonSettings()
        {
            DataSet ds = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM SeasonSettings", ConnStr);
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            adapter.Fill(ds, "SeasonSettings");
            return ds;
        }

        public int AddSeasonSettings(DateTime startDate, DateTime endDate)
        {
            try
            {
                conn.Open();
                trans = conn.BeginTransaction();
                SqlCommand cmd = new SqlCommand("AddSeasonSettings", conn);
                cmd.Transaction = trans;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@StartDate", startDate));
                cmd.Parameters.Add(new SqlParameter("@EndDate", endDate));

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

        public int UpdateSeasonSettings(DateTime startDate, DateTime endDate)
        {
            try
            {
                conn.Open();
                trans = conn.BeginTransaction();
                SqlCommand cmd = new SqlCommand("UpdateSeasonSettings", conn);
                cmd.Transaction = trans;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@SeasonStart", startDate));
                cmd.Parameters.Add(new SqlParameter("@SeasonEnd", endDate));

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
                cmd.Parameters.Add(new SqlParameter("@PrimaryContact", contact.PrimaryContact));
                cmd.Parameters.Add(new SqlParameter("@VersionCode", contact.VersionCode));
                cmd.Parameters.Add(new SqlParameter("@MotherEmail", contact.MotherEmail));
                cmd.Parameters.Add(new SqlParameter("@FatherEmail", contact.FatherEmail));

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

        public int UpdateContact(Contact contact)
        {
            try
            {
                conn.Open();
                trans = conn.BeginTransaction();
                SqlCommand cmd = new SqlCommand("UpdateContactById", conn);
                cmd.Transaction = trans;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@ContactNumber", contact.ContactNumber));
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
                cmd.Parameters.Add(new SqlParameter("@PrimaryContact", contact.PrimaryContact));
                cmd.Parameters.Add(new SqlParameter("@VersionCode", contact.VersionCode));
                cmd.Parameters.Add(new SqlParameter("@MotherEmail", contact.MotherEmail));
                cmd.Parameters.Add(new SqlParameter("@FatherEmail", contact.FatherEmail));

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

        public int DeleteContact(int contactNumber)
        {
            try
            {
                conn.Open();
                trans = conn.BeginTransaction();
                SqlCommand cmd = new SqlCommand("DeleteContact", conn);
                cmd.Transaction = trans;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@ContactNumber", contactNumber));

                int result = cmd.ExecuteNonQuery();
                trans.Commit();
                return result;
            }
            catch (System.Exception)
            {
                return 13;
            }
            finally
            {
                conn.Close();
            }

        }
        public int InsertUser(User user)
        {
            try
            {
                conn.Open();
                trans = conn.BeginTransaction();
                SqlCommand cmd = new SqlCommand("AddUsers", conn);
                cmd.Transaction = trans;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Username", user.username));
                cmd.Parameters.Add(new SqlParameter("@UserPassword", user.password));
                cmd.Parameters.Add(new SqlParameter("@UserRole", user.userRole));

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

        public int DeleteUser(int userNumber)
        {
            try
            {
                conn.Open();
                trans = conn.BeginTransaction();
                SqlCommand cmd = new SqlCommand("DeleteUser", conn);
                cmd.Transaction = trans;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@UserNumber", userNumber));

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
                cmd.Parameters.Add(new SqlParameter("@CostPrice", product.costPrice));
                cmd.Parameters.Add(new SqlParameter("@ProductPrice", product.price));
                cmd.Parameters.Add(new SqlParameter("@Currency", product.currency));
                cmd.Parameters.Add(new SqlParameter("@ProductType", product.productType));
                cmd.Parameters.Add(new SqlParameter("@ProductGroup", product.productGroup));
                cmd.Parameters.Add(new SqlParameter("VersionCode", product.VersionCode));

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

        public int DeleteProduct(int productNumber)
        {
            try
            {
                conn.Open();
                trans = conn.BeginTransaction();
                SqlCommand cmd = new SqlCommand("DeleteProduct", conn);
                cmd.Transaction = trans;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@ProductCode", productNumber));

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

        public int InsertMarketingsource(Marketingsource msource)
        {
            try
            {
                conn.Open();
                trans = conn.BeginTransaction();
                SqlCommand cmd = new SqlCommand("AddMarketingsource", conn);
                cmd.Transaction = trans;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@msName", msource.msName));
                cmd.Parameters.Add(new SqlParameter("@msContact", msource.msContact));
                cmd.Parameters.Add(new SqlParameter("@msDetails", msource.msDetails));
                cmd.Parameters.Add(new SqlParameter("@msPrice", msource.msPrice));
                cmd.Parameters.Add(new SqlParameter("@VersionCode", msource.VersionCode));

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

        public int DeleteProvider(int providerNumber)
        {
            try
            {
                conn.Open();
                trans = conn.BeginTransaction();
                SqlCommand cmd = new SqlCommand("DeleteProvider", conn);
                cmd.Transaction = trans;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@ProviderNumber", providerNumber));

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
                cmd.Parameters.Add(new SqlParameter("@VisaDocsObtained", booking.VisaDocumentsObtained));
                cmd.Parameters.Add(new SqlParameter("@BookingType", booking.BookingType));
                cmd.Parameters.Add(new SqlParameter("@VersionCode", booking.VersionCode));
                

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

        public int DeleteBooking(int bookingNumber)
        {
            try
            {
                conn.Open();
                trans = conn.BeginTransaction();
                SqlCommand cmd = new SqlCommand("DeleteBookingById", conn);
                cmd.Transaction = trans;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("BookingNumber", bookingNumber));

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
                cmd.Parameters.Add(new SqlParameter("@ProductNumber", item.ProductNumber));
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

        public int DeleteBookingItem(int bookingNumber)
        {
            try
            {
                conn.Open();
                trans = conn.BeginTransaction();
                SqlCommand cmd = new SqlCommand("DeleteBookingItems", conn);
                cmd.Transaction = trans;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("BookingNumber", bookingNumber));

                int result = cmd.ExecuteNonQuery();
                trans.Commit();
                return result;
            }
            catch(System.Exception)
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

        public int DeleteBookingRates(int bookingNumber)
        {
            try
            {
                conn.Open();
                trans = conn.BeginTransaction();
                SqlCommand cmd = new SqlCommand("DeleteBookingRatesById", conn);
                cmd.Transaction = trans;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("BookingNumber", bookingNumber));

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

        public int DeleteSinglePaymentRate(PaymentRate paymentRate)
        {
            return 0;
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

        public DataSet GetContactInfo(string firstName, string lastName)
        {
            Contact resultContact = new Contact();
            SqlCommand cmd = new SqlCommand("FindContact", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@FirstName", firstName));
            cmd.Parameters.Add(new SqlParameter("@LastName", lastName));

            DataSet ds = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            adapter.Fill(ds);
            return ds;
        }

        public DataSet GetProviderByNumber(int providerNumber)
        {
            SqlCommand cmd = new SqlCommand("GetProviderByNumber", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@ProviderNumber", providerNumber));

            DataSet ds = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            adapter.Fill(ds);
            return ds;
        }

        public DataSet GetProductBycode(int productCode)
        {
            SqlCommand cmd = new SqlCommand("GetProductByCode", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@ProductCode", productCode));

            DataSet ds = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            adapter.Fill(ds);
            return ds;
        }

        public int UpdateProductBycode(Product product)
        {
            try
            {
                conn.Open();
                trans = conn.BeginTransaction();
                SqlCommand cmd = new SqlCommand("UpdateProductByCode", conn);
                cmd.Transaction = trans;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@ProductCode", product.productCode));
                cmd.Parameters.Add(new SqlParameter("@ProductName", product.productName));
                cmd.Parameters.Add(new SqlParameter("@ProductProvider", product.provider));
                cmd.Parameters.Add(new SqlParameter("@CostPrice", product.costPrice));
                cmd.Parameters.Add(new SqlParameter("@ProductPrice", product.price));
                cmd.Parameters.Add(new SqlParameter("@Currency", product.currency));
                cmd.Parameters.Add(new SqlParameter("@ProductType", product.productType));
                cmd.Parameters.Add(new SqlParameter("@ProductGroup", product.productGroup));
                cmd.Parameters.Add(new SqlParameter("@VersionCode", product.VersionCode));

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

        public int UpdateProviderByNumber(Provider provider)
        {
            try
            {
                conn.Open();
                trans = conn.BeginTransaction();
                SqlCommand cmd = new SqlCommand("UpdateProviderByNumber", conn);
                cmd.Transaction = trans;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@ProviderNumber", provider.providerNumber));
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

        public DataSet GetContactInfoById(int contactNumber)
        {
            SqlCommand cmd = new SqlCommand("FindContactById", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@ContactNumber", contactNumber));

            DataSet ds = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            adapter.Fill(ds);
            return ds;
        }

        public DataSet GetAllBookingItems()
        {
            DataSet ds = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM BookingItems", ConnStr);
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            adapter.Fill(ds, "BookingItems");
            return ds;
        }

        public DataSet GetBookingByCode(string bookingCode)
        {
            SqlCommand cmd = new SqlCommand("FindBookingByCode", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@BookingCode", bookingCode));

            DataSet ds = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            adapter.Fill(ds);
            return ds;
        }

        public DataSet GetBookingItemsByBookingNumber(int bookingNumber)
        {
            SqlCommand cmd = new SqlCommand("FindItemsByBookingNumber", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@BookingNumber", bookingNumber));

            DataSet ds = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            adapter.Fill(ds);
            return ds;
        }

        public DataSet GetPaymentRatesByBookingNumber(int bookingNumber)
        {
            SqlCommand cmd = new SqlCommand("FindRatesByBookingNumber", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@BookingNumber", bookingNumber));

            DataSet ds = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            adapter.Fill(ds);
            return ds;
        }

        public int updateBookingCode(int bookingNumber, string bookingCode)
        {
            try
            {
                conn.Open();
                trans = conn.BeginTransaction();
                SqlCommand cmd = new SqlCommand("CreateBookingCode", conn);
                cmd.Transaction = trans;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@BookingNumber", bookingNumber));
                cmd.Parameters.Add(new SqlParameter("@BookingCode", bookingCode));

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

        public int updateBookingById(Booking booking)
        {
            try
            {
                conn.Open();
                trans = conn.BeginTransaction();
                SqlCommand cmd = new SqlCommand("UpdateBookingById", conn);
                cmd.Transaction = trans;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@BookingNumber", booking.BookingNumber));
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
                cmd.Parameters.Add(new SqlParameter("@PaymentDeadline", booking.PaymentDeadline));
                cmd.Parameters.Add(new SqlParameter("@OutstandingBalance", booking.OutstandingBalance));
                cmd.Parameters.Add(new SqlParameter("@GWFnumber", booking.GWFnumber));
                cmd.Parameters.Add(new SqlParameter("@CancellationDate", booking.CancellationDate));
                cmd.Parameters.Add(new SqlParameter("@VisaDocsObtained", booking.VisaDocumentsObtained));
                cmd.Parameters.Add(new SqlParameter("@BookingType", booking.BookingType));
                cmd.Parameters.Add(new SqlParameter("@BusNeeded", booking.BusNeeded));
                cmd.Parameters.Add(new SqlParameter("@VersionCode", booking.VersionCode));

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

        public int DeleteBookingItemByNumber(int bookingNumber, int itemNumber)
        {
            try
            {
                conn.Open();
                trans = conn.BeginTransaction();
                SqlCommand cmd = new SqlCommand("delete from BookingItems where BookingNumber =@BNumber AND ItemNumber =@INumber", conn);
                cmd.Transaction = trans;
                cmd.Parameters.Add(new SqlParameter("@BNumber", bookingNumber));
                cmd.Parameters.Add(new SqlParameter("@INumber", itemNumber));
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

        public int UpdateBookingItemBynumber(int bookingNumber, int itemNumber)
        {

            try
            {
                conn.Open();
                trans = conn.BeginTransaction();
                SqlCommand cmd = new SqlCommand("update BookingItems set ItemNumber =@INumber where BookingNumber =@BNumber", conn);
                cmd.Transaction = trans;
                cmd.Parameters.Add(new SqlParameter("@INumber", itemNumber));
                cmd.Parameters.Add(new SqlParameter("@BNumber", bookingNumber));
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

        public DataSet GetAllTeachers()
        {
            SqlCommand cmd = new SqlCommand("GetAllTeachers", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            DataSet ds = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            adapter.Fill(ds);
            return ds;
        }

        public DataSet GetAllAgencies()
        {
            SqlCommand cmd = new SqlCommand("GetAllAgencies", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            DataSet ds = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            adapter.Fill(ds);
            return ds;
        }

        public DataSet GetBookingsByContact(int contactNumber)
        {
            SqlCommand cmd = new SqlCommand("GetBookingsByContact", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@ContactNumber", contactNumber));

            DataSet ds = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            adapter.Fill(ds);
            return ds;
        }

        public void UpdateBookingStatus(DateTime seasonStart)
        {
            try
            {
                conn.Open();
                trans = conn.BeginTransaction();
                SqlCommand cmd = new SqlCommand("UpdateBookingStatus", conn);
                cmd.Transaction = trans;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@BookingNumber", SqlDbType.Int);
                
                DataSet bookingItems = this.GetAllBookingItems();
                foreach (DataRow dr in bookingItems.Tables[0].Rows)
                {
                    if (Convert.ToDateTime(dr["StartDate"]).CompareTo(seasonStart) < 0)
                    {
                        int bookingNumber = Convert.ToInt32(dr["BookingNumber"]);
                        cmd.Parameters["@BookingNumber"].Value = bookingNumber;
                        cmd.ExecuteNonQuery();
                    }
                }
                trans.Commit();
            }
            catch (System.Exception ex)
            {
                trans.Rollback();
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }

        public void InsertWeekParameters(DateTime date1, DateTime date2)
        {
            try
            {
                conn.Open();
                trans = conn.BeginTransaction();
                SqlCommand cmd = new SqlCommand("AddWeekParams", conn);
                cmd.Transaction = trans;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@StartWeek", date1));
                cmd.Parameters.Add(new SqlParameter("@EndWeek", date2));
                int result = cmd.ExecuteNonQuery();
                trans.Commit();
            }
            catch (System.Exception ex)
            {
                trans.Rollback();
            }
            finally
            {
                conn.Close();
            }
        }

        public void UpdateWeekParameters(DateTime date1, DateTime date2)
        {
            try
            {
                conn.Open();
                trans = conn.BeginTransaction();
                SqlCommand cmd = new SqlCommand("UpdateWeekParams", conn);
                cmd.Transaction = trans;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@StartWeek", date1));
                cmd.Parameters.Add(new SqlParameter("@EndWeek", date2));
                int result = cmd.ExecuteNonQuery();
                trans.Commit();
            }
            catch (System.Exception)
            {
                trans.Rollback();
            }
            finally
            {
                conn.Close();
            }
        }

        public int InsertVisaDocsObtainedInfo(int ContactNumber, string VisaDocsObtained, string Note)
        {
            try
            {
                conn.Open();
                trans = conn.BeginTransaction();
                SqlCommand cmd = new SqlCommand("AddVisaDocsObtainedInfo", conn);
                cmd.Transaction = trans;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@ContactNumber", ContactNumber));
                cmd.Parameters.Add(new SqlParameter("@VisaDocsObtained", VisaDocsObtained));
                cmd.Parameters.Add(new SqlParameter("@Note", Note));
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

        public int UpdateVisaDocsObtainedInfo(int ContactNumber)
        {
            try
            {
                conn.Open();
                trans = conn.BeginTransaction();
                SqlCommand cmd = new SqlCommand("UpdateVisaDocumentsObtainedInfo", conn);
                cmd.Transaction = trans;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@ContactNumber", ContactNumber));
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

        public string ReturnVisaDocStatus(int ContactNumber)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM VisaDocumentsObtained", ConnStr);
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            adapter.Fill(ds, "VisaDocumentsObtained");

            string VisaDocsObt = "";

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                if (Convert.ToInt32(dr["ContactNumber"]) == ContactNumber)
                {
                    VisaDocsObt = dr["VisaDocsObtained"].ToString();
                }
            }

            return VisaDocsObt;
        }

        public int LogUserAction(string userAction, string actionDetails)
        {
            try
            {
                conn.Open();
                trans = conn.BeginTransaction();
                SqlCommand cmd = new SqlCommand("LogUserAction", conn);
                cmd.Transaction = trans;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@UserAction", userAction));
                cmd.Parameters.Add(new SqlParameter("@ActionDetails", actionDetails));
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

        public DataSet GetWeekSettings()
        {
            DataSet ds = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM WeekSettings", ConnStr);
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            adapter.Fill(ds, "WeekSettings");
            return ds;
        }

        #region Contract-related methods
        public int AddContract(Contract contract)
        {
            try
            {
                conn.Open();
                trans = conn.BeginTransaction();
                SqlCommand cmd = new SqlCommand("AddContract", conn);
                cmd.Transaction = trans;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@pContractNumber", contract.ContractNumber));
                cmd.Parameters.Add(new SqlParameter("@pContractDate", contract.ContractDate));

                if (contract.ReceiptNumber == null)
                {
                    cmd.Parameters.Add(new SqlParameter("pReceiptNumber", DBNull.Value));
                }
                else
                {
                    cmd.Parameters.Add(new SqlParameter("pReceiptNumber", contract.ReceiptNumber));
                }

                if (contract.ReceiptIssueDate == null)
                {
                    cmd.Parameters.Add(new SqlParameter("@pReceiptDate", DBNull.Value));
                }
                else
                {
                    cmd.Parameters.Add(new SqlParameter("@pReceiptDate", contract.ReceiptIssueDate));
                }
                cmd.Parameters.Add(new SqlParameter("@pBookingNumber", contract.BookingNumber));
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

        public Contract GetContractByBookingNumber(int bookingNumber)
        {

            Contract contract;
            SqlCommand cmd = new SqlCommand("GetContractByBookingNumber", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@pBookingNumber", bookingNumber));
            DataSet ds = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            adapter.Fill(ds);

            if (ds.Tables[0].Rows.Count == 0)
            {
                contract = null;
            }
            else
            {
                DataRow result = ds.Tables[0].Rows[0];
                contract = new Contract();
                contract.ContracId = Convert.ToInt32(result["ContractId"]);
                contract.ContractNumber = result["ContractNumber"].ToString();
                contract.ContractDate = result["ContractDate"].ToString();
                int receiptNumber;
                if (Int32.TryParse(result["ReceiptNumber"].ToString(), out receiptNumber))
                {
                    contract.ReceiptNumber = receiptNumber;
                }
                else
                {
                    contract.ReceiptNumber = null;
                }
                contract.ReceiptIssueDate = result["ReceiptIssueDate"].ToString();
                contract.BookingNumber = Convert.ToInt32(result["BookingNumber"]);
            }

            return contract;
        }

        public int UpdateContract(Contract contract)
        {
            try
            {
                conn.Open();
                trans = conn.BeginTransaction();
                SqlCommand cmd = new SqlCommand("UpdateContract", conn);
                cmd.Transaction = trans;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@pContractNumber", contract.ContractNumber));
                cmd.Parameters.Add(new SqlParameter("@pContractDate", contract.ContractDate));
                if (contract.ReceiptNumber == null)
                {
                    cmd.Parameters.Add(new SqlParameter("pReceiptNumber", DBNull.Value));
                }
                else
                {
                    cmd.Parameters.Add(new SqlParameter("pReceiptNumber", contract.ReceiptNumber));
                }

                if (contract.ReceiptIssueDate == null)
                {
                    cmd.Parameters.Add(new SqlParameter("@pReceiptDate", DBNull.Value));
                }
                else
                {
                    cmd.Parameters.Add(new SqlParameter("@pReceiptDate", contract.ReceiptIssueDate));
                };
                cmd.Parameters.Add(new SqlParameter("@pBookingNumber", contract.BookingNumber));
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

        public int DeleteContract(Contract contract)
        {
            try
            {
                conn.Open();
                trans = conn.BeginTransaction();
                SqlCommand cmd = new SqlCommand("DeleteContractByBookingId", conn);
                cmd.Transaction = trans;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@pBookingNumber", contract.BookingNumber));
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
        #endregion

    }

    public class Contact
    {
        //fields
        public int ContactNumber;
        public string FirstName;
        public string LastName;
        public string DateOfBirth;
        public string PassportNumber;
        public string Address;
        public string City;
        public string PoBox;
        public string Phone;
        public string MobilePhone;
        public string Email;
        public string MotherName;
        public string FatherName;
        public string MotherPhone;
        public string FatherPhone;
        public string ContactType;
        public string GroupLeader;
        public string SchoolName;
        public string SchoolAddress;
        public string TeacherPhone;
        public string EBClubMember;
        public string PromoCodeMember;
        public string AgencyName;
        public string MarketingSource;
        public int VersionCode;
        public string PrimaryContact;
        public string MotherEmail;
        public string FatherEmail;

        public Contact()
        {

        }

    }

    public class Booking
    {
        public int BookingNumber;
        public int ContactNumber;
        public string DateOfBooking;
        public decimal TotalPrice;
        public string RequiresVisa;
        public string VisaAppointmentScheduled;
        public string DateOfAppointment;
        public string TimeOfAppointment;
        public string VisaObtained;
        public string VisaRejected;
        public string IsBooked;
        public string IsCancelled;
        public string ReasonForCancellation;
        public string BookingCode;
        public string PaymentDeadline;
        public decimal OutstandingBalance;
        public string Active;
        public string GWFnumber;
        public string CancellationDate;
        public int VersionCode;
        public string VisaDocumentsObtained;
        public string BookingType;
        public string BusNeeded;

        public Booking()
        {

        }
    }

    public class BookingItems
    {
        public int BookingNumber;
        public int ItemNumber;
        public int ProductNumber;
        public string ItemName;
        public string StartDate;
        public string ReturnDate;
        public int Qty;
        public decimal ItemPrice;
        public decimal Discount;
        public string ArrivalTime;
        public string DepartueTime;
        public string ItemProvider;
        public string BookingNote;
        public string ItemType;
        public int VersionCode;

        public BookingItems()
        {
        }
    }

    public class PaymentRate
    {
        public int BookingNumber;
        public int RateNumber;
        public string date;
        public decimal AmountPaid;
        public string Currency;
        public string PaymentMethod;
        public decimal ConversionValue;
        public string RateNote;
        public decimal OriginalValue;
        public string OriginalCurrency;
        public int VersionCode;

        public PaymentRate()
        {

        }
    }

    public class Provider
    {
        public int providerNumber;
        public string providerName;
        public string providerAddress;
        public string contactPerson;
        public string contactPosition;
        public string contactEmail;
        public string contactPhone;
        public string contactPerson2;
        public string contactPosition2;
        public string contactEmail2;
        public string contactPhone2;
        public string contactPerson3;
        public string contactPosition3;
        public string contactEmail3;
        public string contactPhone3;
        public string contactPerson4;
        public string contactPosition4;
        public string contactEmail4;
        public string contactPhone4;
        public string contactPerson5;
        public string contactPosition5;
        public string contactEmail5;
        public string contactPhone5;
        public int VersionCode;

        public Provider()
        {

        }
    }

    public class Product
    {
        public int productCode;
        public string productName;
        public string provider;
        public decimal price;
        public decimal costPrice;
        public string discount;
        public string currency;
        public string productType;
        public string productGroup;
        public int VersionCode;

        public Product()
        {

        }
    }

    public class User
    {
        public string username;
        public string password;
        public string userRole;
        public int VersionCode;

        public User()
        {

        }
    }

    public class Marketingsource
    {
        public int msNumber;
        public string msName;
        public string msContact;
        public string msDetails;
        public decimal msPrice;
        public int VersionCode;

        public Marketingsource()
        {
        }
    }

    public class Contract
    {
        private int contracId;
        private string contractNumber;
        private string contractDate;
        private int? receiptNumber;
        private string receiptIssueDate;
        private int bookingNumber;

        public int BookingNumber
        {
            get { return bookingNumber; }
            set { bookingNumber = value; }
        }

        public int ContracId
        {
            get { return contracId; }
            set { contracId = value; }
        }

        public string ContractNumber
        {
            get { return contractNumber; }
            set { contractNumber = value; }
        }

        public string ContractDate
        {
            get { return contractDate; }
            set { contractDate = value; }
        }

        public int? ReceiptNumber
        {
            get { return receiptNumber; }
            set { receiptNumber = value; }
        }

        public string ReceiptIssueDate
        {
            get { return receiptIssueDate; }
            set { receiptIssueDate = value; }
        }

        public Contract()
        {

        }
    }
}
