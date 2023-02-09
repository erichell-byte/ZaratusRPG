namespace Game.App.Loggers
{
    public interface IAnalyticsLogger
    {
        void LogEvent(string eventName, params AnalyticsParameter[] parameters);
    }
}