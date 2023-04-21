using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;

namespace EmployeeDetails.BusinessLogic
{
    public static class WebAPI
    {
        private static readonly string baseURL = "https://gorest.co.in/public-api/users";
        public const string accessToken = "fa114107311259f5f33e70a5d85de34a2499b4401da069af0b1d835cd5ec0d56";

        public static async Task<string> GetAllEmployeeDetails(string page)
        {
            string details = string.Empty;
            try
            {
                if (string.IsNullOrEmpty(page))
                {
                    page = "1";
                }
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);
                    using (HttpResponseMessage res = await client.GetAsync(baseURL + "?page=" + page))
                    {
                        details = await GetContentResultInString(res);
                    }
                }
            }
            catch(Exception e)
            {
                File.AppendAllText("error.log", e.ToString());
                AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(GlobalExceptionhandler.UnhandledException);
            }
            return details;
        }

        public static async Task<string> GetSpecificEmployeeDetails(string first_Name, string id)
        {
            string input = string.Empty, details = string.Empty;
            try
            {               
                if (!string.IsNullOrEmpty(first_Name))
                {
                    input = "?name=" + first_Name;
                }
                else if (!string.IsNullOrEmpty(id))
                {
                    input = "/" + id;
                }
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);
                    using (HttpResponseMessage res = await client.GetAsync(baseURL + input))
                    {
                        details = await GetContentResultInString(res);
                    }
                }
            }
            catch (Exception e)
            {
                File.AppendAllText("error.log", e.ToString());
                AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(GlobalExceptionhandler.UnhandledException);
            }
            return details;
        }

        public static async Task<string> InsertEmployeeDetails(string name, string email, string gender, string status)
        {
            string insertEmployee = string.Empty;
            try
            {
                var request = new Dictionary<string, string>
                {
                    {"name", name },
                    {"email",email },
                    {"gender",gender },
                    {"status",status }
                };
                var reqData = new FormUrlEncodedContent(request);
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);
                    using (HttpResponseMessage res = await client.PostAsync(baseURL + "/", reqData))
                    {
                        insertEmployee = await GetContentResultInString(res);
                    }
                }
            }
            catch (Exception e)
            {
                File.AppendAllText("error.log", e.ToString());
                AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(GlobalExceptionhandler.UnhandledException);
            }
            return insertEmployee;
        }

        public static async Task<string> UpdateEmployeeDetails(string id, string name, string email, string gender, string status)
        {
            string updateEmployee = string.Empty;
            try
            {
                var request = new Dictionary<string, string>
                {
                    {"name", name },
                    {"email",email },
                    {"gender",gender },
                    {"status",status }
                };
                var reqData = new FormUrlEncodedContent(request);
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);
                    using (HttpResponseMessage res = await client.PutAsync(baseURL + "/" + id, reqData))
                    {
                        updateEmployee = await GetContentResultInString(res);
                    }
                }
            }
            catch (Exception e)
            {
                File.AppendAllText("error.log", e.ToString());
                AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(GlobalExceptionhandler.UnhandledException);
            }
            return updateEmployee;
        }

        public static async Task<string> DeleteEmployeeDetails(string id)
        { 
            string deleteEmployee = string.Empty;
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);
                    using (HttpResponseMessage res = await client.DeleteAsync(baseURL + "/" + id))
                    {
                        MessageBox.Show("Employee Details deleted for employee id : " + id);
                        deleteEmployee = await GetContentResultInString(res);
                    }
                }
            }
            catch (Exception e)
            {
                File.AppendAllText("error.log", e.ToString());
                AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(GlobalExceptionhandler.UnhandledException);
            }
            return deleteEmployee;
        }


        public static string ConvertToJSONFormat(string response)
        {
                JToken parseJson = JToken.Parse(response);
                return parseJson.ToString(Formatting.Indented);
        }


        private static async Task<string> GetContentResultInString(HttpResponseMessage res)
        {
            string details = string.Empty;
            HttpContent content = res.Content;
            details = await content.ReadAsStringAsync();
            if (details != null)
            {
                return details;
            }
            else
            {
                return string.Empty;
            }
        }
    }

}
