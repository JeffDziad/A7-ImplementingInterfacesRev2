using System;

namespace A6_MediaLibrary.Models
{

    public class Show : Media
    {
        public int season {get; set;}
        public int episode {get; set;}
        public string[] writers {get; set;}

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