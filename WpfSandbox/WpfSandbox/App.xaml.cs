using System.Configuration;
using System.Data;
using System.Windows;
using WpfApp.Libs;

namespace ExampleLauncher;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    private ApplicationProcess process = new();

    public App()
    {
    }
}
