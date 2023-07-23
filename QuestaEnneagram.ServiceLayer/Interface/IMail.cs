using QuestaEnneagram.ServiceLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestaEnneagram.ServiceLayer.Interface
{
    public interface IMail
    {
        MailBM GetMailDetailByUniqueId(int CMapHrId, bool IsInitialMail, bool IsFinalMail);
        Task SentMail(MailBM objmailbody, string url, bool IsInitialMail, bool IsFinalMail);
    }
}
