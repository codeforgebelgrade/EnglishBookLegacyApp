using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using SummerSchoolsApp.DBBroker;

namespace SummerSchoolsApp
{
    public partial class Form1 : Form
    {
        //Broker broker;

        frmLogin parentForm;

        public Form1()
        {
            InitializeComponent();
            ControlClientInfo cl = new ControlClientInfo();
            cl.Dock = DockStyle.Fill;
            this.panel2.Controls.Add(cl);
            ContactBtn.BackColor = SystemColors.Control;
        }

        private void ContactBtn_Click(object sender, EventArgs e)
        {
            RepaintButtons();
            ContactBtn.BackColor = SystemColors.Control;
            this.panel2.Controls.Clear();
            ControlClientInfo cl = new ControlClientInfo();
            cl.Dock = DockStyle.Fill;
            this.panel2.Controls.Add(cl);
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            RepaintButtons();
            EditBtn.BackColor = SystemColors.Control;
            this.panel2.Controls.Clear();
            ControlEditContacts editControl = new ControlEditContacts();
            editControl.Dock = DockStyle.Fill;
            this.panel2.Controls.Add(editControl);
        }

        private void MaintenanceBtn_Click(object sender, EventArgs e)
        {
            RepaintButtons();
            MaintenanceBtn.BackColor = SystemColors.Control;
            this.panel2.Controls.Clear();
            ControlMaintenance maintenanceControl = new ControlMaintenance();
            maintenanceControl.Dock = DockStyle.Fill;
            this.panel2.Controls.Add(maintenanceControl);
        }

        private void SettingsBtn_Click(object sender, EventArgs e)
        {
            RepaintButtons();
            SettingsBtn.BackColor = SystemColors.Control;
            this.panel2.Controls.Clear();
            ControlUserSettings us = new ControlUserSettings();
            us.Dock = DockStyle.Fill;
            this.panel2.Controls.Add(us);
        }

        public void LoadSettings(string username, string userRole)
        {
            //Disable 'User settings' button for users
            if (userRole.Equals("User"))
            {
                SettingsBtn.Enabled = false;
                SettingsBtn.BackColor = Color.Gray;
            }
        }

        public void setParentForm(frmLogin caller)
        {
            parentForm = caller as frmLogin;
        }

        private void MainFrm_Closing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("The application will exit now. Are you sure?", "Info Box", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                e.Cancel = false;
                parentForm.Close();
            }
            else
                e.Cancel = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.panel2.Controls.Clear();
            ControlBookingInformation bic = new ControlBookingInformation();
            this.panel2.Controls.Add(bic);
        }

        private void RepaintButtons()
        {
            foreach (Button btn in this.panelButtons.Controls)
            {
                btn.BackColor = SystemColors.ControlDarkDark;
            }
        }

    }
}
