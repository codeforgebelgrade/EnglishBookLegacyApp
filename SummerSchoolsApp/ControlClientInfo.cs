using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using SummerSchoolsApp.DBBroker;


namespace SummerSchoolsApp
{
    public partial class ControlClientInfo : UserControl
    {
        Contact cont;
        Broker broker;
        DataSet ds;
        ArrayList ItemList;
        DataSet teachers;
        DataSet marketingSources;
        DataSet agencies;
        DataSet contacts;

        public ControlClientInfo()
        {
            InitializeComponent();
            broker = new Broker();
            //this.comboBox1.SelectedIndex = 0;
            //this.comboBoxGroupLeader.SelectedIndex = 0;

            teachers = new DataSet();
            agencies = new DataSet();
            cont = new Contact();
            ItemList = new ArrayList();

            checkBoxMother.CheckedChanged += new EventHandler(checkBoxMother_CheckedChanged);
            checkBoxFather.CheckedChanged += new EventHandler(checkBoxFather_CheckedChanged);

            ds = broker.ReturnProductInfo();
            teachers = broker.GetAllTeachers();
            marketingSources = broker.ReturnMarketingSourceInfo();
            agencies = broker.GetAllAgencies();
            contacts = broker.GetAllAvailableContacts();

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

            comboBoxMarketingSource.SelectedIndex = 0;
            //comboBoxAgency.SelectedItem = "No agency";
            //comboBoxGroupLeader.SelectedItem = "Individual";

            textBoxLastName.TextChanged += new EventHandler(textBoxLastName_TextChanged);
        }

        void textBoxLastName_TextChanged(object sender, EventArgs e)
        {
            //clear the box
            textBoxSimilarContacts.Clear();

            int numberOfSimilarContacts = 0;
            ArrayList contactIds = new ArrayList();

            //find the similar names, count them, save their IDs
            if (textBoxFirstName.Text.Trim() != string.Empty)
            {
                foreach (DataRow cr in contacts.Tables[0].Rows)
                {
                    if (cr["FirstName"].ToString().ToLower().Equals(textBoxFirstName.Text.Trim().ToLower()) &&
                        cr["LastName"].ToString().ToLower().Equals(textBoxLastName.Text.Trim().ToLower()))
                    {
                        numberOfSimilarContacts++;
                        contactIds.Add(Convert.ToInt32(cr["ContactNumber"]));
                    }
                }
            }

            if (numberOfSimilarContacts > 0 && contactIds.Count > 0)
            {
                MessageBox.Show("Contact with this name already exists!");

                textBoxSimilarContacts.Visible = true;
                labelSimilarContacts.Visible = true;
                labelSimilarContacts.Text = numberOfSimilarContacts + " contact(s) with the same name detected! Please chack the data below: ";

                int counter = 0;

                foreach (int id in contactIds)
                {
                    counter++;

                    DataSet ds_contact_info = broker.GetContactInfoById(id);
                    this.textBoxSimilarContacts.Text += "Contact information # " + counter + ": " + "\r\n"+
                                          "First name: " + ds_contact_info.Tables[0].Rows[0]["FirstName"].ToString() + "\r\n" +
                                          "Last name: " + ds_contact_info.Tables[0].Rows[0]["LastName"].ToString() + "\r\n" +
                                          "Date of birth: " + ds_contact_info.Tables[0].Rows[0]["DateOfBirth"].ToString() + "\r\n" +
                                          "Email address: " + ds_contact_info.Tables[0].Rows[0]["Email"].ToString() + "\r\n" +
                                          "Mobile phone: " + ds_contact_info.Tables[0].Rows[0]["MobilePhone"].ToString() + "\r\n" +
                                          "\r\n";

                }

            }
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

        void ClearAllFields()
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
            textBoxFatherFirstName.Clear();
            textBoxFatherPhone.Clear();
            textBoxMotherPhone.Clear();
            textBoxMotherFirstName.Clear();

            textBoxSchoolName.Clear();
            textBoxTeacherAddress.Clear();
            textBoxTeacherPhone.Clear();

            checkBoxEBClubMember.Checked = false;
            checkBoxPromoCodeMember.Checked = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
        }

        //this method checks if required fields are filled
        private bool CheckRequiredFields()
        {
            bool result = true;

            if (this.textBoxFirstName.Text == string.Empty || this.textBoxLastName.Text == string.Empty)
            {
                result = false;
            }

            if (this.textBoxEmail.Text == string.Empty && this.textBoxMobilePhone.Text == string.Empty)
            {
                result = false;
            }

            if (this.comboBox1.Text == string.Empty || this.comboBoxAgency.Text == string.Empty || this.comboBoxGroupLeader.Text == string.Empty)
            {
                result = false;
            }

            return result;
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

            comboBoxMarketingSource.SelectedIndex = 0;
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            if (CheckRequiredFields() != true)
            {
                MessageBox.Show("Some of the required fields are empty! Also check if you have assigned group leader, agancy and type to a contact.");
            }
            else
            {
                //ADDING NEW CONTACT
                Contact contact = new Contact();

                contact.FirstName = textBoxFirstName.Text.Trim();
                contact.LastName = textBoxLastName.Text.Trim();
                contact.DateOfBirth = dateTimePickerBirth.Text;
                contact.PassportNumber = textBoxPassport.Text;
                contact.Address = textBoxAddress.Text;
                contact.City = textBoxCity.Text;
                contact.Phone = textBoxPhone.Text;
                contact.PoBox = textBoxPoBox.Text;

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
                contact.FatherName = textBoxFatherFirstName.Text;
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

                int result = broker.InsertContact(contact);

                if (result == -1)
                {
                    MessageBox.Show("Client added to database!");
                    ClearAllFields();
                    ReloadDropdownMenus();
                    labelSimilarContacts.Visible = false;
                    textBoxSimilarContacts.Clear();
                    textBoxSimilarContacts.Visible = false;
                    contacts = broker.GetAllAvailableContacts();
                }
                else
                {
                    MessageBox.Show("Database error! Unable to save client data!");
                    ReloadDropdownMenus();
                }
            }
        }
    }
}
