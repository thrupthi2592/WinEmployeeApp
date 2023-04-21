namespace EmployeeDetails.BusinessLogic
{
    public class GlobalExceptionhandler
    {
        public static void UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            File.AppendAllText("error.log", e.ExceptionObject.ToString());

            MessageBox.Show("An erroe has occured.Please try again later");
        }
    }
}