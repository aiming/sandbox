using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Security.Principal;
using System.Windows;

namespace WpfApp.Libs
{
    public class ApplicationProcess
    {
        private static Process CurrentProcess => Process.GetCurrentProcess();
        private static Assembly ExecutingAssembly => Assembly.GetExecutingAssembly();
        private static string ExecutableLocation => CurrentProcess.MainModule.FileName;

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
            var p = Process.GetProcessesByName(Path.GetFileNameWithoutExtension(ExecutableLocation));
            return p.Length > 1;
        }

        public bool IsAdministrator()
        {
            var identity = WindowsIdentity.GetCurrent();
            var principal = new WindowsPrincipal(identity);
            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }

        public void RebootAsAdministrator()
        {
            var psi = new ProcessStartInfo
            {
                UseShellExecute = true,
                FileName = ExecutableLocation,
                Verb = "runas",
                Arguments = "-reboot",
            };

            try
            {
                Process.Start(psi);
                if (Application.Current.MainWindow != null)
                    Application.Current.MainWindow.Close();
            }
            catch (System.ComponentModel.Win32Exception e)
            {
                Console.Error.WriteLine(e);
            }
        }

        public void RebootAsUser()
        {
            Process.Start("explorer.exe", ExecutableLocation);
            if (Application.Current.MainWindow != null)
                Application.Current.MainWindow.Close();
        }
    }
}
