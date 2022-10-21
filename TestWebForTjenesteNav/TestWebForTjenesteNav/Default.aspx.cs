//using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Web.Services;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected async void butPost_Click(object sender, EventArgs e)
    {
        string url = "http://localhost:10006/api/JuntaContacts?search=" + txtContactId.Text + "&iType=1";
        HttpClient client = httpClient(url);

        var res = await client.GetAsync(url);
        if (res.IsSuccessStatusCode)
        {
            //var result = res.Content.ReadAsStringAsync();
            //var cont = result.Result.ToString();

            string resp = await res.Content.ReadAsStringAsync();
            
            var json = JsonConvert.DeserializeObject<object>(resp);
            
        }

    }
    private HttpClient httpClient(string url)
    {
        HttpClient client = new HttpClient();
        client.BaseAddress = new Uri(url);
        //client.DefaultRequestHeaders.Authorization =
        //    new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
        return client;
    }


    [WebMethod]
    public static List<string> GetAdresser(string prefix)
    {
        List<string> suggestions = new List<string>();

        var url = "http://localhost:10002/api/KVAddress?searchstring=" + prefix + "*";
        url += "&treffPerSide=100";

        var client = new HttpClient();
        client.BaseAddress = new Uri(url);
        var response = client.GetAsync(url).Result;
        var str = response.Content.ReadAsStringAsync().Result;
        var aryAddresses = str.Split(',');
        foreach (var a in aryAddresses)
        {
            suggestions.Add(a.ToString().Substring(1, a.Length -2));
        }
        return suggestions;
    }

    [WebMethod]
    public static List<string> GetJuntaName(string prefix)
    {
        List<string> suggestions = new List<string>();

        var url = "http://localhost:10006/api/JuntaContacts?search=iType=1&" + prefix + "*";
        

        var client = new HttpClient();
        client.BaseAddress = new Uri(url);
        var response = client.GetAsync(url).Result;
        var str = response.Content.ReadAsStringAsync().Result;
        var dserObj = JsonConvert.DeserializeObject<List<ContactProxy>>(str);
        var aryAddresses = str.Split(',');
        //foreach (var a in aryAddresses)
        //{
        //    suggestions.Add(a.ToString().Substring(1, a.Length - 2));
        //}
        return suggestions;
    }

    [WebMethod]
    public static string GetCoverageForGCAddressAsync(string searchstring)
    {

        string retval = "String from GetCoverageForGCAddressAsync " + searchstring;
        ///Short cut
        //var filePath = "C:\\source\\repos\\CoverageForGCAddress_Verkstedvn_1_Oslo.json";
        //var reader = new StreamReader(filePath);
        //var jsonStr = reader.ReadToEnd();
        //var jsonObj = JObject.Parse(jsonStr);

        //retval = jsonObj["articleList"].ToString();


        //return retval.ToString();
        ///Short cut
        ///


        //New class call
        //var str = await new GCTest.CoverageTest().RunTestAsync();
        //var strRet = await new ComClient().RunTestAsync();
        //return strRet;
        //

        var client = new HttpClient();
        var byteArray = Encoding.ASCII.GetBytes("nhntest:gctest00");
        var header = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
        client.DefaultRequestHeaders.Authorization = header;


        var url = "https://api-2445582745966.production.gw.apicast.io/1.0/address/" + searchstring + "*?user_key=9f1ce36c5b3986988941ad047465e049";
        var response = client.GetAsync(url).Result;
        string str = response.Content.ReadAsStringAsync().Result.ToString();
        var subStr = str.Substring(1, str.Length - 2);

        JObject joResponse = JObject.Parse(subStr);


        var adresser = from r in joResponse["gabId"].ToString()
                       select r;
        string strgabid = "";
        foreach (var c in adresser)
        {
            strgabid += c.ToString();

        }
        //return "";
        //
        //url = "https://api-2445582745966.production.gw.apicast.io/1.0/product/articlegroups/201834?user_key=9f1ce36c5b3986988941ad047465e049";
        //var response2 = client.GetAsync(url).Result;
        //string str2 = response2.Content.ReadAsStringAsync().Result.ToString();

        //for new call
        var searchparam = strgabid;


        int gabid = 0;
        int.TryParse(strgabid, out gabid);
        //var obj = new CoverageTest();
        //var returfrom = await new CoverageTest().PostingClient(gabid);
        //Action PostingGCClient(int i);
        //object value = await Task.Run(PostingGCClient());
        //retval.Add("Return from CoverageTest: " + returfrom + Environment.NewLine);
        //foreach(var r in returfrom )
        //{
        //    retval.Add(r.ToString());
        //}
        //List<string> ResultFromGC = await PostingGCClient;
        retval = "Pre calling...";



        ////return retval;

        //var model = new CoverageSearchRequest();
        //model.fromAddressGabId = 285683564; //
        //model.articleGroupName = "IPVPN Fiber";
        //var url2 = "https://api-2445582745966.production.gw.apicast.io/1.0/coverage/articles/201834?user_key=9f1ce36c5b3986988941ad047465e049";

        //var client2 = new HttpClient();
        //var byteArray2 = Encoding.ASCII.GetBytes("nhntest:gctest00");
        //var header2 = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray2));
        //var serializer = new JavaScriptSerializer();
        //var json = serializer.Serialize(model);
        //var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
        //client2.DefaultRequestHeaders.Authorization = header2;
        ////string tmp = "";
        ////var response2 = await client2.PostAsync(url2, stringContent);
        ////var result = await response2.Content.ReadAsStringAsync();
        ////retval = result.ToString();

        return retval;

    }
    protected void sokadresse_TextChanged(object sender, EventArgs e)
    {

    }

    protected void JuntaNamesearch_TextChanged(object sender, EventArgs e)
    {

    }
}   