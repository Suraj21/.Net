using System;
using System.Collections.Generic;
using System.Text;

namespace DelegateAndEvents
{
    public class MailService
    {
        //public void OnVideoEncode(object source,EventArgs eventArgs)
        public void OnVideoEncode(object source, VideoEventArgs eventArgs) //passing Custom Data
        {
            Console.WriteLine("Mail Service called..." + eventArgs.video.Title);
        }
    }
}
