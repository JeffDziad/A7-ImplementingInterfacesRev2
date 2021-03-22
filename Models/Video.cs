using System;

namespace A7_ImplementingInterfaces.Models
{

    public class Video : Media
    {
        public string format {get; set;}
        public int length {get; set;}
        public int[] regions {get; set;}

        public override string displayConfirmation()
        {
            return String.Format($"Video:\nID: {ID}\nTitle: {Title}\nFormats: {format.Replace("|", ",")}\nLength: {length}min.\nRegions: {String.Join(",", regions)}");
        }
    }
}