using System;
using System.Collections.Generic;

namespace A6_MediaLibrary.Models
{

    public abstract class Media
    {

        public int ID {get; set;}
        public string Title {get; set;}

        public abstract void display();

        public abstract void addMedia();

    }

}