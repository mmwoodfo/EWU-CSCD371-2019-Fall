using System;

namespace Logger
{
    public static class BaseLoggerMixins
    {
        public static void Error(string message, params string[] args)
        {
            if(message is null)
            {
                throw new ArgumentNullException(nameof(message));
            }
            else
            {
                
            }
        }

        public static void Warning(string message, params string[] args)
        {
            if (message is null)
            {
                throw new ArgumentNullException(nameof(message));
            }
            else
            {

            }
        }

        public static void Information(string message, params string[] args)
        {
            if (message is null)
            {
                throw new ArgumentNullException(nameof(message));
            }
            else
            {

            }
        }

        public static void Debug(string message, params string[] args)
        {
            if (message is null)
            {
                throw new ArgumentNullException(nameof(message));
            }
            else
            {

            }
        }
    }
}
