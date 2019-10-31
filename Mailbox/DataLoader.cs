using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Mailbox
{
    public class DataLoader : IDisposable
    {
        private readonly Stream source;

        public DataLoader(Stream source)
        {
            if (source is null)
            {
                throw new ArgumentNullException("DataLoader Stream cannot be null");
            }
            else
            {
                this.source = source;
            }
        }

        public void Dispose()
        {
            source.Dispose();
        }

        public List<MailBox>? Load()
        {
            List<MailBox> mailboxes = new List<MailBox>();
            source.Position = 0;

            using (StreamReader sr = new StreamReader(source))
            {
                try
                {
                    string? jsonMailBox = sr.ReadLine();
                    MailBox mailbox = JsonConvert.DeserializeObject<MailBox>(jsonMailBox);
                    mailboxes.Add(mailbox);
                    return mailboxes;
                }
                catch (JsonReaderException)
                {
                    return null;
                }
                catch (ArgumentNullException)
                {
                    return null;
                }
            }
        }

        public void Save(List<MailBox> mailboxes)
        {
            source.Position = 0;

            using (StreamWriter sw = new StreamWriter(source))
            {
                foreach (MailBox mailbox in mailboxes)
                {
                    string jsonMailBox = JsonConvert.SerializeObject(mailbox);
                    sw.WriteLine(jsonMailBox);
                }
            }
        }
    }
}
