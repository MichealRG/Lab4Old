using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace API
{
    class FileDownloadingController:ApiController
    {
        [HttpGet]
        [Route("api/FileDownloading/download")]
        public HttpResponseMessage GetDate()
        {
            var result = new HttpResponseMessage(HttpStatusCode.OK);

            //getfilebytes


            return result;
        }
    }
}
