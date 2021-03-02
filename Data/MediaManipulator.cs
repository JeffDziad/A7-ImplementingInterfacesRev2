using System;
using System.IO;
using System.Collections.Generic;
using A6_MediaLibrary.Models;

namespace A6_MediaLibrary.Data
{

    public static class MediaManipulator
    {

        public static void createMovie()
        {
            Console.Write("Enter Movie Title: ");
            string movieTitle = Console.ReadLine();
            Console.Write("Enter Movie Year: ");
            string movieYearStr = Console.ReadLine();
            int movieYearInt;
            try
            {
                movieYearInt = Convert.ToInt32(movieYearStr);
            }catch(FormatException fe)
            {
                Console.Clear();
                Log.log($"{movieYearStr} is not a valid number! Try again...", fe);
                createMovie();
            }
            if(movieTitle.Contains(","))
            {
                movieTitle = String.Format($"\"{movieTitle} ({movieYearStr})\"");
            }else
            {
                movieTitle = String.Format($"{movieTitle} ({movieYearStr})");
            }
            List<String> movieGenres = new List<string>();
            bool finishGenres = false;
            do
            {
                Console.Write("Enter a Genre: ");
                movieGenres.Add(Console.ReadLine());
                Console.Write("Add Another? (Y/N): ");
                char[] cont = Console.ReadLine().ToUpper().ToCharArray();
                if(cont[0] == 'N')
                {
                    finishGenres = true;
                }
            }while(!finishGenres);
            List<string> movieToAdd = new List<string>();
            movieToAdd.Add((MediaManager.getLineNum("movie") + 1).ToString());
            movieToAdd.Add(movieTitle);
            movieToAdd.Add(String.Join("|", movieGenres.ToArray()));
            addMedia(movieToAdd, MediaManager.getPath("movie"));
        }

        public static void createShow()
        {
            Console.Write("Enter Show Title: ");
            string showTitle = Console.ReadLine();
            Console.Write("Enter Show Premier Year: ");
            string showYearStr = Console.ReadLine();
            int showYearInt;
            try
            {
                showYearInt = Convert.ToInt32(showYearStr);
            }catch(FormatException fe)
            {
                Console.Clear();
                Log.log($"{showYearStr} is not a valid number! Try again...", fe);
                createShow();
            }
            if(showTitle.Contains(","))
            {
                showTitle = String.Format($"\"{showTitle} ({showYearStr})\"");
            }else
            {
                showTitle = String.Format($"{showTitle} ({showYearStr})");
            }
            Console.Write("Enter Season Number: ");
            string showSeasonStr = Console.ReadLine();
            int showSeasonInt;
            try{
                showSeasonInt = Convert.ToInt32(showSeasonStr);
            }catch(FormatException fe){
                Console.Clear();
                Log.log($"{showSeasonStr} is not a valid number! Try again...", fe);
                createShow();
            }
            Console.Write("Enter Episode Number: ");
            string showEpisodeStr = Console.ReadLine();
            int showEpisodeInt;
            try{
                showEpisodeInt = Convert.ToInt32(showEpisodeStr);
            }catch(FormatException fe){
                Console.Clear();
                Log.log($"{showEpisodeStr} is not a valid number! Try again...", fe);
                createShow();
            }
            List<string> showWriters = new List<string>();
            bool finishWriters = false;
            do
            {
                Console.Write("Enter Show Writer: ");
                showWriters.Add(Console.ReadLine());
                Console.Write("Add Another? (Y/N): ");
                char[] cont = Console.ReadLine().ToUpper().ToCharArray();
                if(cont[0] == 'N')
                {
                    finishWriters = true;
                }
            }while(!finishWriters);
            List<string> showToAdd = new List<string>();
            showToAdd.Add((MediaManager.getLineNum("show") + 1).ToString());
            showToAdd.Add(showTitle);
            showToAdd.Add(showSeasonStr);
            showToAdd.Add(showEpisodeStr);
            showToAdd.Add(String.Join("|", showWriters.ToArray()));
            addMedia(showToAdd, MediaManager.getPath("show"));
        }

        public static void createVideo()
        {
            Console.Write("Enter Video Title: ");
            string videoTitle = Console.ReadLine();
            Console.Write("Enter Video Release Year: ");
            string videoYearStr = Console.ReadLine();
            int videoYearInt;
            try
            {
                videoYearInt = Convert.ToInt32(videoYearStr);
            }catch(FormatException fe)
            {
                Console.Clear();
                Log.log($"{videoYearStr} is not a valid number! Try again...", fe);
                createShow();
            }
            if(videoTitle.Contains(","))
            {
                videoTitle = String.Format($"\"{videoTitle} ({videoYearStr})\"");
            }else
            {
                videoTitle = String.Format($"{videoTitle} ({videoYearStr})");
            }
            List<string> videoFormats = new List<string>();
            bool finishFormats = false;
            do
            {
                Console.Write("Enter Video Format: ");
                videoFormats.Add(Console.ReadLine());
                Console.Write("Add Another? (Y/N): ");
                char[] cont = Console.ReadLine().ToUpper().ToCharArray();
                if(cont[0] == 'N')
                {
                    finishFormats = true;
                }
            }while(!finishFormats);
            Console.Write("Enter Video Length (Minutes): ");
            string videoLengthStr = Console.ReadLine();
            int videoLengthInt;
            try
            {
                videoLengthInt = Convert.ToInt32(videoLengthStr);
            }catch(FormatException fe)
            {
                Console.Clear();
                Log.log($"{videoLengthStr} is not a valid number! Try again...", fe);
                createVideo();
            }
            List<int> videoRegions = new List<int>();
            bool finishedRegions = false;   
            do
            {
                Console.Write("Enter Video Region Code: ");
                try
                {
                    videoRegions.Add(Convert.ToInt32(Console.ReadLine()));
                }catch(Exception e)
                {
                    Console.Clear();
                    Log.log("That is not a valid region code! Try again...", e);
                    createVideo();
                }
                Console.Write("Add Another? (Y/N): ");
                char[] cont = Console.ReadLine().ToUpper().ToCharArray();
                if(cont[0] == 'N')
                {
                    finishedRegions = true;
                }
            }while(!finishedRegions);
            List<string> videoToAdd = new List<string>();
            videoToAdd.Add((MediaManager.getLineNum("video") + 1).ToString());
            videoToAdd.Add(videoTitle);
            videoToAdd.Add(String.Join("|", videoFormats.ToArray()));
            videoToAdd.Add(videoLengthStr);
            videoToAdd.Add(String.Join("|", videoRegions.ToArray()));
            addMedia(videoToAdd, MediaManager.getPath("video"));
        }

        public static void addMedia(List<string> media, string path)
        {
            try
            {
                using(StreamWriter sw = new StreamWriter(path, true))
                {
                    string output = String.Join(",", media.ToArray());
                    sw.WriteLine(output);
                    sw.Close();
                }
            }catch(FileNotFoundException fnfe)
            {
                Console.Clear();
                Log.log($"Something went wrong when trying to write to the file located at {path}!", fnfe);
            }
            Console.Clear();
            Console.WriteLine("Media added Successfully!");
        }

    }

}