using BusinessLogic;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace APIClient
{
    // http://restsharp.org/
    // https://www.codeproject.com/Articles/1018369/Calling-an-API-using-RestSharp-in-ASP-NET
    // https://social.technet.microsoft.com/wiki/contents/articles/31792.asp-net-how-to-consume-web-api-from-mvc4-using-restsharp.aspx
    public class RestSharpClient<T> where T : new()
    {
        private readonly RestClient _client;
        private readonly string _controllerUrl;
        
        public RestSharpClient(string baseUrl, string controllerUrl)
        {
            _client = new RestClient(baseUrl);
            _controllerUrl = controllerUrl;
        }

        public IEnumerable<T> Get()
        {
            try
            {
                var request = new RestRequest(_controllerUrl, Method.GET) { RequestFormat = DataFormat.Json };
                var response = _client.Execute<List<T>>(request);
                if (response.Data == null)
                    throw new Exception(response.ErrorMessage);
                return response.Data;
            }
            catch (Exception ex)
            {
                throw new JkcsException { ExcpetionTime = DateTime.Now, ExcpetionMessage = "Get All - " + _controllerUrl};
            }
        }

        public T Get(int primaryKey)
        {
            try
            {
                var request = new RestRequest(_controllerUrl + "{id}", Method.GET) { RequestFormat = DataFormat.Json };
                request.AddParameter("id", primaryKey, ParameterType.UrlSegment);
                var response = _client.Execute<T>(request);

                if (response.Data == null)
                    throw new Exception(response.ErrorMessage);
                return response.Data;
            }
            catch (Exception ex)
            {
                throw new JkcsException { ExcpetionTime = DateTime.Now, ExcpetionMessage = "Get by Id - " + _controllerUrl };
            }
        }

        public void Insert(T entity)
        {
            try
            {
                var request = new RestRequest(_controllerUrl, Method.POST) { RequestFormat = DataFormat.Json };
                request.AddBody(entity);

                var response = _client.Execute<T>(request);

                if (response.StatusCode != HttpStatusCode.Created)
                    throw new Exception(response.ErrorMessage);
            }
            catch (Exception)
            {
                throw new JkcsException { ExcpetionTime = DateTime.Now, ExcpetionMessage = "Insert - " + _controllerUrl };
            }
        }

        public void Update(T entity)
        {
            try
            {
                var request = new RestRequest(_controllerUrl, Method.PUT) { RequestFormat = DataFormat.Json };
                request.AddBody(entity);

                var response = _client.Execute<T>(request);

                if (response.StatusCode != HttpStatusCode.OK)
                    throw new Exception(response.ErrorMessage);
            }
            catch (Exception)
            {
                throw new JkcsException { ExcpetionTime = DateTime.Now, ExcpetionMessage = "Insert - " + _controllerUrl };
            }
        }

        public void Delete(object primaryKey)
        {
            try
            {
                var request = new RestRequest(_controllerUrl, Method.DELETE) { RequestFormat = DataFormat.Json };
                request.AddBody(primaryKey);

                var response = _client.Execute<T>(request);

                if (response.StatusCode != HttpStatusCode.OK)
                    throw new Exception(response.ErrorMessage);
            }
            catch (Exception)
            {
                throw new JkcsException { ExcpetionTime = DateTime.Now, ExcpetionMessage = "Insert - " + _controllerUrl };
            }
        }

        //DbRawSqlQuery<TEntity> SQLQuery<TEntity>(string sql, params object[] parameters);
    }
}
