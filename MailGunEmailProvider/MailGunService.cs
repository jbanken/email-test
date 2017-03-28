using System;
using System.Threading.Tasks;
using Email.MailGunEmailProvider.Interfaces;
using Email.MailGunEmailProvider.Models;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using System.Collections.Generic;
namespace Email.MailGunEmailProvider
{
    public class MailGunService : IMailGunService
    {
        private string _mailGunURL { get; set; }
        private string _mailGunAPIKey { get; set; }
        private string _mailGunDomain { get; set; }
        public MailGunService()
        {
            _mailGunURL = "xxx";
            _mailGunDomain = "xxx";
            _mailGunAPIKey = "xxx";
        }
        public async Task<SendResponse> Send(SendRequest request)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(_mailGunURL);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));
            
            string creds = Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes("api:" + _mailGunAPIKey));

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", creds);
            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("to", request.to)
                ,new KeyValuePair<string, string>("from", request.from)
                ,new KeyValuePair<string, string>("subject", request.subject)
                ,new KeyValuePair<string, string>("html", request.html)
                ,new KeyValuePair<string, string>("text", request.text)
            });

            var response = await client.PostAsync("messages", content); 

            var result = new SendResponse();
            result.Content = await response.Content.ReadAsStringAsync();
            if(response.StatusCode == System.Net.HttpStatusCode.OK)
                result.Id = JsonConvert.DeserializeObject<MailGunSendResponse>(result.Content).Id;
            result.StatusCode = response.StatusCode;

            return result;
        }
    }
}
