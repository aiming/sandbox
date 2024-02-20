using System.ComponentModel;
using System.Windows;

namespace ExampleLauncher;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private CancellationTokenSource cts = new();

    public MainWindow()
    {
        InitializeComponent();

        ContentFrame.Source = new Uri("MainMenu/View/MainMenu.xaml", UriKind.Relative);

        // // set binding value
        // DataContext = new
        // {
        //     X = "Hello WPF !!",
        //     Y = Environment.CurrentDirectory,
        // };
        //

        DummyTask();
    }

    protected override void OnClosing(CancelEventArgs e)
    {
        base.OnClosing(e);
        cts.Cancel();
        cts.Dispose();
    }

    private async void DummyTask()
    {
        // while (!cts.IsCancellationRequested)
        // {
        //     DownloadProgressBar.Value = Lerp(
        //         DownloadProgressBar.Value,
        //         progressValue,
        //         0.1);
        //     await Task.Delay(16);
        // }
    }

    private double Lerp(double from, double to, double t)
    {
        return t * to + (1 - t) * from;
    }

    private void Exit(object sender, RoutedEventArgs e)
    {
        Close();
    }
}
