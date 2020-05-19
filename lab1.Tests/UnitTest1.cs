using System;
using NUnit.Framework;

namespace lab1.Tests{
    [TestFixture]
    public class Tests{
        [Test]
        public void Test1(){
            MusicTrack track = new MusicTrack("simple", "track", "4:20", "album");
            Assert.IsTrue(track.GetAuthor() != null && track.GetName() != null && track.GetTime() != null
            && track.GetAuthor() == "track" && track.GetName() == "simple" && track.GetTime() == "4:20" && track.GetAlbum() == "album");
        }
    
        
        [Test]
        public void Test2(){
            var ex = Assert.Throws<Exception>(() => new MusicTrack("simple", "music", "track", "album"));
            Assert.AreEqual("Incorrect time format", ex.Message);
        }

        [Test]
        public void Test3(){
            var ex = Assert.Throws<Exception>(() => new MusicTrack(null, "track", "2:28", "album"));
            Assert.AreEqual("Incorrect data format", ex.Message);
        }

        [Test]
        public void Test4(){
            MusicRegister reg = new MusicRegister();
            MusicTrack track = new MusicTrack("simple", "track", "7:29", "album");
            reg.Add(track);
            var ex = Assert.Throws<Exception>(() =>  reg.Add(track));
            Assert.AreEqual("This track already exists", ex.Message);
        }

        [Test]
        public void Test5(){
            MusicRegister reg = new MusicRegister();
            MusicTrack track = new MusicTrack("simple", "track", "7:29", "album");
            var ex = Assert.Throws<Exception>(() => reg.Del(track));
            Assert.AreEqual("Registry is empty", ex.Message);
        }

        [Test]
        public void Test6(){
            MusicRegister reg = new MusicRegister();
            MusicTrack track = new MusicTrack("simple", "track", "7:29", "album");
            var ex = Assert.Throws<Exception>(() => reg.Find(track));
            Assert.AreEqual("Register don`t contains this track", ex.Message);
        }

        [Test]
        public void Test7(){
            MusicTrack track = new MusicTrack("simple", "track", "7:29", "album");
            MusicRegister register = new MusicRegister();
            register.Add(track);
            var result = register.Find(track).Equals(track);
            Assert.IsTrue(result, "the same track");
        }
    }
}