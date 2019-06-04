using System;

namespace Possible.MessageWeb.Models.Messages
{
    public class Message
    {
        public int MessageId { get; set; }
        public DateTime CreationDate { get; set; }
        public string UsernameFrom { get; set; }
        public string UserNameTo { get; set; }
        public string Contents { get; set; }
        public bool Read { get; set; }
    }
}