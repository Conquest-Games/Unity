using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Pun.UtilityScripts;
using UnityEngine;
using UnityEngine.UI;

namespace WorldConqueror
{
    public class Unit : MonoBehaviour
    {
        private PhotonView _view;
        #region Attributs

        public SoldierType type;
        private PunTeams.Team team;
        public int lvl = 0;

        public int hp = 0;
        public int Maxhp = 0;

        public int damage = 0;
        public float attackSpeed = 1f;
        public float speed = 0f;
        public float initialSpeed = 0f;
        public float range = 0f;
        
        private bool isDead;
        public bool fight = false;

        public enum SoldierType
        {
            Ninja, Infantry, Archer, Cavalry, SiegeWeapon
        }

        public enum SoldierTeam
        {
            Blue, Red, Yellow, Green
        }

        public GameObject Level;
        public GameObject MiniMapRender;

        public PunTeams.Team Team
        {
            get { return team; }
        }

        public float Speed => speed;

        public int UnitDamage => damage;

        #endregion

        #region Stats

        static int[] InfantryDommage = { 10, 15, 20, 30 };
        static int[] ArcheryDommage = { 15, 25, 35, 50 };
        static int[] CavaleryDommage = { 10, 15, 20, 30 };
        static int[] SiegeWeaponDommage = { 50, 100, 150, 200 };
        static int[] NinjaDommage = { 5, 10, 15, 20 };

        static float InfantryRange = 20f;
        static float ArcheryRange = 30f;
        static float CavaleryRange = 25f;
        static float SiegeWeaponRange = 45f;
        static float NinjaRange = 20f;

        static float[] InfantryAttackSpeed = { 1.6f, 1.4f, 1.2f, 1f };
        static float[] ArcheryAttackSpeed = { 1.5f, 1.4f, 1.3f, 1.2f };
        static float[] CavaleryAttackSpeed = { 0.7f, 0.6f, 0.5f, 0.4f };
        static float[] SiegeWeaponAttackSpeed = { 10f, 9f, 8f, 7f };
        static float[] NinjaAttackSpeed = { 0.7f, 0.6f, 0.5f, 0.4f };

        static float[] InfantrySpeed = { 5f, 6f, 7f, 8f };
        static float[] ArcherySpeed = { 5f, 6f, 7f, 8f };
        static float[] CavalerySpeed = { 8f, 9f, 10f, 11f };
        static float[] SiegeWeaponSpeed = { 2.5f, 3f, 3.5f, 4f };
        static float[] NinjaSpeed = {6.5f, 7.5f, 8.5f, 10f };

        static int[] InfantryHeal = { 50, 65, 80, 100 };
        static int[] ArcheryHeal = { 25, 30, 35, 40 };
        static int[] CavaleryHeal = { 35, 45, 55, 75 };
        static int[] SiegeWeaponHeal = { 50, 100, 150, 200 };
        static int[] NinjaHeal = { 30, 35, 40, 50 };

        #endregion

        [PunRPC]
        public void Initiate()
        {
            isDead = false;

            switch(type)
            {
                case SoldierType.Archer:
                    this.lvl = UnitStats.ArcheryLevel;
                    break;
                case SoldierType.Cavalry:
                    this.lvl = UnitStats.CavaleryLevel;
                    break;
                case SoldierType.SiegeWeapon:
                    this.lvl = UnitStats.SiegeWeaponLevel;
                    break;
                case SoldierType.Ninja:
                    this.lvl = UnitStats.NinjaLevel;
                    break;
                default:
                    this.lvl = UnitStats.InfantryLevel;
                    break;

            }

            switch (type)
            {
                case (SoldierType.Archer):
                    this.damage = ArcheryDommage[lvl];
                    this.hp = ArcheryHeal[lvl];
                    this.Maxhp = ArcheryHeal[lvl];
                    this.attackSpeed = ArcheryAttackSpeed[lvl];
                    this.speed = ArcherySpeed[lvl];
                    this.range = ArcheryRange;
                    break;
                case (SoldierType.Cavalry):
                    this.damage = CavaleryDommage[lvl];
                    this.hp = CavaleryHeal[lvl];
                    this.Maxhp = CavaleryHeal[lvl];
                    this.attackSpeed = CavaleryAttackSpeed[lvl];
                    this.speed = CavalerySpeed[lvl];
                    this.range = CavaleryRange;
                    break;
                case (SoldierType.SiegeWeapon):
                    this.damage = SiegeWeaponDommage[lvl];
                    this.hp = SiegeWeaponHeal[lvl];
                    this.Maxhp = SiegeWeaponHeal[lvl];
                    this.attackSpeed = SiegeWeaponAttackSpeed[lvl];
                    this.speed = SiegeWeaponSpeed[lvl];
                    this.range = SiegeWeaponRange;
                    break;
                case (SoldierType.Ninja):
                    this.damage = NinjaDommage[lvl];
                    this.hp = NinjaHeal[lvl];
                    this.Maxhp = NinjaHeal[lvl];
                    this.attackSpeed = NinjaAttackSpeed[lvl];
                    this.speed = NinjaSpeed[lvl];
                    this.range = NinjaRange;
                    break;
                default:
                    this.damage = InfantryDommage[lvl];
                    this.hp = InfantryHeal[lvl];
                    this.Maxhp = InfantryHeal[lvl];
                    this.attackSpeed = InfantryAttackSpeed[lvl];
                    this.speed = InfantrySpeed[lvl];
                    this.range = InfantryRange;
                    break;


            }
        }

        public void MoveRight()
        {
            transform.Translate(Vector3.right * Time.deltaTime * 10, Space.Self);
        }
        
        public void TakeDammage(int dam)
        {
            hp -= dam;
            if (hp <= 0)
            {
                hp = 0;
                PhotonView.Destroy(gameObject);
            }

        }
        
        private void UpdateText()
        {
            switch(transform.tag)
            {
                case "Red":
                    {
                        Level.GetComponent<TextMesh>().color = Color.red;
                        MiniMapRender.GetComponent<SpriteRenderer>().color = Color.red;
                        break;
                    }
                case "Yellow":
                    {
                        Level.GetComponent<TextMesh>().color = Color.yellow;
                        MiniMapRender.GetComponent<SpriteRenderer>().color = Color.yellow;
                        break;

                    }
                case "Green":
                    {
                        Level.GetComponent<TextMesh>().color = Color.green;
                        MiniMapRender.GetComponent<SpriteRenderer>().color = Color.green;
                        break;
                    }
                default:
                    {
                        Level.GetComponent<TextMesh>().color = Color.cyan;
                        MiniMapRender.GetComponent<SpriteRenderer>().color = Color.cyan;
                        break;
                    }
            }

            Level.GetComponent<TextMesh>().text = lvl.ToString() + ": " + hp.ToString() + " / " + Maxhp.ToString();
        }

        void ResetSpeed()
        {
            this.speed = initialSpeed;
        }

        void Start()
        {
            _view = PhotonView.Get(gameObject);
            _view.RPC("Initiate", RpcTarget.All);
            initialSpeed = speed;

            InvokeRepeating("ResetSpeed", 0f, 0.1f);

            UpdateText();
        }

        void Update()
        {
            Level.GetComponent<TextMesh>().text = lvl.ToString() + ": " + hp.ToString() + " / " + Maxhp.ToString();
        }
    }
}