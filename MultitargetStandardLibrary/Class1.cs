using System;
#if NET40
using System.Net;
using System.Text;
using System.Web.Script.Serialization;
#else
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
#endif
namespace MultitargetStandardLibrary
{
    public class DemoClass
    {

#if NET40
private readonly WebClient _client = new WebClient();
#else
        private readonly HttpClient _client = new HttpClient();
#endif

#if NET40
// .NET Framework 4.0 does not have async/await
public static Employee GetEmployee(string employeeID)
{
          Employee emp = null;
        try{
          string apiUrl = "http://dummy.restapiexample.com/api/v1";
          WebClient client = new WebClient();
          client.Headers["Content-type"] = "application/json";
          client.Encoding = Encoding.UTF8;
          string json = client.DownloadString(apiUrl + "/employee/"+employeeID);
          emp=  (new JavaScriptSerializer()).Deserialize<Employee>(json);
        }catch(Exception ex){
        }
        return emp;
}
#else
        // .NET 4.5+ can use async/await!
        public static async Task<Employee> GetEmployeeAsync(string employeeID)
        {
            Employee emp = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://dummy.restapiexample.com/api/v1");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //GET Method  
                HttpResponseMessage response = await client.GetAsync("/employee/" + employeeID);
                if (response.IsSuccessStatusCode)
                {
                    emp = JsonConvert.DeserializeObject<Employee>(response.Content.ReadAsStringAsync().Result);
                }

            }
            return emp;
        }
#endif
    }

    public class Employee
    {
        public string id { get; set; }
        public string employee_name { get; set; }
        public string employee_salary { get; set; }
        public string employee_age { get; set; }
        public string profile_image { get; set; }
    }
}
