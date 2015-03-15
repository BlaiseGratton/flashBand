using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pitch.Models;

namespace Pitch.Tests
{
    [TestClass]
    public class ModelTests
    {
        [TestMethod]
        public void TestPlayerConstructor()
        {
            Player newPlayer = new Player("CoolGuy07", "cool@guy.com", "1,2,3", "4,5,6");
            Assert.AreEqual("CoolGuy07", newPlayer.userName);
            Assert.AreEqual("1,2,3", newPlayer.instrumentIDs);
            Assert.AreEqual("4,5,6", newPlayer.songIDs);
        }

        [TestMethod]
        public void TestInstrumentConstructor()
        {
            Instrument newInst = new Instrument("piano", "1,2,3");
            Assert.AreEqual("piano", newInst.name);
            Assert.AreEqual("1,2,3", newInst.playerIDs);
        }

        [TestMethod]
        public void TestSongConstructor()
        {
            Song newSong = new Song("Tequila", "1,2,3");
            Assert.AreEqual("Tequila", newSong.title);
            Assert.AreEqual("1,2,3", newSong.playerIDs);
        }
    }
}
