using System.IO;
using System;
using System.Collections.Generic;
using A7_ImplementingInterfaces.Models;
using Microsoft.VisualBasic.FileIO;
using ConsoleTables;

namespace A7_ImplementingInterfaces.Data
{
    public class FileRepository : IRepository
    {
        private static readonly string moviesPath = Path.Combine(Environment.CurrentDirectory, "MediaData", "movies.csv");
        private static readonly string showsPath = Path.Combine(Environment.CurrentDirectory, "MediaData", "shows.csv");
        private static readonly string videosPath = Path.Combine(Environment.CurrentDirectory, "MediaData", "videos.csv");

        private static string repositoryName = "File Repository";

        private List<Media> mediaList;

        private static bool checkPath(string path)
        {
            if (!File.Exists(path))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public int getLineNum(int mediaCode)
        {
            List<Media> countList = getMediaList(mediaCode);
            return countList.Count;
        }

        public List<Media> getMediaList(int mediaCode)
        {
            TextFieldParser parser;
            List<Media> listOutput = new List<Media>();
            switch (mediaCode)
            {
                case 1:
                    parser = new TextFieldParser(moviesPath);
                    if (checkPath(moviesPath))
                    {
                        parser.HasFieldsEnclosedInQuotes = true;
                        parser.SetDelimiters(",");
                        string[] fields;
                        if (!parser.EndOfData)
                        {
                            parser.ReadLine();
                        }
                        while (!parser.EndOfData)
                        {
                            fields = parser.ReadFields();
                            Movie movie = new Movie();
                            movie.ID = Convert.ToInt32(fields[0]);
                            movie.Title = fields[1];
                            movie.genres = fields[2].Split("|");
                            listOutput.Add(movie);
                        }
                        if (listOutput.Count > 0)
                        {
                            return listOutput;
                        }
                        else
                        {
                            return null;
                        }
                    }
                    else
                    {
                        return null;
                    }
                case 2:
                    parser = new TextFieldParser(showsPath);
                    if (checkPath(showsPath))
                    {
                        parser.HasFieldsEnclosedInQuotes = true;
                        parser.SetDelimiters(",");
                        string[] fields;
                        if (!parser.EndOfData)
                        {
                            parser.ReadLine();
                        }
                        while (!parser.EndOfData)
                        {
                            fields = parser.ReadFields();
                            Show show = new Show();
                            show.ID = Convert.ToInt32(fields[0]);
                            show.Title = fields[1];
                            show.season = Convert.ToInt32(fields[2]);
                            show.episode = Convert.ToInt32(fields[3]);
                            show.writers = fields[4].Split("|");
                            listOutput.Add(show);
                        }
                        if (listOutput.Count > 0)
                        {
                            return listOutput;
                        }
                        else
                        {
                            return null;
                        }
                    }
                    else
                    {
                        return null;
                    }
                default:
                    parser = new TextFieldParser(videosPath);
                    if (checkPath(videosPath))
                    {
                        parser.HasFieldsEnclosedInQuotes = true;
                        parser.SetDelimiters(",");
                        string[] fields;
                        if (!parser.EndOfData)
                        {
                            parser.ReadLine();
                        }
                        while (!parser.EndOfData)
                        {
                            fields = parser.ReadFields();
                            Video video = new Video();
                            video.ID = Convert.ToInt32(fields[0]);
                            video.Title = fields[1];
                            video.format = fields[2].Replace("|", ",");
                            video.length = Convert.ToInt32(fields[3]);
                            video.regions = Array.ConvertAll(fields[4].Split("|"), v => int.Parse(v));
                            listOutput.Add(video);
                        }
                        if (listOutput.Count > 0)
                        {
                            return listOutput;
                        }
                        else
                        {
                            return null;
                        }
                    }
                    else
                    {
                        return null;
                    }
            }
        }

        public string getName()
        {
            return repositoryName;
        }

        public string getPath(string strPath)
        {
            switch(strPath)
            {
                case "movie":
                    return moviesPath;
                case "show":
                    return showsPath;
                default:
                    return videosPath;
            }
        }
        public void viewAll(int mediaCode)
        {
            mediaList = getMediaList(mediaCode);
            switch(mediaCode)
            {
                case 1:
                    var moviesTable = new ConsoleTable("ID", "Title", "Genres");
                    foreach (Movie movie in mediaList)
                    {
                        moviesTable.AddRow(movie.ID, movie.Title, String.Join(",", movie.genres));
                    }
                    moviesTable.Write();
                    break;
                case 2:
                    var showsTable = new ConsoleTable("ID", "Title", "Season", "Episode", "Writers");
                    foreach (Show show in mediaList)
                    {
                        showsTable.AddRow(show.ID, show.Title, show.season, show.episode, String.Join(",", show.writers));
                    }
                    showsTable.Write();
                    break;
                case 3:
                    var videosTable = new ConsoleTable("ID", "Title", "Format", "Length (Minutes)", "Regions");
                    foreach (Video video in mediaList)
                    {
                        videosTable.AddRow(video.ID, video.Title, video.format, video.length, String.Join(",", video.regions));
                    }
                    videosTable.Write();
                    break;
            }
        }

        public void searchById(int mediaCode)
        {
            mediaList = getMediaList(mediaCode);
            Console.Write("Enter ID for Search: ");
            string userInputStr = Console.ReadLine();
            int userInputInt;
            try
            {
                userInputInt = Convert.ToInt32(userInputStr);
            }
            catch (FormatException fe)
            {
                Console.Clear();
                Log.log($"{userInputStr} is not a valid ID! Try again...", fe);
                searchById(mediaCode);
            }
            List<Media> searchList = new List<Media>();
            Media media;
            switch (mediaCode)
            {
                case 1:
                    searchList = getMediaList(1);
                    media = new Movie();
                    break;
                case 2:
                    searchList = getMediaList(2);
                    media = new Show();
                    break;
                case 3:
                    searchList = getMediaList(3);
                    media = new Video();
                    break;
            }
            bool foundMatch = false;
            foreach (Media m in searchList)
            {
                if (m.ID == Convert.ToInt32(userInputStr))
                {
                    foundMatch = true;
                    media = m;
                    Console.WriteLine(media.displayConfirmation());
                    break;
                }
            }
            if(foundMatch == false)
            {
                Console.Clear();
                Log.logX($"{userInputStr} was not a valid ID.");
            }
        }

        public void writeData(List<string> media, string strPath)
        {
            string path = getPath(strPath);
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
            Console.WriteLine("File Repository - Media added Successfully!");
        }
    }
}