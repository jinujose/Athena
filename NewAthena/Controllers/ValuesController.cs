using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Json;
using Athenahealth;

namespace NewAthena.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        // GET api/values
        [HttpGet]
        public JsonValue Get()
        {
            string key = "3ygfkfhhqsbpyz9kbvwkan2h";
            string secret = "nebVUnPqvVbju68";
            string version = "preview1";
            string practiceid = "195900";
            APIConnection api = new APIConnection(version, key, secret, practiceid);
            string format = "MM/dd/yyyy";
            DateTime today = DateTime.Now;
            DateTime nextyear = today.AddYears(1);
            //  Dictionary<string, string> search = new Dictionary<string, string>()
            //{
            //  {"departmentid", "1"},
            //  {"ignoreschedulablepermission", "true"},

            //  {"appointmenttypeid", "2"},

            //};

            //  JsonValue result = api.GET("/appointments/open", search);

            //Dictionary<string, string> search = new Dictionary<string, string>()
            //{
            //  {"name", "pet"},
            //  {"zip", "35801"}

            //};

            //JsonValue result = api.GET("/clinicalproviders/search", search);
            //return Convert.ToString(result);
            Dictionary<string, string> search = new Dictionary<string, string>()
            {

                {"departmentid" ,"1" },
                {"appointmentdate" ,"11/01/2018"},
                {"appointmenttime" ,"15:00"},
                {"appointmenttypeid" ,"2"},

                {"providerid" ,"1"}

            };
            JsonValue result = api.POST("/appointments/open", search);
            return result;

        }

        // GET api/values/5
        [HttpGet("{id}")]
        public JsonValue Get(int id)
        {
            string key = "3ygfkfhhqsbpyz9kbvwkan2h";
            string secret = "nebVUnPqvVbju68";
            string version = "preview1";
            string practiceid = "195900";
            APIConnection api = new APIConnection(version, key, secret, practiceid);
            //Dictionary<string, string> search = new Dictionary<string, string>()
            //{
            //  {"appointmentid", "1020835"},
            //    {"practiceid" ,"195900" },
            //    {"ignorerestrictions" ,"true" },
            //    {"showclaimdetail" ,"true" },
            //    {"showcopay" ,"true" },
            //    {"showexpectedprocedurecodes	" ,"true" },
            //    {"showinsurance" ,"true" },
            //    {"showpatientdetail" ,"true" }

            //};
            Dictionary<string, string> search = new Dictionary<string, string>()
            {

                {"departmentid" ,"1" },
                {"ignoreschedulablepermission" ,"true"}

            };
            JsonValue result = api.GET("/appointments/open", search);
            return result;
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
