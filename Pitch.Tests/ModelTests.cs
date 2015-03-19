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
            Profile newPlayer = new Profile("CoolGuy07");
            Assert.AreEqual("CoolGuy07", newPlayer.userName);
        }

        [TestMethod]
        public void TestInstrumentConstructor()
        {
            Instrument newInst = new Instrument("piano");
            Assert.AreEqual("piano", newInst.name);
        }

        [TestMethod]
        public void TestSongConstructor()
        {
            Song newSong = new Song("Tequila");
            Assert.AreEqual("Tequila", newSong.title);
        }
    }
}
