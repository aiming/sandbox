using System.Windows.Input;

namespace ExampleLauncher;

public class StartDownloadCommand : ICommand
{
    public event EventHandler? CanExecuteChanged;

    private Uri Uri { get; }
    private DownloaderViewModel DownloaderViewModel { get; }

    public StartDownloadCommand(Uri uri, DownloaderViewModel downloaderViewModel)
    {
        Uri = uri;
        DownloaderViewModel = downloaderViewModel;
    }

    public bool CanExecute(object? parameter) => true;

    public void Execute(object? parameter)
    {
        ApplicationContext.Instance.JobRunner.EnqueueJob(new DownloadJob(Uri, DownloaderViewModel));
    }
}
