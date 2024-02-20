using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ExampleLauncher;

public class DownloaderViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;
    public StartDownloadCommand StartDownloadCommand { get; set; }

    public DownloaderViewModel()
    {
        StartDownloadCommand = new StartDownloadCommand(
            new Uri("http://example.com/"), this);
    }

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    protected bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value)) return false;
        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }

    public void Progress(long receivedSize, long totalSize)
    {
        ReceivedSize = receivedSize;
        TotalSize = totalSize;
        Progression = (double)receivedSize / totalSize * 100;
    }

    private long _receivedSize;
    public long ReceivedSize
    {
        get => _receivedSize;
        set
        {
            SetField(ref _receivedSize, value);
            Progression = (double)ReceivedSize / TotalSize * 100;
        }
    }

    private long _totalSize;
    public long TotalSize
    {
        get => _totalSize;
        set
        {
            SetField(ref _totalSize, value);
            Progression = (double)ReceivedSize / TotalSize * 100;
        }
    }

    private double _progression;
    public double Progression
    {
        get => _progression;
        set => SetField(ref _progression, value);
    }

    private TimeSpan _elapsedTime;
    public TimeSpan ElapsedTime
    {
        get => _elapsedTime;
        set => SetField(ref _elapsedTime, value);
    }


    private Uri _uri;
    public Uri Uri
    {
        get => _uri;
        set => SetField(ref _uri, value);
    }
}
