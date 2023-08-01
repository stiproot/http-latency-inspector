namespace HttpLatencyInspector.Dependencies;

public class Timer
{
    private DateTime _started;
    private DateTime _stopped;

    public Timer Start()
    {
        this._started = DateTime.UtcNow;
        return this;
    }

    public Timer Stop()
    {
        this._stopped = DateTime.UtcNow;
        return this;
    }

    public TimeSpan Diff() => this._stopped - this._started;

    public int DiffAsMilliseconds() => this.Diff().Milliseconds;
}