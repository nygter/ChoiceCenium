using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using ChoiceCenium.Hubs;
using ChoiceCenium.Services;

namespace ChoiceCenium
{
    public class WebJobController : ApiController
    {
        // GET api/<controller>
        
        public OkResult Get()
        {
            HotelService.CheckHotelsAsCompletedByUpgradeDate();
            var hub = new HotelInfoHub();
            hub.SendUpdateToClients();

            return Ok();
        }


        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}