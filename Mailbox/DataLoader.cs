using Newtonsoft.Json;
using System;
using System.IO;

namespace Mailbox {
    public class DataLoader : IDisposable {
        bool disposedFlag = false;

        private readonly Stream _Source;
        public DataLoader(Stream newStreamSource) {
            _Source = newStreamSource ?? throw new ArgumentNullException($"{nameof(newStreamSource)} was null.");
        }

        public Mailbox[,] Load() {

            _Source.Position = 0;
            Mailbox[,] returnMe;


            using (StreamReader streamReader = new StreamReader(_Source, leaveOpen: true)) {
                try {
                    returnMe = JsonConvert.DeserializeObject<Mailbox[,]>(streamReader.ReadLine());
                } catch (Exception exceptionCaught) {
                    if(exceptionCaught is JsonReaderException || exceptionCaught is ArgumentNullException)
                    {
                        return null;
                    }
                    throw;
                }
            }
            return returnMe;
        }

        public void Save(Mailbox[,] mailboxes)
        {
            _Source.Position = 0;
            using (StreamWriter streamWriter = new StreamWriter(_Source, leaveOpen: true))
            {
                streamWriter.WriteLine(JsonConvert.SerializeObject(mailboxes));
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposedFlag)
                return;
            if(disposing)
            {
                _Source.Dispose();
            }

            disposedFlag = true;
        }
    }
}
