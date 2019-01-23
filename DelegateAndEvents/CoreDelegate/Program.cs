using System;

namespace CoreDelegate
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            PhotoProcessor photoProcessor = new PhotoProcessor();
            var filters = new PhotoFilters();
            //Custom way of calling the delegate
            //PhotoProcessor.PhotoFilterHandler filterHandler = filters.ApplyBrightness; //This is the place where the developer
            // is invoking the already written dll or framework, so developer can write their own method matching the delegate 
            // and call it using filterHandler(i.e delegate instance) 

            Action<Photo> filterHandler = filters.ApplyBrightness;//using the system Delegate
            filterHandler += filters.ApplyContrast;
            filterHandler += RemoveRedEye;
            filterHandler -= filters.ApplyContrast;
            filterHandler += AnotherDeveloperClass.ApplyGreen;
            photoProcessor.Process("Cdrive",filterHandler); //all the method are being passed from here 
            Console.ReadKey();
        }

        /// <summary>
        /// And extension method written by developer on the PhotoProcessor and PhotoFilter framework
        /// </summary>
        /// <param name="photo"></param>
        static void RemoveRedEye(Photo photo)
        {
            Console.WriteLine("Apply Remove Red Eye");
        }
    }

    public class AnotherDeveloperClass
    {
        public static void ApplyGreen(Photo photo)
        {
            Console.WriteLine("Apply Green");
        }
    }

    //As per the Guide Line of the MSDN use Delegate Over Interface when
    //1. An Event design Pattern is used
    //2. The caller doesn't need to access other properties or method on the object implementing the method
}
