using System;
using System.Collections.Generic;
using System.Text;
using OzerNet.Commands.Infrastructure;

namespace OzerNet.Commands.Commands.Common
{
    [Describe(Module.Common, Process.Create, "Veritabanını oluşturur"), AuthorizedAttribute]
    public class CreateDatabase : Command
    {
        public bool CreateBaseData { get; set; } = true;
        public string Password { get; set; }
    }
}
