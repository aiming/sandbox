using System.Diagnostics;

namespace ExampleLauncher;

public class DownloadJob : ILauncherJob
{
    public Uri Uri { get; set; }
    private DownloaderViewModel DownloaderViewModel { get; set; }

    public string RelatedViewUri => "DownloadJob/View/DownloadIndicator.xaml";

    public DownloadJob(Uri uri, DownloaderViewModel downloaderViewModel)
    {
        Uri = uri;
        DownloaderViewModel = downloaderViewModel;
    }

    public async Task Run(CancellationToken ct)
    {
        var downloaded = 0l;
        var bandwidth = 1l;
        var rnd = new Random();
        var sw = Stopwatch.StartNew();
        int total = rnd.Next(1000000, 10000000);
        var elapsedTick = 0l;

        DownloaderViewModel.Uri = new Uri($"http://example.com/file{rnd.Next()}.zip");

        while (downloaded < total)
        {
            DownloaderViewModel.Progress(downloaded, total);
            var nextElapsedTick = sw.ElapsedTicks;
            var d = nextElapsedTick - elapsedTick;
            elapsedTick = nextElapsedTick;
            DownloaderViewModel.ElapsedTime = sw.Elapsed;
            await Task.Delay(1, ct);
            bandwidth = Math.Clamp(bandwidth + rnd.Next(-100, 100), 0, 10000);
            downloaded += (d * bandwidth) / 100;
        }
    }
}
