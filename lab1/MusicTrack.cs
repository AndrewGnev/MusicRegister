using System;

namespace lab1{
    public class MusicTrack{
        private string Author;
        private string Name;
        private string Time;

        /// <summary>
        /// Creates instance of class type MusicTrack by parameters
        /// </summary>
        /// <param name="name">Name of track (any string)</param>
        /// <param name="author">Name of author (any string)</param>
        /// <param name="time">Length of track(minutes:seconds)</param>
        public MusicTrack(string name, string author, string time){
            if(name == null || author == null || time == null){
                throw new Exception("Incorrect data format");
            }
            if(!check_time_format.Check(time)){
                throw new Exception("Incorrect time format");
            }
            this.Author = author;
            this.Name = name;
            this.Time = time;
            
        }

        /// <summary>
        /// Creates empty instance of class MusicTrack
        /// </summary>
        public MusicTrack(){
            Author = "";
            Name = "";
            Time = "";
        }

        /// <summary>
        /// Function for get name of author of track
        /// </summary>
        /// <returns>String with name of author</returns>
        public string GetAuthor(){
            return this.Author;
        }

        /// <summary>
        /// Function for get name of track
        /// </summary>
        /// <returns>String with name of track</returns>
        public string GetName(){
            return this.Name;
        }

        /// <summary>
        /// Function for get length of track
        /// </summary>
        /// <returns>String in forrmat "minutes:seconds"</returns>
        public string GetTime(){
            return this.Time;
        }

    }
}