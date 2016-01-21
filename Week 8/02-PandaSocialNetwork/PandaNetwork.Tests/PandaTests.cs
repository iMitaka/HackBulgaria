using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PandaNetwork.Tests
{
    [TestClass]
    public class PandaTests
    {
        [TestMethod]
        [ExpectedException(typeof(FormatException),
                "Email is not valid!")]
        public void CreatePandaWithInvalidEmailTest()
        {
            var panda = new Panda("Ivo", "ivopandamail", GenderType.Male);
        }

        [TestMethod]
        public void TwoEqualsPandasTest()
        {
            var panda = new Panda("Ivo", "ivo@pandamail.com", GenderType.Male);
            var otherPanda = new Panda("Ivo", "ivo@pandamail.com", GenderType.Male);

            Assert.AreEqual(panda, otherPanda);
        }
    }
}
