using System;

namespace DelegateAndEvents
{
    class Program
    {
        static void Main(string[] args)
        {
            var video = new Video { Title = "Title1" };
            var videoEncoder = new VideoEncoder(); //Publisher
            MailService mailService = new MailService(); //Subscriber
            MessageService messageService = new MessageService();//new Subscriber ***

            //VideoEncoded behind the scene is a list of pointer to method, when the videoEncoder wantes to publish 
            //the event it looks the list (i.e at if(VideoEncoded != null)) if it is not null then it means 
            //that we have a pointer to an event handler method 
            videoEncoder.VideoEncoded += mailService.OnVideoEncode;//Since we are not writing it like a method this 
            //means this is actully a reference to the method which delegate id defining
            //first the subscriber is defined, so now 
            //1. who is the publisher(videoEncoder) and what event are we interested in invoking (VideoEncoded) and after that what mehtod we need to subscribe (+= subscribe) messageSubscribe OnVideoEncode method which matches the same signature as that of the delegate
            videoEncoder.VideoEncoded += messageService.OnVideoEncoded;
            videoEncoder.Encode(video);
        }
    }
}
