using _07InfernoInfinity.Enums;
using _07InfernoInfinity.Models.Gems;
using System;
using System.Collections.Generic;
using System.Text;

namespace _07InfernoInfinity.Contracts
{
    public interface IWeapon
    {
        string Name { get; }

        int MinDamage { get; }

        int MaxDamage { get; }

        int BaseMaxDamage { get; }

        int BaseMinDamage { get; }

        IReadOnlyCollection<IGem> Gems { get; }

        RarityLevel Rarity { get; }

        void AddGem(int index, IGem gem);

        void RemoveGem(int index);
    }
}
