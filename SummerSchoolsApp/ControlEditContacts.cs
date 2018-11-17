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
    public partial class ControlEditContacts : UserControl
    {
        Broker broker;
        int contactNum;

        decimal TotalAmount;
        ArrayList ItemList;
        BookingItems item;
        int itemCounter;
        Contact contact;
        DataSet teachers;
        DataSet marketingSources;
        DataSet agencies;
        DataSet ds_contacts;
        int VersionCode;


        public ControlEditContacts()
        {
            InitializeComponent();
            this.panel1.Enabled = false;
            this.panel2.Enabled = false;
            this.panel3.Enabled = false;
            this.button3.Enabled = false;
            this.panel4.Enabled = false;
            this.button5.Enabled = false;

            broker = new Broker();

            itemCounter = 0;
            TotalAmount = 0;

            ItemList = new ArrayList();

            teachers = broker.GetAllTeachers();
            marketingSources = broker.ReturnMarketingSourceInfo();
            agencies = broker.GetAllAgencies();

            checkBoxMother.CheckedChanged += new EventHandler(checkBoxMother_CheckedChanged);
            checkBoxFather.CheckedChanged += new EventHandler(checkBoxFather_CheckedChanged);

            foreach (DataRow row in teachers.Tables[0].Rows)
            {
                string teacherName = row["FirstName"].ToString() + " " + row["LastName"].ToString();
                comboBoxGroupLeader.Items.Add(teacherName);
            }

            foreach (DataRow row in marketingSources.Tables[0].Rows)
            {
                string sourceName = row["msName"].ToString();
                comboBoxMarketingSource.Items.Add(sourceName);
            }

            foreach (DataRow row in agencies.Tables[0].Rows)
            {
                string sourceName = row["LastName"].ToString();
                comboBoxAgency.Items.Add(sourceName);
            }

            BirthDatePicker.ValueChanged += new EventHandler(BirthDatePicker_ValueChanged);

            SetUpAutoCompleteBox();

        }

        void checkBoxFather_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxFather.Checked)
            {
                checkBoxMother.Enabled = false;
            }
            else
            {
                checkBoxMother.Enabled = true;
            }
        }

        void checkBoxMother_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxMother.Checked)
            {
                checkBoxFather.Enabled = false;
            }
            else
            {
                checkBoxFather.Enabled = true;
            }
        }

        void BirthDatePicker_ValueChanged(object sender, EventArgs e)
        {
            textBoxDateOfBirth.Text = BirthDatePicker.Text;
        }

        //show contact data, based on the search criteria
        private void button2_Click(object sender, EventArgs e)
        {
            GetContactDataByContactName(textBoxNameCheck.Text.Trim());
        }

        private void GetContactDataByContactName(string contactName)
        {
            this.chkListBoxClientBookings.Items.Clear();
            string contactFullName = contactName;
            string[] fullNameSplit = new string[2];
            char[] separator = new char[1];
            separator[0] = ':';
            fullNameSplit = contactFullName.Split(separator);
            contactNum = Convert.ToInt32(fullNameSplit[1]);

            DataSet returnedClient = broker.GetContactInfoById(contactNum);

            if (returnedClient.Tables[0].Rows.Count < 1)
            {
                MessageBox.Show("Client with that number does not exist!");
            }
            else
            {
                ShowContactData(returnedClient);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                Contact contact = new Contact();

                contact.ContactNumber = contactNum;
                contact.FirstName = textBoxFirstName.Text.Trim();
                contact.LastName = textBoxLastName.Text.Trim();
                contact.DateOfBirth = textBoxDateOfBirth.Text;
                contact.PassportNumber = textBoxPassport.Text;
                contact.Address = textBoxAddress.Text;
                contact.City = textBoxCity.Text;
                contact.PoBox = textBoxPoBox.Text;
                contact.Phone = textBoxPhone.Text;

                if (textBoxMobilePhone.Text == "")
                {
                    contact.MobilePhone = "none";
                }
                else
                {
                    contact.MobilePhone = textBoxMobilePhone.Text;
                }
                if (this.textBoxEmail.Text == "")
                {
                    contact.Email = "none";
                }
                else
                {
                    contact.Email = textBoxEmail.Text;
                }
                
                contact.MotherName = textBoxMotherFirstName.Text;
                contact.FatherName = textBoxFatherName.Text;
                contact.MotherPhone = textBoxMotherPhone.Text;
                contact.FatherPhone = textBoxFatherPhone.Text;
                contact.MotherEmail = tbMotherEmail.Text;
                contact.FatherEmail = tbFatherEmail.Text;
                contact.ContactType = comboBox1.Text;
                contact.GroupLeader = comboBoxGroupLeader.Text;
                contact.SchoolName = textBoxSchoolName.Text;
                contact.SchoolAddress = textBoxTeacherAddress.Text;
                contact.TeacherPhone = textBoxTeacherPhone.Text;
                contact.AgencyName = comboBoxAgency.Text;
                contact.MarketingSource = comboBoxMarketingSource.Text;

                if (checkBoxEBClubMember.Checked == true)
                {
                    contact.EBClubMember = "yes";
                }
                else
                {
                    contact.EBClubMember = "no";
                }

                if (checkBoxPromoCodeMember.Checked == true)
                {
                    contact.PromoCodeMember = "yes";
                }
                else
                {
                    contact.PromoCodeMember = "no";
                }

                if (checkBoxMother.Checked)
                {
                    contact.PrimaryContact = "Mother";
                }

                if (checkBoxFather.Checked)
                {
                    contact.PrimaryContact = "Father";
                }

                if (!checkBoxMother.Checked && !checkBoxFather.Checked)
                {
                    contact.PrimaryContact = null;
                }

                contact.VersionCode = VersionCode;

                //CHECK IF CONTACT HAS BEEN MODIFIED

                DataSet ds_cont = broker.GetContactInfoById(contact.ContactNumber);
                
                bool IsModified = false;

                foreach (DataRow contactRow in ds_cont.Tables[0].Rows)
                {
                    if (contact.VersionCode == Convert.ToInt32(contactRow["VersionCode"]))
                    {
                        contact.VersionCode++;
                    }
                    else
                    {
                        IsModified = true;
                    }
                }

                if (IsModified == false)
                {
                    int result = broker.UpdateContact(contact);

                    if (result == -1)
                    {
                        MessageBox.Show("Changes saved!");
                        ClearAllFields();
                        ReloadDropdownMenus();
                        textBoxNameCheck.Clear();
                    }
                }
                else
                {
                    MessageBox.Show("This contact has been already modified by another user.");
                }
            }
            catch (System.Exception)
            {
                MessageBox.Show("It seems that something is wrong!");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmAddBooking abf = new frmAddBooking(contact.ContactNumber);
            abf.Show();
        }

        //SHOW BOOKING BUTTON
        private void button6_Click_1(object sender, EventArgs e)
        {
            string bookingCode = chkListBoxClientBookings.Text; //comboBox2.Text;

            if (bookingCode == null || bookingCode.Equals(string.Empty))
            {
                MessageBox.Show("You must choose a booking!");
            }
            else
            {
                DataSet ds_bookingExist = broker.GetBookingByCode(bookingCode);

                if (ds_bookingExist.Tables[0].Rows.Count == 0)
                {
                    MessageBox.Show("This booking was already deleted. Booking list will be reloaded now.");
                    RefreshBookings();
                }
                else
                {
                    frmBooking bf = new frmBooking(bookingCode);
                    bf.Show();
                }
            }
        }

        //REFRESH BOOKINGS BUTTON
        private void button4_Click_1(object sender, EventArgs e)
        {
            RefreshBookings();
        }

        private void ClearAllFields()
        {
            textBoxFirstName.Clear();
            textBoxLastName.Clear();
            textBoxPassport.Clear();
            textBoxAddress.Clear();
            textBoxCity.Clear();
            textBoxPoBox.Clear();
            textBoxPhone.Clear();
            textBoxMobilePhone.Clear();
            textBoxEmail.Clear();
            textBoxFatherName.Clear();
            textBoxFatherPhone.Clear();
            textBoxMotherPhone.Clear();
            textBoxMotherFirstName.Clear();
            textBoxSchoolName.Clear();
            textBoxTeacherAddress.Clear();
            textBoxTeacherPhone.Clear();

            checkBoxEBClubMember.Checked = false;
            checkBoxPromoCodeMember.Checked = false;

            panel1.Enabled = false;
            panel2.Enabled = false;
            panel3.Enabled = false;
            panel4.Enabled = false;
            button5.Enabled = false;
        }

        private void ReloadDropdownMenus()
        {
            comboBoxGroupLeader.Items.Clear();
            comboBoxGroupLeader.Items.Add("Individual");
            teachers = broker.GetAllTeachers();
            foreach (DataRow row in teachers.Tables[0].Rows)
            {
                string teacherName = row["FirstName"].ToString() + " " + row["LastName"].ToString();
                comboBoxGroupLeader.Items.Add(teacherName);
            }

            comboBoxMarketingSource.Items.Clear();
            foreach (DataRow row in marketingSources.Tables[0].Rows)
            {
                string sourceName = row["msName"].ToString();
                comboBoxMarketingSource.Items.Add(sourceName);
            }

            comboBoxAgency.Items.Clear();
            comboBoxAgency.Items.Add("No agency");
            agencies = broker.GetAllAgencies();
            foreach (DataRow row in agencies.Tables[0].Rows)
            {
                string sourceName = row["LastName"].ToString();
                comboBoxAgency.Items.Add(sourceName);
            }

            comboBoxAgency.SelectedIndex = 0;
            comboBoxGroupLeader.SelectedIndex = 0;
            comboBoxMarketingSource.SelectedIndex = 0;
            comboBox1.SelectedIndex = 0;
        }

        private void RefreshBookings()
        {
            DataSet bookings = broker.GetBookingsByContact(contact.ContactNumber);
            this.chkListBoxClientBookings.Items.Clear();

            if (bookings.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in bookings.Tables[0].Rows)
                {
                    chkListBoxClientBookings.Items.Add(row["BookingCode"].ToString());
                }
                chkListBoxClientBookings.Enabled = true;
            }
            else
            {
                chkListBoxClientBookings.Items.Clear();
                chkListBoxClientBookings.Enabled = false;
            }
        }

        //set up the auto complete options for each search field
        public void SetUpAutoCompleteBox()
        {
            textBoxNameCheck.Clear();
            ds_contacts = broker.GetAllAvailableContacts();
            textBoxNameCheck.AutoCompleteCustomSource.Clear();

            foreach (DataRow row in ds_contacts.Tables[0].Rows)
            {
                string contact_fullname = row["FirstName"] + " " + row["LastName"] + ", " + "CN:" + row["ContactNumber"];
                textBoxNameCheck.AutoCompleteCustomSource.Add(contact_fullname);
                string contact_fullname_lastname = row["LastName"] + " " + row["FirstName"] + ", " + "CN:" + row["ContactNumber"];
                textBoxNameCheck.AutoCompleteCustomSource.Add(contact_fullname_lastname);
            }
        }

        public void ShowContactData(DataSet returnedClient)
        {
            this.panel1.Enabled = true;
            this.panel2.Enabled = true;
            this.panel3.Enabled = true;
            this.button3.Enabled = true;
            this.panel4.Enabled = true;
            this.button5.Enabled = true;

            contact = new Contact();

            foreach (DataRow row in returnedClient.Tables[0].Rows)
            {
                contact.ContactNumber = Convert.ToInt32(row["ContactNumber"].ToString());
                contact.FirstName = row["FirstName"].ToString();
                contact.LastName = row["LastName"].ToString();
                contact.DateOfBirth = row["DateOfBirth"].ToString();
                contact.PassportNumber = row["PassportNum"].ToString();
                contact.Address = row["ContactAddress"].ToString();
                contact.City = row["City"].ToString();
                contact.PoBox = row["PoBox"].ToString();
                contact.Phone = row["Phone"].ToString();
                contact.MobilePhone = row["MobilePhone"].ToString();
                contact.Email = row["Email"].ToString();
                contact.MotherName = row["MotherName"].ToString();
                contact.FatherName = row["FatherName"].ToString();
                contact.MotherPhone = row["MotherPhone"].ToString();
                contact.FatherPhone = row["FatherPhone"].ToString();
                contact.ContactType = row["ContactType"].ToString();
                contact.GroupLeader = row["GroupLeader"].ToString();
                contact.SchoolName = row["SchoolName"].ToString();
                contact.SchoolAddress = row["SchoolAddress"].ToString();
                contact.TeacherPhone = row["TeacherPhone"].ToString();
                contact.AgencyName = row["AgencyName"].ToString();
                contact.EBClubMember = row["EBClubMember"].ToString();
                contact.PromoCodeMember = row["PromoCodeMember"].ToString();
                contact.MarketingSource = row["MarketingMaterial"].ToString();
                contact.PrimaryContact = row["ContactStringA"].ToString();
                contact.VersionCode = Convert.ToInt32(row["VersionCode"]);
                contact.MotherEmail = row["MotherEmail"].ToString();
                contact.FatherEmail = row["FatherEmail"].ToString();
                VersionCode = contact.VersionCode;

                this.textBoxFirstName.Text = contact.FirstName;
                this.textBoxLastName.Text = contact.LastName;
                this.textBoxDateOfBirth.Text = contact.DateOfBirth;
                this.textBoxPassport.Text = contact.PassportNumber;
                this.textBoxAddress.Text = contact.Address;
                this.textBoxCity.Text = contact.City;
                this.textBoxPoBox.Text = contact.PoBox;
                this.textBoxPhone.Text = contact.Phone;
                this.textBoxMobilePhone.Text = contact.MobilePhone;
                this.textBoxEmail.Text = contact.Email;
                this.textBoxMotherFirstName.Text = contact.MotherName;
                this.textBoxFatherName.Text = contact.FatherName;
                this.textBoxMotherPhone.Text = contact.MotherPhone;
                this.textBoxFatherPhone.Text = contact.FatherPhone;
                this.tbMotherEmail.Text = contact.MotherEmail;
                this.tbFatherEmail.Text = contact.FatherEmail;
                this.comboBoxGroupLeader.Text = contact.GroupLeader;
                this.comboBoxMarketingSource.Text = contact.MarketingSource;

                if (contact.ContactType.Equals("Agency"))
                {
                    this.comboBox1.SelectedIndex = 0;
                    this.textBoxSchoolName.Text = contact.SchoolName;
                    this.textBoxTeacherAddress.Text = contact.SchoolAddress;
                    this.textBoxTeacherPhone.Text = contact.TeacherPhone;
                }

                if (contact.ContactType.Equals("Other"))
                {
                    this.comboBox1.SelectedIndex = 1;
                }

                if (contact.ContactType.Equals("Student"))
                {
                    this.comboBox1.SelectedIndex = 2;
                    comboBoxAgency.Text = contact.AgencyName;
                }

                if (contact.ContactType.Equals("Teacher"))
                {
                    this.comboBox1.SelectedIndex = 3;
                    this.textBoxSchoolName.Text = contact.SchoolName;
                    this.textBoxTeacherAddress.Text = contact.SchoolAddress;
                    this.textBoxTeacherPhone.Text = contact.TeacherPhone;
                }

                if (contact.ContactType.Equals("Teacher-Agency"))
                {
                    this.comboBox1.SelectedIndex = 4;
                    this.textBoxSchoolName.Text = contact.SchoolName;
                    this.textBoxTeacherAddress.Text = contact.SchoolAddress;
                    this.textBoxTeacherPhone.Text = contact.TeacherPhone;
                }

                if (contact.EBClubMember == "yes")
                {
                    this.checkBoxEBClubMember.Checked = true;
                }

                if (contact.PromoCodeMember == "yes")
                {
                    this.checkBoxPromoCodeMember.Checked = true;
                }

                if (contact.PrimaryContact.Equals("Mother"))
                {
                    checkBoxMother.Checked = true;
                }

                if (contact.PrimaryContact.Equals("Father"))
                {
                    checkBoxFather.Checked = true;
                }
            }

            //LOADING BOOKINGS FOR THE CLIENT
            
            DataSet bookings = broker.GetBookingsByContact(contact.ContactNumber);
            if (bookings.Tables[0].Rows.Count > 0)
            {
                //chkListBoxClientBookings.Enabled = true;
                foreach (DataRow row in bookings.Tables[0].Rows)
                {
                    chkListBoxClientBookings.Items.Add(row["BookingCode"].ToString());
                }
            }
            else
            {
                chkListBoxClientBookings.Enabled = false;
            }
        }

        private void deselectOtherItems(object sender, ItemCheckEventArgs e)
        {
            //when an item is selected, deselect all other items
            if (e.NewValue == CheckState.Checked)
                for (int ix = 0; ix < chkListBoxClientBookings.Items.Count; ++ix)
                {
                    if (e.Index != ix)
                    {
                        chkListBoxClientBookings.SetItemChecked(ix, false);
                    }
                }
        }
    }
}
