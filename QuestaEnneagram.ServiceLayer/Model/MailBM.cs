using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestaEnneagram.ServiceLayer.Model
{
    public class MailBM
    {
        public int MailTemplateId { get; set; }
        public string SMTP_SenderNAME { get; set; } = string.Empty;
        public string SMTP_USERNAME { get; set; } = string.Empty;
        public string SMTP_PASSWORD { get; set; } = string.Empty;
        public string CONFIGSET { get; set; } = string.Empty;
        public string FromMailAddress { get; set; } = string.Empty;
        public string BCCMailAddress { get; set; } = string.Empty;
        public string CCMailAddress { get; set; } = string.Empty;
        public string HOST { get; set; } = string.Empty;
        public int PORT { get; set; }
        public string BODY { get; set; } = string.Empty;
        public bool Active { get; set; }
        public string RecevierEmailAddress { get; set; } = string.Empty;
        public string RecevierName { get; set; } = string.Empty;
    }
}
