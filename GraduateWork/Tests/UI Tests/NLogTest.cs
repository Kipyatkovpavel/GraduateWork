using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateWork.Tests
{
    [TestFixture]
    public class NLogTest
    {
        protected static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();
        [Test]
        public void LevelsTest()
        {
            Logger.Log(LogLevel.Info,"This is an informational message...");

            Logger.Trace("Trace level...");
            Logger.Debug("Debug level...");
            Logger.Info("Info level...");
            Logger.Warn("Warn level...");
            Logger.Error("Error level...");
            Logger.Fatal("Fatal level...");
        }
        [Test]
        public void ExceptionLogTest()
        {
            try
            {
                throw new AssertionException("Какая-то ошибка..");
            }
            catch (Exception e)
            {
                Logger.Error(e, "Логируем ошибку...");
            }
        }
    }
}
