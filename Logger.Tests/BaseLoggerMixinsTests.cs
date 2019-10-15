using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Logger.Tests
{
    [TestClass]
    public class BaseLoggerMixinsTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Error_WithNullLogger_ThrowsException()
        {            
            BaseLoggerMixins.Error(null, "");
            //testing for exception only, no assert needed
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Warning_WithNullLogger_ThrowsException()
        {
            BaseLoggerMixins.Warning(null, "");
            //testing for exception only, no assert needed
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Information_WithNullLogger_ThrowsException()
        {
            BaseLoggerMixins.Information(null, "");
            //testing for exception only, no assert needed
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Debug_WithNullLogger_ThrowsException()
        {
            BaseLoggerMixins.Debug(null, "");
            //testing for exception only, no assert needed
        }

        [TestMethod]
        public void Error_WithGoodLogger_LogsMessage()
        {
            // Arrange
            var logger = new TestLogger();

            // Act
            logger.Error("Message {0}", 99);

            // Assert
            Assert.AreEqual(1, logger.LoggedMessages.Count);
            Assert.AreEqual(LogLevel.Error, logger.LoggedMessages[0].LogLevel);
            Assert.AreEqual("Message 99", logger.LoggedMessages[0].Message);
        }

        [TestMethod]
        public void Warning_WithGoodLogger_LogMessage()
        {
            var logger = new TestLogger();

            logger.Warning("Message {0}", 98);

            Assert.AreEqual(1, logger.LoggedMessages.Count);
            Assert.AreEqual(LogLevel.Warning, logger.LoggedMessages[0].LogLevel);
            Assert.AreEqual("Message 98", logger.LoggedMessages[0].Message);
        }

        [TestMethod]
        public void Information_WithGoodLogger_LogMessage()
        {
            var logger = new TestLogger();

            logger.Information("Message {0}", 97);

            Assert.AreEqual(1, logger.LoggedMessages.Count);
            Assert.AreEqual(LogLevel.Information, logger.LoggedMessages[0].LogLevel);
            Assert.AreEqual("Message 97", logger.LoggedMessages[0].Message);
        }

        [TestMethod]
        public void Debug_WithGoodLogger_LogMessage()
        {
            var logger = new TestLogger();

            logger.Debug("Message {0}", 96);

            Assert.AreEqual(1, logger.LoggedMessages.Count);
            Assert.AreEqual(LogLevel.Debug, logger.LoggedMessages[0].LogLevel);
            Assert.AreEqual("Message 96", logger.LoggedMessages[0].Message);
        }

    }

    public class TestLogger : BaseLogger
    {
        public List<(LogLevel LogLevel, string Message)> LoggedMessages { get; } = new List<(LogLevel, string)>();

        public override void Log(LogLevel logLevel, string message)
        {
            LoggedMessages.Add((logLevel, message));
        }
    }
}
