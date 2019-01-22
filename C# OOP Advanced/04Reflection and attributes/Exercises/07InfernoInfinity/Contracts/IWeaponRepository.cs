using _07InfernoInfinity.Models.Gems;
using System;
using System.Collections.Generic;
using System.Text;

namespace _07InfernoInfinity.Contracts
{
    public interface IWeaponRepository
    {
        IReadOnlyDictionary<string, IWeapon> Weapons { get; }

        void AddWeapon(IWeapon weapon);

        void AddGem(string weaponName, int index, IGem gem);

        void RemoveGem(string weaponName, int index);

        string Print(string name);
    }
}
