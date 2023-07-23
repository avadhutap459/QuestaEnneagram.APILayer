using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuestaEnneagram.DbLayer.DBModel
{
    [Table("mstMailTemplate")]
    public class DbMailTemplateModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int  MailTemplateId { get; set; }
        
        [StringLength(150)]
        public string SMTP_SenderNAME { get; set; }
        public string SMTP_USERNAME { get; set; }
        public string SMTP_PASSWORD { get; set; }

        [StringLength(150)]
        public string CONFIGSET { get; set; }

        [StringLength(50)]
        public string FromMailAddress { get; set; }
        public string BCCMailAddress { get; set; }
        public string CCMailAddress { get; set; }
        public string HOST { get; set; }
        public int  PORT { get; set; }
        public string BODY { get; set; }
        public bool Active { get; set; }

    }
}
