using System;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SummerSchoolsApp
{
    public partial class FrmProductSettings : Form
    {
        private ControlMaintenance ctrlMaintenance;

        public FrmProductSettings(ControlMaintenance refCtrl)
        {
            InitializeComponent();
            LoadProductDataFromSettingsFile();
            ctrlMaintenance = refCtrl;

        }

        private void LoadProductDataFromSettingsFile()
        {
            using (FileStream fs = new FileStream("product_settings.json", FileMode.Open))
            {
                var jsonSerializer = new DataContractJsonSerializer(typeof(ProductSettings));
                ProductSettings productSettings = jsonSerializer.ReadObject(fs) as ProductSettings;
                tbProductSettingsFile.Text = JsonConvert.SerializeObject(productSettings, Formatting.Indented);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (IsValidJson(tbProductSettingsFile.Text))
            {
                using (FileStream fs = new FileStream("product_settings.json", FileMode.Truncate))
                {
                    ProductSettings productSettings = JsonConvert.DeserializeObject<ProductSettings>(tbProductSettingsFile.Text);
                    DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(ProductSettings));
                    js.WriteObject(fs, productSettings);
                }

                ctrlMaintenance.ProcessEvent();
                this.Close();
            }
            else
            {
                MessageBox.Show("Settings file must be a valid JSON!", "Invalid format", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool IsValidJson(string strInput)
        {
            strInput = strInput.Trim();
            if ((strInput.StartsWith("{") && strInput.EndsWith("}")) || 
                (strInput.StartsWith("[") && strInput.EndsWith("]"))) 
            {
                try
                {
                    var obj = JToken.Parse(strInput);
                    return true;
                }
                catch (Exception ex)
                {
                    //log exception
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
