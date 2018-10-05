using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace DelegateAndEvents
{
    //To pass the custom Data to the Delegate
    public class VideoEventArgs:EventArgs
    {
        public Video video { get; set; }
    }

    public class VideoEncoder //Publisher Class
    {
        //To Publish from this method we have to define the three thing
        //1. Define a Delegate
        //2. Define an Event based on the delegate
        //3. Rasie the Event

        //step 1. Define a Delegate
        //public delegate void VideoEncodedEventHandler(object source, EventArgs args);//this is going to hold the reference 
        // of the method which has the same signature i.e. return type void having two parameters of type object and additional data 

            //Passing the custom Data
        //public delegate void VideoEncodedEventHandler(object source, VideoEventArgs args);

        //step 2. Define an Event based on the delegate
        //public event VideoEncodedEventHandler VideoEncoded;

        //from .net 3.0 we dont want to go everytime and create the delegate type whenever we want to declare an event
        // so they added the a delegate type of eventHandler (thus only the below one line of code for the step 1. and step 2)
        public event EventHandler<VideoEventArgs> VideoEncoded;

        public void Encode(Video video)
        {
            Console.WriteLine("Encoding Video..");
            Thread.Sleep(3000);
            //OnVideoEncoded();//Reponsible to notify the subscriber
            OnVideoEncoded(video);//Reponsible to notify the subscriber ---sending custom data
        }

        //step 3. Raise and Event, so this method is responsible to raise the event
        // as per the .net naming conventions the event handler method should be protected, virtual, void and should begin wiht On
        //protected  virtual  void OnVideoEncoded()
        protected virtual void OnVideoEncoded(Video video)
        {
            //if(VideoEncoded != null) VideoEncoded(this,EventArgs.Empty) --OldWay
            //VideoEncoded?.Invoke(this, EventArgs.Empty);//this means the current class is the source of publishing the event
            //Sending Custom Data
            VideoEncoded?.Invoke(this, new VideoEventArgs() { video = video });//
        }
    }
}
