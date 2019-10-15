using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace Logger.Tests
{
    [TestClass]
    public class LogFactoryTests
    {
        
        [TestMethod]
        public void Not_Configured_Return_Null()
        {
            //arrange
            LogFactory factory = new LogFactory();

            //act
            var logger = factory.CreateLogger(this.GetType().Name);

            //assert
            Assert.IsNull(logger);
        }

        [TestMethod]
        public void Configured_Return_Correct_Logger()
        {
            string testFilePath = Path.GetRandomFileName();

            try
            {
                //arrange
                LogFactory factory = new LogFactory();
                factory.ConfigureFileLogger(testFilePath);

                //act
                var logger = factory.CreateLogger(this.GetType().Name);

                //assert
                Assert.IsNotNull(logger);
                Assert.AreEqual(this.GetType().Name, logger.ClassName);

            } finally
            {
                File.Delete(testFilePath);
            }
        }
    }
}
