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
    public partial class frmEditProduct : Form
    {
        Broker broker;

        DataSet ds_returnedProduct;
        DataSet ds_providers;
        int selectedProduct;
        int currentVersion;

        public frmEditProduct(int productCode)
        {
            InitializeComponent();
            broker = new Broker();
            ds_returnedProduct = new DataSet();
            ds_returnedProduct = broker.GetProductBycode(productCode);
            selectedProduct = productCode;

            foreach (DataRow row in ds_returnedProduct.Tables[0].Rows)
            {
                this.textBoxProdCode.Text = productCode.ToString();
                this.textBoxProductName.Text = row["ProductName"].ToString();
                this.textBoxCostPrice.Text = row["ProductDecimalA"].ToString();
                this.textBoxPrice.Text = row["ProductPrice"].ToString();
                this.comboBoxProviderSelector.Text = row["ProductProvider"].ToString();
                this.comboBoxProductCurrency.Text = row["Currency"].ToString();
                this.comboBoxProductType.Text = row["ProductType"].ToString();
                this.comboBoxProductGroup.Text = row["ProductStringA"].ToString();
                currentVersion = Convert.ToInt32(row["VersionCode"]);
            }

            ds_providers = broker.ReturnProviderInfo();

            foreach (DataRow row in ds_providers.Tables[0].Rows)
            {
                string providerItem = row["ProviderName"].ToString();
                comboBoxProviderSelector.Items.Add(providerItem);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Product product = new Product();
                product.productCode = this.selectedProduct;
                product.productName = textBoxProductName.Text;
                product.costPrice = Convert.ToDecimal(textBoxCostPrice.Text);
                product.price = Convert.ToDecimal(textBoxPrice.Text);
                product.currency = comboBoxProductCurrency.Text;
                product.provider = comboBoxProviderSelector.Text;
                product.productType = comboBoxProductType.Text;
                product.productGroup = comboBoxProductGroup.Text;
                product.VersionCode = currentVersion + 1;
                int result = broker.UpdateProductBycode(product);
                MessageBox.Show("Product information updated!");
                this.Close();
            }
            catch (System.FormatException)
            {
                MessageBox.Show("Please check the price/cost price of the product!");
            }
            catch(System.Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void EditProductForm_Load(object sender, EventArgs e)
        {

        }
    }
}
