using System;
using System.Collections.Generic;

namespace lab1{
    public class Playlist : MusicRegister{
        private List<MusicTrack> Tracks;
        private int Length;

        private string Name;

        public Playlist (List<MusicTrack> list, string name){
            this.Tracks = list;
            this.Length = list.Count;
            this.Name = name;
        }

        public string GetName(){
            return Name;
        }

        public int GetLength(){
            return Length;
        }

        public List<MusicTrack> GetTracks(){
            return this.Tracks;
        }


        public void Randomize (){
            List<MusicTrack> buffer = new List<MusicTrack>();
            this.Tracks = new List<MusicTrack>();
            Random rand = new Random();
            while(buffer.Count > 0){
                int idx = rand.Next(buffer.Count);
                MusicTrack track = buffer[idx];
                this.Tracks.Add(track);
                buffer.Remove(track);
            }
        }
    }
}