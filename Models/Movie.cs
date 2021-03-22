using System;
using System.Collections.Generic;

namespace A7_ImplementingInterfaces.Models
{

    public class Movie : Media
    {
        public string[] genres {get; set;}

        public override string displayConfirmation()
        {
            return String.Format($"Movie:\nID: {ID}\nTitle: {Title}\nGenres: {String.Join(",", genres)}");
        }
    }
}