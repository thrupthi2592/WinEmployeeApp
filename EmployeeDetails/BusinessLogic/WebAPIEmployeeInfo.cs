using EmployeeDetails.Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Configuration;
using System.Net.Http.Headers;
using System.Text.RegularExpressions;

namespace EmployeeDetails.BusinessLogic
{

    public class WebAPIEmployeeInfo
    {
        private static readonly string baseURL = "https://gorest.co.in/public-api/users";
        private static readonly string accessToken = Convert.ToString(ConfigurationManager.AppSettings["AccessToken"]);


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


        public async Task<string> InsertEmployeeDetails(string name, string email, string gender, string status,string type)
        {
            string insertEmployee = string.Empty;
            try
            {
                insertEmployee = validateInputs("",name, email, gender, status, "");
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
                        if (type.Equals("json"))
                        {
                            insertEmployee = await GetContentResultInString(res);
                        }
                        else
                        {
                            insertEmployee =  "Success";
                        }
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

        public async Task<string> UpdateEmployeeDetails(string id, string name, string email, string gender, string status, string type)
        {
            string updateEmployee = string.Empty;
            try
            {
                updateEmployee = validateInputs(id, name, email, gender, status, "Update");
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
                        if (type.Equals("json"))
                        {
                            updateEmployee = await GetContentResultInString(res);
                        }
                        else
                        {
                            updateEmployee = "Success";
                        }
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

        public async Task<string> DeleteEmployeeDetails(string id,string type)
        { 
            string deleteEmployee = string.Empty;
            try
            {
                deleteEmployee = validateInputs(id,"","","","","Delete");
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);
                    using (HttpResponseMessage res = await client.DeleteAsync(baseURL + "/" + id))
                    {
                        if (type.Equals("json"))
                        {
                            MessageBox.Show("Employee Details deleted for employee id : " + id);
                            deleteEmployee = await GetContentResultInString(res);
                        }
                        else
                        {
                            deleteEmployee = "Success";
                        }
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
            try
            {
                JToken parseJson = JToken.Parse(response);
                return parseJson.ToString(Formatting.Indented);
            }
            catch (Exception e)
            {
                return response;
            }
                
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

        public string validateInputs(string id, string name, string email, string gender, string status, string type)
        {
            string validate = string.Empty;
            string allowedChar = "^(.+)@(.+)$";
            try
            {
                if (!type.Equals("Update") || !type.Equals("Delete"))
                {
                    if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(gender) || string.IsNullOrEmpty(status))
                    {
                        validate = "Input Missing";
                    }
                }
                if (!string.IsNullOrEmpty(email) && !Regex.IsMatch(email, allowedChar))
                {
                    validate = "Invalid Email";
                }
                if (type.Equals("Update") || type.Equals("Delete"))
                {
                    if (string.IsNullOrEmpty(id))
                    {
                        validate = "ID value is mandatory";
                    }
                    else if (id.GetType() == typeof(int))
                    {
                        validate = "Enter a integer value";
                    }
                }
            }
            catch (Exception e)
            {
                File.AppendAllText("error.log", e.ToString());
                AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(GlobalExceptionhandler.UnhandledException);
            }
            return validate;
        }

    }

}
