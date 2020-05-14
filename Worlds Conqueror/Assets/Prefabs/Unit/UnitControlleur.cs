using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace WorldConqueror
{
    public class UnitControlleur : MonoBehaviour
    {
        #region Textes

        public Text priceUpgradeInfantry;
        public Text priceUpgradeArchery;
        public Text priceUpgradeCavalery;
        public Text priceUpgradeSiegeWeapon;

        #endregion

        private void Upgrade(UnitStats.SolderType type)
        {
            int level = UnitStats.GetLevel(type);
            if (level == 3)
                return;
            (bool achete, string erreur) = Joueur.Player.Cout(UnitStats.GetPriceUpgrade(type, level));
            if (achete)
                UnitStats.Upgrade(type);

        }

        public void UpgradeInfantry()
        {
            Upgrade(UnitStats.SolderType.Infantry);
        }

        public void UpgradeArchery()
        {
            Upgrade(UnitStats.SolderType.Archer);
        }

        public void UpgradeCavalery()
        {
            Upgrade(UnitStats.SolderType.Cavalery);
        }

        public void UpgradeSiegeWeapon()
        {
            Upgrade(UnitStats.SolderType.SiegeWeapon);
        }

        private void UpdateTexte()
        {
            int infantry = UnitStats.GetPriceUpgrade(
                UnitStats.SolderType.Infantry, UnitStats.GetLevel(
                    UnitStats.SolderType.Infantry));
            int archery = UnitStats.GetPriceUpgrade(
                UnitStats.SolderType.Archer, UnitStats.GetLevel(
                    UnitStats.SolderType.Archer));
            int cavalery = UnitStats.GetPriceUpgrade(
                UnitStats.SolderType.Cavalery, UnitStats.GetLevel(
                    UnitStats.SolderType.Cavalery));
            int siegeWeapon = UnitStats.GetPriceUpgrade(
                UnitStats.SolderType.SiegeWeapon, UnitStats.GetLevel(
                    UnitStats.SolderType.SiegeWeapon));

            if (infantry == -1)
                priceUpgradeInfantry.text = "MAX";
            else
                priceUpgradeInfantry.text = infantry.ToString();

            if (archery == -1)
                priceUpgradeArchery.text = "MAX";
            else
                priceUpgradeArchery.text = archery.ToString();

            if (cavalery == -1)
                priceUpgradeCavalery.text = "MAX";
            else
                priceUpgradeCavalery.text = cavalery.ToString();

            if (siegeWeapon == -1)
                priceUpgradeSiegeWeapon.text = "MAX";
            else
                priceUpgradeSiegeWeapon.text = siegeWeapon.ToString();

        }

        // Start is called before the first frame update
        void Start()
        {
            UpdateTexte();
        }

        // Update is called once per frame
        void Update()
        {
            UpdateTexte();
        }
    }
}
