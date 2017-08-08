using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Formatting;
using System.Threading.Tasks;
using Newtonsoft.Json.Converters;

namespace Web._IntegracaoAPI
{
    public abstract class BaseRepositorioAPI
    {
        public string URL
        {
            get
            {
                try
                {
                    return ConfigurationManager.AppSettings["URL_API_SERVER"];
                }
                catch
                {
                    throw new Exception("Configuração da API de integração não localizada.");
                }

            }
        }

        public TViewModels GetByQueryString<TViewModels>(string querystringURL)
        {
            TViewModels ViewModel = default(TViewModels);

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(URL);

                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var task = client.GetAsync(querystringURL)
                    .ContinueWith((JsonFormater) =>
                    {
                        if (!JsonFormater.Result.IsSuccessStatusCode)
                        {
                            throw new Exception(string.Format("Data access faild,{0} ({1}) method:{2}", (int)JsonFormater.Result.StatusCode, JsonFormater.Result.ReasonPhrase, querystringURL));
                        }

                        var JsonString = JsonFormater.Result.Content.ReadAsStringAsync();
                        JsonString.Wait();
                        ViewModel = JsonConvert.DeserializeObject<TViewModels>(JsonString.Result);
                    });
                task.Wait();
            }

            return ViewModel;
        }

        public T PostApi<T>(T model, string metodoApi)
        {
            T result = default(T);

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(URL);

                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var task = client.PostAsJsonAsync<T>(metodoApi, model)
                    .ContinueWith((JsonFormater) =>
                    {
                        if (!JsonFormater.Result.IsSuccessStatusCode)
                        {
                            throw new Exception(string.Format("Data access faild,{0} ({1}) method:{2}", (int)JsonFormater.Result.StatusCode, JsonFormater.Result.ReasonPhrase, metodoApi));
                        }

                        var JsonString = JsonFormater.Result.Content.ReadAsStringAsync();
                        JsonString.Wait();
                        result = JsonConvert.DeserializeObject<T>(JsonString.Result);
                    });
                task.Wait();
            }

            return result;
        }

        public List<T> GetALL<T>(string metodoApi)
        {
            List<T> model = new List<T>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(URL);

                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var task = client.GetAsync(metodoApi)
                    .ContinueWith((JsonFormater) =>
                    {
                        if (!JsonFormater.Result.IsSuccessStatusCode)
                        {
                            throw new Exception(string.Format("Data access faild,{0} ({1}) method:{2}", (int)JsonFormater.Result.StatusCode, JsonFormater.Result.ReasonPhrase, metodoApi));
                        }

                        var JsonString = JsonFormater.Result.Content.ReadAsStringAsync();
                        JsonString.Wait();
                        model = JsonConvert.DeserializeObject<List<T>>(JsonString.Result);
                    });
                task.Wait();
            }

            return model;
        }

        public Guid PutApi<T>(T vwmodel, string metodoapi)
        {
            Guid JsonGuidResultado = Guid.Empty;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(URL);

                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var task = client.PutAsJsonAsync<T>(metodoapi, vwmodel)
                    .ContinueWith((JsonFormater) =>
                    {
                        if (!JsonFormater.Result.IsSuccessStatusCode)
                        {
                            throw new Exception(string.Format("Data access faild,{0} ({1}) method:{2}", (int)JsonFormater.Result.StatusCode, JsonFormater.Result.ReasonPhrase, metodoapi));
                        }

                        var JsonString = JsonFormater.Result.Content.ReadAsStringAsync();
                        JsonString.Wait();

                        if (JsonString.Result != "")
                            JsonGuidResultado = JsonConvert.DeserializeObject<Guid>(JsonString.Result);
                    });
                task.Wait();
            }

            return JsonGuidResultado;
        }
    }

}


