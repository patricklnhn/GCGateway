using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuntaClient
{
    //public partial class ContactItemsProxy
    //{
    //    public ContactProxy[]? contactProxy { get; set; }
    //    public int current_page { get; set; }
    //    public int per_page { get; set; }
    //    public int total_entries { get; set; }
    //}
        public partial class ContactProxy
        {
            public DateTime created_at { get; set; }
            public string created_by { get; set; } = default!;
            public string description { get; set; } = default!;
            public string email { get; set; } = default!;
            public string fax { get; set; } = default!;
            public int id { get; set; }
            public string mobile { get; set; } = default!;
            public string phone  {get;set; } = default!;
            public string role { get; set; } = default!;
            public int status_id { get; set; } = default!;
            public DateTime updated_at { get; set; }
            public string updated_by { get; set; } = default!;
        }
}
