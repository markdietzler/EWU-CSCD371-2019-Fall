using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace Inheritance
{
    public class Raj : Actor
    {
        public bool WomanIsInView { get; set; }

        public Raj()
        {
            WomanIsInView = false;
        }

        public Raj(bool thereIsAWomanPresent)
        {
            WomanIsInView = thereIsAWomanPresent;
        }

        public void Speak(TextWriter writer)
        {
            writer.WriteLine("Greetings, I am Raj.");
        }

        public void SpeakToWomen(TextWriter writer)
        {
            writer.WriteLine("...mumble...");
        }
    }
}
