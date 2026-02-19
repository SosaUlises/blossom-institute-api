using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlossomInstitute.Infraestructure.Email
{
    public class EmailSettings
    {
        public string Host { get; set; } = default!;
        public int Port { get; set; }
        public bool UseSsl { get; set; } = true;

        public string Username { get; set; } = default!;
        public string Password { get; set; } = default!;

        public string FromEmail { get; set; } = default!;
        public string FromName { get; set; } = "Blossom Institute";
    }
}
