namespace API_Tests
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tbRunAPI = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.butGC_API = new System.Windows.Forms.Button();
            this.butEdit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cboExternalAPI = new System.Windows.Forms.ComboBox();
            this.butSend = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lblNewOrEdit = new System.Windows.Forms.Label();
            this.butSaveParameters = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.grdApiParameters = new System.Windows.Forms.DataGridView();
            this.butAddAPI = new System.Windows.Forms.Button();
            this.txtAPIURL = new System.Windows.Forms.TextBox();
            this.txtAPIDescription = new System.Windows.Forms.TextBox();
            this.txtAPIName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cboTypeOfReturn = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNameOfNewType = new System.Windows.Forms.TextBox();
            this.butAddTypeOfReturn = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.txtJson = new System.Windows.Forms.TextBox();
            //this.txtSearch = new System.Windows.Forms.TextBox();
            this.txtSearch = new txtbox();
            this.button1 = new System.Windows.Forms.Button();
            this.tbRunAPI.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdApiParameters)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbRunAPI
            // 
            this.tbRunAPI.Controls.Add(this.tabPage1);
            this.tbRunAPI.Controls.Add(this.tabPage2);
            this.tbRunAPI.Controls.Add(this.tabPage3);
            this.tbRunAPI.Location = new System.Drawing.Point(12, 38);
            this.tbRunAPI.Name = "tbRunAPI";
            this.tbRunAPI.SelectedIndex = 0;
            this.tbRunAPI.Size = new System.Drawing.Size(1245, 653);
            this.tbRunAPI.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.butGC_API);
            this.tabPage1.Controls.Add(this.butEdit);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.cboExternalAPI);
            this.tabPage1.Controls.Add(this.butSend);
            this.tabPage1.Controls.Add(this.textBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 34);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1237, 615);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "API Testing";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // butGC_API
            // 
            this.butGC_API.Location = new System.Drawing.Point(699, 35);
            this.butGC_API.Name = "butGC_API";
            this.butGC_API.Size = new System.Drawing.Size(112, 34);
            this.butGC_API.TabIndex = 7;
            this.butGC_API.Text = "Call GC";
            this.butGC_API.UseVisualStyleBackColor = true;
            this.butGC_API.Click += new System.EventHandler(this.butGC_API_Click);
            // 
            // butEdit
            // 
            this.butEdit.Location = new System.Drawing.Point(482, 30);
            this.butEdit.Name = "butEdit";
            this.butEdit.Size = new System.Drawing.Size(158, 34);
            this.butEdit.TabIndex = 6;
            this.butEdit.Text = "Edit API details";
            this.butEdit.UseVisualStyleBackColor = true;
            this.butEdit.Click += new System.EventHandler(this.butEdit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 25);
            this.label1.TabIndex = 5;
            this.label1.Text = "External API\'s";
            // 
            // cboExternalAPI
            // 
            this.cboExternalAPI.FormattingEnabled = true;
            this.cboExternalAPI.Location = new System.Drawing.Point(129, 30);
            this.cboExternalAPI.Name = "cboExternalAPI";
            this.cboExternalAPI.Size = new System.Drawing.Size(182, 33);
            this.cboExternalAPI.TabIndex = 4;
            // 
            // butSend
            // 
            this.butSend.Location = new System.Drawing.Point(328, 29);
            this.butSend.Name = "butSend";
            this.butSend.Size = new System.Drawing.Size(112, 34);
            this.butSend.TabIndex = 3;
            this.butSend.Text = "&Send";
            this.butSend.UseVisualStyleBackColor = true;
            this.butSend.Click += new System.EventHandler(this.butSend_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(16, 116);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox1.Size = new System.Drawing.Size(1098, 454);
            this.textBox1.TabIndex = 2;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.lblNewOrEdit);
            this.tabPage2.Controls.Add(this.butSaveParameters);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.grdApiParameters);
            this.tabPage2.Controls.Add(this.butAddAPI);
            this.tabPage2.Controls.Add(this.txtAPIURL);
            this.tabPage2.Controls.Add(this.txtAPIDescription);
            this.tabPage2.Controls.Add(this.txtAPIName);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.cboTypeOfReturn);
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 34);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1237, 615);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Admin";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // lblNewOrEdit
            // 
            this.lblNewOrEdit.AutoSize = true;
            this.lblNewOrEdit.Location = new System.Drawing.Point(14, 31);
            this.lblNewOrEdit.Name = "lblNewOrEdit";
            this.lblNewOrEdit.Size = new System.Drawing.Size(79, 25);
            this.lblNewOrEdit.TabIndex = 13;
            this.lblNewOrEdit.Text = "New API";
            // 
            // butSaveParameters
            // 
            this.butSaveParameters.Location = new System.Drawing.Point(15, 525);
            this.butSaveParameters.Name = "butSaveParameters";
            this.butSaveParameters.Size = new System.Drawing.Size(242, 34);
            this.butSaveParameters.TabIndex = 12;
            this.butSaveParameters.Text = "Save &Parameters And Values";
            this.butSaveParameters.UseVisualStyleBackColor = true;
            this.butSaveParameters.Click += new System.EventHandler(this.butSaveParameters_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 337);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(99, 25);
            this.label7.TabIndex = 11;
            this.label7.Text = "Parameters";
            // 
            // grdApiParameters
            // 
            this.grdApiParameters.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdApiParameters.Location = new System.Drawing.Point(13, 372);
            this.grdApiParameters.Name = "grdApiParameters";
            this.grdApiParameters.RowHeadersWidth = 62;
            this.grdApiParameters.RowTemplate.Height = 33;
            this.grdApiParameters.Size = new System.Drawing.Size(681, 138);
            this.grdApiParameters.TabIndex = 10;
            // 
            // butAddAPI
            // 
            this.butAddAPI.Location = new System.Drawing.Point(13, 290);
            this.butAddAPI.Name = "butAddAPI";
            this.butAddAPI.Size = new System.Drawing.Size(112, 34);
            this.butAddAPI.TabIndex = 9;
            this.butAddAPI.Text = "&Add API";
            this.butAddAPI.UseVisualStyleBackColor = true;
            this.butAddAPI.Click += new System.EventHandler(this.butAddAPI_Click);
            // 
            // txtAPIURL
            // 
            this.txtAPIURL.Location = new System.Drawing.Point(163, 191);
            this.txtAPIURL.Name = "txtAPIURL";
            this.txtAPIURL.Size = new System.Drawing.Size(742, 31);
            this.txtAPIURL.TabIndex = 8;
            // 
            // txtAPIDescription
            // 
            this.txtAPIDescription.Location = new System.Drawing.Point(163, 151);
            this.txtAPIDescription.Name = "txtAPIDescription";
            this.txtAPIDescription.Size = new System.Drawing.Size(742, 31);
            this.txtAPIDescription.TabIndex = 7;
            // 
            // txtAPIName
            // 
            this.txtAPIName.Location = new System.Drawing.Point(161, 108);
            this.txtAPIName.Name = "txtAPIName";
            this.txtAPIName.Size = new System.Drawing.Size(313, 31);
            this.txtAPIName.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 238);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(130, 25);
            this.label6.TabIndex = 5;
            this.label6.Text = "Type Of Return";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 193);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 25);
            this.label5.TabIndex = 4;
            this.label5.Text = "URL";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 154);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 25);
            this.label4.TabIndex = 3;
            this.label4.Text = "Description";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "Name";
            // 
            // cboTypeOfReturn
            // 
            this.cboTypeOfReturn.FormattingEnabled = true;
            this.cboTypeOfReturn.Location = new System.Drawing.Point(165, 233);
            this.cboTypeOfReturn.Name = "cboTypeOfReturn";
            this.cboTypeOfReturn.Size = new System.Drawing.Size(182, 33);
            this.cboTypeOfReturn.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtNameOfNewType);
            this.groupBox1.Controls.Add(this.butAddTypeOfReturn);
            this.groupBox1.Location = new System.Drawing.Point(815, 393);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(396, 198);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Return types:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Name";
            // 
            // txtNameOfNewType
            // 
            this.txtNameOfNewType.Location = new System.Drawing.Point(82, 78);
            this.txtNameOfNewType.Name = "txtNameOfNewType";
            this.txtNameOfNewType.Size = new System.Drawing.Size(150, 31);
            this.txtNameOfNewType.TabIndex = 1;
            // 
            // butAddTypeOfReturn
            // 
            this.butAddTypeOfReturn.Location = new System.Drawing.Point(268, 149);
            this.butAddTypeOfReturn.Name = "butAddTypeOfReturn";
            this.butAddTypeOfReturn.Size = new System.Drawing.Size(112, 34);
            this.butAddTypeOfReturn.TabIndex = 0;
            this.butAddTypeOfReturn.Text = "Add &Type";
            this.butAddTypeOfReturn.UseVisualStyleBackColor = true;
            this.butAddTypeOfReturn.Click += new System.EventHandler(this.butAddTypeOfReturn_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.button1);
            this.tabPage3.Controls.Add(this.txtJson);
            this.tabPage3.Controls.Add(this.txtSearch);
            this.tabPage3.Location = new System.Drawing.Point(4, 34);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1237, 615);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "tabPage3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // txtJson
            // 
            this.txtJson.Location = new System.Drawing.Point(116, 313);
            this.txtJson.Multiline = true;
            this.txtJson.Name = "txtJson";
            this.txtJson.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtJson.Size = new System.Drawing.Size(827, 185);
            this.txtJson.TabIndex = 1;
            // 
            // txtSearch
            // 
            this.txtSearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtSearch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtSearch.Location = new System.Drawing.Point(185, 101);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(734, 31);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(977, 279);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 34);
            this.button1.TabIndex = 2;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1296, 791);
            this.Controls.Add(this.tbRunAPI);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tbRunAPI.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdApiParameters)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private TabControl tbRunAPI;
        private TabPage tabPage1;
        private Label label1;
        private ComboBox cboExternalAPI;
        private Button butSend;
        private TextBox textBox1;
        private TabPage tabPage2;
        private GroupBox groupBox1;
        private Button butAddTypeOfReturn;
        private Label label2;
        private TextBox txtNameOfNewType;
        private ComboBox cboTypeOfReturn;
        private TextBox txtAPIURL;
        private TextBox txtAPIDescription;
        private TextBox txtAPIName;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Button butEdit;
        private Label label7;
        private DataGridView grdApiParameters;
        private Button butAddAPI;
        private Button butSaveParameters;
        private Label lblNewOrEdit;
        private Button butGC_API;
        private TabPage tabPage3;
        private TextBox txtSearch;
        private TextBox txtJson;
        private Button button1;
    }
}