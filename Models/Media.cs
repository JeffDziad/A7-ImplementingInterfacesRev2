using System;
using System.Collections.Generic;

namespace A7_ImplementingInterfaces.Models
{

    public abstract class Media
    {

        public int ID {get; set;}
        public string Title {get; set;}

        public abstract string displayConfirmation();
    }
}