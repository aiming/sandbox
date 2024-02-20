using System.Windows.Controls;

namespace ExampleLauncher;

public class JobRunner
{
    // ジョブの状態を表示するための Frame
    private Frame? TargetView { get; set; }

    private Queue<ILauncherJob> JobQueue { get; } = new();

    public void EnqueueJob(ILauncherJob job, Frame? jobFrame = null)
    {
        TargetView = jobFrame;
        JobQueue.Enqueue(job);
    }

    public async Task NextAsync(CancellationToken ct)
    {
        if (!JobQueue.Any()) return;

        var job = JobQueue.Dequeue();

        if (TargetView is not null && !string.IsNullOrEmpty(job.RelatedViewUri))
        {
            var uri = new Uri(job.RelatedViewUri, UriKind.Relative);
            TargetView.Navigate(uri);
        }

        await job.Run(ct);

        if (TargetView is not null && !string.IsNullOrEmpty(job.RelatedViewUri))
        {
            TargetView.Navigate(null);
        }
    }
}
