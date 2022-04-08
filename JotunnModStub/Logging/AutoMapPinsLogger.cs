using System;

namespace AutoMapPins.Log
{
    public class AutoMapPinsLogger
    {
        private static readonly string DEBUG_PREFIX_FORMAT = "BMP-Debug[{0}]: {1}";
        private static readonly string ERROR_PREFIX_FORMAT = "BMP-Error[{0}]: {1}";

        public static void Debug(string message)
        {
            Log(UnityEngine.Debug.Log, message, DEBUG_PREFIX_FORMAT);
        }

        public static void Error(string message)
        {
            Log(UnityEngine.Debug.LogError, message, ERROR_PREFIX_FORMAT);
        }

        private static void Log(Action<object> loggerMethod, string message, string format)
        {
            string dateString = DateTime.Now.ToString("HH:mm:ss:fff");
            string formattedMessage = string.Format(format, dateString, message);
            loggerMethod(formattedMessage);
        }
    }
}
