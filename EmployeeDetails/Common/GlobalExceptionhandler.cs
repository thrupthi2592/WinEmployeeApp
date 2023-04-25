namespace EmployeeDetails.Common
{
    public class GlobalExceptionhandler
    {
        public static void UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            File.AppendAllText("error.log", e.ExceptionObject.ToString());

            MessageBox.Show("An error has occured.Please try again later");
        }
    }
}