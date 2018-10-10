using Athenahealth;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Json;
using Xunit;

namespace XUnitTestProject1
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            string key = "3ygfkfhhqsbpyz9kbvwkan2h";
            string secret = "nebVUnPqvVbju68";
            string version = "preview1";
            string practiceid = "195900";
            APIConnection api = new APIConnection(version, key, secret, practiceid);
            Dictionary<string, string> search = new Dictionary<string, string>()
            {

                {"departmentid" ,"1" },
                {"appointmentdate" ,"11/01/2018"},
                {"appointmenttime" ,"15:00"},
                {"appointmenttypeid" ,"2"},

                {"providerid" ,"1"}

            };
            JsonValue result = api.POST("/appointments/open", search);

            JObject json = JObject.Parse(result.ToString());

            Assert.NotNull(json["appointmentids"]);
        }
    }
}
