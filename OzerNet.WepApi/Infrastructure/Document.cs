using System.Collections.Generic;

namespace OzerNet.WepApi.Infrastructure
{
    public class Document
    {
        public string Module { get; set; }
        public List<dynamic> Commands { get; set; }
    }
}
