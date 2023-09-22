using Microsoft.Data.Sqlite;
using System;
using System.ComponentModel.Design;
using System.Xml.Linq;

namespace Lab3_QueryBuilder
{
    internal class Program
    {
        static string root = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.ToString();
        static string dbPath = root + "\\data\\data.db";
        static string connectionString = $"Data Source={dbPath}";

        static void Main(string[] args)
        {
            List<Pokemon> pokemonList = new List<Pokemon>();
            List<BannedGame> bannedGameList = new List<BannedGame>();

            //Pokemon test = new Pokemon(1, 1, "Bulbasaur"," ", "Grass", "Poison", 318, 45, 49, 49, 65, 65, 45, 1);
            Pokemon pokemonBase = new Pokemon();
            BannedGame bannedGameBase = new BannedGame();

            //fills a list full of pokemon objects from the CSV
            using (StreamReader PokemonReader = new StreamReader(root + "\\data\\AllPokemon.csv"))
            {
                int i = 1;
                while (!PokemonReader.EndOfStream)
                {
                    var line = PokemonReader.ReadLine();
                    var data = line.Split(',');
                    

                    Pokemon p = new Pokemon(i, Convert.ToInt32(data[0]), data[1], data[2], data[3], data[4], Convert.ToInt32(data[5]),
                        Convert.ToInt32(data[6]), Convert.ToInt32(data[7]), Convert.ToInt32(data[8]), Convert.ToInt32(data[9]),
                        Convert.ToInt32(data[10]), Convert.ToInt32(data[11]), Convert.ToInt32(data[12]));

                    pokemonList.Add( p );
                    i++;
                }
                i = 0;
            }



            
            //fills a list full of BannedGame objects from the CSV
            using (StreamReader GameReader = new StreamReader(root + "\\data\\BannedGames.csv"))
            {
                int i = 1;
                while (!GameReader.EndOfStream)
                {
                    var line = GameReader.ReadLine();
                    var data = line.Split(',');
                    

                    BannedGame g = new BannedGame(i, data[0], data[1], data[2], data[3]);
                    bannedGameList.Add( g );
                    i++;
                }
                i = 0;
            }

            using (var connection = new QueryBuilder(dbPath))
            {
                Console.WriteLine("Clearing the database...");
                connection.DeleteAll(pokemonBase);
                connection.DeleteAll(bannedGameBase);

                //Console.ReadLine();

                Console.WriteLine("Repopulating the database...");
                foreach(Pokemon p in pokemonList)
                {
                    connection.Create(p);
                }

                foreach(BannedGame g in bannedGameList)
                {
                    connection.Create(g);
                }
                Console.WriteLine("Succsess!");

                Console.WriteLine("Adding the pokemon Tinkaton to database");
                Pokemon tink = new Pokemon(1046,959,"Tinkaton"," ","Fairy","Steel",506,85,75,77,70,105,94,9);

                connection.Create(tink);


                Console.WriteLine("Adding the game Overwatch to the database");
                BannedGame ow = new BannedGame(137,"Overwatch 2","Overwatch","United States", "Bad game honestly, I hate that I play it");

                connection.Create(ow);

            }
            Console.WriteLine("I win");

        }
    }
}