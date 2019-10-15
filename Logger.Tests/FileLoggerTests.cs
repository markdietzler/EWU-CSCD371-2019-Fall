using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;

namespace Logger.Tests
{
    [TestClass]
    public class FileLoggerTests
    {

        [TestMethod]
        public void Logfile_Output_To_File_With_Error()
        {
            string testFilePath = Path.GetRandomFileName();

            try
            {
                string[] nullSpace = new string[] { "" };
                File.AppendAllLines(testFilePath, nullSpace);

                FileLogger newFileLogger = new FileLogger(testFilePath) { 
                    ClassName = this.GetType().Name
                };
                newFileLogger.Error("{0}", "Inconceivable!");
                //List<string> parsedFile = new List<string>(); //simpler to just use a string array

                string[] arrayOfTextFromFile = File.ReadAllLines(testFilePath);
                string output = arrayOfTextFromFile[arrayOfTextFromFile.Length - 1];
                                
                Assert.AreEqual(DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss tt") + " " + newFileLogger.ClassName + " Error: Inconceivable!", output);
            }
            finally
            {
                File.Delete(testFilePath);
            }
        }
    }
}