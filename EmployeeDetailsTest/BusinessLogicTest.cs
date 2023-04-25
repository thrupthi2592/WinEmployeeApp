using EmployeeDetails;
using EmployeeDetails.BusinessLogic;
using System.Net.Http;
using NUnit.Framework.Constraints;
using EmployeeDetails.Common;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Xml.Linq;

namespace BusinessLogicTest
{
    
    public class Tests
    {
        private WebAPIEmployeeInfo webAPI { get; set; } = null!;
        private string actual = null!;

         [SetUp]
        public void  setup()
        {
            if (webAPI == null)
            {
                webAPI = new WebAPIEmployeeInfo();
            }
        }


        [TestCase("Thrupthi", "thrupthi@test.com", "female", "active","Success")]
        [TestCase("", "thrupthi@t.c", "female", "active", "Input Missing")]
        [TestCase("Sujith", "Sujith@test.com", "male", "active", "Success")]
        [TestCase("thrupthi", "thrupthi", "female", "active", "Invalid Email")]
        public async Task InsertEmployeeDetails_Tests(string name, string email, string gender, string status, string expected)
        {
            var actual = await webAPI.InsertEmployeeDetails(name,email,gender,status,"string");
            Console.WriteLine(actual);
            Assert.That(expected, Is.EqualTo(actual));
        }

        [TestCase("628691", "Dr. Aayushman Nayar", "aayushman_dr_nayar@upton.name", "female", "inactive", "Success")]
        [TestCase("", "Dr. Aayushman Nayar", "aayushman_dr_nayar@upton.name", "female", "inactive", "ID value is mandatory")]
        [TestCase("628691","Dr. Aayushman Nayar", "aayushman_dr_nayar@upton.name", "female", "", "Success")]
        [TestCase("628691", "Dr. Aayushman Nayar", "aayushman_dr_nayar", "female", "inactive", "Invalid Email")]
        public async Task UpdateEmployeeDetails_Tests(string id,string name, string email, string gender, string status, string expected)
        {
            var actual = await webAPI.UpdateEmployeeDetails(id,name, email, gender, status, "string");
            Console.WriteLine(actual);
            Assert.That(expected, Is.EqualTo(actual));
        }

        [TestCase("1203767", "Success")]
        [TestCase("",  "ID value is mandatory")]
        [TestCase("1203767.99", "Enter a integer value")]
        public async Task DeleteEmployeeDetails_Tests(string id, string expected)
        {
            var actual = await webAPI.DeleteEmployeeDetails(id, "string");
            Console.WriteLine(actual);
            Assert.That(expected, Is.EqualTo(actual));
        }
    }


}