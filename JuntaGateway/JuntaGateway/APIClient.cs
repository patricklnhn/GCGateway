using JuntaClient;
//using Newtonsoft.Json;
//using Nancy;
//using Newtonsoft.Json.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text;
using System.Collections;
using Newtonsoft.Json;

namespace JuntaGateway
    
{/// <summary>
/// 
/// </summary>
    public class APIClient : ClientBase
    {
        //private readonly ILogger _logger;
        //private readonly ILogger _logger;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="logger"></param>
        //public APIClient(ILogger<APIClient> logger)
        //{
        //    _logger = logger;
        //}

        //public APIClient(ILogger logger)
        //{
        //    _logger = logger;
        //}

        private enum iType
        {
            email,
            ids,
            name
        }

        public async Task<List<PopProxy>> GetPopsFromJuntaOnAddress(string streetname, int streetNo, string zip)
        {//PopProxy
         //TODO Find a way to hide usernames/passwords in docker secrets or other methods.
            List<PopProxy> retur = new List<PopProxy>();
            byteArray = Encoding.ASCII.GetBytes("zabbix:mahm4xeeNeejah3ahz9phahp2jige4buNeiNa4CesaiThii3");          
            string url = baseurl + "flow_pops?address=" + streetname + "&street_no=" + streetNo + "&zip" + zip;
            var client = HttpClient(url);
            var res = await client.GetAsync(url);
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync();
                string cont = result.Result.ToString();               
                try
                {
                    var deserialized = System.Text.Json.JsonSerializer.Deserialize<List<PopProxy>>(result.Result.ToString());
                    return deserialized; //JsonSerializer.Deserialize<List<PopProxy>>(result.Result.ToString());
                }
                catch (Exception ex)
                {
                    //TODO Add Logging
                    //var error = new Dictionary<string, string>
                //{
                //    {"Type", ex.GetType().ToString()},
                //    {"Message", ex.Message},
                //    {"StackTrace", ex.StackTrace}
                //};

                //    foreach (DictionaryEntry data in ex.Data)
                //        error.Add(data.Key.ToString(), data.Value.ToString());

                //    string json = JsonConvert.SerializeObject(error, Formatting.Indented);

                //    HttpResponseMessage response = new HttpResponseMessage();
                //    response.Content = new StringContent(json);

                //    retur.Add(response);
                }
            }
            return new List<PopProxy>();
        }

        public async Task<List<ContactProxy>> GetContact(int id)
        {//ContactProxy
            //ILogger _logger = null;
            //_logger.LogInformation("Start GetContact");
            List<ContactProxy> retur = new List<ContactProxy>();
            try
            {
                byteArray = Encoding.ASCII.GetBytes("flow_agresso:ohqu9aivahKu0ahgh1de1mah4ooHai7fie7gee3u");
                string url = baseurl + "flow_contacts?id=" + id;
                var client = HttpClient(url);
                var res = await client.GetAsync(url);
                if (res.IsSuccessStatusCode)
                {
                    //_logger.LogInformation("res.IsSuccessStatusCode OK");
                    var result = res.Content.ReadAsStringAsync();
                    string cont = result.Result.ToString();
                    //_logger.LogInformation(cont);
                    var cont2 = cont.Substring(9, cont.LastIndexOf("]") - 8);
                    return System.Text.Json.JsonSerializer.Deserialize<List<ContactProxy>>(cont2);

                }
            }
            catch (Exception ex)
            {
                ////TODO add logging
                //var error = new Dictionary<string, string>
                //{
                //    {"Type", ex.GetType().ToString()},
                //    {"Message", ex.Message},
                //    {"StackTrace", ex.StackTrace}
                //};

                //foreach (DictionaryEntry data in ex.Data)
                //    error.Add(data.Key.ToString(), data.Value.ToString());

                //string json = JsonConvert.SerializeObject(error, Formatting.Indented);

                //HttpResponseMessage response = new HttpResponseMessage();
                //response.Content = new StringContent(json);

                //retur.Add(response);
            }
            return retur;
        }

        public async Task<List<ContactProxy>> GetListOfContacts(int[] ids)
        { //ContactProxy
            List<ContactProxy> retur = new List<ContactProxy>();
            try
            {
                byteArray = Encoding.ASCII.GetBytes("flow_agresso:ohqu9aivahKu0ahgh1de1mah4ooHai7fie7gee3u");
                string url = baseurl + "flow_contacts?id=" + ids[0] + "," + ids[1];// + "*";
                var client = HttpClient(url);
                var res = await client.GetAsync(url);
                if (res.IsSuccessStatusCode)
                {
                    var result = res.Content.ReadAsStringAsync();
                    string cont = result.Result.ToString();
                    var cont2 = cont.Substring(9, cont.LastIndexOf("]") - 8);
                    return System.Text.Json.JsonSerializer.Deserialize<List<ContactProxy>>(cont2);
                }
            }
            catch (Exception ex)
            {
                //TODO add logging
                //var error = new Dictionary<string, string>
                //{
                //    {"Type", ex.GetType().ToString()},
                //    {"Message", ex.Message},
                //    {"StackTrace", ex.StackTrace}
                //};

                //foreach (DictionaryEntry data in ex.Data)
                //    error.Add(data.Key.ToString(), data.Value.ToString());

                //string json = JsonConvert.SerializeObject(error, Formatting.Indented);

                //HttpResponseMessage response = new HttpResponseMessage();
                //response.Content = new StringContent(json);

                //retur.Add(response);

            }
            return retur;
        }


        public async Task<List<ContactProxy>> GetContactByEmail(string mail)
        { //ContactProxy
            List<ContactProxy> retur = new List<ContactProxy>();
            try
            {
                byteArray = Encoding.ASCII.GetBytes("flow_agresso:ohqu9aivahKu0ahgh1de1mah4ooHai7fie7gee3u");
                string url = baseurl + "flow_contacts?email=" + mail; // + "*";
                var client = HttpClient(url);
                var res = await client.GetAsync(url);
                if (res.IsSuccessStatusCode)
                {
                    var result = res.Content.ReadAsStringAsync();
                    string cont = result.Result.ToString();
                    var cont2 = cont.Substring(9, cont.LastIndexOf("]") - 8);
                    //var contact =  JsonSerializer.Deserialize<List<ContactProxy>>(cont2);
                    return System.Text.Json.JsonSerializer.Deserialize<List<ContactProxy>>(cont2);

                }
            }
            catch (Exception ex)
            {
                //TODO add logging
                //var error = new Dictionary<string, string>
                //{
                //    {"Type", ex.GetType().ToString()},
                //    {"Message", ex.Message},
                //    {"StackTrace", ex.StackTrace}
                //};

                //foreach (DictionaryEntry data in ex.Data)
                //    error.Add(data.Key.ToString(), data.Value.ToString());

                //string json = JsonConvert.SerializeObject(error, Formatting.Indented);

                //HttpResponseMessage response = new HttpResponseMessage();
                //response.Content = new StringContent(json);

                //retur.Add(response);

            }
            return retur;
        }

        public async Task<List<ContactProxy>> GetContactByName(string name)
        { //ContactProxy
            List<ContactProxy> retur = new List<ContactProxy>();
            try
            {
                byteArray = Encoding.ASCII.GetBytes("flow_agresso:ohqu9aivahKu0ahgh1de1mah4ooHai7fie7gee3u");
                string url = baseurl + "flow_contacts?name=" + name ;
                var client = HttpClient(url);
                var res = await client.GetAsync(url);
                if (res.IsSuccessStatusCode)
                {
                    var result = res.Content.ReadAsStringAsync();
                    string cont = result.Result.ToString();
                    var cont2 = cont.Substring(9, cont.LastIndexOf("]") - 8);
                    return System.Text.Json.JsonSerializer.Deserialize<List<ContactProxy>>(cont2);

                }
            }
            catch (Exception ex)
            {
                //TODO add logging
                //var error = new Dictionary<string, string>
                //{
                //    {"Type", ex.GetType().ToString()},
                //    {"Message", ex.Message},
                //    {"StackTrace", ex.StackTrace}
                //};

                //foreach (DictionaryEntry data in ex.Data)
                //    error.Add(data.Key.ToString(), data.Value.ToString());

                //string json = JsonConvert.SerializeObject(error, Formatting.Indented);

                //HttpResponseMessage response = new HttpResponseMessage();
                //response.Content = new StringContent(json);

                //retur.Add(response);

            }
            return retur;
        }
    }
}
