using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;
using Joueur;

namespace WorldConqueror
{
    public class UnitControlleur : MonoBehaviour
    {
        private PhotonView _view;
        
        #region Textes

        public Text priceUpgradeInfantry;
        public Text priceUpgradeArchery;
        public Text priceUpgradeCavalery;
        public Text priceUpgradeSiegeWeapon;
        public Text priceUpgradeNinja;

        public Text priceSpawnInfantry;
        public Text priceSpawnArchery;
        public Text priceSpawnCavalery;
        public Text priceSpawnSiegeWeapon;
        public Text priceSpawnNinja;

        public GameObject pieceInfantry;
        public GameObject pieceArchery;
        public GameObject pieceCavalery;
        public GameObject pieceSiegeWeapon;
        public GameObject pieceNinja;

        private void UpdateTexte()
        {
            int infantry = UnitStats.GetPriceUpgrade(
                UnitStats.SolderType.Infantry, UnitStats.GetLevel(
                    UnitStats.SolderType.Infantry, GameObject.Find("Player").GetComponent<Player>().tag));
            int archery = UnitStats.GetPriceUpgrade(
                UnitStats.SolderType.Archery, UnitStats.GetLevel(
                    UnitStats.SolderType.Archery, GameObject.Find("Player").GetComponent<Player>().tag));
            int cavalery = UnitStats.GetPriceUpgrade(
                UnitStats.SolderType.Cavalery, UnitStats.GetLevel(
                    UnitStats.SolderType.Cavalery, GameObject.Find("Player").GetComponent<Player>().tag));
            int siegeWeapon = UnitStats.GetPriceUpgrade(
                UnitStats.SolderType.SiegeWeapon, UnitStats.GetLevel(
                    UnitStats.SolderType.SiegeWeapon, GameObject.Find("Player").GetComponent<Player>().tag));
            int ninja = UnitStats.GetPriceUpgrade(
                UnitStats.SolderType.Ninja, UnitStats.GetLevel(
                    UnitStats.SolderType.Ninja, GameObject.Find("Player").GetComponent<Player>().tag));

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

            if (ninja == -1)
                priceUpgradeNinja.text = "MAX";
            else
                priceUpgradeNinja.text = ninja.ToString();


            priceSpawnInfantry.text = UnitStats.GetPrice(UnitStats.SolderType.Infantry, GameObject.Find("Player").GetComponent<Player>().tag).ToString();
            priceSpawnArchery.text = UnitStats.GetPrice(UnitStats.SolderType.Archery, GameObject.Find("Player").GetComponent<Player>().tag).ToString();
            priceSpawnCavalery.text = UnitStats.GetPrice(UnitStats.SolderType.Cavalery, GameObject.Find("Player").GetComponent<Player>().tag).ToString();
            priceSpawnSiegeWeapon.text = UnitStats.GetPrice(UnitStats.SolderType.SiegeWeapon, GameObject.Find("Player").GetComponent<Player>().tag).ToString();
            priceSpawnNinja.text = UnitStats.GetPrice(UnitStats.SolderType.Ninja, GameObject.Find("Player").GetComponent<Player>().tag).ToString();
        }

        #endregion

        #region Interface

        public void UpdatePiece()
        {
            if (priceUpgradeInfantry.text == "MAX")
                pieceInfantry.SetActive(false);
            else
                pieceInfantry.SetActive(true);

            if (priceUpgradeArchery.text == "MAX")
                pieceArchery.SetActive(false);
            else
                pieceArchery.SetActive(true);

            if (priceUpgradeCavalery.text == "MAX")
                pieceCavalery.SetActive(false);
            else
                pieceCavalery.SetActive(true);

            if (priceUpgradeSiegeWeapon.text == "MAX")
                pieceSiegeWeapon.SetActive(false);
            else
                pieceSiegeWeapon.SetActive(true);

            if (priceUpgradeNinja.text == "MAX")
                pieceNinja.SetActive(false);
            else
                pieceNinja.SetActive(true);

        }

        #endregion

        #region Upgrade

        [PunRPC]
        void LevelUp(UnitStats.SolderType type)
        {
            UnitStats.Upgrade(type);
        }
        private void Upgrade(UnitStats.SolderType type)
        {
            int level = UnitStats.GetLevel(type, GameObject.Find("Player").GetComponent<Player>().tag);
            if (level == 3)
                return;
            (bool achete, string erreur) = Joueur.Player.Cout(UnitStats.GetPriceUpgrade(type, level));
            if (achete)
                //LevelUp(type);
                _view.RPC("LevelUp", RpcTarget.All, type);
            
        }

        public void UpgradeInfantry()
        {
            Upgrade(UnitStats.SolderType.Infantry);
        }

        public void UpgradeArchery()
        {
            Upgrade(UnitStats.SolderType.Archery);
        }

        public void UpgradeCavalery()
        {
            Upgrade(UnitStats.SolderType.Cavalery);
        }

        public void UpgradeSiegeWeapon()
        {
            Upgrade(UnitStats.SolderType.SiegeWeapon);
        }

        public void UpgradeNinja()
        {
            Upgrade(UnitStats.SolderType.Ninja);
        }

        #endregion

        // Start is called before the first frame update
        void Start()
        {
            _view = PhotonView.Get(gameObject);
            UpdateTexte();
            UpdatePiece();
        }

        // Update is called once per frame
        void Update()
        {
            UpdateTexte();
            UpdatePiece();
        }
    }
}
