
using System;
using log4net;
using log4net.Appender;
using log4net.Config;
using log4net.Core;
using log4net.Layout;
using LogManager = log4net.LogManager;

namespace TravelAgencyApp.Ultils
{
    public class Log4Net
    {
        #region Field

        private static ILog _logger;
        private static ILog _xmlLogger;
        private static ConsoleAppender _consoleAppender;
        private static FileAppender _fileAppender;
        private static RollingFileAppender _rollingFileAppender;
        private static string _layout = "%date{dd-MMM-yyyy-HH:mm:ss} [%class] [%level] [%method] - %message%newline";
        #endregion

        #region Property
        public static string Layout { set { _layout = value; }  }
        #endregion

        #region Private

        private static PatternLayout GetPatternLayout()
        {
            var patternLayout = new PatternLayout()
            {
                ConversionPattern = _layout,
            };
            patternLayout.ActivateOptions();
            return patternLayout;
        }
        private static ConsoleAppender GetConsoleAppender()
        {
            var consoleAppender = new ConsoleAppender()
            {
                Name = "Console Appender",
                Layout = GetPatternLayout(),
                Threshold = Level.All
            };
            consoleAppender.ActivateOptions();
            return consoleAppender;
        }
        private static FileAppender GetFileAppender()
        {
            var fileAppender = new FileAppender()
            {
                Name = "File Appender",
                Layout = GetPatternLayout(),
                Threshold = Level.All,
                AppendToFile = true,
                File = "FileLogger.log"
            };
            fileAppender.ActivateOptions();
            return fileAppender;
        }
        private static RollingFileAppender GetRollingFileAppender()
        {
            var rollingFileAppender = new RollingFileAppender()
            {
                Name = "Rolling File Appender",
                Layout = GetPatternLayout(),
                Threshold = Level.All,
                AppendToFile = true,
                File = @"Logs\RollingFile.log",
                MaximumFileSize = "5MB",
                MaxSizeRollBackups = 15
            };
            rollingFileAppender.ActivateOptions();
            return rollingFileAppender;
        }
        #endregion

        #region Public
        public static ILog GetLogger(Type type)
        {
            if (_consoleAppender == null)
            {
                _consoleAppender = GetConsoleAppender();
            }
            if (_fileAppender == null)
            {
                _fileAppender = GetFileAppender();
            }
            if (_rollingFileAppender == null)
            {
                _rollingFileAppender = GetRollingFileAppender();
            }
            if (_logger != null)
            {
                return _logger;
            }
            //add _fileAppender 
            BasicConfigurator.Configure(_consoleAppender, _rollingFileAppender);
            _logger = LogManager.GetLogger(type);
            return _logger;
        }

        public static ILog GetXmlLogger(Type type)
        {
            if (_xmlLogger != null)
            {
                return _xmlLogger;
            }
            XmlConfigurator.Configure();
            _xmlLogger = LogManager.GetLogger(type);
            return _xmlLogger;
        }
        #endregion
    }
}
