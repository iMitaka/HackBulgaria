using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PandaNetwork
{
    public interface IPandaSocialNetworkStorageProvider
    {
        void Save(PandaSocialNetwork network, string fileName);
        PandaSocialNetwork Load(string fileName);
    }
}
