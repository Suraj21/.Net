using System;
using System.Collections.Generic;
using System.Text;

namespace DelegateAndEvents
{
    public class MessageService
    {
        //public void OnVideoEncoded(object source,EventArgs eventArgs) Passing Custom Data
        public void OnVideoEncoded(object source, VideoEventArgs eventArgs)
        {
            Console.WriteLine("Message Service Sending Text Message..." + eventArgs.video.Title);
        }
    }
}
