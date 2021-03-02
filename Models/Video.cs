using System;

namespace A6_MediaLibrary.Models
{

    public class Video : Media
    {
        public string format {get; set;}
        public int length {get; set;}
        public int[] regions {get; set;}

        public override void display()
        {
            throw new NotImplementedException();
        }

        public override void addMedia()
        {
            throw new NotImplementedException();
        }
    }

}