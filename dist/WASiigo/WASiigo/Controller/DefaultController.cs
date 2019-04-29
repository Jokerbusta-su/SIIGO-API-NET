using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using WASiigo.Model;
using WASiigo.Utils;

namespace WASiigo.Controller
{
    public class DefaultController
    {
        private const string TOKEN_BASIC = "Basic U2lpZ29XZWI6QUJBMDhCNkEtQjU2Qy00MEE1LTkwQ0YtN0MxRTU0ODkxQjYx";
        private const string BODY_TOKEN_SERVICE = "grant_type=password&username=Empresadeperas\\admin@peras.com&password=siigo2019&scope=WebApi offline_access";
        private const string SUBSCRIPTION_KEY = "a21a8a8413134995b658925143dc87e7";

        public static async Task<string> getToken()
        {
            string token = "";
            try
            {
                var client = new HttpClient();
                client.DefaultRequestHeaders.Add("Authorization", TOKEN_BASIC);
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                client.DefaultRequestHeaders.Add("Content-Type", "application/x-www-form-urlencoded");
                var uri = "https://siigonube.siigo.com:50050/connect/token";
                HttpResponseMessage response;
                byte[] byteData = Encoding.UTF8.GetBytes(BODY_TOKEN_SERVICE);

                using (var content = new ByteArrayContent(byteData))
                {
                    content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                    response = await client.PostAsync(uri, content);
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return token;
        }

        public static async Task<List<Developer>> GetDevelopers()
        {
            List<Developer> result = null;
            try
            {
                var client = new HttpClient();
                client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", SUBSCRIPTION_KEY);
                client.DefaultRequestHeaders.Add("Authorization", await getToken());
                //var uri = "http://localhost:16391/api/v1/Developers/GetAll?namespace=v1";
                var uri = "http://siigoapi.azure-api.net/siigo/api/v1/Developers/GetAll?namespace=v1";
                HttpResponseMessage response = await client.GetAsync(uri);
                result = Util.fromJson<List<Developer>>(response.Content.ReadAsStringAsync().Result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public static async Task<List<Product>> GetProducts()
        {
            List<Product> result = null;
            try
            {
                var client = new HttpClient();
                client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", SUBSCRIPTION_KEY);
                client.DefaultRequestHeaders.Add("Authorization", await getToken());
                //var uri = "http://localhost:16391/api/v1/Products/GetAll?numberPage=0&namespace=v1";
                var uri = "http://siigoapi.azure-api.net/siigo/api/v1/Products/GetAll?numberPage=0&namespace=v1";
                HttpResponseMessage response = await client.GetAsync(uri);
                result = Util.fromJson<List<Product>>(response.Content.ReadAsStringAsync().Result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public static async Task<Product> CreateProduct(Product product)
        {
            try
            {
                var client = new HttpClient();
                client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", SUBSCRIPTION_KEY);
                client.DefaultRequestHeaders.Add("Authorization", await getToken());
                //var uri = "http://localhost:16391/api/v1/Products/Create?namespace=v1";
                var uri = "http://siigoapi.azure-api.net/siigo/api/v1/Products/Create?namespace=v1";
                HttpResponseMessage response;
                string productStr = Util.toJson(product);
                byte[] byteData = Encoding.UTF8.GetBytes(productStr);

                using (var content = new ByteArrayContent(byteData))
                {
                    content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                    response = await client.PostAsync(uri, content);
                    product = Util.fromJson<Product>(response.Content.ReadAsStringAsync().Result);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return product;
        }

        public static async void DeleteProduct(long id)
        {
            try
            {
                var client = new HttpClient();
                client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", SUBSCRIPTION_KEY);
                client.DefaultRequestHeaders.Add("Authorization", await getToken());
                //var uri = "http://localhost:16391/api/v1/Products/Delete/" + id + "?namespace=v1";
                var uri = "http://siigoapi.azure-api.net/siigo/api/v1/Products/Delete/" + id + "?namespace=v1";
                var response = await client.DeleteAsync(uri);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}