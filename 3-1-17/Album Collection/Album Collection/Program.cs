using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Album_Collection
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 2; i++)
            {
                string[] album = new string[2];
                string[] artistName = new string[2];
                int[] year = new int[2];
                string[] genre = new string[2];
                int[] tracks = new int[2];

                //get user input
                Console.WriteLine("What is the name of the album you want to add?");
                album[i] = Console.ReadLine();//could also just have done newAlbum.Title = Console.ReadLine() so i wouldn't need all the strings
                Console.WriteLine("Who is the artist of the album?");
                artistName[i] = Console.ReadLine();
                Console.WriteLine("What year was the album recorded?");
                year[i] = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("What genre is the album?");
                genre[i] = Console.ReadLine();
                Console.WriteLine("How many tracks are in the album?");
                tracks[i] = Convert.ToInt32(Console.ReadLine());

                Console.Clear();
                //store input in Album
                Album[] newAlbum = new Album[2];//making the album array
                newAlbum[i] = new Album();//adding a new album
                newAlbum[i].SetAlbumInfo(album[i], artistName[i], year[i], genre[i], tracks[i]);//putting input in to SetAlbumInfo

                Console.WriteLine(newAlbum[i].GetAlbumInfo());//writing the new album that is pulling info from GetAlbumInfo
                Console.ReadLine();
            }//end of for loop
        }//end of Main

    }//end of Class Program

    class Album
    {
        public string Title;
        public string Artist;
        public int Year;
        public string Genre;
        public int Tracks;

        public void SetAlbumInfo(string albumTitle, string albumArtist, int albumYear, string albumGenre, int albumTracks)
        {
            Title = albumTitle;
            Artist = albumArtist;
            Year = albumYear;
            Genre = albumGenre;
            Tracks = albumTracks;
        }

        public string GetAlbumInfo()
        {
            return ("Album: " +Title + "\nArtist/Band: " + Artist + "\nYear: " + Year +"\nGenre: " + Genre + "\n" + Tracks + " Tracks");
        }
    }
}
