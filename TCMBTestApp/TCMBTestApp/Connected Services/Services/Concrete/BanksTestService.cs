using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using TCMBTestApp.Connected_Services.Services.Abstract;

namespace TCMBTestApp.Connected_Services.Services.Concrete
{
    public class BanksTestService : IBanksService
    {
        public void GetAllBanks()
        {
            Console.WriteLine("All banks are brought to you by Husokanyus.");
        }

        public HttpWebRequest CreateSOAPWebRequest()
        {
            //Making Web Request    
            HttpWebRequest Req = (HttpWebRequest)WebRequest.Create(@"https://appg.tcmb.gov.tr/mbnbasuse/services/bankaSubeOku");
            //SOAPAction    
            Req.Headers.Add(@"SOAPAction:https://appg.tcmb.gov.tr/mbnbasuse/services/bankaSubeOku");
            //Content_type    
            Req.ContentType = "text/xml;charset=\"utf-8\"";
            Req.Accept = "text/xml";
            //HTTP method    
            Req.Method = "POST";
            //return HttpWebRequest    
            return Req;
        }

        public void InvokeService(string a, string b = "", string c= "")
        {
            //Calling CreateSOAPWebRequest method    
            HttpWebRequest request = CreateSOAPWebRequest();

            XmlDocument SOAPReqBody = new XmlDocument();
            //SOAP Body Request    
            SOAPReqBody.LoadXml(@"<soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:ban=""https://appg.tcmb.gov.tr/mbnbasuse/services/bankaSubeOku"">" +
               "<soapenv:Header/>"+
               "<soapenv:Body>" +
               "<ban:bankaSubeOkuIstem>" +
               "<ban:blgTur>" + "BLS" + "</ban:blgTur>" +
               "<!--Optional:-->" +
               "<ban:bKd>" + "TUM" + "</ban:bKd>" +
               "<!--Optional:-->" +
               "<ban:sKd>" + "TUM" + "</ban:sKd>" +
               "</ban:bankaSubeOkuIstem>"+
               "</soapenv:Body>" +
               "</soapenv:Envelope>"
            );    



   using (Stream stream = request.GetRequestStream())
            {
                SOAPReqBody.Save(stream);
            }
            //Geting response from request    
            try
            {
                using (WebResponse Serviceres = request.GetResponse())
                {
                    using (StreamReader rd = new StreamReader(Serviceres.GetResponseStream()))
                    {
                        //reading stream    
                        var ServiceResult = rd.ReadToEnd();
                        //writting stream result on console    
                        Console.WriteLine(ServiceResult);
                        Console.ReadLine();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            
        }
    }
}
