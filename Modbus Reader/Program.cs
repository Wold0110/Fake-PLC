namespace Modbus_Reader
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            Control.CheckForIllegalCrossThreadCalls = false;
            string file = "";
            string[] args = Environment.GetCommandLineArgs();
            foreach (var x in args)
                if (x.Contains(".wsbs"))
                    file = x;
            ApplicationConfiguration.Initialize();
            if (file == "")
                Application.Run(new MainForm());
            else
                Application.Run(new MainForm(file));
        }
    }
}