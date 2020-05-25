using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Joueur;

namespace WorldConqueror
{
    public class UnitStats : MonoBehaviour
    {
        public enum SolderType
        {
            Infantry, Archery, Cavalery, SiegeWeapon, Ninja
        }

        #region Prix

        public static readonly int[] InfantryPrice = { 25, 30, 40, 50 };
        public static readonly int[] ArcheryPrice = { 30, 40, 50, 60 };
        public static readonly int[] CavaleryPrice = { 50, 65, 80, 100 };
        public static readonly int[] SiegeWeaponPrice = { 50, 75, 100, 125 };
        public static readonly int[] NinjaPrice = { 10, 15, 20, 30 };

        public static readonly int[] InfantryPriceUpgrade = { 100, 200, 500 };
        public static readonly int[] ArcheryPriceUpgrade = { 100, 200, 500 };
        public static readonly int[] CavaleryPriceUpgrade = { 100, 200, 500 };
        public static readonly int[] SiegeWeaponPriceUpgrade = { 100, 200, 500 };
        public static readonly int[] NinjaPriceUpgrade = { 100, 200, 500 };

        #endregion

        #region Levels

        public static int InfantryLevelRed = 0;
        public static int ArcheryLevelRed = 0;
        public static int CavaleryLevelRed = 0;
        public static int SiegeWeaponLevelRed = 0;
        public static int NinjaLevelRed = 0;

        public static int InfantryLevelBlue = 0;
        public static int ArcheryLevelBlue = 0;
        public static int CavaleryLevelBlue = 0;
        public static int SiegeWeaponLevelBlue = 0;
        public static int NinjaLevelBlue = 0;

        public static int InfantryLevelYellow = 0;
        public static int ArcheryLevelYellow = 0;
        public static int CavaleryLevelYellow = 0;
        public static int SiegeWeaponLevelYellow = 0;
        public static int NinjaLevelYellow = 0;

        public static int InfantryLevelGreen = 0;
        public static int ArcheryLevelGreen = 0;
        public static int CavaleryLevelGreen = 0;
        public static int SiegeWeaponLevelGreen = 0;
        public static int NinjaLevelGreen = 0;

        #endregion

        public static int GetPrice(SolderType type, string tag)
        {
            int level = GetLevel(type, tag);

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
                case SolderType.Ninja:
                    if (level >= 4)
                        return NinjaPrice[3];
                    if (level < 0)
                        return NinjaPrice[0];
                    return NinjaPrice[level];

                default:
                    return 0;
            }
        }

        public static int GetLevel(SolderType type, string tag)
        {
            switch (tag)
            {
                case "Red":
                    switch (type)
                    {
                        case SolderType.Infantry:
                            return InfantryLevelRed;
                        case SolderType.Archery:
                            return ArcheryLevelRed;
                        case SolderType.Cavalery:
                            return CavaleryLevelRed;
                        case SolderType.SiegeWeapon:
                            return SiegeWeaponLevelRed;
                        case SolderType.Ninja:
                            return NinjaLevelRed;
                        default:
                            return 0;
                    }
                    break;
                case "Green":
                    switch (type)
                    {
                        case SolderType.Infantry:
                            return InfantryLevelGreen;
                        case SolderType.Archery:
                            return ArcheryLevelGreen;
                        case SolderType.Cavalery:
                            return CavaleryLevelGreen;
                        case SolderType.SiegeWeapon:
                            return SiegeWeaponLevelGreen;
                        case SolderType.Ninja:
                            return NinjaLevelGreen;
                        default:
                            return 0;
                    }
                    break;
                case "Yellow":
                    switch (type)
                    {
                        case SolderType.Infantry:
                            return InfantryLevelYellow;
                        case SolderType.Archery:
                            return ArcheryLevelYellow;
                        case SolderType.Cavalery:
                            return CavaleryLevelYellow;
                        case SolderType.SiegeWeapon:
                            return SiegeWeaponLevelYellow;
                        case SolderType.Ninja:
                            return NinjaLevelYellow;
                        default:
                            return 0;
                    }
                    break;
                default:
                    switch (type)
                    {
                        case SolderType.Infantry:
                            return InfantryLevelBlue;
                        case SolderType.Archery:
                            return ArcheryLevelBlue;
                        case SolderType.Cavalery:
                            return CavaleryLevelBlue;
                        case SolderType.SiegeWeapon:
                            return SiegeWeaponLevelBlue;
                        case SolderType.Ninja:
                            return NinjaLevelBlue;
                        default:
                            return 0;
                    }
                    break;
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
                case SolderType.Ninja:
                    return NinjaPriceUpgrade[level];
                default:
                    return 0;
            }
        }

        public static void Upgrade(SolderType type)
        {
            switch (GameObject.Find("Player").GetComponent<Player>().tag)
            {
                case "Red":
                    switch (type)
                    {
                        case SolderType.Infantry:
                            InfantryLevelRed++;
                            return;
                        case SolderType.Archery:
                            ArcheryLevelRed++;
                            return;
                        case SolderType.Cavalery:
                            CavaleryLevelRed++;
                            return;
                        case SolderType.SiegeWeapon:
                            SiegeWeaponLevelRed++;
                            return;
                        case SolderType.Ninja:
                            NinjaLevelRed++;
                            return;
                        default:
                            return;
                    }
                    break;
                case "Green":
                    switch (type)
                    {
                        case SolderType.Infantry:
                            InfantryLevelGreen++;
                            return;
                        case SolderType.Archery:
                            ArcheryLevelGreen++;
                            return;
                        case SolderType.Cavalery:
                            CavaleryLevelGreen++;
                            return;
                        case SolderType.SiegeWeapon:
                            SiegeWeaponLevelGreen++;
                            return;
                        case SolderType.Ninja:
                            NinjaLevelGreen++;
                            return;
                        default:
                            return;
                    }
                    break;
                case "Yellow":
                    switch (type)
                    {
                        case SolderType.Infantry:
                            InfantryLevelYellow++;
                            return;
                        case SolderType.Archery:
                            ArcheryLevelYellow++;
                            return;
                        case SolderType.Cavalery:
                            CavaleryLevelYellow++;
                            return;
                        case SolderType.SiegeWeapon:
                            SiegeWeaponLevelYellow++;
                            return;
                        case SolderType.Ninja:
                            NinjaLevelYellow++;
                            return;
                        default:
                            return;
                    }
                    break;
                default:
                    switch (type)
                    {
                        case SolderType.Infantry:
                            InfantryLevelBlue++;
                            return;
                        case SolderType.Archery:
                            ArcheryLevelBlue++;
                            return;
                        case SolderType.Cavalery:
                            CavaleryLevelBlue++;
                            return;
                        case SolderType.SiegeWeapon:
                            SiegeWeaponLevelBlue++;
                            return;
                        case SolderType.Ninja:
                            NinjaLevelBlue++;
                            return;
                        default:
                            return;
                    }
                    break;
            }
        }

        void start()
        {
            InfantryLevelRed = 0;
            ArcheryLevelRed = 0;
            CavaleryLevelRed = 0;
            SiegeWeaponLevelRed = 0;
            NinjaLevelRed = 0;

            InfantryLevelBlue = 0;
            ArcheryLevelBlue = 0;
            CavaleryLevelBlue = 0;
            SiegeWeaponLevelBlue = 0;
            NinjaLevelBlue = 0;

            InfantryLevelYellow = 0;
            ArcheryLevelYellow = 0;
            CavaleryLevelYellow = 0;
            SiegeWeaponLevelYellow = 0;
            NinjaLevelYellow = 0;

            InfantryLevelGreen = 0;
            ArcheryLevelGreen = 0;
            CavaleryLevelGreen = 0;
            SiegeWeaponLevelGreen = 0;
            NinjaLevelGreen = 0;
        }
    }
}