using System.Windows;
using System.Windows.Controls;

namespace ExampleLauncher;

public partial class MainMenu : Page
{
    public DownloadIndicator Page { get; set; }

    public MainMenu()
    {
        InitializeComponent();
        DataContext = ApplicationContext.Instance.DownloaderViewModel;
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        var downloadJob = new DownloadJob(
            new Uri("http://example.com/"),
            ApplicationContext.Instance.DownloaderViewModel);
        ApplicationContext.Instance.JobRunner.EnqueueJob(downloadJob, JobFrame);
    }

    private void Button_Click2(object sender, RoutedEventArgs e)
    {
        JobFrame.Navigate(null);
    }

    private void Exit(object sender, RoutedEventArgs e)
    {
        if (Application.Current.MainWindow != null)
            Application.Current.MainWindow.Close();
    }
}
