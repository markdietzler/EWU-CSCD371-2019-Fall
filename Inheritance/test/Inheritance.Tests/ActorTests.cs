using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace Inheritance.Tests
{
    [TestClass]
    public class ActorTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NullActorAndTextWriter_ThrowsException()
        {
            // Arrange

            // Act
            ActorExtension.Speak(null, null);

            // Assert
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NullActor_ThrowsException()
        {
            // Arrange
            using (var memoryStream = new MemoryStream())
            {
                using (var writer = new StreamWriter(memoryStream))
                {
                    //Act
                    ActorExtension.Speak(null, writer);

                    // Assert
                }
            }
                        
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NullTextWriter_ThrowsException()
        {
            // Arrange
            Actor penny = new Penny();

            // Act
            ActorExtension.Speak(penny, null);

            // Assert
        }

        [TestMethod]
        public void Penny_Speak()
        {
            // Arrange
            using (var memoryStream = new MemoryStream())
            {
                using (var writer = new StreamWriter(memoryStream))
                {
                    // Act
                    Actor penny = new Penny();
                    penny.Speak(writer);
                    writer.Flush();

                    memoryStream.Position = 0;
                    memoryStream.Seek(0, SeekOrigin.Begin);

                    // Assert
                    using (var reader = new StreamReader(memoryStream))
                    {
                        var lineWritten = reader.ReadLine();
                        Assert.AreEqual("Hi, I'm Penny!", lineWritten);
                    }
                }
            }
        }

        [TestMethod]
        public void Sheldon_Speak()
        {
            // Arrange
            using (var memoryStream = new MemoryStream())
            {
                using (var writer = new StreamWriter(memoryStream))
                {
                    // Act
                    Actor sheldon = new Sheldon();
                    sheldon.Speak(writer);
                    writer.Flush();

                    memoryStream.Position = 0;
                    memoryStream.Seek(0, SeekOrigin.Begin);

                    // Assert
                    using (var reader = new StreamReader(memoryStream))
                    {
                        var lineWritten = reader.ReadLine();
                        Assert.AreEqual("Hello, my name is Sheldon, you're in my spot.", lineWritten);
                    }
                }
            }
        }

        [TestMethod]
        public void Raj_Speak_No_Women()
        {
            // Arrange
            using (var memoryStream = new MemoryStream())
            {
                using (var writer = new StreamWriter(memoryStream))
                {
                    // Act
                    Actor raj = new Raj(false);
                    raj.Speak(writer);
                    writer.Flush();

                    memoryStream.Position = 0;
                    memoryStream.Seek(0, SeekOrigin.Begin);

                    // Assert
                    using (var reader = new StreamReader(memoryStream))
                    {
                        var lineWritten = reader.ReadLine();
                        Assert.AreEqual("Greetings, I am Raj.", lineWritten);
                    }
                }
            }
        }

        [TestMethod]
        public void Raj_Speaks_to_Women()
        {
            // Arrange
            using (var memoryStream = new MemoryStream())
            {
                using (var writer = new StreamWriter(memoryStream))
                {
                    // Act
                    Actor raj = new Raj(true);
                    raj.Speak(writer);
                    writer.Flush();

                    memoryStream.Position = 0;
                    memoryStream.Seek(0, SeekOrigin.Begin);

                    // Assert
                    using(var reader = new StreamReader(memoryStream))
                    {
                        var lineWritten = reader.ReadLine();
                        Assert.AreEqual("...mumble...", lineWritten);
                    }
                }
            }
        }

    }
}
