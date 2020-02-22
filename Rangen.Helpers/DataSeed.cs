
using System;

namespace Rangen.Helpers
{
    public class DataSeed
    {
        public DataSeed()
        {
            #region Category Types

            var geography = new CategoryType("geography");

            var beliefs = new CategoryType("beliefs, religion, spirituality");

            var cosmology = new CategoryType("cosmology");

            var biology = new CategoryType("biology");

            var something = new CategoryType("something");

            var beings = new CategoryType("beings");

            #endregion

            var catTypes = new[] { geography, beliefs, cosmology, biology };

            #region Categories
            var ocean = new Category("Ocean")
            {
                Description = "Vast and a continuous frame of salty water, often taking a large part of planet's surface.",
                CategoryType = geography
            };
            var sea = new Category("Sea")
            {
                Description = "Body of salt water, smaller and shallower than ocean.",
                CategoryType = geography
            };

            var continent = new Category("Continent")
            {
                Description = "Any of a world's main continuous expanses of land.",
                CategoryType = geography
            };
            var world = new Category("World")
            {
                Description = "Place in the universe or the multiverse characterized by connected set of culture or history." +
                     "Usually one planet with the surrounding area.",
                CategoryType = cosmology
            };
            var river = new Category("River")
            {
                Description = "A large natural stream of water flowing in a channel to the sea, a lake, or another river.",
                CategoryType = geography
            };
            var city = new Category("City")
            {
                Description = "A built-up area with a name, defined boundaries, and local government, that is larger than a town and a village.",
                CategoryType = geography
            };
            var person = new Category("Person")
            {
                Description = "A conscious being regarded as an individual.",
                CategoryType = beings
            };
            var race = new Category("Race")
            {
                Description = "A group or set of beings or things with a common feature or features.",
                CategoryType = beings
            };
            var country = new Category("Country")
            {
                Description = "A nation with its own government, occupying a particular territory.",
                CategoryType = geography
            };
            #endregion

            var categories = new[]
            {world, ocean, continent, sea, country, city, river, race, person};

            #region Elements


            #endregion



        }

        public static void Seed(IRepository repository)
        {
            throw new NotImplementedException();
        }
    }
}
