using ForWritingArticle.Models;
using Microsoft.Extensions.Configuration;

namespace ForWritingArticle.Classes
{
    public class OffTheReservation
    {
        public static void StarWars()
        {
            // local function
            string Ability(StarWarsCharacter character) =>
                character switch
                {
                    Hero hero2 => hero2.Healing(),
                    Villain villain2 => villain2.Lightning(),
                    _ => "Droid"
                };

            var hero = new Hero("Obi-Wan Kenobi");
            var villain = new Villain("Count Dooku");

            StarWarsCharacter character = hero;
            string ability = Ability(character);
            Console.WriteLine($"{character.Name} {ability}");

            Console.WriteLine();

            character = villain;
            ability = Ability(character);
            Console.WriteLine($"{character.Name} {ability}");

        }

        public static string ConfigurationDebugView()
        {
            if (File.Exists("appsettings.json"))
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                    .AddJsonFile("appsettings.json")
                    .Build();

                return configuration.GetDebugView();
            }
            else
            {
                return null;
            }

        }
    }
}
