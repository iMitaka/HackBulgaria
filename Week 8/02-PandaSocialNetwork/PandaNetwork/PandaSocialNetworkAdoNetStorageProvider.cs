using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PandaNetwork
{
    public class PandaSocialNetworkAdoNetStorageProvider : IPandaSocialNetworkStorageProvider
    {
        public void Save(PandaSocialNetwork network, string connectionString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand deleteCommand = new SqlCommand("DELETE FROM Panda", connection);
                SqlCommand deleteFriend = new SqlCommand("DELETE FROM PandaFriends", connection);
                SqlCommand reseed = new SqlCommand("DBCC CHECKIDENT (Panda, RESEED, 0)", connection);
                deleteFriend.ExecuteNonQuery();
                deleteCommand.ExecuteNonQuery();
                reseed.ExecuteNonQuery();

                string addPandaToDbCommand = "INSERT INTO Panda (Name,Email,Gender) VALUES (@name,@email,@gender)";
                string addFirendCommand = "INSERT INTO PandaFriends (Panda_Id,Friend_Id) VALUES (@pandaId,@friendId)";

                foreach (var panda in network.AllPandasAndFriends)
                {
                    SqlCommand addPandaToDbSQLCommand = new SqlCommand(addPandaToDbCommand, connection);
                    addPandaToDbSQLCommand.Parameters.AddWithValue("@name", panda.Key.Name);
                    addPandaToDbSQLCommand.Parameters.AddWithValue("@email", panda.Key.Email);
                    addPandaToDbSQLCommand.Parameters.AddWithValue("@gender", panda.Key.Gender);
                    addPandaToDbSQLCommand.ExecuteNonQuery();
                }

                string getAllPandas = "SELECT * FROM Panda";
                SqlCommand getAllPandasSQL = new SqlCommand(getAllPandas, connection);
                var reader = getAllPandasSQL.ExecuteReader();
                var pandaList = new List<Panda>();
                while (reader.Read())
                {
                    var panda = new Panda((string)reader["Name"], (string)reader["Email"], (GenderType)reader["Gender"]);
                    panda.Id = (int)reader["Id"];
                    pandaList.Add(panda);
                }
                reader.Close();

                foreach (var panda in pandaList)
                {
                    var friends = network.FriendsOf(panda);
                    foreach (var friend in friends)
                    {
                        foreach (var equalFriend in pandaList)
                        {
                            if (friend.Equals(equalFriend))
                            {
                                friend.Id = equalFriend.Id;
                            }
                        }
                    }

                    foreach (var friend in friends)
                    {
                        SqlCommand addFriendCommandSQL = new SqlCommand(addFirendCommand, connection);
                        addFriendCommandSQL.Parameters.AddWithValue("@pandaId", panda.Id);
                        addFriendCommandSQL.Parameters.AddWithValue("@friendId", friend.Id);
                        addFriendCommandSQL.ExecuteNonQuery();
                    }
                }
            }
        }

        public PandaSocialNetwork Load(string connectionString)
        {
            using (var connection = new SqlConnection(connectionString)) 
            {
                connection.Open();

                var network = new PandaSocialNetwork();

                string getAllPandas = "SELECT * FROM Panda";
                SqlCommand getAllPandasSQL = new SqlCommand(getAllPandas, connection);
                var reader = getAllPandasSQL.ExecuteReader();
                var pandaList = new List<Panda>();
                while (reader.Read())
                {
                    var panda = new Panda((string)reader["Name"], (string)reader["Email"], (GenderType)reader["Gender"]);
                    panda.Id = (int)reader["Id"];
                    pandaList.Add(panda);
                }
                reader.Close();

                foreach (var panda in pandaList)
                {
                    if (!network.HasPanda(panda))
                    {
                        network.AddPanda(panda);
                    }
                    
                    string getFiendsCommand = "SELECT pf.Friend_Id FROM PandaSocialNetowrk.dbo.PandaFriends pf JOIN PandaSocialNetowrk.dbo.Panda p ON p.Id = pf.Panda_Id WHERE pf.Panda_Id = @pandaId";
                    SqlCommand getFriendsSQL = new SqlCommand(getFiendsCommand, connection);
                    getFriendsSQL.Parameters.AddWithValue("@pandaId", panda.Id);
                    var idReader = getFriendsSQL.ExecuteReader();
                    while (idReader.Read())
                    {
                        int id = (int)idReader["Friend_Id"];
                        var friend = pandaList.Where(p => p.Id == id).LastOrDefault();
                        if (!network.AreFriends(panda,friend))
                        {
                            network.MakeFriends(panda, friend);
                        }
                    }
                    idReader.Close();
                }

                return network;
            }
        }
    }
}
