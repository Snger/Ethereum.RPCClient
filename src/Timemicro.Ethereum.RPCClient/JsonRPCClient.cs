using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using Newtonsoft.Json;

namespace Timemicro.Ethereum.RPCClient
{
    public class JsonRPCClient
    {
        private string rpcurl;

        private string rpcuser;

        private string rpcpassword;

        public string WalletPassphrase { get; }

        public JsonRPCClient(string rpcurl
            , string rpcuser
            , string rpcpassword
            , string walletPassphrase)
        {
            this.rpcurl = rpcurl;
            this.rpcuser = rpcuser;
            this.rpcpassword = rpcpassword;
            WalletPassphrase = walletPassphrase;
        }

        public JsonRPCClient(string rpcurl, string rpcuser, string rpcpassword)
        {
            this.rpcurl = rpcurl;
            this.rpcuser = rpcuser;
            this.rpcpassword = rpcpassword;
        }

        public string Call(string method, params object[] parameters)
        {
            byte[] requestData = null;
            try
            {
                var http = CreateHttp();

                var requestText = new JsonRPCRequest(method, parameters.ToList()).ToString();

                requestData = Encoding.UTF8.GetBytes(requestText);

                http.ContentLength = requestData.Length;

                using (var requestStream = http.GetRequestStream())
                {
                    requestStream.Write(requestData, 0, requestData.Length);

                    var response = http.GetResponse();

                    using (var reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
                    {
                        return reader.ReadToEnd();
                    }
                }
            }
            catch (WebException ex)
            {
                using (var reader = new StreamReader(ex.Response.GetResponseStream(), Encoding.UTF8))
                {
                    return reader.ReadToEnd();
                }
            }
            finally
            {
                requestData = null;
            }
        }

        private HttpWebRequest CreateHttp()
        {
            var http = WebRequest.CreateHttp(rpcurl);

            http.Method = "POST";
            http.ContentType = "application/json";
            http.Headers["Authorization"] = $"Basic {Convert.ToBase64String(Encoding.UTF8.GetBytes($"{rpcuser}:{rpcpassword}"))}";

            return http;
        }
    }
}
