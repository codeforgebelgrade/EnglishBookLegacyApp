namespace SummerSchoolsApp
{
    partial class frmEditProduct
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEditProduct));
            this.label45 = new System.Windows.Forms.Label();
            this.comboBoxProductCurrency = new System.Windows.Forms.ComboBox();
            this.comboBoxProviderSelector = new System.Windows.Forms.ComboBox();
            this.label20 = new System.Windows.Forms.Label();
            this.textBoxPrice = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.textBoxProductName = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.comboBoxProductType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxProductGroup = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxCostPrice = new System.Windows.Forms.TextBox();
            this.textBoxProdCode = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.Location = new System.Drawing.Point(363, 117);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(49, 13);
            this.label45.TabIndex = 15;
            this.label45.Text = "Currency";
            // 
            // comboBoxProductCurrency
            // 
            this.comboBoxProductCurrency.BackColor = System.Drawing.SystemColors.ControlDark;
            this.comboBoxProductCurrency.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxProductCurrency.FormattingEnabled = true;
            this.comboBoxProductCurrency.Items.AddRange(new object[] {
            "EUR",
            "GBP"});
            this.comboBoxProductCurrency.Location = new System.Drawing.Point(366, 133);
            this.comboBoxProductCurrency.Name = "comboBoxProductCurrency";
            this.comboBoxProductCurrency.Size = new System.Drawing.Size(140, 21);
            this.comboBoxProductCurrency.Sorted = true;
            this.comboBoxProductCurrency.TabIndex = 14;
            // 
            // comboBoxProviderSelector
            // 
            this.comboBoxProviderSelector.FormattingEnabled = true;
            this.comboBoxProviderSelector.Location = new System.Drawing.Point(8, 176);
            this.comboBoxProviderSelector.Name = "comboBoxProviderSelector";
            this.comboBoxProviderSelector.Size = new System.Drawing.Size(498, 21);
            this.comboBoxProviderSelector.Sorted = true;
            this.comboBoxProviderSelector.TabIndex = 13;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(184, 118);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(31, 13);
            this.label20.TabIndex = 5;
            this.label20.Text = "Price";
            // 
            // textBoxPrice
            // 
            this.textBoxPrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxPrice.Location = new System.Drawing.Point(184, 134);
            this.textBoxPrice.Name = "textBoxPrice";
            this.textBoxPrice.Size = new System.Drawing.Size(160, 20);
            this.textBoxPrice.TabIndex = 4;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(8, 160);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(49, 13);
            this.label21.TabIndex = 3;
            this.label21.Text = "Provider ";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(8, 16);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(73, 13);
            this.label24.TabIndex = 1;
            this.label24.Text = "Product name";
            // 
            // textBoxProductName
            // 
            this.textBoxProductName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxProductName.Location = new System.Drawing.Point(8, 32);
            this.textBoxProductName.Name = "textBoxProductName";
            this.textBoxProductName.Size = new System.Drawing.Size(336, 20);
            this.textBoxProductName.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(391, 224);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(115, 40);
            this.button1.TabIndex = 16;
            this.button1.Text = "Save changes";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboBoxProductType
            // 
            this.comboBoxProductType.BackColor = System.Drawing.SystemColors.ControlDark;
            this.comboBoxProductType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxProductType.FormattingEnabled = true;
            this.comboBoxProductType.Items.AddRange(new object[] {
            "Course",
            "Misc.",
            "Plane tickets",
            "Registration fees"});
            this.comboBoxProductType.Location = new System.Drawing.Point(8, 80);
            this.comboBoxProductType.Name = "comboBoxProductType";
            this.comboBoxProductType.Size = new System.Drawing.Size(160, 21);
            this.comboBoxProductType.Sorted = true;
            this.comboBoxProductType.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Product type";
            // 
            // comboBoxProductGroup
            // 
            this.comboBoxProductGroup.BackColor = System.Drawing.SystemColors.ControlDark;
            this.comboBoxProductGroup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxProductGroup.FormattingEnabled = true;
            this.comboBoxProductGroup.Items.AddRange(new object[] {
            "Kopaonik",
            "Malta",
            "Other",
            "UK"});
            this.comboBoxProductGroup.Location = new System.Drawing.Point(184, 80);
            this.comboBoxProductGroup.Name = "comboBoxProductGroup";
            this.comboBoxProductGroup.Size = new System.Drawing.Size(160, 21);
            this.comboBoxProductGroup.Sorted = true;
            this.comboBoxProductGroup.TabIndex = 19;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(184, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "Product group";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "Cost Price";
            // 
            // textBoxCostPrice
            // 
            this.textBoxCostPrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxCostPrice.Location = new System.Drawing.Point(8, 133);
            this.textBoxCostPrice.Name = "textBoxCostPrice";
            this.textBoxCostPrice.Size = new System.Drawing.Size(160, 20);
            this.textBoxCostPrice.TabIndex = 23;
            // 
            // textBoxProdCode
            // 
            this.textBoxProdCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxProdCode.Location = new System.Drawing.Point(368, 32);
            this.textBoxProdCode.Name = "textBoxProdCode";
            this.textBoxProdCode.ReadOnly = true;
            this.textBoxProdCode.Size = new System.Drawing.Size(136, 20);
            this.textBoxProdCode.TabIndex = 24;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(368, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 13);
            this.label4.TabIndex = 25;
            this.label4.Text = "Product code";
            // 
            // frmEditProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(524, 276);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxProdCode);
            this.Controls.Add(this.textBoxCostPrice);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxProductGroup);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxProductType);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label45);
            this.Controls.Add(this.comboBoxProductCurrency);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.comboBoxProviderSelector);
            this.Controls.Add(this.textBoxProductName);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.textBoxPrice);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmEditProduct";
            this.Text = "Edit Product Information";
            this.Load += new System.EventHandler(this.EditProductForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label45;
        private System.Windows.Forms.ComboBox comboBoxProductCurrency;
        private System.Windows.Forms.ComboBox comboBoxProviderSelector;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox textBoxPrice;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TextBox textBoxProductName;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBoxProductType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxProductGroup;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxCostPrice;
        private System.Windows.Forms.TextBox textBoxProdCode;
        private System.Windows.Forms.Label label4;

    }
}