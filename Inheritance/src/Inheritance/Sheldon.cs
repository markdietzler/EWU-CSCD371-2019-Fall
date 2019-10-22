using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Inheritance
{
    public class Sheldon : Actor
    {
        public void Speak(TextWriter writer)
        {
            writer.WriteLine("Hello, my name is Sheldon, you're in my spot.");
        }
    }
}
