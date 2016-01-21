using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PandaNetwork;

namespace PandaConsoleInterface
{
    public class PandaNetworkConsoleApp
    {
        public static void Main()
        {
            //var network = new PandaSocialNetwork();
            var ivo = new Panda("Ivo", "ivo@pandamail.com", GenderType.Male);
            var rado = new Panda("Rado", "rado@pandamail.com", GenderType.Male);
            var tony = new Panda("Tony", "tony@pandamail.com", GenderType.Female);

            var tonyz = new Panda("Tonyz", "tony@pandamail.com", GenderType.Female);

            // Adding pandas to network:

            //network.AddPanda(ivo);
            //network.AddPanda(rado);
            //network.AddPanda(tony);
            //network.AddPanda(tonyz);

            // Make some of them to be friends:

            //network.MakeFriends(ivo, rado);
            //network.MakeFriends(rado, tony);          

            IPandaSocialNetworkStorageProvider provider = new PandaSocialNetworkStorageProvider();
            // provider.Save(network, "MyNetwork");  // Make save of network

            var network = provider.Load("MyNetwork"); // network is loaded from save file.

            // Check some methods:

            Console.WriteLine(network.ConnectionLevel(ivo, rado)); // 1
            Console.WriteLine(network.ConnectionLevel(ivo, tony)); // 2
            Console.WriteLine(network.ConnectionLevel(ivo, tonyz)); // -1
            Console.WriteLine(network.AreConnected(ivo, tonyz));

            network.MakeFriends(tony, tonyz);

            foreach (var friend in network.FriendsOf(rado))
            {
                Console.WriteLine(friend.ToString());
            }

            Console.WriteLine(network.HowManyGenderInNetwork(2, rado, GenderType.Female)); // 1
        }
    }
}
