using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ForWritingArticle.Models;

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
            Console.WriteLine($"{character.GetType().Name} {ability}");

            Console.WriteLine();

            character = villain;
            ability = Ability(character);
            Console.WriteLine($"{character.GetType().Name} {ability}");

        }
    }
}
