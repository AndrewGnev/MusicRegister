using System;
using System.Collections.Generic;

namespace lab1{
    public class Playlist : MusicRegister{
        private List<MusicTrack> Tracks;
        private int Length;

        public Playlist (List<MusicTrack> list){
            this.Tracks = list;
            this.Length = list.Count;
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