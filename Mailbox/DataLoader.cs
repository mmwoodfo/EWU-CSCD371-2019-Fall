using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Mailbox
{
    public class DataLoader : IDisposable
    {
        private readonly Stream _Source;

        public DataLoader(Stream source)
        {
            _Source = source ?? throw new ArgumentNullException(nameof(source));
        }

        public void Dispose()
        {
            _Source.Dispose();
        }

        public List<MailBox>? Load()
        {
            if(_Source is null)
            {
                throw new ArgumentNullException(nameof(_Source));
            }

            List<MailBox> mailboxes = new List<MailBox>();
            _Source.Position = 0;

            try
            {
                using (StreamReader sr = new StreamReader(_Source))
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
            _Source.Position = 0;

            using (StreamWriter sw = new StreamWriter(_Source))
            {
                string json = JsonConvert.SerializeObject(mailboxes);
                sw.WriteLine(json);
            }
        }
    }
}
