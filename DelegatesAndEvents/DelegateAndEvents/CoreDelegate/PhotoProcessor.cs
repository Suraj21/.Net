using System;
using System.Collections.Generic;
using System.Text;

namespace CoreDelegate
{
    public class PhotoProcessor
    {
        //This method is not extensible, what if this dll/framework is release and another developer wanted to add new Apply
        //features i.e filters method which is not defined here, then how it will be achieved
        //so using delegate this can be made extensible
        //public void Process(string path)
        //{
        //    var photo = Photo.Load(path);
        //    var filters = new PhotoFilters();
        //    filters.ApplyBrightness(photo);
        //    filters.ApplyContrast(photo);
        //    filters.Resize(photo);

        //    photo.Save();
        //}

        //Custom Delegate
        //public delegate void PhotoFilterHandler(Photo photo);
        //Instead of using Custom delegate we can use system delete that is Action func and predicate

        //public void Process(string path, PhotoFilterHandler filterHandler)
        public void Process(string path, Action<Photo> filterHandler)
        {
            var photo = Photo.Load(path);
            filterHandler(photo);

            photo.Save();
        }
    }
}
