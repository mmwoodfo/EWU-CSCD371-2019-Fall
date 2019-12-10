namespace Logger
{
    public class LogFactory
    {
        private string _FilePath;

        public BaseLogger CreateLogger(string className)
        {
            if(_FilePath is null)
            {
                return null;
            }
            else
            {
                BaseLogger baseLogger = new FileLogger(_FilePath)
                {
                    ClassName = className
                };
                return baseLogger;
            }
            
        }

        public void ConfigureFileLogger(string filePath)
        {
            this._FilePath = filePath;
        }
    }
}
