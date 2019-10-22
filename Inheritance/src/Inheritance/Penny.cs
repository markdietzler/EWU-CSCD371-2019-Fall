using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Inheritance
{
    public class Penny : Actor
    {

        public void Speak(TextWriter writer)
        {
            writer.WriteLine("Hi, I'm Penny!");
        }
    }
}
