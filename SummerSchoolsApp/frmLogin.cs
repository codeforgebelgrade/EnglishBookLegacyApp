using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SummerSchoolsApp.DBBroker;
using System.Configuration;
using System.IO; 

namespace SummerSchoolsApp
{
    public partial class frmLogin : Form
    {

        Broker broker;
        bool userExist;

        public frmLogin()
        {
            InitializeComponent();

            userExist = false;
            broker = new Broker();

            textBoxPword.KeyDown += new KeyEventHandler(textBoxPword_KeyDown);
        }

        void textBoxPword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                PerformLogin();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PerformLogin();
        }

        private bool CheckMasterCredentials(string uname, string pword)
        {
            bool result;

            string masterUname = ConfigurationManager.AppSettings["masterUsername"].ToString();
            string masterPword = ConfigurationManager.AppSettings["masterPassword"].ToString();

            if (uname.Equals(masterUname) && pword.Equals(masterPword))
            {
                result = true;
            }
            else
            {
                result = false;
            }

            return result;
        }

        private string CheckDatabaseCredentials(string uname, string pword)
        {
            string userRole = "none";

            DataSet ds_users = broker.ReturnUserInfo();

            foreach (DataRow row in ds_users.Tables[0].Rows)
            {
                if (uname == row["Username"].ToString() && pword == row["UserPassword"].ToString())
                {
                    userRole = row["UserRole"].ToString();
                }
            }

            if (userRole.Equals(null) || userRole.Equals(string.Empty))
            {
                userRole = "User";
            }
 
            return userRole;

        }

        private void PerformLogin()
        {
            try
            {
                string uname = this.textBoxUname.Text;
                string pword = this.textBoxPword.Text;

                string userRole = string.Empty;

                if (CheckMasterCredentials(uname, pword) == true)
                {
                    userExist = true;
                    userRole = "Administrator";
                }
                else
                {
                    userRole = CheckDatabaseCredentials(uname, pword);

                    if (!userRole.Equals("none"))
                    {
                        userExist = true;
                    }
                }

                if (userExist == true)
                {
                    if (userRole.Equals("Administrator"))
                    {
                        Form1 mainForm = new Form1();
                        mainForm.LoadSettings(uname, userRole);
                        mainForm.setParentForm(this);
                        mainForm.Show();
                        this.Hide();
                    }

                    else
                    {
                        Form1 mainForm = new Form1();
                        mainForm.LoadSettings(uname, userRole);
                        mainForm.setParentForm(this);
                        mainForm.Show();
                        this.Hide();
                    }
                }
                else
                {
                    MessageBox.Show("Incorrect username and/or password.");
                }
            }
            catch (System.Data.SqlClient.SqlException)
            {
                MessageBox.Show("Application cannot start! Please check your database connection. Application will exit now.");
                Application.Exit();
            }
            catch (System.Exception)
            {
                MessageBox.Show("Application cannot start!. Please check your user credentials. Application will exit now.");
                Application.Exit();
            }
        }
    }
}
