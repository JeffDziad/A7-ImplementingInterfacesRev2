using System;
using System.Collections.Generic;

namespace A6_MediaLibrary.Models
{

    public class Movie : Media
    {
        public string[] genres {get; set;}

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