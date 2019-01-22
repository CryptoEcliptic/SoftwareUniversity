using _07InfernoInfinity.Contracts;
using _07InfernoInfinity.Enums;
using System;

namespace _07InfernoInfinity.Core
{
    public class CommandInterpreter
    {

        public IWeapon CreateCommand(string[] data)
        {
            string[] weaponData = data[1].Split();
            string rarityAsString = weaponData[0];
            RarityLevel rarity = (RarityLevel)Enum.Parse(typeof(RarityLevel), rarityAsString);
            string weaponType = weaponData[1];
            string name = data[2];
            Type classType = Type.GetType("_07InfernoInfinity.Models.Weapons." + weaponType);
            var weaponInstance = (IWeapon)Activator.CreateInstance(classType, new object[] { rarity, name });

            return weaponInstance;
        }

        public IGem CreateGem(string[] data)
        {
            string[] gemData = data[3].Split();

            string qualityAsString = gemData[0];
            GemCondition quality = (GemCondition)Enum.Parse(typeof(GemCondition), qualityAsString);

            string gemType = gemData[1];
            Type gemClassType = Type.GetType("_07InfernoInfinity.Models.Gems." + gemType);
            var gemInstance = (IGem)Activator.CreateInstance(gemClassType, new object[] { quality });

            return gemInstance;
        }
    }
}
