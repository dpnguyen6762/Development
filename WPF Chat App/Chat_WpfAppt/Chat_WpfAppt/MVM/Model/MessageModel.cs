using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat_WpfAppt.MVM.Model
{
    internal class MessageModel
    {
        public string Username { get; set; }
        public string UsernameColor { get; set; }
        public string ImageSource { get; set; }
        public string Message { get; set; }
        public DateTime MessageTime { get; set; }
        public bool IsNativeOrigin { get; set; } // 
        public bool? FirstMessage { get; set; }
    }
}
