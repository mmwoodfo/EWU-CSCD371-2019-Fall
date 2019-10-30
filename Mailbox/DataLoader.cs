using System;
using System.Collections.Generic;
using System.IO;

namespace Mailbox
{
    public class DataLoader : IDisposable
    {
        public DataLoader(Stream source)
        {
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public List<MailBox> Load()
        {
            throw new NotImplementedException();
        }

        public void Save(List<MailBox> mailboxes)
        {
            throw new NotImplementedException();
        }
    }
}
