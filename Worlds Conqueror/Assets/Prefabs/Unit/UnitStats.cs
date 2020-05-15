using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WorldConqueror
{
    public class UnitStats : MonoBehaviour
    {
        public enum SolderType
        {
            Infantry, Archery, Cavalery, SiegeWeapon
        }

        #region Prix

        public static readonly int[] InfantryPrice = { 25, 30, 40, 50 };
        public static readonly int[] ArcheryPrice = { 30, 40, 50, 60 };
        public static readonly int[] CavaleryPrice = { 50, 65, 80, 100 };
        public static readonly int[] SiegeWeaponPrice = { 50, 75, 100, 125 };

        public static readonly int[] InfantryPriceUpgrade = { 100, 200, 500 };
        public static readonly int[] ArcheryPriceUpgrade = { 100, 200, 500 };
        public static readonly int[] CavaleryPriceUpgrade = { 100, 200, 500 };
        public static readonly int[] SiegeWeaponPriceUpgrade = { 100, 200, 500 };

        #endregion

        #region Levels

        static int InfantryLevel = 0;
        static int ArcheryLevel = 0;
        static int CavaleryLevel = 0;
        static int SiegeWeaponLevel = 0;

        #endregion

        public static int GetPrice(SolderType type)
        {
            int level = GetLevel(type);

            switch (type)
            {
                case SolderType.Infantry:
                    if (level >= 4)
                        return InfantryPrice[3];
                    if (level < 0)
                        return InfantryPrice[0];
                    return InfantryPrice[level];
                case SolderType.Archery:
                    if (level >= 4)
                        return ArcheryPrice[3];
                    if (level < 0)
                        return ArcheryPrice[0];
                    return ArcheryPrice[level];
                case SolderType.Cavalery:
                    if (level >= 4)
                        return CavaleryPrice[3];
                    if (level < 0)
                        return CavaleryPrice[0];
                    return CavaleryPrice[level];
                case SolderType.SiegeWeapon:
                    if (level >= 4)
                        return SiegeWeaponPrice[3];
                    if (level < 0)
                        return SiegeWeaponPrice[0];
                    return SiegeWeaponPrice[level];
                default:
                    return 0;
            }
        }

        public static int GetLevel(SolderType type)
        {
            switch (type)
            {
                case SolderType.Infantry:
                    return InfantryLevel;
                case SolderType.Archery:
                    return ArcheryLevel;
                case SolderType.Cavalery:
                    return CavaleryLevel;
                case SolderType.SiegeWeapon:
                    return SiegeWeaponLevel;
                default:
                    return 0;
            }
        }

        public static int GetPriceUpgrade(SolderType type, int level)
        {
            if (level >= 3)
                return -1;
            switch (type)
            {
                case SolderType.Infantry:
                    return InfantryPriceUpgrade[level];
                case SolderType.Archery:
                    return ArcheryPriceUpgrade[level];
                case SolderType.Cavalery:
                    return CavaleryPriceUpgrade[level];
                case SolderType.SiegeWeapon:
                    return SiegeWeaponPriceUpgrade[level];
                default:
                    return 0;
            }
        }

        public static void Upgrade(SolderType type)
        {
            switch (type)
            {
                case SolderType.Infantry:
                    InfantryLevel++;
                    return;
                case SolderType.Archery:
                    ArcheryLevel++;
                    return;
                case SolderType.Cavalery:
                    CavaleryLevel++;
                    return;
                case SolderType.SiegeWeapon:
                    SiegeWeaponLevel++;
                    return;
                default:
                    return;
            }
        }
    }
}