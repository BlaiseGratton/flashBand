﻿using Effort;
using Pitch;
using Pitch.Models;
using Pitch.Repository;
using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace Pitch.Tests
{
    [TestClass]
    public class AppRepositoryTests
    {
        private AppRepository _repo;

        [TestInitialize]
        public void SetUpTest()
        {
            DbConnection connection = Effort.DbConnectionFactory.CreateTransient();
            using (var context = new AppContext(connection))
            {
                context.Players.Add(new Profile("Blaise"));
                context.SaveChanges();
            }

            _repo = new AppRepository(new AppContext(connection));
            //repo = new AppRepository();
            //repo.Clear();
        }

        [TestMethod]
        public void TestAddPlayer()
        {
            //_repo.Clear();
            Assert.AreEqual(0, _repo.GetPlayersCount());
            Profile player = new Profile("Blaise");
            Assert.AreEqual(1, _repo.GetPlayersCount());
        }
    }
}
