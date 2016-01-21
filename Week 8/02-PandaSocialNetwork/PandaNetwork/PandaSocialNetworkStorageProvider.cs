using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace PandaNetwork
{
    public class PandaSocialNetworkStorageProvider : IPandaSocialNetworkStorageProvider
    {
        private IFormatter formatter;

        public PandaSocialNetworkStorageProvider()
        {
            this.formatter = new BinaryFormatter();
        }

        public void Save(PandaSocialNetwork network, string fileName)
        {
            using (Stream stream = new FileStream(fileName + ".bin", FileMode.Create, FileAccess.Write, FileShare.None))
            {
                formatter.Serialize(stream, network);
            }
        }

        public PandaSocialNetwork Load(string fileName)
        {
            using (Stream stream = new FileStream(fileName + ".bin", FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                PandaSocialNetwork network = (PandaSocialNetwork)formatter.Deserialize(stream);
                return network;
            }
        }
    }
}
