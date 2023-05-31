using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Net.NetworkInformation;
namespace UriDns{

    class Program{
        static void uridemo(){
        string url ="https://www.nettruyenplus.com/";
         var uri = new Uri(url);
         var uriType = typeof(Uri);
         uriType.GetProperties().ToList().ForEach(property =>{
            System.Console.WriteLine($"{property.Name,15} {property.GetValue(uri)}" );
         });
         System.Console.WriteLine($"Segments: {string.Join(",",uri.Segments)}");
        }

        static void getLocalHost(){
            var hostname = Dns.GetHostName(); //get host local
         System.Console.WriteLine(hostname);
        }

        //Mot ten mien co the tro den nhieu server khac nhau
        //Tro den nhieu ip
        static void entryHostIp(){
         var url = "https://www.bootstrapcdn.com/";
         var uri  = new Uri(url);
         System.Console.WriteLine(uri.Host);
         var iphostentry = Dns.GetHostEntry(uri.Host);
         System.Console.WriteLine(iphostentry.HostName);
         iphostentry.AddressList.ToList().ForEach(ip => {
         System.Console.WriteLine(ip);
         });
        }

        static void pings(){
         //Check server respond

        var ping = new Ping();
        var pingReply = ping.Send("google.com.vn");
        System.Console.WriteLine(pingReply.Status);
        if(pingReply.Status == IPStatus.Success){
            System.Console.WriteLine(pingReply.RoundtripTime);
            System.Console.WriteLine(pingReply.Address);
        }
        }

        static void ShowHeader(HttpResponseHeaders headers){
        System.Console.WriteLine("Headers");
        foreach(var header in headers){
        System.Console.WriteLine($"{header.Key} : {header.Value}");
        }
        }

        public static async Task<string> GetWebContent(string url){
        using var httpClient = new HttpClient();

        try{
          HttpResponseMessage httpResponseMessage = await httpClient.GetAsync(url);
        ShowHeader(httpResponseMessage.Headers);
            string html = await httpResponseMessage.Content.ReadAsStringAsync();
                    return html;
        }catch(Exception ex){
          System.Console.WriteLine(ex.Message);
          return "Loi";
        }
        }
        

        static async Task Main(String[] args){
         using var httpClient = new HttpClient();
         var httpRequestMessage = new HttpRequestMessage();
         httpRequestMessage.Method = HttpMethod.Get;
         httpRequestMessage.RequestUri = new Uri("https://postman-echo.com/post");
         httpRequestMessage.Headers.Add("User-Agent","Mozilla/5.0");

         //httpMessageRequest.Content => Form HTML, File ...
         //Post =>  Form Html
         /*
           key1 => value 1      [Input]
           key2 => [Value2-1,Value2-2]   [Multi Select]

         */

         var parameters = new List<KeyValuePair<string,string>>();
         parameters.Add(new KeyValuePair<string, string>("key1","value1"));
         parameters.Add(new KeyValuePair<string, string>("key2","value2-1"));
         parameters.Add(new KeyValuePair<string, string>("key2","value2-2"));


         var content = new FormUrlEncodedContent(parameters);
         httpRequestMessage.Content = content;

         var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);

         var html = await httpResponseMessage.Content.ReadAsStringAsync();
         System.Console.WriteLine(html);

        }
       
    }
}