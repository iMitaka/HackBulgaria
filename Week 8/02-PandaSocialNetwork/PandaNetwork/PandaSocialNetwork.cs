using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PandaNetwork
{
    [Serializable]
    public class PandaSocialNetwork
    {
        private Dictionary<Panda, List<Panda>> pandasAndFriends = new Dictionary<Panda, List<Panda>>();

        public void AddPanda(Panda panda)
        {
            if (this.HasPanda(panda))
            {
                throw new PandaException.PandaAlreadyThereException("The panda is already in network!");
            }
            else
            {
                this.pandasAndFriends.Add(panda, new List<Panda>());
            }
        }

        public bool HasPanda(Panda panda)
        {
            if (this.pandasAndFriends.ContainsKey(panda))
            {
                return true;
            }

            return false;
        }

        public void MakeFriends(Panda firstPanda, Panda secondPanda)
        {
            if (this.AreFriends(firstPanda, secondPanda))
            {
                throw new PandaException.PandasAlreadyFriendsException("This pandas are already friends!");
            }

            if (!this.HasPanda(firstPanda))
            {
                this.AddPanda(firstPanda);
            }

            if (!this.HasPanda(secondPanda))
            {
                this.AddPanda(secondPanda);
            }

            this.pandasAndFriends[firstPanda].Add(secondPanda);
            this.pandasAndFriends[secondPanda].Add(firstPanda);
        }

        public bool AreFriends(Panda firstPanda, Panda secondPanda)
        {
            if (this.HasPanda(firstPanda) && this.HasPanda(secondPanda))
            {
                if (this.pandasAndFriends[firstPanda].Contains(secondPanda) && this.pandasAndFriends[secondPanda].Contains(firstPanda))
                {
                    return true;
                }
            }

            return false;
        }

        public List<Panda> FriendsOf(Panda panda)
        {
            if (this.HasPanda(panda))
            {
                return this.pandasAndFriends[panda].ToList();
            }

            throw new PandaException.PandaIsNotOnNetworkException();
        }

        public int ConnectionLevel(Panda firstPanda, Panda secondPanda)
        {
            if (this.HasPanda(firstPanda) && this.HasPanda(secondPanda))
            {
                if (AreFriends(firstPanda, secondPanda))
                {
                    return 1;
                }
                else
                {
                    List<Panda> friends = this.FriendsOf(firstPanda);
                    int level = 1;
                    while (true)
                    {
                        if (friends.Contains(secondPanda))
                        {
                            break;
                        }
                        int friendsCount = friends.Count;
                        for (int i = 0; i < friends.Count; i++)
                        {
                            var friendList = this.FriendsOf(friends[i]);

                            for (int j = 0; j < friendList.Count; j++)
                            {
                                if (!friends.Contains(friendList[j]) && !friendList[j].Equals(firstPanda))
                                {
                                    friends.Add(friendList[j]);
                                    i++;
                                }
                            }
                        }

                        if (friendsCount == friends.Count)
                        {
                            return -1;
                        }

                        level++;
                    }

                    return level;
                }
            }

            throw new PandaException.PandaIsNotOnNetworkException();
        }

        public bool AreConnected(Panda firstPanda, Panda secondPanda)
        {
            if (this.HasPanda(firstPanda) && this.HasPanda(secondPanda))
            {
                if (this.ConnectionLevel(firstPanda, secondPanda) > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            throw new PandaException.PandaIsNotOnNetworkException();
        }

        public int HowManyGenderInNetwork(int level, Panda panda, GenderType gender)
        {
            List<Panda> friends = this.FriendsOf(panda);

            Dictionary<Panda, int> pandasAndLevels = new Dictionary<Panda, int>();
            foreach (var fr in friends)
            {
                pandasAndLevels.Add(fr, 1);
            }
  
            int countLevel = 0;
            int genderCount = 0;
            while (true)
            {
                countLevel++;

                for (int i = 0; i < friends.Count; i++)
                {
                    var friendList = this.FriendsOf(friends[i]);
                    for (int j = 0; j < friendList.Count; j++)
                    {
                        if (!friends.Contains(friendList[j]) && !friendList[j].Equals(panda))
                        {
                            friends.Add(friendList[j]);
                            pandasAndLevels.Add(friendList[j], level);
                            i++;
                        }
                    }
                }
                if (countLevel == level)
                {
                    genderCount = pandasAndLevels.Where(x => x.Key.Gender == gender && x.Value == level).Count();
                    break;
                }
            }
            return genderCount;
        }
    }
}

