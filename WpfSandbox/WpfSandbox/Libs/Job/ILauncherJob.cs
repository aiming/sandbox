namespace ExampleLauncher;

public interface ILauncherJob
{
    string RelatedViewUri { get; }
    Task Run(CancellationToken ct);
}
