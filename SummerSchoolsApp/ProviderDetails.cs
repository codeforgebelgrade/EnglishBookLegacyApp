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
    public partial class ProviderDetails : Form
    {
        Broker broker;
        int providerNumber;
        DataSet ds_provider;
        string old_provider_name;
        int currentVersion;

        public ProviderDetails(int searchNumber)
        {
            InitializeComponent();
            providerNumber = searchNumber;
            broker = new Broker();
            ds_provider = new DataSet();

            ds_provider = broker.GetProviderByNumber(providerNumber);

            foreach (DataRow row in ds_provider.Tables[0].Rows)
            {
                this.textBox1.Text = providerNumber.ToString();
                this.textBoxProviderName.Text = row["ProviderName"].ToString();

                old_provider_name = row["ProviderName"].ToString();

                this.textBoxProviderAddress.Text = row["ProviderAddress"].ToString();
                this.textBoxContactPerson.Text = row["ContactPerson"].ToString();
                this.textBoxContactPosition.Text = row["ContactPosition"].ToString();
                this.textBoxContactPhone.Text = row["ContactPhone"].ToString();
                this.textBoxContactEmail.Text = row["ContactEmail"].ToString();
                this.textBoxContactPerson2.Text = row["ContactPerson2"].ToString();
                this.tbContactPosition2.Text = row["ContactPosition2"].ToString();
                this.tbContactPhone2.Text = row["ContactPhone2"].ToString();
                this.tbContactEmail2.Text = row["ContactEmail2"].ToString();
                this.textBoxContactPerson3.Text = row["ContactPerson3"].ToString();
                this.tbContactPosition3.Text = row["ContactPosition3"].ToString();
                this.tbContactPhone3.Text = row["ContactPhone3"].ToString();
                this.tbContactEmail3.Text = row["ContactEmail3"].ToString();
                this.textBoxContactPerson4.Text = row["ContactPerson4"].ToString();
                this.tbcontactPosition4.Text = row["ContactPosition4"].ToString();
                this.tbContactPhone4.Text = row["ContactPhone4"].ToString();
                this.tbContactEmail4.Text = row["ContactEmail4"].ToString();
                this.textBoxContactPerson5.Text = row["ContactPerson5"].ToString();
                this.tbContactPosition5.Text = row["ContactPosition5"].ToString();
                this.tbContactPhone5.Text = row["ContactPhone5"].ToString();
                this.tbContactEmail5.Text = row["ContactEmail5"].ToString();
                currentVersion = Convert.ToInt32(row["VersionCode"]);

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Provider prov = new Provider();

            prov.providerNumber = providerNumber;
            prov.providerName = textBoxProviderName.Text;
            prov.providerAddress = textBoxProviderAddress.Text;
            prov.contactPerson = textBoxContactPerson.Text;
            prov.contactPosition = textBoxContactPosition.Text;
            prov.contactPhone = textBoxContactPhone.Text;
            prov.contactEmail = textBoxContactEmail.Text;
            prov.contactPerson2 = textBoxContactPerson2.Text;
            prov.contactPosition2 = tbContactPosition2.Text;
            prov.contactPhone2 = tbContactPhone2.Text;
            prov.contactEmail2 = tbContactEmail2.Text;
            prov.contactPerson3 = textBoxContactPerson3.Text;
            prov.contactPosition3 = tbContactPosition3.Text;
            prov.contactPhone3 = tbContactPhone3.Text;
            prov.contactEmail3 = tbContactEmail3.Text;
            prov.contactPerson4 = textBoxContactPerson4.Text;
            prov.contactPosition4 = tbcontactPosition4.Text;
            prov.contactPhone4 = tbContactPhone4.Text;
            prov.contactEmail4 = tbContactEmail4.Text;
            prov.contactPerson5 = textBoxContactPerson5.Text;
            prov.contactPosition5 = tbContactPosition5.Text;
            prov.contactPhone5 = tbContactPhone5.Text;
            prov.contactEmail5 = tbContactEmail5.Text;
            prov.VersionCode = currentVersion + 1;

            int updateResult = broker.UpdateProviderByNumber(prov);

            if (updateResult != 13)
            {

                DataSet ds_products = broker.ReturnProductInfo();

                foreach (DataRow dr in ds_products.Tables[0].Rows)
                {
                    if (dr["ProductProvider"].ToString().ToLower() == old_provider_name.ToLower())
                    {
                        Product product = new Product();
                        product.productCode = Convert.ToInt32(dr["ProductCode"]);
                        product.productName = dr["ProductName"].ToString();
                        product.provider = prov.providerName;
                        product.price = Convert.ToDecimal(dr["ProductPrice"]);
                        product.currency = dr["Currency"].ToString();
                        product.productType = dr["ProductType"].ToString();
                        product.productGroup = dr["ProductStringA"].ToString();
                        product.VersionCode = Convert.ToInt32(dr["VersionCode"]);

                        int result = broker.UpdateProductBycode(product);

                        if (result == 13)
                        {
                            MessageBox.Show("ERROR: Unable to update product information!");
                            this.Enabled = false;
                        }
                        /*else
                        {
                            MessageBox.Show("ERROR: Unable to update product information!");
                            this.Enabled = false;
                        }*/
                    }
                }

                MessageBox.Show("Provider information updated!");
                this.Close();
            }
        }
    }
}
