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
            Player newPlayer = new Player("CoolGuy07", "cool@guy.com", new int[] { 1, 2, 3 }, new int[] { 4, 5, 6 });
            Assert.AreEqual("CoolGuy07", newPlayer.userName);
            Assert.AreEqual(new int[] { 1, 2, 3 }.ToString(), newPlayer.instrumentIDs.ToString());
            Assert.AreEqual(new int[] { 4, 5, 6 }.ToString(), newPlayer.songIDs.ToString());
        }

        [TestMethod]
        public void TestInstrumentConstructor()
        {
            Instrument newInst = new Instrument("piano", new int[] { 1, 2, 3 });
            Assert.AreEqual("piano", newInst.name);
            Assert.AreEqual(new int[] { 1, 2, 3 }.ToString(), newInst.playerIDs.ToString());
        }

        [TestMethod]
        public void TestSongConstructor()
        {
            Song newSong = new Song("Tequila", new int[] { 1, 2, 3 });
            Assert.AreEqual("Tequila", newSong.title);
            Assert.AreEqual(new int[] { 1, 2, 3 }.ToString(), newSong.playerIDs.ToString());
        }
    }
}
