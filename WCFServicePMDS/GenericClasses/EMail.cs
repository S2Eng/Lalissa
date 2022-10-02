using Microsoft.Exchange.WebServices.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;


namespace WCFServicePMDS
{

    public class EMail
    {


        public class cAttachment
        {
            public string NameAttachment = "";
            public byte[] fileBytes = null;
        }






        public bool sendEMailOffice365(System.Collections.Generic.List<String> lstAdresessTo, System.Collections.Generic.List<String> AdressCC, System.Collections.Generic.List<String> adressBcc,
                                        string Title, string Body, bool IsHtml, System.Collections.Generic.List<cAttachment> lstAttachments)
        {
            try
            {
                throw new Exception("sendEMailOffice365: Function not activated!");
                ExchangeService es = new ExchangeService(ExchangeVersion.Exchange2010_SP2);     //>> ExchangeWorld4You

                es.Url = new Uri(ENV.ENVWcf.ExchangeUrl.Trim());
                es.Credentials = new NetworkCredential(ENV.ENVWcf.ExchangeUsr.Trim(), ENV.ENVWcf.ExchangePwd.Trim());

                EmailMessage message = new EmailMessage(es);
                Microsoft.Exchange.WebServices.Data.EmailAddress adrSender = new Microsoft.Exchange.WebServices.Data.EmailAddress();
                adrSender.Address = ENV.ENVWcf.ExchangeAdressFrom.Trim();
                message.From = adrSender;
                message.Subject = Title.Trim();
                message.Body = Body;

                if (IsHtml)
                {
                    message.Body.BodyType = BodyType.HTML;
                }
                else
                {
                    message.Body.BodyType = BodyType.Text;
                }

                foreach (string AdressTo in lstAdresessTo)
                {
                    Microsoft.Exchange.WebServices.Data.EmailAddress adrTo = new Microsoft.Exchange.WebServices.Data.EmailAddress();
                    adrTo.Address = AdressTo.Trim();
                    message.ToRecipients.Add(adrTo);
                }
                if (AdressCC != null)
                {
                    foreach (string AdressCc in AdressCC)
                    {
                        Microsoft.Exchange.WebServices.Data.EmailAddress adrTo = new Microsoft.Exchange.WebServices.Data.EmailAddress();
                        adrTo.Address = AdressCc.Trim();
                        message.CcRecipients.Add(adrTo);
                    }
                }
                if (adressBcc != null)
                {
                    foreach (string AdressBcc in adressBcc)
                    {
                        Microsoft.Exchange.WebServices.Data.EmailAddress adrTo = new Microsoft.Exchange.WebServices.Data.EmailAddress();
                        adrTo.Address = AdressBcc.Trim();
                        message.BccRecipients.Add(adrTo);
                    }
                }


                foreach (cAttachment Attachment in lstAttachments)
                {
                    MemoryStream memStream = new MemoryStream(Attachment.fileBytes);
                    FileAttachment fileAttachment = message.Attachments.AddFileAttachment(Attachment.NameAttachment.Trim(), memStream);
                }

                message.Send();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("WCFServicePMDS.EMail.sendEMailOffice365: " + ex.ToString());
            }
        }

        public static bool sendSMTPEMail(string title, string txt)
        {
            try
            {
                EMail EMail1 = new EMail();
                System.Collections.Generic.List<String> lstAdresessTo = new List<string>();
                System.Collections.Generic.List<String> lstAdressCC = new List<string>();
                System.Collections.Generic.List<String> lstAdressBcc = new List<string>();
                System.Collections.Generic.List<cAttachment> lstAttachments = new List<cAttachment>();

                lstAdresessTo.Add(ENV.ENVWcf.SmtpUsr);
                return EMail1.sendEMailSmtp(lstAdresessTo, lstAdressCC, lstAdressBcc, title, txt, false, lstAttachments);
            }
            catch (Exception ex)
            {
                throw new Exception("WCFServicePMDS.EMail.sendExceptionAsSMTPEMail: " + ex.ToString());
            }
        }

        public static bool sendExceptionAsSMTPEMail(string except, string client, string User, DateTime dAt)
        {
            try
            {
                EMail EMail1 = new EMail();
                System.Collections.Generic.List<String> lstAdresessTo = new List<string>();
                System.Collections.Generic.List<String> lstAdressCC = new List<string>();
                System.Collections.Generic.List<String> lstAdressBcc = new List<string>();
                System.Collections.Generic.List<cAttachment> lstAttachments = new List<cAttachment>();

                string sTitle = "PMDS Exception from " + User;
                string sBody = "Time: " + dAt.ToString() + "\r\n" +
                                "User: " + User.Trim() + "\r\n" +
                                "Client: " + client.Trim() + "\r\n" + "\r\n" +
                                "Exception:" + "\r\n" + except;

                lstAdresessTo.Add(ENV.ENVWcf.SmtpUsr);
                return EMail1.sendEMailSmtp(lstAdresessTo, lstAdressCC, lstAdressBcc, sTitle, sBody, false, lstAttachments);
            }
            catch (Exception ex)
            {
                throw new Exception("WCFServicePMDS.EMail.sendExceptionAsSMTPEMail: " + ex.ToString());
            }
        }
        public bool sendEMailSmtp(System.Collections.Generic.List<String> lstAdresessTo, System.Collections.Generic.List<String> AdressCC, System.Collections.Generic.List<String> adressBcc,
                                    string Title, string Body, bool IsHtml, System.Collections.Generic.List<cAttachment> lstAttachments)
        {
            try
            {
                if (!string.IsNullOrEmpty(ENV.ENVWcf.SmtpServer) && ENV.ENVWcf.SmtpAdressFrom != null)
                {
                    System.Net.Mail.MailMessage email = new System.Net.Mail.MailMessage();
                    System.Net.Mail.MailAddress adrFrom = new System.Net.Mail.MailAddress(ENV.ENVWcf.SmtpAdressFrom.Trim(), ENV.ENVWcf.SmtpAdressFrom.Trim());
                    email.From = adrFrom;

                    email.Subject = Title;
                    email.Priority = System.Net.Mail.MailPriority.Normal;
                    email.Body = Body;
                    email.IsBodyHtml = IsHtml;

                    foreach (string AdressTo in lstAdresessTo)
                    {
                        System.Net.Mail.MailAddress adrTo = new System.Net.Mail.MailAddress(AdressTo);
                        email.To.Add(adrTo);
                    }
                    if (AdressCC != null)
                    {
                        foreach (string AdressCc in AdressCC)
                        {
                            System.Net.Mail.MailAddress adrCc = new System.Net.Mail.MailAddress(AdressCc);
                            email.CC.Add(adrCc);
                        }
                    }
                    if (adressBcc != null)
                    {
                        foreach (string AdressBcc in adressBcc)
                        {
                            System.Net.Mail.MailAddress adrBcc = new System.Net.Mail.MailAddress(AdressBcc);
                            email.Bcc.Add(adrBcc);
                        }
                    }


                    foreach (cAttachment Attachment in lstAttachments)
                    {
                        MemoryStream memStream = new MemoryStream(Attachment.fileBytes);
                        System.Net.Mail.Attachment fileAttachment = new System.Net.Mail.Attachment(memStream, Attachment.NameAttachment.Trim());
                        email.Attachments.Add(fileAttachment);
                    }

                    System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;
                    System.Net.Mail.SmtpClient SmtpMail = new System.Net.Mail.SmtpClient(ENV.ENVWcf.SmtpServer, ENV.ENVWcf.SmtpPort);


                    System.Net.NetworkCredential basicAuthenticationInfo = new System.Net.NetworkCredential(ENV.ENVWcf.SmtpUsr, ENV.ENVWcf.SmtpPwd);
                    SmtpMail.Credentials = basicAuthenticationInfo;
                    SmtpMail.EnableSsl = ENV.ENVWcf.SmtpSSL;
                    SmtpMail.Port = ENV.ENVWcf.SmtpPort;

                    SmtpMail.Send(email);
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                return false;
                throw new Exception("WCFServicePMDS.EMail.sendEMailSmtp: " + ex.ToString());
            }
        }


        public static bool RedirectionUrlValidationCallback(String redirectionUrl)
        {
            return (redirectionUrl == "https://autodiscover-s.outlook.com/autodiscover/autodiscover.xml");
        }

    }
}
