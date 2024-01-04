using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace InvoiceSystem.ViewModels.Public
{
    public class ResponseJsonViewModel
    {
        public int Id { get; set; }
        public HttpStatusCode Status { get; set; }
        public string Msg { get; set; }
        public string Url { get; set; }
        public object data { get; set; }
    }

}
