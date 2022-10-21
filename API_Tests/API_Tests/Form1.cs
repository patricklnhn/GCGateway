using Database;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json.Converters;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using Newtonsoft.Json;
using System.Threading;
using System.Web;

namespace API_Tests
{
    public partial class Form1 : Form
    {
        private Mutex m = new Mutex();
        public Form1()
        {
            InitializeComponent();
            
        }

        private void butSend_Click(object sender, EventArgs e)
        {
            bool needsAuthentication = false;
            Services.Service obj = new Services.Service();
            int selected = 0;
            int.TryParse(cboExternalAPI.SelectedValue.ToString(), out selected);

            var item = obj.GetExternalAPI(selected);
            string url = item.Url;
            //Adresser
            //https://ws.geonorge.no/adresser/v1/

            var parameters = obj.GetRelatedAPIParameters(selected);
            foreach (var param in parameters)
            {

                url += param.ParameterName + "/" + param.ParameterValue;
            }
            var client = new HttpClient();
            //var url = "https://data.brreg.no/enhetsregisteret/api/enheter/984161867";
            //Check if need for authentication
            //needsAuthentication = item.NeedsAuthentication 
            if (needsAuthentication)
            {

                //    var byteArray = Encoding.ASCII.GetBytes("my_client_id:my_client_secret");
                //    var header = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
                //    client.DefaultRequestHeaders.Authorization = header;
                ////https://stackoverflow.com/questions/30858890/how-to-use-httpclient-to-post-with-authentication

            }

            client.BaseAddress = new Uri(url);

            var response = client.GetAsync(url).Result;
            var str = response.Content.ReadAsStringAsync().Result;

            JObject joResponse = JObject.Parse(str);
            textBox1.Text = joResponse.ToString();


        }

        private void butAddTypeOfReturn_Click(object sender, EventArgs e)
        {
            Services.Service obj = new Services.Service();
            Database.TypeOfReturn NewType = new Database.TypeOfReturn();
            NewType.Name = txtNameOfNewType.Text.Trim();
            obj.AddTypeOfReturn(NewType);
            LoadTypeOfReturnsCombo();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //LoadControls();
        }

        private void LoadControls()
        {
            LoadTypeOfReturnsCombo();
            LoadExternalAPICombo();
        }
        private void LoadTypeOfReturnsCombo()
        {
            Services.Service obj = new Services.Service();
            var items = obj.GetAllTypeOfReturn();
            cboTypeOfReturn.Items.Clear();
            cboTypeOfReturn.DataSource = items;
            cboTypeOfReturn.DisplayMember = "Name";
            cboTypeOfReturn.ValueMember = "Id";
        }

        private void LoadExternalAPICombo()
        {
            Services.Service obj = new Services.Service();
            var items = obj.GetAllExternalAPIs();
            cboExternalAPI.Items.Clear();
            cboExternalAPI.DataSource = items;
            cboExternalAPI.DisplayMember = "Name";
            cboExternalAPI.ValueMember = "Id";
        }

        private void butEdit_Click(object sender, EventArgs e)
        {
            //tbRunAPI.TabIndex = 1;
            tbRunAPI.SelectedIndex = 1;
            int SelectedAPI = 0;
            int.TryParse(cboExternalAPI.SelectedValue.ToString(), out SelectedAPI);

            PopulateAPIform(SelectedAPI);
        }

        private void PopulateAPIform(int selectedAPI)
        {
            Services.Service obj = new Services.Service();
            Database.ExternalAPIs Item = obj.GetExternalAPI(selectedAPI);
            txtAPIName.Text = Item.Name.ToString();
            txtAPIDescription.Text = Item.Description.ToString();
            txtAPIURL.Text = Item.Url.ToString();
            cboTypeOfReturn.SelectedValue = Item.TypeOfReturn;
            lblNewOrEdit.Text = "Editing API Id: " + selectedAPI.ToString();
            grdApiParameters.DataSource = null;
            grdApiParameters.Rows.Clear();
            //grdApiParameters.Rows.D = 0;
            int i = grdApiParameters.RowCount;
            List<APIParameters> parameters = obj.GetRelatedAPIParameters(selectedAPI);
            grdApiParameters.DataSource = parameters;
            //grdApiParameters

        }

        private void butAddAPI_Click(object sender, EventArgs e)
        {
            Services.Service obj = new Services.Service();
            Database.ExternalAPIs NewItem = new Database.ExternalAPIs();
            NewItem.Name = @txtAPIName.Text.Trim();
            NewItem.Description = @txtAPIDescription.Text.Trim();
            NewItem.Url = @txtAPIURL.Text.Trim();
            int TypeSelectedvalue = 0;
            int.TryParse(cboTypeOfReturn.SelectedValue.ToString(), out TypeSelectedvalue);
            //NewItem.TypeOfReturn = TypeSelectedvalue;
            obj.AddExternalAPI(NewItem);
        }

        private void butSaveParameters_Click(object sender, EventArgs e)
        {
            Services.Service obj = new Services.Service();
            //Database.APIParameters NewItem = new Database.APIParameters();
            string? id = string.Empty;
            string? name = string.Empty;
            string? value = string.Empty;

            foreach (DataGridViewRow row in grdApiParameters.Rows)
            {
                if (row.Cells[1].Value != null)
                {
                    if (row.Cells[0].Value != null)
                        id = row.Cells[0].Value.ToString();

                    name = row.Cells[1].Value.ToString();
                    if (row.Cells[2].Value != null)
                        value = row.Cells[2].Value.ToString();
                }
                if (id != string.Empty)
                {
                    //Update
                    Database.APIParameters UpdateParamItem = new Database.APIParameters();
                    int i = 0;
                    int.TryParse(id, out i);
                    UpdateParamItem.Id = i;
                    UpdateParamItem.ParameterName = name;
                    UpdateParamItem.ParameterValue = value;
                    obj.UpdateParameter(UpdateParamItem);
                }
                else
                {
                    //Insert
                    Database.APIParameters NewParamItem = new Database.APIParameters();
                    NewParamItem.ParameterName = name;
                    NewParamItem.ParameterValue = value;
                    int i;
                    int.TryParse(cboExternalAPI.SelectedValue.ToString(), out i);
                    ExternalAPIs extAPI = obj.GetExternalAPI(i);
                    NewParamItem.ExternalAPI.Id = extAPI.Id;
                    obj.InsertParameter(NewParamItem);


                }
            }
        }

        private void butGC_API_Click(object sender, EventArgs e)
        {
            SearchGC();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text.Trim().Length > 3)
                txtSearch_TypingCompleted(sender, e);
        }
        private void txtSearch_TypingCompleted(object sender, System.EventArgs e)
        {
            m.WaitOne();
            try
            {
                if (txtSearch.Text.Trim().Length > 4)
                {
                    //Thread.Sleep(2000);
                    var autoCompleteListCollection = new AutoCompleteStringCollection();
                   
                    autoCompleteListCollection.AddRange(GetSuggestions(txtSearch.Text, null).ToArray());
                    //Thread.Sleep(2000);
                    txtSearch.AutoCompleteCustomSource = autoCompleteListCollection;
                    Application.DoEvents();
                }
            }
            finally
            {
                m.ReleaseMutex();   
            }
            
        }

        class tmpAddr
        {
            public string addrText { get; set; }
            public string pNr { get; set; }
            public string pSted { get; set; }
            public override string ToString()
            {
                return addrText + " | " + pNr +" | "+ pSted;
            }
        }

        private void  SearchGC()
        {
            string input = txtSearch.Text;
            string ?sok = "";
            string url = "";
            if (input.Length >0)
            {
                var strSplitted = input.Split("|");
                string addr = strSplitted[0].ToString().Trim();
                string pnr = strSplitted[1].ToString().Trim();
                string sted = strSplitted[2].ToString().Trim();
                sok = addr + " " + " " + pnr + " " + sted;
            }
            
            

            textBox1.Text = "";
            //User nhntest
            //User Key 9f1ce36c5b3986988941ad047465e049
            //Pwd gctest00
            // Documentation https://developer.globalconnect.net/
            var client = new HttpClient();
            var byteArray = Encoding.ASCII.GetBytes("nhntest:gctest00");
            var header = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
            client.DefaultRequestHeaders.Authorization = header;
            
            //string sok = @"Karenslyst 42"; // 0278 OSLO
            //string sok = @"Storgata 24"; // 0278 OSLO

            if(sok.Length > 0)
            {
                url = "https://api-2445582745966.production.gw.apicast.io/1.0/address/" + sok + "*?user_key=9f1ce36c5b3986988941ad047465e049";
            }
            else
            {
                url = "https://api-2445582745966.production.gw.apicast.io/1.0/address/Verkstedveien%201?user_key=9f1ce36c5b3986988941ad047465e049";

            }




            //var url = "https://api-2445582745966.production.gw.apicast.io/1.0/product/articlegroups/201834?user_key=9f1ce36c5b3986988941ad047465e049";


            var response = client.GetAsync(url).Result;
            var str = response.Content.ReadAsStringAsync().Result;

            textBox1.Text = response.ToString() + Environment.NewLine;
            textBox1.Text += str;
        }

        private List<string> GetSuggestions(string search, string? kommunenavn)
        {
            List<string> suggestions = new List<string>();
            
            var url = "https://ws.geonorge.no/adresser/v1/sok?adressetekst="+ search + "*";
            url += "&treffPerSide=30";
            if(kommunenavn !=null)
            url += "&kommunenavn=" + kommunenavn;

            var client = new HttpClient();
            client.BaseAddress = new Uri(url);
            var response = client.GetAsync(url).Result;
            var str = response.Content.ReadAsStringAsync().Result;
            
            JObject joResponse = JObject.Parse(str);
            
            var adresser = from r in joResponse["adresser"]
                           select new tmpAddr { addrText = r["adressetekst"].ToString(), pNr = r["postnummer"].ToString(), pSted =r["poststed"].ToString() };

            foreach (var a in adresser)
            {
                suggestions.Add(a.ToString());
            }
            return suggestions;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //GetSuggestions("Karenslyst allé 42", null);//txtSearch.Text);
            SearchGC();
            tbRunAPI.SelectedIndex = 0;

        }
    }
}