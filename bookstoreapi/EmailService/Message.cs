using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailService
{
    public class Message
    {
        public List<MailboxAddress> To { get; set; }

        public string Subject { get; set; }
        
        public string Body { get; set; }

        public Message(IEnumerable<string> to, string subject, string body)
        {
            To = new List<MailboxAddress>();

            //set name => ""
            //set email address => list item
            To.AddRange(to.Select(r => new MailboxAddress("", r)));
            Subject = subject;
            Body = body;
        }
    }
}
