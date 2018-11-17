using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using SummerSchoolsApp.DBBroker;
using System.Runtime.Serialization.Json;
using System.IO;

namespace SummerSchoolsApp
{
    public partial class ControlMaintenance : UserControl
    {
        Broker broker;
        DataSet ds_providers;

        public ControlMaintenance()
        {
            InitializeComponent();
            broker = new Broker();

            ds_providers = new DataSet();

            SetProviderDataGrid();
            SetProductsDataGrid();
            SetMarketingSourceDataGrid();
            LoadProductDataFromSettingsFile();
        }

        private void LoadProductDataFromSettingsFile()
        {
            var jsonSerializer = new DataContractJsonSerializer(typeof(ProductSettings));
            ProductSettings productSettings = jsonSerializer.ReadObject(File.OpenRead("product_settings.json")) as ProductSettings;
            foreach(string item in productSettings.productTypes)
            {
                comboBoxProductType.Items.Add(item);
            }

            foreach(string item in productSettings.productGroups)
            {
                comboBoxProductGroup.Items.Add(item);
            }
        }

        public void SetProviderDataGrid()
        {
            ds_providers = broker.ReturnProviderInfo();
            Dictionary<int, string> providerMap = new Dictionary<int, string>();
            foreach (DataRow row in ds_providers.Tables[0].Rows)
            {
                providerMap.Add(Convert.ToInt32(row["ProviderNumber"]), row["ProviderName"].ToString());
            }

            this.comboBoxProvider.DataSource = new BindingSource(providerMap, null);
            this.comboBoxProvider.ValueMember = "Key";
            this.comboBoxProvider.DisplayMember = "Value";
            this.comboBoxProvider.SelectedIndex = 0;

        }

        public void SetProductsDataGrid()
        {
            DataSet ds_productList = new DataSet();
            ds_productList = broker.ReturnProductInfo();
            Dictionary<int, string> map = new Dictionary<int, string>();

            foreach (DataRow row in ds_productList.Tables[0].Rows)
            {
                map.Add(Convert.ToInt32(row["ProductCode"]), row["ProductName"].ToString());
            }

            this.comboBoxProductList.DataSource = new BindingSource(map, null);
            this.comboBoxProductList.ValueMember = "Key";
            this.comboBoxProductList.DisplayMember = "Value";
            comboBoxProductList.SelectedIndex = 0;

            DataSet ds_providerSelector = broker.ReturnProviderInfo();
            foreach (DataRow dr in ds_providerSelector.Tables[0].Rows)
            {
                comboBoxProviderSelector.Items.Add(dr["ProviderName"].ToString());
            }

            comboBoxProviderSelector.SelectedIndex = 0;
            comboBoxProductCurrency.SelectedIndex = 0;
        }

        public void SetMarketingSourceDataGrid()
        {
            this.dataGridView1.DataSource = broker.ReturnMarketingSourceInfo().Tables[0];
            foreach (DataGridViewTextBoxColumn column in dataGridView1.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

            dataGridView1.Columns[0].HeaderText = "Medium number";
            dataGridView1.Columns[1].HeaderText = "Medium name";
            dataGridView1.Columns[2].HeaderText = "Contact person";
            dataGridView1.Columns[3].HeaderText = "Contact details";
            dataGridView1.Columns[4].HeaderText = "Price";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Provider provider = new Provider();

            provider.providerName = this.textBoxProviderName.Text;
            provider.providerAddress = this.textBoxProviderAddress.Text;

            if (CheckProviderParams(provider.providerName, provider.providerAddress) == true)
            {
                provider.contactPerson = this.textBoxContactPerson.Text;
                provider.contactPosition = this.textBoxContactPosition.Text;
                provider.contactEmail = this.textBoxContactEmail.Text;
                provider.contactPhone = this.textBoxContactPhone.Text;
                provider.contactPerson2 = this.textBoxContactPerson2.Text;
                provider.contactPosition2 = this.tbContactPosition2.Text;
                provider.contactEmail2 = this.tbContactEmail2.Text;
                provider.contactPhone2 = this.tbContactPhone2.Text;
                provider.contactPerson3 = this.textBoxContactPerson3.Text;
                provider.contactPosition3 = this.tbContactPosition3.Text;
                provider.contactEmail3 = this.tbContactEmail3.Text;
                provider.contactPhone3 = this.tbContactPhone3.Text;
                provider.contactPerson4 = this.textBoxContactPerson4.Text;
                provider.contactPosition4 = this.tbcontactPosition4.Text;
                provider.contactEmail4 = this.tbContactEmail4.Text;
                provider.contactPhone4 = this.tbContactPhone4.Text;
                provider.contactPerson5 = this.textBoxContactPerson5.Text;
                provider.contactPosition5 = this.tbContactPosition5.Text;
                provider.contactEmail5 = this.tbContactEmail5.Text;
                provider.contactPhone5 = this.tbContactPhone5.Text;
                provider.VersionCode = 1;

                int result = broker.InsertProvider(provider);

                if (result == -1)
                {
                    MessageBox.Show("New provider added!");

                    SetProviderDataGrid();
                    textBoxProviderName.Clear();
                    textBoxProviderAddress.Clear();
                    textBoxContactPerson.Clear();
                    textBoxContactPosition.Clear();
                    textBoxContactEmail.Clear();
                    textBoxContactPhone.Clear();
                    textBoxContactPerson2.Clear();
                    tbContactPosition2.Clear();
                    tbContactPhone2.Clear();
                    tbContactEmail2.Clear();
                    textBoxContactPerson3.Clear();
                    tbContactPosition3.Clear();
                    tbContactPhone3.Clear();
                    tbContactEmail3.Clear();
                    textBoxContactPerson4.Clear();
                    tbcontactPosition4.Clear();
                    tbContactPhone4.Clear();
                    tbContactEmail4.Clear();
                    textBoxContactPerson5.Clear();
                    tbContactPosition5.Clear();
                    tbContactPhone5.Clear();
                    tbContactEmail5.Clear();

                    SetProviderDataGrid();

                    this.comboBoxProviderSelector.DataSource = broker.ReturnProviderInfo().Tables[0];
                    comboBoxProviderSelector.DisplayMember = "ProviderName";
                    comboBoxProductCurrency.SelectedIndex = 0;
                }
            }
            else
            {
                MessageBox.Show("You must fill the required fields!");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (this.TextBoxPoviderNumberDelete.Text != "" && this.textBoxProviderTypeDelete.Text.ToLower() == "delete")
            {
                int providerNumber = Convert.ToInt32(this.TextBoxPoviderNumberDelete.Text);
                int result = broker.DeleteProvider(providerNumber);

                if (result == -1)
                {
                    MessageBox.Show("Provider deleted!");
                    textBoxProviderTypeDelete.Clear();
                    TextBoxPoviderNumberDelete.Clear();
                    comboBoxProvider.Text = "";
                    comboBoxProviderSelector.Text = "";
                    SetProviderDataGrid();
                }
            }
            else
            {
                MessageBox.Show("You must fill the required fields!");
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                Product product = new Product
                {
                    productName = textBoxProductName.Text,
                    provider = comboBoxProviderSelector.Text,
                    //TODO: regulisanje cene?
                    costPrice = Convert.ToDecimal(textBoxCostPrice.Text),
                    price = Convert.ToDecimal(textBoxPrice.Text),
                    currency = comboBoxProductCurrency.Text,
                    productType = comboBoxProductType.Text,
                    productGroup = comboBoxProductGroup.Text,
                    VersionCode = 1
                };

                if (CheckProductParams(product) == true)
                {

                    int result = broker.InsertProduct(product);

                    if (result != 13)
                    {
                        this.textBoxProductName.Clear();
                        textBoxPrice.Clear();
                        textBoxPrice.Clear();
                        SetProductsDataGrid();

                        MessageBox.Show("New product added!");
                    }
                    else
                    {
                        MessageBox.Show("ERROR: Unable to add product!");
                    }
                }

                else
                {
                    MessageBox.Show("You must fill the required fields!");
                }
            }
            catch (System.FormatException)
            {
                MessageBox.Show("Please check the price/cost price of the product!");
            }

            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (this.TextBoxProdNumber.Text != "" && this.textBoxProdTypeDelete.Text.ToLower() == "delete")
            {
                int productNumber = Convert.ToInt32(this.TextBoxProdNumber.Text);
                int result = broker.DeleteProduct(productNumber);

                if (result == -1)
                {
                    MessageBox.Show("Product successfully deleted!", "SUCESS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TextBoxProdNumber.Clear();
                    textBoxProdTypeDelete.Clear();
                    comboBoxProductList.Text = "";
                    SetProductsDataGrid();
                }
            }
            else
            {
                MessageBox.Show("You must fill the required fields!");
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
           
        }

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                Marketingsource ms = new Marketingsource();
                ms.msName = textBoxMedimName.Text;

                if (textBoxMediumContact.Text.Trim().Equals(string.Empty))
                {
                    ms.msContact = null;
                }
                else
                {
                    ms.msContact = textBoxMediumContact.Text;
                }

                if (textBoxMediumDetails.Text.Trim().Equals(string.Empty))
                {
                    ms.msDetails = null;
                }
                else
                {
                    ms.msDetails = textBoxMediumDetails.Text;
                }

                if (textBoxMediumPrice.Text.Equals(string.Empty))
                {
                    ms.msPrice = 0;
                }
                else
                {
                    ms.msPrice = Convert.ToDecimal(textBoxMediumPrice.Text);
                }
                ms.VersionCode = 1;

                if (CheckMarketingMaterialsParams(ms) == true)
                {

                    broker.InsertMarketingsource(ms);

                    SetMarketingSourceDataGrid();

                    MessageBox.Show("Marketing source added!");

                    textBoxMediumPrice.Clear();
                    textBoxMediumDetails.Clear();
                    textBoxMediumContact.Clear();
                    textBoxMedimName.Clear();
                }
                else
                {
                    MessageBox.Show("Please check the fields and their values!");
                }
            }
            catch (System.FormatException)
            {
                MessageBox.Show("Please check the price of the item!");
            }
            catch (System.Exception)
            {
                MessageBox.Show("Error!!");
            }


        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (this.comboBoxProvider.Text != "")
            {
                var value = comboBoxProvider.SelectedItem;
                var providerNumber = value.GetType().GetProperty("Key").GetValue(value, null);
                ProviderDetails pd_form = new ProviderDetails(Convert.ToInt32(providerNumber));
                pd_form.Show();
            }
            else
            {
                MessageBox.Show("You must choose a provider!");
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (this.comboBoxProductList.Text != "")
            {
                var value = comboBoxProductList.SelectedItem;
                var productCode = value.GetType().GetProperty("Key").GetValue(value, null);
                frmEditProduct epf = new frmEditProduct(Convert.ToInt32(productCode));
                epf.Show();
            }
            else
            {
                MessageBox.Show("You must choose a product!");
            }
        }

        public bool CheckUserParams(string uname, string pword)
        {
            if (uname == "" || pword == "")
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool CheckProviderParams(string name, string address)
        {
            if (name.Equals(string.Empty) || address.Equals(string.Empty))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool CheckProductParams(Product product)
        {
            if (product.productName.Equals(string.Empty) ||
                product.provider.Equals(string.Empty) ||
                product.currency.Equals(string.Empty) ||
                product.productType.Equals(string.Empty) ||
                product.price == 0 ||
                product.costPrice == 0)
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        public bool CheckMarketingMaterialsParams(Marketingsource ms)
        {
            if (ms.msName.Equals(string.Empty))
            {
                return false;
            }
            else
            return true;
        }


    }
}
