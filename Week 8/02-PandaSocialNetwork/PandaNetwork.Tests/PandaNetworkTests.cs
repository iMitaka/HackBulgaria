using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PandaNetwork;
using System.Collections.Generic;

namespace PandaNetwork.Tests
{
    [TestClass]
    public class PandaNetworkTests
    {
        private PandaSocialNetwork network;
        private Panda ivo;
        private Panda rado;
        private Panda tony;
        private Panda pesho;

        [TestInitialize]
        public void TestInitialize()
        {
            network = new PandaSocialNetwork();
            ivo = new Panda("Ivo", "ivo@pandamail.com", GenderType.Male);
            rado = new Panda("Rado", "rado@pandamail.com", GenderType.Male);
            tony = new Panda("Tony", "tony@pandamail.com", GenderType.Female);
            pesho = new Panda("Pesho", "pesho@pandamail.com", GenderType.Male);
        }

        [TestMethod]
        [ExpectedException(typeof(PandaException.PandaAlreadyThereException))]
        public void AddAlreadySamePandaIntoNetwork()
        {
            network.AddPanda(ivo);
            network.AddPanda(ivo);
        }

        [TestMethod]
        [ExpectedException(typeof(PandaException.PandasAlreadyFriendsException))]
        public void AddAlreadyPandasAsFriendTest()
        {
            network.MakeFriends(ivo, rado);
            network.MakeFriends(ivo, rado);
        }

        [TestMethod]
        public void CheckConnectionLevelBetweenPandas()
        {
            network.MakeFriends(ivo, rado);

            var level = network.ConnectionLevel(ivo, rado);

            Assert.AreEqual(1, level);
        }

        [TestMethod]
        public void CheckDeeperConnectionLevelBetweenPandas()
        {
            network.MakeFriends(ivo, rado);
            network.MakeFriends(rado, tony);
            network.MakeFriends(tony, pesho);

            var level = network.ConnectionLevel(ivo, pesho);

            Assert.AreEqual(3, level);
        }

        [TestMethod]
        public void CheckForNonConnectionBetweenPandas()
        {
            network.AddPanda(pesho);

            network.MakeFriends(ivo, rado);
            network.MakeFriends(rado, tony);

            var level = network.ConnectionLevel(ivo, pesho);

            Assert.AreEqual(-1, level);
        }

        [TestMethod]
        [ExpectedException(typeof(PandaException.PandaIsNotOnNetworkException))]
        public void ChechConnectionLevelWhenOneOfPandasAreNotInNetwork()
        {
            network.AddPanda(ivo);
            network.ConnectionLevel(ivo, rado);
        }

        [TestMethod]
        public void CheckHowManyGenderInNetworkTest()
        {
            network.MakeFriends(ivo, rado);
            network.MakeFriends(rado, tony);

            var gendersCount = network.HowManyGenderInNetwork(1, rado, GenderType.Female);

            Assert.AreEqual(1, gendersCount);

        }

        [TestMethod]
        public void CheckFriendsOfMethod()
        {
            var friendOfIvo = new List<Panda>();
            friendOfIvo.Add(rado);

            network.MakeFriends(ivo, rado);

            var ivoFriendList = network.FriendsOf(ivo);

            CollectionAssert.AreEqual(friendOfIvo, ivoFriendList);
        }

        [TestMethod]
        [ExpectedException(typeof(PandaException.PandaIsNotOnNetworkException))]
        public void CheckFriendsOfMethodWhenPandaIsNotInNetwork()
        {
            var panda = new Panda("Panda", "panda@pandamail.com", GenderType.Male);

            network.FriendsOf(panda);
        }
    }
}
