using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace lab1{
    public class MusicRegister{
        private List<MusicTrack> Register;

        private List<Playlist> Playlists;

        /// <summary>
        /// Creates instance of class MusicRegister with empty register of tracks
        /// </summary>
        public MusicRegister(){
            this.Register = new List<MusicTrack>();
        }

        public MusicRegister(List<MusicTrack> list){
            this.Register = list;
        }

        public MusicRegister RegisterFromDirectory(string directory){
            string[] files = Directory.GetFiles(directory, "*.mp3");
            List<MusicTrack> tracks = new List<MusicTrack>();
            foreach(var track in files){
                var musicTr = TagLib.File.Create(track);
                string name = musicTr.Tag.Title;
                string author = musicTr.Tag.FirstPerformer;
                string album = musicTr.Tag.Album;
                TimeSpan time = musicTr.Properties.Duration;
                MusicTrack newTrack = new MusicTrack(name, author, time.ToString("c"), album);
                tracks.Add(newTrack);
            }
            return new MusicRegister(tracks);
        }

        public MusicRegister RegisterFromSeveralDirectories(string dirs){
            string[] directories = dirs.Split(' ');
            List<MusicTrack> tracks = new List<MusicTrack>();
            foreach(string directory in directories){
                string[] files = Directory.GetFiles(directory, "*.mp3");
                foreach(var track in files){
                    var musicTr = TagLib.File.Create(track);
                    string name = musicTr.Tag.Title;
                    string author = musicTr.Tag.FirstPerformer;
                    string album = musicTr.Tag.Album;
                    TimeSpan time = musicTr.Properties.Duration;
                    MusicTrack newTrack = new MusicTrack(name, author, time.ToString("c"), album);
                    tracks.Add(newTrack);
                }
            }
            return new MusicRegister(tracks);
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

        public List<string> GetPlaylists(){
            List<string> playlists = new List<string>();
            foreach(Playlist playlist in Playlists){
                playlists.Add(playlist.GetName());
            }
            return playlists;
        }
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
        
        public Playlist CreatePlaylistByAuthor(string author, string name){
            List<MusicTrack> buffer = new List<MusicTrack>();
            foreach(MusicTrack track in this.Register){
                if (track.GetAuthor().Equals(author)){
                    buffer.Add(track);
                }
            }
            return new Playlist(buffer, name);
        }

        public Playlist CreatePlaylistByAlbum(string album, string name){
            List<MusicTrack> buffer = new List<MusicTrack>();
            foreach(MusicTrack track in this.Register){
                if (track.GetAuthor().Equals(album)){
                    buffer.Add(track);
                }
            }
            return new Playlist(buffer, name);
        }

        //dtrfhgjk
    

        public Playlist CreatePlaylistByAuthorFromDirectory(string directory, string authorname, string name){
            string[] files = Directory.GetFiles(directory, "*.mp3");
            List<MusicTrack> tracks = new List<MusicTrack>();
            foreach(var track in files){
                var musicTr = TagLib.File.Create(track);
                string author = musicTr.Tag.FirstPerformer;
                if(!author.Equals(authorname)){
                    continue;
                }
                string title = musicTr.Tag.Title;
                string album = musicTr.Tag.Album;
                TimeSpan time = musicTr.Properties.Duration;
                MusicTrack newTrack = new MusicTrack(name, author, time.ToString("c"), album);
                tracks.Add(newTrack);
            }
            return new Playlist(tracks, name);
        }

         public Playlist CreatePlaylistByAlbumFromDirectory(string directory, string albumtitle, string name){
            string[] files = Directory.GetFiles(directory, "*.mp3");
            List<MusicTrack> tracks = new List<MusicTrack>();
            foreach(var track in files){
                var musicTr = TagLib.File.Create(track);
                string album = musicTr.Tag.Album;
                if(!album.Equals(albumtitle)){
                    continue;
                }
                string title = musicTr.Tag.Title;                
                string author = musicTr.Tag.FirstPerformer;
                TimeSpan time = musicTr.Properties.Duration;
                MusicTrack newTrack = new MusicTrack(name, author, time.ToString("c"), album);
                tracks.Add(newTrack);
            }
            return new Playlist(tracks, name);
        }

        public Playlist CreatePlaylistByAuthorFromSeveralDirectories(string dirs, string authorname, string name){
            string[] directories = dirs.Split(' ');
            List<MusicTrack> tracks = new List<MusicTrack>();
            foreach(string directory in directories){
                string[] files = Directory.GetFiles(directory, "*.mp3");
                foreach(var track in files){
                    var musicTr = TagLib.File.Create(track);
                    string author = musicTr.Tag.FirstPerformer;
                    if(!author.Equals(authorname)){
                        continue;
                    }
                    string album = musicTr.Tag.Album;
                    string title = musicTr.Tag.Title;
                    TimeSpan time = musicTr.Properties.Duration;
                    MusicTrack newTrack = new MusicTrack(name, author, time.ToString("c"), album);
                    tracks.Add(newTrack);
                }
            }
            return new Playlist(tracks, name);
        }

        public Playlist CreatePlaylistByAlbumFromSeveralDirectories(string dirs, string albumtitle, string name){
            string[] directories = dirs.Split(' ');
            List<MusicTrack> tracks = new List<MusicTrack>();
            foreach(string directory in directories){
                string[] files = Directory.GetFiles(directory, "*.mp3");
                foreach(var track in files){
                    var musicTr = TagLib.File.Create(track);
                    string album = musicTr.Tag.Album;
                    if(!album.Equals(albumtitle)){
                        continue;
                    }
                    string author = musicTr.Tag.FirstPerformer;
                    string title = musicTr.Tag.Title;
                    TimeSpan time = musicTr.Properties.Duration;
                    MusicTrack newTrack = new MusicTrack(name, author, time.ToString("c"), album);
                    tracks.Add(newTrack);
                }
            }
            return new Playlist(tracks, name);
        }
    }
}