using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ServiciosIncapacidades
{
    public class HttpClientHelper<TResponse>
    {
        #region Consts
        //private const string jsonContentTypeForm = "application/x-www-form-urlencoded";
        private const string jsonContentTypeJson = "application/json";
        #endregion Consts

        #region Attributes
        private HttpClient httpClient;
        public  string token;
        #endregion Attributes

        #region Constructor

        public HttpClientHelper(string apiUrl)
        {
            httpClient = new HttpClient();

            if (httpClient.BaseAddress == null)
            {
                httpClient.BaseAddress = new Uri(apiUrl);
            }

            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(jsonContentTypeJson));
            httpClient.DefaultRequestHeaders.CacheControl = new CacheControlHeaderValue { NoCache = false };

            //if (!string.IsNullOrWhiteSpace(tokenValue))
            //{
            //    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenValue);
            //    httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
            //    httpClient.DefaultRequestHeaders.Add("x-ibm-client-id", AppSettingHelper.GetValueSetting("DaviviendaClientId"));
            //}

            //ServicePointManager.ServerCertificateValidationCallback += delegate (object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
            //{
            //    return true;
            //};

            //ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;


        }
        #endregion Constructor

        #region methods

        public async Task<TResponse> GetSingleItemRequest(string apiUrl)
        {
            TResponse result = default;
            HttpResponseMessage response = await httpClient.GetAsync(apiUrl).ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                await response.Content.ReadAsStringAsync().ContinueWith((Task<string> x) =>
                {
                   result = JsonConvert.DeserializeObject<TResponse>(x.Result);
                });
            }
            else
            {
                string content = await response.Content.ReadAsStringAsync();
                if (response.Content != null)
                {
                    response.Content.Dispose();
                }

                throw new HttpRequestException(string.Format("{0} : {1}", response.StatusCode, content));
            }
            return result;
        }


        public async Task<IEnumerable<TResponse>> GetMultipleItemsRequest(string apiUrl)
        {
            List<TResponse> result = null;
            HttpResponseMessage response = await httpClient.GetAsync(apiUrl).ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                await response.Content.ReadAsStringAsync().ContinueWith((Task<string> item) =>
                {
                    result = JsonConvert.DeserializeObject<List<TResponse>>(item.Result);
                });
            }
            else
            {
                string content = await response.Content.ReadAsStringAsync();

                if (response.Content != null)
                {
                    response.Content.Dispose();
                }
                throw new HttpRequestException(string.Format("{0} : {1}", response.StatusCode, content));
            }

            return result;
        }

        public async Task<TResponse> PostRequest(string apiUrl, List<KeyValuePair<string, string>> formParameters)
        {
            TResponse result = default;
            //try
            //{
                HttpResponseMessage response = await httpClient.PostAsync(apiUrl, new FormUrlEncodedContent(formParameters)).ConfigureAwait(false);
                if (response.IsSuccessStatusCode)
                {
                    await response.Content.ReadAsStringAsync().ContinueWith((Task<string> x) =>
                    {
                        result = JsonConvert.DeserializeObject<TResponse>(x.Result);
                    });
                }
                else
                {
                    string content = await response.Content.ReadAsStringAsync();
                    if (response.Content != null)
                    {
                        response.Content.Dispose();
                    }
                    
                    throw new HttpRequestException(string.Format("{0} : {1}", response.StatusCode, content));
                }
               
            //}
            //catch (Exception exc)
            //{
            //    Console.WriteLine(exc);
            //}
            return result;
        }


        public async Task<TResponse> PostRequest(string apiUrl, string body)
        {
            TResponse result = default;
            //try
            //{
                HttpResponseMessage response = await httpClient.PostAsync(apiUrl, new StringContent(body, Encoding.UTF8, jsonContentTypeJson)).ConfigureAwait(false);
                if (response.IsSuccessStatusCode)
                {
                    await response.Content.ReadAsStringAsync().ContinueWith((Task<string> x) =>
                    {
                        result = JsonConvert.DeserializeObject<TResponse>(x.Result);
                    });
                }
                else
                {
                    string content = await response.Content.ReadAsStringAsync();
                    if (response.Content != null)
                    {
                        response.Content.Dispose();
                    }
                    result = JsonConvert.DeserializeObject<TResponse>(content);
                    throw new HttpRequestException(string.Format("{0} : {1}", response.StatusCode, content));
                }
            //}
            //catch (Exception exc)
            //{
            //    Console.WriteLine(exc);
            //}
            return result;
        }



        public async Task<TResponse> PutRequest(string apiUrl, string jsonItem)
        {
            TResponse result = default;
            //string json = JsonConvert.SerializeObject(item);
            HttpResponseMessage response = await httpClient.PutAsync(apiUrl, new StringContent(jsonItem, Encoding.UTF8, jsonContentTypeJson)).ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                await response.Content.ReadAsStringAsync().ContinueWith((Task<string> x) =>
                {
                    result = JsonConvert.DeserializeObject<TResponse>(x.ToString());
                });
            }
            else
            {
                string content = await response.Content.ReadAsStringAsync();
                if (response.Content != null)
                {
                    response.Content.Dispose();
                }
                throw new HttpRequestException(string.Format("{0} : {1}", response.StatusCode, content));
            }

            return result;
        }


        public async Task<bool> DeleteRequest(string apiUrl)
        {
            HttpResponseMessage response = await httpClient.DeleteAsync(apiUrl).ConfigureAwait(false);
            return response.IsSuccessStatusCode;
        }

        #endregion methods

    }

}