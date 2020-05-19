using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace lab1{
    public class MusicRegister{
        private List<MusicTrack> Register;

        /// <summary>
        /// Creates instance of class MusicRegister with empty register of tracks
        /// </summary>
        public MusicRegister(){
            this.Register = new List<MusicTrack>();
        }

        /// <summary>
        /// Function for get register of tracks
        /// </summary>
        /// <returns>Register of tracks in list of music tracks</returns>

        public List<MusicTrack> GetRegister(){
            return Register;
        }
        /// <summary>
        /// Function for add new track in register
        /// </summary>
        /// <param name="track">MusicTrack object</param>

        public void Add(MusicTrack track){
            foreach(var v in Register){
                if(v.Equals(track)){
                    throw new Exception("This track already exists");
                }
            }
            Register.Add(track);
        }
        /// <summary>
        /// Function that finds MusicTrack object from register equal with param
        /// </summary>
        /// <param name="track">MusicTrack object</param>

        public void Del(MusicTrack track){
            if(Register.Count == 0) throw new Exception("Registry is empty");
            foreach(var v in Register){
                if(v.Equals(track)){
                    Register.Remove(v);
                    break;
                }
            }
        }
        /// <summary>
        /// Function that finds MusicTrack from register
        /// </summary>
        /// <param name="track"></param>
        /// <returns>Music track object if founded and null if not founded</returns>

        public MusicTrack Find(MusicTrack track){
            foreach(var v in Register){
                if(v.Equals(track)){
                    return v;
                }
            }
            throw new Exception("Register don`t contains this track");
        }

        /// <summary>
        /// Function for sort register by name of author
        /// </summary>
        public void SortByAuthor(){
            if(Register.Count == 0) throw new Exception("Register is empty");
            Register.Sort((x, y) => x.GetAuthor().CompareTo(y.GetAuthor()));
        }

        /// <summary>
        /// Function for sort register by name of track
        /// </summary>
        public void SortByName(){
            Register.Sort((x, y) => x.GetName().CompareTo(y.GetName()));
        }

        /// <summary>
        /// Function for sort register by length of track
        /// </summary>
        public void SortByTime(){
            Register.Sort((x, y) => x.GetTime().CompareTo(y.GetTime()));
        }

        /// <summary>
        /// Function for find music track on vk
        /// </summary>
        public void FindOnVK(MusicTrack track){
            String trackName = track.GetName();
            trackName.Replace(" ", "%20");
            Process.Start("xdg-open", "https://vk.com/music?q=" + trackName);
        }
    }
}