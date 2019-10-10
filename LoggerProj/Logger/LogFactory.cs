namespace Logger
{
    public class LogFactory
    {
        private string filePath;

        public BaseLogger CreateLogger(string className)
        {
            if(filePath is null)
            {
                return null;
            }
            else
            {
                BaseLogger baseLogger = new FileLogger(filePath)
                {
                    ClassName = className
                };
                return baseLogger;
            }
            
        }

        public void ConfigureFileLogger(string filePath)
        {
            this.filePath = filePath;
        }
    }
}
