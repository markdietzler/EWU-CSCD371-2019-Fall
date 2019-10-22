using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Inheritance
{
    public static class ActorExtension
    {
        public static void Speak(this Actor speakingActor, TextWriter writer)
        {
            if(speakingActor is null || writer is null)
            {
                throw new ArgumentNullException("Null arguments for actor or textwriter given");
            }

            if(speakingActor is null && !(writer is null))
            {
                throw new ArgumentNullException("Null argument for TextWriter given");
            }

            if(!(speakingActor is null) && writer is null)
            {
                throw new ArgumentNullException("Null argument for Actor given");
            }

            switch (speakingActor)
            {
                case Penny penny:
                    penny.Speak(writer);
                    break;

                case Sheldon sheldon:
                    sheldon.Speak(writer);
                    break;

                case Raj raj when !raj.WomanIsInView:
                    raj.Speak(writer);
                    break;

                case Raj raj when raj.WomanIsInView:
                    raj.SpeakToWomen(writer);
                    break;
            }
        }
    }
}
