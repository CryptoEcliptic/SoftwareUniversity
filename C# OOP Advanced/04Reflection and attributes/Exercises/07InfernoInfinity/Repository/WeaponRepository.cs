using _07InfernoInfinity.Contracts;
using _07InfernoInfinity.Models.Weapons;
using System;
using System.Collections;
using System.Collections.Generic;

namespace _07InfernoInfinity.Repository
{
    public class WeaponRepository : IWeaponRepository
    {
        private Dictionary<string, IWeapon> weapons;

        public WeaponRepository()
        {
            this.weapons = new Dictionary<string, IWeapon>();
        }

        public IReadOnlyDictionary<string, IWeapon> Weapons => new Dictionary<string, IWeapon>(this.weapons);

        public void AddGem(string weaponName, int index, IGem gem)
        {
            weapons[weaponName].AddGem(index, gem);
        }

        public void AddWeapon(IWeapon weapon)
        {
            string weaponName = weapon.Name;
            if (!weapons.ContainsKey(weaponName))
            {
                weapons.Add(weaponName, weapon);
            }
            else
            {
                weapons[weaponName] = weapon;
            }
        }

        public void RemoveGem(string weaponName, int index)
        {
            IWeapon currentWeapon = weapons[weaponName];
            currentWeapon.RemoveGem(index);
        }

        public string Print(string name)
        {
            IWeapon weapon = weapons[name];
            return weapon.ToString();
        }
       
    }
}
