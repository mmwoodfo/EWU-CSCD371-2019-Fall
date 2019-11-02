using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Mailbox
{
    public class DataLoader : IDisposable
    {
        private Stream Source { get; }

        public DataLoader(Stream source)
        {
            Source = source ?? throw new ArgumentNullException(nameof(source));
        }

        public List<MailBox>? Load()
        {
            List<MailBox> mailboxes = new List<MailBox>();
            Source.Position = 0;

            try
            {
                using (StreamReader sr = new StreamReader(Source))
                {
                    string? jsonLine;
                    while ((jsonLine = sr.ReadLine()) != null)
                    {
                        MailBox mailbox = JsonConvert.DeserializeObject<MailBox>(jsonLine);
                        mailboxes.Add(mailbox);
                    }
                }
            }
            catch (JsonReaderException)
            {
                return null;
            }

            return mailboxes;
        }

        public void Save(List<MailBox> mailboxes)
        {
            Source.Position = 0;

            using (StreamWriter sw = new StreamWriter(Source, leaveOpen:true))
            {
                foreach (MailBox mailbox in mailboxes)
                    sw.WriteLine(JsonConvert.SerializeObject(mailbox));
            }
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    Source.Dispose();
                }

                disposedValue = true;
            }
        }

        ~DataLoader()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(false);
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
