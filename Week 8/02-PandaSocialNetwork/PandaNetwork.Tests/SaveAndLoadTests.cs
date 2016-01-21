using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PandaNetwork.Tests
{
    [TestClass]
    public class SaveAndLoadTests
    {
        private IPandaSocialNetworkStorageProvider provider;
        private Panda ivo;

        [TestInitialize]
        public void TestInitialize()
        {
            provider = new PandaSocialNetworkStorageProvider();

            // Make some network and save to file:

            var network = new PandaSocialNetwork();

            ivo = new Panda("Ivo", "ivo@pandamail.com", GenderType.Male);

            network.AddPanda(ivo);

            provider.Save(network, "MyTestNetwork");
        }

        [TestMethod]
        public void CheckForLoadNetworkWork() 
        {
            // If this method work then and Save method in TestInitialize works well.

            var network = provider.Load("MyTestNetwork");

            bool hasPanda = network.HasPanda(ivo);
            
            Assert.IsTrue(hasPanda); 
        }
    }
}
