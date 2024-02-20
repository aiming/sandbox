namespace ExampleLauncher;

public partial class DownloadIndicator
{
    public DownloadIndicator()
    {
        InitializeComponent();
        DataContext = ApplicationContext.Instance.DownloaderViewModel;
        ApplicationContext.Instance.DownloaderViewModel.Progression = 0.4;
    }
}
