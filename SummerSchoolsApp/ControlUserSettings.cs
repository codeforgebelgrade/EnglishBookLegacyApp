using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Data.Sql;
using System.Data.SqlClient;
using SummerSchoolsApp.DBBroker;

namespace SummerSchoolsApp
{
    public partial class ControlUserSettings : UserControl
    {
        string connStr;
        string connStrReports;
        System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        Broker broker = new Broker();

        public ControlUserSettings()
        {
            InitializeComponent();
            RefreshSeasonSettings();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DateTime seasonStart = dtSeasonStart.Value;
            DateTime seasonEnd = dtSeasonEnd.Value;

            DataSet ds_season = broker.ReturnSeasonSettings();
            int rowCount = ds_season.Tables[0].Rows.Count;
            int result = 0;

            if (rowCount == 1)
            {
                result = broker.UpdateSeasonSettings(seasonStart, seasonEnd);
            }
            else
            {
                result = broker.AddSeasonSettings(seasonStart, seasonEnd);
            }

            if (result != 13)
            {
                MessageBox.Show("New season settings saved!");
            }
            else
            {
                MessageBox.Show("Error while saving settings! ", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            RefreshSeasonSettings();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet ds_season = broker.ReturnSeasonSettings();
                DataRow dr_season = ds_season.Tables[0].Rows[0];
                DateTime seasonStart = Convert.ToDateTime(dr_season["StartDate"]);
                broker.UpdateBookingStatus(seasonStart);
                MessageBox.Show("Bookings belonging to previous season are deactivated!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while deactivating bookings: " + ex.Message, "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RefreshSeasonSettings()
        {
            DataSet ds_season = broker.ReturnSeasonSettings();
            if (ds_season.Tables[0].Rows.Count == 0)
            {
                MessageBox.Show("Please add season settings!");
            }
            else
            {
                DataRow dr_season = ds_season.Tables[0].Rows[0];
                this.dtSeasonStart.Value = Convert.ToDateTime(dr_season["StartDate"]);
                this.dtSeasonEnd.Value = Convert.ToDateTime(dr_season["EndDate"]);
            }
        }
    }
}
