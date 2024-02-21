using System.Diagnostics;
using System.IO;
using System.Windows;

namespace WpfApp.Libs
{
    internal class ApplicationProcess
    {
        public ApplicationProcess()
        {
            if (IsOtherClientRunning())
            {
                MessageBox.Show("他のクライアントが起動しています。");
                Application.Current.Shutdown();
            }
        }

        private bool IsOtherClientRunning()
        {
            // get application executable path
            var path = System.Reflection.Assembly.GetExecutingAssembly().Location;

            var p = Process.GetProcessesByName(Path.GetFileNameWithoutExtension(path));
            return p.Length > 1;
        }
    }
}
