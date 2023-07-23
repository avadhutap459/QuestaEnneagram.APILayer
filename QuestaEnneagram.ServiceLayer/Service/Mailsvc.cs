using AutoMapper;
using QuestaEnneagram.DbLayer.DBModel;
using QuestaEnneagram.ServiceLayer.EF.Interface;
using QuestaEnneagram.ServiceLayer.Interface;
using QuestaEnneagram.ServiceLayer.Model;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;

namespace QuestaEnneagram.ServiceLayer.Service
{
    public class Mailsvc: IMail,IDisposable
    {
        private static TimeZoneInfo INDIAN_ZONE = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");

        public IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public Mailsvc(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            this._mapper = mapper;
        }
        ~Mailsvc()
        {
            Dispose(false);
        }


        public MailBM GetMailDetailByUniqueId(int CMapHrId,bool IsInitialMail,bool IsFinalMail)
        {
            MailBM ObjMailmodel = null;
            int MailTemplateId = 0;
            try
            {
                MailTemplateId = GetMailTemplateId(CMapHrId, IsInitialMail, IsFinalMail);

                DbMailTemplateModel Mailtemplatedbmodel = _unitOfWork.dbContext.mstMailTemplates.Where(x=>x.MailTemplateId == MailTemplateId).FirstOrDefault();

                if (Mailtemplatedbmodel != null)
                    ObjMailmodel = this._mapper.Map<DbMailTemplateModel, MailBM>(Mailtemplatedbmodel);

                var Getemailandname = GetEmailIdAndNameoftheperson(CMapHrId, IsInitialMail, IsFinalMail);

                ObjMailmodel.RecevierEmailAddress = Getemailandname.Item1;
                ObjMailmodel.RecevierName = Getemailandname.Item2;

                return ObjMailmodel;
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public async Task SentMail(MailBM objmailbody, string url,bool IsInitialMail,bool IsFinalMail)
        {
            try
            {
                string FROM = objmailbody.FromMailAddress;
                string FROMNAME = objmailbody.SMTP_SenderNAME;

                string TO = objmailbody.RecevierEmailAddress;

                List<string> BCC = new List<string>();
                if (!string.IsNullOrEmpty(objmailbody.BCCMailAddress))
                {
                    BCC = objmailbody.BCCMailAddress.Split(';').ToList();
                }

                List<string> CC = new List<string>();
                if (!string.IsNullOrEmpty(objmailbody.CCMailAddress))
                {
                    CC = objmailbody.CCMailAddress.Split(';').ToList();
                }
                string RecevierName = objmailbody.RecevierName;
                string SMTP_USERNAME = objmailbody.SMTP_USERNAME;
                string SMTP_PASSWORD = objmailbody.SMTP_PASSWORD;
                string CONFIGSET = objmailbody.CONFIGSET;
                string HOST = objmailbody.HOST;
                int PORT = Convert.ToInt32(objmailbody.PORT);

                var MailBodyAndSubject = GetSubjectLineAndBodyForInitialMail(url, objmailbody.BODY, RecevierName, TO);

                string SUBJECT = MailBodyAndSubject.Item1;
                string Body = MailBodyAndSubject.Item2;

                MailMessage message = new MailMessage();
                message.IsBodyHtml = true;
                AlternateView htmlView = AlternateView.CreateAlternateViewFromString(Body, null, "text/html");

                var buildDir = Directory.GetCurrentDirectory().Substring(0, Directory.GetCurrentDirectory().LastIndexOf('\\')) + '\\' + "QuestaEnneagram.APILayer";

                string FooterImagePath = buildDir + "\\Images\\" + "QuestaMailFooterLogo.png";
                byte[] FooterImageBytes = System.IO.File.ReadAllBytes(FooterImagePath);
                System.IO.MemoryStream FooterImagestreamBitmap = new System.IO.MemoryStream(FooterImageBytes);
                LinkedResource FooterLinkResources = new LinkedResource(FooterImagestreamBitmap, MediaTypeNames.Image.Jpeg);
                FooterLinkResources.ContentId = "myFooterID";
                htmlView.LinkedResources.Add(FooterLinkResources);

                string FacebookImagePath = buildDir + "\\Images\\" + "facebook.png";
                byte[] FacebookImageBytes = System.IO.File.ReadAllBytes(FacebookImagePath);
                System.IO.MemoryStream FacebookImagestreamBitmap = new System.IO.MemoryStream(FacebookImageBytes);
                LinkedResource FacebookLinkResources = new LinkedResource(FacebookImagestreamBitmap, MediaTypeNames.Image.Jpeg);
                FacebookLinkResources.ContentId = "myFacebookID";
                htmlView.LinkedResources.Add(FacebookLinkResources);

                string ATImagePath = buildDir + "\\Images\\" + "AtLogo.png";
                byte[] ATImageBytes = System.IO.File.ReadAllBytes(ATImagePath);
                System.IO.MemoryStream ATImagestreamBitmap = new System.IO.MemoryStream(ATImageBytes);
                LinkedResource ATLinkResources = new LinkedResource(ATImagestreamBitmap, MediaTypeNames.Image.Jpeg);
                ATLinkResources.ContentId = "myAtID";
                htmlView.LinkedResources.Add(ATLinkResources);

                string LinkedImagePath = buildDir + "\\Images\\" + "linkedin.png";
                byte[] LinkedImageBytes = System.IO.File.ReadAllBytes(LinkedImagePath);
                System.IO.MemoryStream LinkedImagestreamBitmap = new System.IO.MemoryStream(LinkedImageBytes);
                LinkedResource LinkedLinkResources = new LinkedResource(LinkedImagestreamBitmap, MediaTypeNames.Image.Jpeg);
                LinkedLinkResources.ContentId = "myLinkedInID";
                htmlView.LinkedResources.Add(LinkedLinkResources);

                message.AlternateViews.Add(htmlView);

                message.From = new MailAddress(FROM, FROMNAME);
                message.To.Add(new MailAddress(TO));
                foreach (var bcc in BCC)
                {
                    message.Bcc.Add(new MailAddress(bcc));
                }
                foreach (var cc in CC)
                {
                    message.CC.Add(new MailAddress(cc));
                }
                message.Subject = SUBJECT;
                message.Body = Body;

                message.Headers.Add("X-SES-CONFIGURATION-SET", CONFIGSET);

                using (var client = new System.Net.Mail.SmtpClient(HOST, PORT))
                {
                    // Pass SMTP credentials
                    client.Credentials =
                        new NetworkCredential(SMTP_USERNAME, SMTP_PASSWORD);

                    // Enable SSL encryption
                    client.EnableSsl = true;

                    client.Send(message);
                }
            }
            catch(Exception ex)
            {
                throw;
            }
        }



        private int GetMailTemplateId(int CMapHrId,bool Initial,bool Final)
        {
            try
            {
                if(Initial)
                {
                    return _unitOfWork.dbContext.HrMapToCompanies.Where(x => x.CMapHId == CMapHrId).Select(x => x.InitialMailId.Value).FirstOrDefault();
                }
                else if(Final)
                {
                    return _unitOfWork.dbContext.HrMapToCompanies.Where(x => x.CMapHId == CMapHrId).Select(x => x.FinalMailId.Value).FirstOrDefault();
                }
                return 0;
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        private Tuple<string,string> GetEmailIdAndNameoftheperson(int CMapHrId,bool Inital,bool Final)
        {
            string EmailId = string.Empty;
            string Name = string.Empty;
            try
            {
                if(Inital)
                {
                    int HrId = _unitOfWork.dbContext.HrMapToCompanies.Where(x => x.CMapHId == CMapHrId).Select(x => x.HrId).FirstOrDefault();

                    var HrDetails = _unitOfWork.dbContext.HumanResources.Where(x => x.HrId == HrId).Select(y => new { y.HrName, y.HrEmail }).FirstOrDefault();

                    EmailId = HrDetails.HrEmail;
                    Name = HrDetails.HrName;
                }


                return new Tuple<string, string>(EmailId, Name);
            }
            catch(Exception ex)
            {
                throw;
            }
        }


        private Tuple<string,string> GetSubjectLineAndBodyForInitialMail(string Url,string Body,string RecevierName,string ToEmailAddress)
        {
            string BodyTemplate = string.Empty;
            string SubjectLine =string.Empty;
            try
            {
                SubjectLine = "Questa Enneagram Assessment - Test Login Details";

                string HTMLContent = "<html><head><style>.image{margin - left: auto; margin - right: auto;height: 55px;width: 103px;}p{font-size: 12px;font-family: Arial, Helvetica, sans-serif;text-align: justify;text-align-last: left;-moz-text-align-last: left;}";
                HTMLContent = HTMLContent + ".image - container {justify - content: center;}li{font-size: 12px;font-family: Arial, Helvetica, sans-serif;text-align: justify;text-align-last: left;-moz-text-align-last: left;}.border{border: 1px solid black;}</style></head><body>";
                string HTMLEndContent = "</body></html> ";
                BodyTemplate = HTMLContent + Body + HTMLEndContent;
                BodyTemplate = BodyTemplate.Replace("@RecevierName", RecevierName);
                BodyTemplate = BodyTemplate.Replace("@URL", Url);
                BodyTemplate = BodyTemplate.Replace("@Email", ToEmailAddress);
                BodyTemplate = BodyTemplate.Replace("@TestId", "");


                return new Tuple<string, string>(SubjectLine, BodyTemplate);
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                // Console.WriteLine("This is the first call to Dispose. Necessary clean-up will be done!");

                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                    // Console.WriteLine("Explicit call: Dispose is called by the user.");
                }
                else
                {
                    // Console.WriteLine("Implicit call: Dispose is called through finalization.");
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // Console.WriteLine("Unmanaged resources are cleaned up here.");

                // TODO: set large fields to null.

                disposedValue = true;
            }
            else
            {
                // Console.WriteLine("Dispose is called more than one time. No need to clean up!");
            }
        }



        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
