using Pitch;
using Pitch.Models;
using Pitch.Repository;
using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace Pitch.Tests
{
    [TestClass]
    public class AppRepositoryTests
    {
        private static AppRepository repo;

        [ClassInitialize]
        public static void SetUp(TestContext _context)
        {
            repo = new AppRepository();
            repo.Clear();
        }

        [ClassCleanup]
        public static void Cleanup()
        {
            repo.Clear();
        }

        [TestCleanup]
        public void ClearDatabase()
        {
            repo.Clear();
        }

        [TestMethod]
        public void TestAddPlayer()
        {
            repo.Clear();
            Assert.AreEqual(0, repo.GetPlayersCount());
            Player player = new Player("Blaise", "b@g.com", new int[] { 1, 2, 3 }, new int[] { 1, 2, 3 });
            Assert.AreEqual(1, repo.GetPlayersCount());
        }
    }
}
