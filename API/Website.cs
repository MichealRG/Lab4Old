using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace API
{
    class Website
    {
        public Website(string link)
        {
            _linkToWeb = new RestClient(link);
        }
        public string Download(string path)
        {
            var request = new RestRequest(path, Method.GET);
            var response = _linkToWeb.Execute(request);
            return response.Content;
        }
        public Task<IRestResponse> DownloadAsync(string path)
        {
            var request = new RestRequest(path, Method.GET);
            var response = _linkToWeb.ExecuteAsync(request);
            return response;
        }
        public RestClient _linkToWeb { get; set; }
    }
}
