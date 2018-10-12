namespace Task_3
{
    using log4net;
    using log4net.Config;

    public static class Logger
    {
        public static ILog Log { get; } = LogManager.GetLogger("LOGGER");

        public static void InitLogger() => XmlConfigurator.Configure();
    }
}
