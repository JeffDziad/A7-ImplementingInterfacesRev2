using System;

namespace A7_ImplementingInterfaces.Models
{

    public class Show : Media
    {
        public int season {get; set;}
        public int episode {get; set;}
        public string[] writers {get; set;}

        public override string displayConfirmation()
        {
            return String.Format($"Show:\nID: {ID}\nTitle: {Title}\nSeason: {season}\nEpisode: {episode}\nWriters: {String.Join(",", writers)}");
        }
    }
}